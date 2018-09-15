using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Model;
using Model.Elements;

namespace View
{
    /// <summary>
    ///     Рисовальщик цепи.
    /// </summary>
    public class Drawer
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Цепь.
        /// </summary>
        private readonly Circuit _circuit;


        /// <summary>
        ///     Формат текста.
        /// </summary>
        private Font _font = new Font(new FontFamily("Calibri"), 12, FontStyle.Regular);

        /// <summary>
        ///     Поверхность рисования.
        /// </summary>
        private Graphics _graphics;

        /// <summary>
        ///     Ручка.
        /// </summary>
        private Pen _pen = new Pen(Color.Black);

        /// <summary>
        ///     Картинка
        /// </summary>
        private readonly PictureBox _picture;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Отступ.
        /// </summary>
        private Point Displacement { get; } = new Point(0, 0);


        /// <summary>
        ///     Формат текста.
        /// </summary>
        public Font Font
        {
            get => _font;
            set => _font = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        ///     Ручка.
        /// </summary>
        public Pen Pen
        {
            get => _pen;
            set => _pen = value ?? throw new ArgumentNullException(nameof(value));
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Рисовать схему электрической цепи.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="displacement">Смещение.</param>
        /// <returns>Размер поддерева.</returns>
        private Point DrawCircuit(INode root, Point displacement)
        {
            if (root.Nodes.Count == 0)
            {
                DrawElement(_graphics, Pen, (ElementBase) root, displacement);
                return new Point(1, 1);
            }

            int maxCount = 0;
            List<int> steps = new List<int>();

            if (root is ParallelSubcircuit)
            {
                _graphics.DrawLine(Pen, new Point(displacement.X, 25 + displacement.Y),
                    new Point(25 + displacement.X, 25 + displacement.Y));

                for (int i = 0; i < root.Nodes.Count; i++)
                {
                    Point count = DrawCircuit(root.Nodes[i],
                        new Point(25 + displacement.X,
                            steps.Sum() * 40 + displacement.Y));

                    steps.Add(count.Y);

                    if (maxCount < count.X)
                    {
                        int step = 0;
                        for (int j = 0; j < i; j++)
                        {
                            _graphics.DrawLine(Pen,
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
                        int step = 0;
                        for (int j = 0; j < i; j++)
                        {
                            step += steps[j];
                        }

                        _graphics.DrawLine(Pen,
                            new Point(25 + count.X * 50 + displacement.X,
                                25 + step * 40 + displacement.Y),
                            new Point(25 + maxCount * 50 + displacement.X,
                                25 + step * 40 + displacement.Y));
                    }
                }

                _graphics.DrawLine(Pen,
                    new Point(25 + maxCount * 50 + displacement.X, 25 + displacement.Y),
                    new Point(50 + maxCount * 50 + displacement.X, 25 + displacement.Y));


                _graphics.DrawLine(Pen,
                    new Point(25 + displacement.X, 25 + displacement.Y),
                    new Point(25 + displacement.X,
                        25 + (steps.Sum() - steps[steps.Count - 1]) * 40 +
                        displacement.Y));

                _graphics.DrawLine(Pen,
                    new Point(25 + maxCount * 50 + displacement.X, 25 + displacement.Y),
                    new Point(25 + maxCount * 50 + displacement.X,
                        25 + (steps.Sum() - steps[steps.Count - 1]) * 40 +
                        displacement.Y));

                return new Point(maxCount + 1, steps.Sum());
            }

            foreach (INode child in root.Nodes)
            {
                Point count = DrawCircuit(child,
                    new Point(steps.Sum() * 50 + displacement.X, displacement.Y));

                steps.Add(count.X);

                if (maxCount < count.Y)
                {
                    maxCount = count.Y;
                }
            }

            return new Point(steps.Sum(), maxCount);
        }


        /// <summary>
        ///     Рисовать элемент электрической цепи.
        /// </summary>
        /// <param name="graphics">Поверхность рисования.</param>
        /// <param name="pen">Ручка.</param>
        /// <param name="element">Элемент электрической цепи.</param>
        /// <param name="displacement">Смещение.</param>
        private void DrawElement(Graphics graphics, Pen pen, ElementBase element,
            Point displacement)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
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

        #region Public methods

        public Drawer(PictureBox picture, Circuit circuit)
        {
            _picture = picture ?? throw new ArgumentNullException(nameof(picture));
            _circuit = circuit ?? throw new ArgumentNullException(nameof(circuit));
        }

        /// <summary>
        ///     Нарисовать цепь.
        /// </summary>
        public void DrawCircuit()
        {
            Bitmap bitmap = new Bitmap(1000, 1000);
            _graphics = Graphics.FromImage(bitmap);
            DrawCircuit(_circuit.Root, Displacement);
            _picture.Image = bitmap;
        }

        #endregion
    }
}