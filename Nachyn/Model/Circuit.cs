using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using Model.Elements;

namespace Model
{
    /// <summary>
    ///     Электрическая цепь
    /// </summary>
    public class Circuit
    {
        /// <summary>
        ///     Список элементов цепи
        /// </summary>
        public ObservableCollection<Branch> Branches;

        /// <summary>
        ///     Конструктор
        /// </summary>
        public Circuit()
        {
            Branches = new ObservableCollection<Branch>();
        }

        public List<Complex> CalculateZ(params double[] frequencies)
        {
            List<Complex> resistanceZ = new List<Complex>();

            foreach (double frequency in frequencies)
            {
                Dictionary<string, List<Branch>>
                    tempBranches = new Dictionary<string, List<Branch>>();

                foreach (Branch branch in Branches)
                {
                    string branchKey = branch.NodeIn + "_" + branch.NodeOut;
                    if (!tempBranches.ContainsKey(branchKey))
                    {
                        tempBranches[branchKey] = new List<Branch>();
                    }

                    tempBranches[branchKey].Add(branch);
                }

                Complex resistanceTempBranches = new Complex();
                foreach (string key in tempBranches.Keys)
                {
                    if (tempBranches[key].Count > 1)
                    {
                        Complex totalСonductivity = new Complex();

                        foreach (Branch branch in tempBranches[key])
                        {
                            Complex conduction = 1 / branch.CalculateZ(frequency);
                            totalСonductivity += conduction;
                        }

                        resistanceTempBranches += 1 / totalСonductivity;
                    }
                    else
                    {
                        if (tempBranches[key].Count == 1)
                        {
                            resistanceTempBranches +=
                                tempBranches[key][0].CalculateZ(frequency);
                        }
                    }
                }
                resistanceZ.Add(resistanceTempBranches);
            }
            return resistanceZ;
        }
    }
}