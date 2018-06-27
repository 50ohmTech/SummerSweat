using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using Model.Elements;

namespace Model
{
    public sealed class Branch
    {
        public uint NodeIn { get; }

        public uint NodeOut { get; }

        public ObservableCollection<ElementBase> Elements { get; }

        public Branch(uint nodeIn, uint nodeOut, params ElementBase[] elements)
        {           
            Elements = new ObservableCollection<ElementBase>();

            foreach (ElementBase element in elements)
            {
                Elements.Add(element);
            }

            NodeIn = nodeIn;
            NodeOut = nodeOut;
        }

        /// <summary>
        ///     Расчет комплексного сопротивления Ветви
        /// </summary>
        /// <param name="frequencies">Частота</param>
        /// <returns>Комплексное сопротивление</returns>
        public Complex CalculateZ(double frequency)
        {
            Complex resistance = new Complex();
            foreach (ElementBase element in Elements)
            {
                resistance += element.CalculateZ(frequency);
            }

            return resistance;
        }
    }
}