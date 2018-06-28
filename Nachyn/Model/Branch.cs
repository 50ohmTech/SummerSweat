using System.Collections.ObjectModel;
using System.Numerics;
using Model.Elements;
using Model.Events;

namespace Model
{
    public sealed class Branch
    {
        public static event CollectionChangedEventHandler CollectionChanged;

        public Branch(uint nodeIn, uint nodeOut)
        {
            Elements = new ObservableCollection<ElementBase>();
            Elements.CollectionChanged += Elements_CollectionChanged;
            NodeIn = nodeIn;
            NodeOut = nodeOut;
            Key = NodeIn + "_" + NodeOut;
        }

        private void Elements_CollectionChanged(object sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke();
        }

        public uint NodeIn { get; }

        public uint NodeOut { get; }

        public string Key { get; }

        public ObservableCollection<ElementBase> Elements { get; }

        /// <summary>
        ///     Расчет комплексного сопротивления Ветви
        /// </summary>
        /// <param name="frequencies">Частота</param>
        /// <returns>Комплексное сопротивление</returns>
        public Complex CalculateZ(double frequency)
        {
            var resistance = new Complex();
            foreach (var element in Elements)
            {
                resistance += element.CalculateZ(frequency);
            }

            return resistance;
        }
    }
}