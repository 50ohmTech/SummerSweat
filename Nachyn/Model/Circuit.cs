using System;
using System.Collections.Generic;
using System.Numerics;

namespace Model
{
    /// <summary>
    ///     Электрическая цепь
    /// </summary>
    public class Circuit
    {
        #region Public

        /// <summary>
        ///     Список элементов цепи
        /// </summary>
        public readonly List<Branch> Branches = new List<Branch>();

        /// <summary>
        ///     Пустая ли цепь
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                foreach (Branch branch in Branches)
                {
                    if (branch.Elements.Count > 0)
                    {
                        return branch.Elements.Count <= 0;
                    }
                }

                return true;
            }
        }

        /// <summary>
        ///     Расчет комплексного сопротивления Ветви
        /// </summary>
        /// <param name="frequencies">Частоты</param>
        /// <returns>Комплексные сопротивления</returns>
        public List<Complex> CalculateZ(params double[] frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException();
            }

            Calculations.Calculations.CheckFrequencies(frequencies);

            List<Complex> resistanceZ = new List<Complex>();

            foreach (double frequency in frequencies)
            {
                Dictionary<string, List<Branch>> tempBranches =
                    new Dictionary<string, List<Branch>>();

                foreach (Branch branch in Branches)
                {
                    if (!tempBranches.ContainsKey(branch.Key))
                    {
                        tempBranches[branch.Key] = new List<Branch>();
                    }

                    tempBranches[branch.Key].Add(branch);
                }

                Complex resistanceTempBranches = new Complex();
                foreach (string key in tempBranches.Keys)
                {
                    if (tempBranches[key].Count > 1)
                    {
                        Complex totalСonductivity = new Complex();

                        foreach (Branch branch in tempBranches[key])
                        {
                            if (branch.Elements.Count < 1)
                            {
                                continue;
                            }

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

        /// <summary>
        ///     Очистить пустые ветки
        /// </summary>
        public void ClearEmptyBranches()
        {
            Branches.RemoveAll(branch => branch.Elements.Count < 1);
        }

        #endregion
    }
}