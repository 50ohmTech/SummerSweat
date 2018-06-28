using System;
using System.Numerics;

namespace Gpt.Model
{
    /// <summary>
    ///     Индуктивность
    /// </summary>
    public class Inductor : ElementBase
    {
        /// <summary>
        ///     Конструктор для создание индуктивности
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="inductance">Индуктивность</param>
        public Inductor(string name, double inductance = 0) : base(name, inductance)
        {
        }

        /// <summary>
        ///     Расчет комплексного сопротивления индуктивности
        /// </summary>
        /// <param name="f">Частоста</param>
        /// <returns>Комплексное сопротивление</returns>
        public override Complex CalculateZ(double f)
        {
            var valueZ = 2 * Math.PI * f * Value;
            return new Complex(0, valueZ);
        }
    }
}