using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;

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
            var resistanceZ = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                var
                    tempBranches = new Dictionary<string, List<Branch>>();

                foreach (var branch in Branches)
                {
                    if (!tempBranches.ContainsKey(branch.Key))
                    {
                        tempBranches[branch.Key] = new List<Branch>();
                    }

                    tempBranches[branch.Key].Add(branch);
                }

                var resistanceTempBranches = new Complex();
                foreach (var key in tempBranches.Keys)
                {
                    if (tempBranches[key].Count > 1)
                    {
                        var totalСonductivity = new Complex();

                        foreach (var branch in tempBranches[key])
                        {
                            var conduction = 1 / branch.CalculateZ(frequency);
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