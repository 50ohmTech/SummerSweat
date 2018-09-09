using System;
using System.Numerics;
using Model.Elements;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Класс проверки базовых элементов цепи")]
    internal class ElementBaseTests
    {
        #region Public methods

        [TestCase(20)]
        [TestCase(200)]
        [TestCase(20000)]
        [Description("Тест номинала на разные частоты")]
        public void ResistorTest(double frequency)
        {
            Resistor resistor = new Resistor("Name", 20);

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
                Resistor resistor = new Resistor("Name", resistance);
            });
        }

        [TestCase(0)]
        [TestCase(-100)]
        [TestCase(1000000000001)]
        public void NegativeFrequencyTest(double frequency)
        {
            ElementBase elementBase = new Capacitor("Name", 20);
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
            Capacitor capacitor = new Capacitor("Name", 50);
            double expected = 1 / (2 * Math.PI * frequency * 50);

            Assert.AreEqual(expected, capacitor.CalculateZ(frequency).Imaginary);
        }

        [TestCase(20)]
        [TestCase(200)]
        [TestCase(100000)]
        [Description("Тест номинала на разные частоты")]
        public void InductorTest(double frequency)
        {
            Inductor inductor = new Inductor("Name", 50);
            double expected = 2 * Math.PI * frequency * 50;

            Assert.AreEqual(expected, inductor.CalculateZ(frequency).Imaginary);
        }

        [Test(Description = "Тест на вызов события")]
        public void EventHandlerTest()
        {
            Inductor inductor = new Inductor("Name", 40);
            bool test = false;

            inductor.ValueChanged += (sender, argument) => { test = true; };

            inductor.Value = 50;

            Assert.AreEqual(true, test);
        }

        #endregion
    }
}