using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace View
{
    /// <summary>
    /// Рисовальщик цепи.
    /// </summary>
    public static class Drawer
    {
        #region - - Поля - -

        /// <summary>
        /// Формат текста.
        /// </summary>
        private static Font _font;

        /// <summary>
        /// Поверхность рисования.
        /// </summary>
        private static Graphics _graphics;

        /// <summary>
        /// Ручка.
        /// </summary>
        private static Pen _pen;

        #endregion

        #region - - Свойства - -

        /// <summary>
        /// Формат текста.
        /// </summary>
        public static Font Font
        {
            get => _font;
            set => _font = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Поверхность рисования.
        /// </summary>
        public static Graphics Graphics
        {
            get => _graphics;
            set => _graphics = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Ручка.
        /// </summary>
        public static Pen Pen
        {
            get => _pen;
            set => _pen = value ?? throw new ArgumentNullException(nameof(value));
        }

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Рисовать схему электрической цепи.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="displacement">Смещение.</param>
        /// <returns>Размер поддерева.</returns>
        public static Point DrawCircuit(Node root,
            Point displacement)
        {
            //TODO: разбить на подметоды
            if (root.Brood.Count == 0)
            {
                DrawElement(Graphics, Pen, root.Element, displacement);
                return new Point(1, 1);
            }

            var maxCount = 0;
            var steps = new List<int>();

            if (root.IsSerial)
            {
                //TODO: магические числа вынести в именованные константы класса
                Graphics.DrawLine(Pen, new Point(displacement.X, 25 + displacement.Y),
                    new Point(25 + displacement.X, 25 + displacement.Y));

                for (var i = 0; i < root.Brood.Count; i++)
                {
                    var count = DrawCircuit(root.Brood[i],
                        new Point(25 + displacement.X,
                            steps.Sum() * 40 + displacement.Y));

                    steps.Add(count.Y);

                    if (maxCount < count.X)
                    {
                        var step = 0;
                        for (var j = 0; j < i; j++)
                        {
                            Graphics.DrawLine(Pen,
                                new Point(25 + maxCount * 50 + displacement.X,
                                    25 + step * 40 + displacement.Y),
                                new Point(25 + count.X * 50 + displacement.X,
                                    25 + step * 40 + displacement.Y));

                            step += steps[j];
                        }

                        maxCount = count.X;
                    }
                    else
                    {
                        var step = 0;
                        for (var j = 0; j < i; j++)
                        {
                            step += steps[j];
                        }

                        Graphics.DrawLine(Pen,
                            new Point(25 + count.X * 50 + displacement.X,
                                25 + step * 40 + displacement.Y),
                            new Point(25 + maxCount * 50 + displacement.X,
                                25 + step * 40 + displacement.Y));
                    }
                }

                Graphics.DrawLine(Pen,
                    new Point(25 + maxCount * 50 + displacement.X, 25 + displacement.Y),
                    new Point(50 + maxCount * 50 + displacement.X, 25 + displacement.Y));


                Graphics.DrawLine(Pen,
                    new Point(25 + displacement.X, 25 + displacement.Y),
                    new Point(25 + displacement.X,
                        25 + (steps.Sum() - steps[steps.Count - 1]) * 40 +
                        displacement.Y));

                Graphics.DrawLine(Pen,
                    new Point(25 + maxCount * 50 + displacement.X, 25 + displacement.Y),
                    new Point(25 + maxCount * 50 + displacement.X,
                        25 + (steps.Sum() - steps[steps.Count - 1]) * 40 +
                        displacement.Y));

                return new Point(maxCount + 1, steps.Sum());
            }

            foreach (var child in root.Brood)
            {
                var count = DrawCircuit(child,
                    new Point(steps.Sum() * 50 + displacement.X, displacement.Y));

                steps.Add(count.X);

                if (maxCount < count.Y)
                {
                    maxCount = count.Y;
                }
            }

            return new Point(steps.Sum(), maxCount);
        }

        #endregion

        #region - - Приватные методы - -

        /// <summary>
        /// Рисовать элемент электрической цепи.
        /// </summary>
        /// <param name="graphics">Поверхность рисования.</param>
        /// <param name="pen">Ручка.</param>
        /// <param name="element">Элемент электрической цепи.</param>
        /// <param name="displacement">Смещение.</param>
        private static void DrawElement(Graphics graphics, Pen pen, ElementBase element,
            Point displacement)
        {
            //TODO: разбить на подметоды
            var brush = new SolidBrush(Color.Black);
            switch (element)
            {
                case Resistor _:
                    graphics.DrawLine(pen,
                        new Point(10 + displacement.X, 20 + displacement.Y),
                        new Point(10 + displacement.X, 30 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(10 + displacement.X, 30 + displacement.Y),
                        new Point(40 + displacement.X, 30 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(40 + displacement.X, 20 + displacement.Y),
                        new Point(40 + displacement.X, 30 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(40 + displacement.X, 20 + displacement.Y),
                        new Point(10 + displacement.X, 20 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(0 + displacement.X, 25 + displacement.Y),
                        new Point(10 + displacement.X, 25 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(40 + displacement.X, 25 + displacement.Y),
                        new Point(50 + displacement.X, 25 + displacement.Y));

                    graphics.DrawString(element.Name, Font, brush, 15 + displacement.X,
                        40 + displacement.Y);

                    break;
                case Capacitor _:
                    graphics.DrawLine(pen,
                        new Point(20 + displacement.X, 15 + displacement.Y),
                        new Point(20 + displacement.X, 35 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(30 + displacement.X, 15 + displacement.Y),
                        new Point(30 + displacement.X, 35 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(0 + displacement.X, 25 + displacement.Y),
                        new Point(20 + displacement.X, 25 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(30 + displacement.X, 25 + displacement.Y),
                        new Point(50 + displacement.X, 25 + displacement.Y));

                    graphics.DrawString(element.Name, Font, brush, 15 + displacement.X,
                        40 + displacement.Y);

                    break;
                case Inductor _:
                    graphics.DrawArc(pen, 10 + displacement.X, 20 + displacement.Y,
                        10, 10, 180, 180);

                    graphics.DrawArc(pen, 20 + displacement.X, 20 + displacement.Y,
                        10, 10, 180, 180);

                    graphics.DrawArc(pen, 30 + displacement.X, 20 + displacement.Y,
                        10, 10, 180, 180);

                    graphics.DrawLine(pen,
                        new Point(0 + displacement.X, 25 + displacement.Y),
                        new Point(10 + displacement.X, 25 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(40 + displacement.X, 25 + displacement.Y),
                        new Point(50 + displacement.X, 25 + displacement.Y));

                    graphics.DrawString(element.Name, Font, brush, 15 + displacement.X,
                        40 + displacement.Y);

                    break;
            }
        }

        #endregion
    }
}
