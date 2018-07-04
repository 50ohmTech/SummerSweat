﻿using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Elements;

namespace Model
{
    /// <summary>
    ///     Ветвь
    /// </summary>
    public sealed class Branch
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="nodeIn">Вход. узел</param>
        public Branch(uint nodeIn)
        {
            if (nodeIn > NodeOutLast)
            {
                throw new ArgumentException(
                    $"Вход. узел должен быть равен или меньше последнего узла = {NodeOutLast}");
            }

            Elements = new List<ElementBase>();
            NodeIn = nodeIn;
            NodeOut = NodeIn + 1;
            NodeOutLast = NodeOut;
            Key = NodeIn + "_" + NodeOut;
        }

        public static uint NodeOutLast { get; private set; }

        /// <summary>
        ///     Входящий узел
        /// </summary>
        public uint NodeIn { get; }

        /// <summary>
        ///     Выходящий узел
        /// </summary>
        public uint NodeOut { get; }

        /// <summary>
        ///     Ключ, который определяется из узлов
        /// </summary>
        public string Key { get; }

        /// <summary>
        ///     Список элементов в ветви
        /// </summary>
        public List<ElementBase> Elements { get; }

        /// <summary>
        ///     Расчет комплексного сопротивления Ветви
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Комплексное сопротивление</returns>
        public Complex CalculateZ(double frequency)
        {
            if (frequency < 1 || frequency > 1000000000000)
            {
                throw new ArgumentException(
                    "Частота может иметь значение только от 1 Гц. до 1 ТГц.");
            }

            Complex resistance = new Complex();
            foreach (ElementBase element in Elements)
            {
                resistance += element.CalculateZ(frequency);
            }

            return resistance;
        }
    }
}