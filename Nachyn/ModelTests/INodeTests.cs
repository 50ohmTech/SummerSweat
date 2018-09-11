using System;
using System.Numerics;
using Model.Elements;
using Model.Elements.Checks;
using Model.Elements.Events;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Класс проверки базовых элементов цепи")]
    internal class INodeTests
    {
        #region Public methods

        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        [Test(Description = "Негативный Тест имени у базового элемента")]
        public void NegativeBaseElementNameTest(string name)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ElementBase elementBase = new Resistor(name, 40);
            });
        }

        [Test(Description = "Тест имени у базового элемента")]
        public void BaseElementNameTest()
        {
            string name = Guid.NewGuid().ToString();
            ElementBase elementBase = new Resistor(name, 40);
        }

        [Test(Description = "Тест детей INode на not null")]
        public void NodeChildrenNotNullTest()
        {
            void ChildrenNotNullTest(INode node)
            {
                if (node.Nodes == null)
                {
                    throw new Exception("Nodes был null");
                }
            }

            ChildrenNotNullTest(new SeriesSubcircuit());
            ChildrenNotNullTest(new ParallelSubcircuit());
            ChildrenNotNullTest(new Resistor("Message", 1));
            ChildrenNotNullTest(new Capacitor("Message", 1));
            ChildrenNotNullTest(new Inductor("Message", 1));
        }

        [TestCase(20)]
        [TestCase(200)]
        [TestCase(20000)]
        [Description("Тест номинала на разные частоты")]
        public void ResistorTest(double frequency)
        {
            Resistor resistor = new Resistor("Message", 20);

            Complex expected = new Complex(20, 0);

            Assert.AreEqual(expected, resistor.CalculateZ(frequency));
        }

        [TestCase(-20)]
        [TestCase(-200)]
        [TestCase(-20000)]
        [Description("Негативный тест на отрицательный номинал")]
        public void NegativeResistorTest(double resistance)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Resistor resistor = new Resistor("Message", resistance);
            });
        }

        [TestCase(0)]
        [TestCase(-100)]
        [TestCase(1000000000001)]
        [Description("Негативный тест на отрицательную частоту")]
        public void NegativeFrequencyTest(double frequency)
        {
            ElementBase elementBase = new Capacitor("Message", 20);
            Assert.Throws<ArgumentException>(() =>
            {
                elementBase.CalculateZ(frequency);
            });
        }

        [TestCase(20)]
        [TestCase(200)]
        [TestCase(100000)]
        [Description("Тест номинала на разные частоты")]
        public void CapacitorTest(double frequency)
        {
            Capacitor capacitor = new Capacitor("Message", 50);
            double expected = 1 / (2 * Math.PI * frequency * 50);


            Assert.AreEqual(expected, capacitor.CalculateZ(frequency).Imaginary, 0.001);
        }

        [TestCase(20)]
        [TestCase(200)]
        [TestCase(100000)]
        [Description("Тест номинала на разные частоты")]
        public void InductorTest(double frequency)
        {
            Inductor inductor = new Inductor("Message", 50);
            double expected = 2 * Math.PI * frequency * 50;

            Assert.AreEqual(expected, inductor.CalculateZ(frequency).Imaginary, 0.001);
        }

        [Test(Description = "Тест на вызов события")]
        public void EventHandlerTest()
        {
            Inductor inductor = new Inductor("Message", 40);
            bool test = false;

            inductor.ValueChanged += (sender, argument) => { test = true; };

            inductor.Value = 50;

            Assert.AreEqual(true, test);
        }


        [Test(Description = "Тест номинала у аргумента события")]
        public void EventArgsValueTest(
            [Random(Calculations.MIN_FREQUENCY, Calculations.MAX_FREQUENCY, 10)]
            double value)
        {
            ElementValueEventArgs args = new ElementValueEventArgs("Message", value);
        }

        [Test(Description = "Негативный Тест номинала у аргумента события")]
        public void NegativeEventArgsValueTest([Random(-1000000d, 0d, 10)] double value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ElementValueEventArgs args = new ElementValueEventArgs("Message", value);
            });
        }

        [Test(Description = "Тест имени у аргумента события")]
        public void EventArgsNameTest()
        {
            string name = Guid.NewGuid().ToString();
            ElementValueEventArgs args = new ElementValueEventArgs(name, 1);
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        [Test(Description = "Негативный Тест имени у аргумента события")]
        public void NegativeEventArgsNameTest(string name)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ElementValueEventArgs args = new ElementValueEventArgs(name, 1);
            });
        }

        [Test(Description = "Негативный тест параллельного соединения на вычисление")]
        public void NegativeParallelSubcircuitCalculateTest()
        {
            ParallelSubcircuit parallel = new ParallelSubcircuit();
            parallel.Nodes.Add(new Resistor("Message", 20));
            Assert.Throws<Exception>(() => { parallel.CalculateZ(20); });
        }


        [Test(Description = "Тест инкремента у подцепи")]
        public void SubcircuitIdTest()
        {
            bool test = true;
            SeriesSubcircuit seriesSubcircuit = new SeriesSubcircuit();
            ParallelSubcircuit parallelSubcircuit = new ParallelSubcircuit();

            if (seriesSubcircuit.Id == parallelSubcircuit.Id)
            {
                test = false;
            }

            Assert.AreEqual(true, test);
        }

        #endregion
    }
}