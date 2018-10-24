using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CircuitLibrary;
using CircuitLibrary.Subcircuit;

namespace CircuitView
{
    /// <summary>
    ///     Class for drawing circuit elements
    ///     in an electrical circuit
    /// </summary>
    public static class Drawer
    {
        #region Static fields

        /// <summary>
        ///     The count of arcs of the inductor
        /// </summary>
        private static readonly int _arcCount = 3;

        /// <summary>
        ///     The diameter of arc of the inductor
        /// </summary>
        private static readonly int _arcDiameter = 10;

        /// <summary>
        ///     The X coordinate of the first plate of the capacitor
        /// </summary>
        private static readonly int _capacitorFirstPlatePosition = 20;

        /// <summary>
        ///     Height of capacitor
        /// </summary>
        private static readonly int _capacitorHeight = 20;

        /// <summary>
        ///     The X coordinate of the second plate of the capacitor
        /// </summary>
        private static readonly int _capacitorSecondPlatePosition = 30;

        /// <summary>
        ///     the length of the electrical circuit element along the X coordinate
        /// </summary>
        private static readonly int _elementLengthX = 50;

        /// <summary>
        ///     The Y coordinate for inductor
        /// </summary>
        private static readonly int _inductorPositionX = 10;

        /// <summary>
        ///     The Y coordinate for inductor
        /// </summary>
        private static readonly int _inductorPositionY = 20;

        /// <summary>
        ///     Displacement of the drawing line by Y coordinate
        /// </summary>
        private static readonly int _lineDisplasemantY = 25;

        /// <summary>
        ///     The length of the extension line at the X coordinate
        /// </summary>
        private static readonly int _lineLengthX = 25;

        /// <summary>
        ///     The length of the extension line at the Y coordinate
        /// </summary>
        private static readonly int _lineLengthY = 45;

        /// <summary>
        ///     Displacement along the X coordinate for to drawing the element name
        /// </summary>
        private static readonly int _nameDisplacementX = 15;

        /// <summary>
        ///     Displacement along the Y coordinate for to drawing the element name
        /// </summary>
        private static readonly int _nameDisplacementY = 40;

        /// <summary>
        ///     Height of resistor
        /// </summary>
        private static readonly int _resistorHeight = 10;

        /// <summary>
        ///     The X coordinate for resistor
        /// </summary>
        private static readonly int _resistorPositionX = 10;

        /// <summary>
        ///     The Y coordinate for resistor
        /// </summary>
        private static readonly int _resistorPositionY = 20;

        /// <summary>
        ///     Width of resistor
        /// </summary>
        private static readonly int _resistorWidth = 30;

        /// <summary>
        ///     The size of the Bitmap along the X-axis
        /// </summary>
        private static readonly int _sizeBackgroundX = 1000;

        /// <summary>
        ///     The size of the Bitmap along the Y-axis
        /// </summary>
        private static readonly int _sizeBackgroundY = 1000;

        /// <summary>
        ///     The start  X-coordinate
        /// </summary>
        private static readonly int _startX = 1;

        /// <summary>
        ///     The start  Y-coordinate
        /// </summary>
        private static readonly int _startY = 1;

        /// <summary>
        ///     Font of drawing
        /// </summary>
        private static Font _font;

        /// <summary>
        ///     Canvas for drawing
        /// </summary>
        private static Graphics _graphics;

        /// <summary>
        ///     Pen for drawing electrical circuit elements
        /// </summary>
        private static Pen _pen;

        #endregion

        #region Properties

        /// <summary>
        ///     Font of drawing
        /// </summary>
        private static Font Font
        {
            get => _font;
            set => _font =
                value ?? throw new ArgumentNullException(nameof(value), "Font is null");
        }

        /// <summary>
        ///     Canvas for drawing
        /// </summary>
        private static Graphics Graphics
        {
            get => _graphics;
            set => _graphics =
                value ?? throw new ArgumentNullException(nameof(value),
                    "Graphics is null");
        }

        /// <summary>
        ///     Pen for drawing electrical circuit elements
        /// </summary>
        private static Pen Pen
        {
            get => _pen;
            set => _pen =
                value ?? throw new ArgumentException(nameof(value), "Pen is null");
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Drawing the Subcircuit elements of electrical circuit
        /// </summary>
        /// <param name="root">Root of tree </param>
        /// <param name="displacement">Displacement</param>
        /// <returns>The size of the drawn electrical circuit</returns>
        private static Point DrawSubcircuit(INode root, Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement),
                    "Displacement is null");
            }

            if (root is ElementBase elementBase)
            {
                DrawElement(elementBase, displacement);
                return new Point(_startX, _startY);
            }

            return root is SerialSubcircuit
                ? DrawSerialConnection(root, displacement)
                : DrawParallelConnection(root, displacement);
        }

        /// <summary>
        ///     Drawing a serial connection of an electrical circuit
        /// </summary>
        /// <param name="root">Root of tree</param>
        /// <param name="displacement">Displacement</param>
        /// <returns>The size of the drawn electrical circuit</returns>
        private static Point DrawSerialConnection(INode root,
            Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement),
                    "Displacement is null");
            }

            var maxCount = 0;
            var steps = new List<int>();

            foreach (var child in root.Nodes)
            {
                var count = DrawSubcircuit(child,
                    new Point(steps.Sum() * _elementLengthX + displacement.X,
                        displacement.Y));

                steps.Add(count.X);

                if (maxCount < count.Y)
                {
                    maxCount = count.Y;
                }
            }

            return new Point(steps.Sum(), maxCount);
        }

        /// <summary>
        ///     Drawing a parallel connection of an electrical circuit
        /// </summary>
        /// <param name="root">Root of tree</param>
        /// <param name="displacement">Displacement</param>
        /// <returns>The size of the drawn electrical circuit</returns>
        private static Point DrawParallelConnection(INode root,
            Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement),
                    "Displacement is null");
            }

            var maxCount = 0;
            var steps = new List<int>();


            Graphics.DrawLine(Pen,
                new Point(displacement.X,
                    _lineDisplasemantY + displacement.Y),
                new Point(_lineLengthX + displacement.X,
                    _lineDisplasemantY + displacement.Y));

            for (var i = 0; i < root.Nodes.Count; i++)
            {
                var count = DrawSubcircuit(root.Nodes[i],
                    new Point(_lineLengthX + displacement.X,
                        steps.Sum() * _lineLengthY + displacement.Y));

                steps.Add(count.Y);

                if (maxCount < count.X)
                {
                    var step = 0;
                    for (var j = 0; j < i; j++)
                    {
                        Graphics.DrawLine(Pen,
                            new Point(
                                _lineLengthX + maxCount * _elementLengthX +
                                displacement.X,
                                _lineDisplasemantY + step * _lineLengthY +
                                displacement.Y),
                            new Point(
                                _lineLengthX + count.X * _elementLengthX +
                                displacement.X,
                                _lineDisplasemantY + step * _lineLengthY +
                                displacement.Y));

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
                        new Point(
                            _lineLengthX + count.X * _elementLengthX +
                            displacement.X,
                            _lineDisplasemantY + step * _lineLengthY +
                            displacement.Y),
                        new Point(
                            _lineLengthX + maxCount * _elementLengthX +
                            displacement.X,
                            _lineDisplasemantY + step * _lineLengthY +
                            displacement.Y));
                }
            }

            if (root.Nodes.Count < 2)
            {
                return new Point(maxCount + 1, steps.Sum());
            }

            Graphics.DrawLine(Pen,
                new Point(
                    _lineLengthX + maxCount * _elementLengthX + displacement.X,
                    _lineDisplasemantY + displacement.Y),
                new Point(
                    2 * _lineLengthX + maxCount * _elementLengthX +
                    displacement.X, _lineDisplasemantY + displacement.Y));

            if (steps.Count != 0)
            {
                Graphics.DrawLine(Pen,
                    new Point(_lineLengthX + displacement.X,
                        _lineDisplasemantY + displacement.Y),
                    new Point(_lineLengthX + displacement.X,
                        _lineDisplasemantY + (steps.Sum() - steps[steps.Count - 1]) *
                        _lineLengthY +
                        displacement.Y));


                Graphics.DrawLine(Pen,
                    new Point(
                        _lineLengthX + maxCount * _elementLengthX + displacement.X,
                        _lineDisplasemantY + displacement.Y),
                    new Point(
                        _lineLengthX + maxCount * _elementLengthX + displacement.X,
                        _lineDisplasemantY + (steps.Sum() - steps[steps.Count - 1]) *
                        _lineLengthY +
                        displacement.Y));
            }

            return new Point(maxCount + 1, steps.Sum());
        }

        /// <summary>
        ///     Drawing electrical circuit elements
        /// </summary>
        /// <param name="element">Electrical circuit element</param>
        /// <param name="displacement">Dispalcement</param>
        private static void DrawElement(ElementBase element,
            Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement),
                    "Displacement is null");
            }

            if (element == null)
            {
                throw new ArgumentNullException(nameof(element),
                    "Element of electrical circuit is null");
            }

            var brush = new SolidBrush(Color.Black);

            switch (element)
            {
                case Resistor _:
                    DrawResistor(displacement);
                    break;
                case Capacitor _:
                    DrawCapacitor(displacement);
                    break;
                case Inductor _:
                    DrawInductor(displacement);
                    break;
            }

            Graphics.DrawString(element.Name, Font, brush,
                _nameDisplacementX + displacement.X,
                _nameDisplacementY + displacement.Y);
        }

        /// <summary>
        ///     Drawing resistor
        /// </summary>
        /// <param name="displacement">Displacement</param>
        private static void DrawResistor(Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement),
                    "Displacement is null");
            }

            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + displacement.X,
                    _resistorPositionY + displacement.Y),
                new Point(_resistorPositionX + displacement.X,
                    _resistorPositionY + _resistorHeight + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + displacement.X,
                    _resistorPositionY + _resistorHeight + displacement.Y),
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _resistorPositionY + _resistorHeight + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _resistorPositionY + displacement.Y),
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _resistorPositionY + _resistorHeight + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _resistorPositionY + displacement.Y),
                new Point(_resistorPositionX + displacement.X,
                    _resistorPositionY + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(displacement.X, _lineDisplasemantY + displacement.Y),
                new Point(_resistorPositionX + displacement.X,
                    _lineDisplasemantY + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _lineDisplasemantY + displacement.Y),
                new Point(_elementLengthX + displacement.X,
                    _lineDisplasemantY + displacement.Y));
        }

        /// <summary>
        ///     Drawing capacitor
        /// </summary>
        /// <param name="displacement">Displacement</param>
        private static void DrawCapacitor(Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement),
                    "Displacement is null");
            }

            Graphics.DrawLine(Pen,
                new Point(_capacitorFirstPlatePosition + displacement.X,
                    _lineDisplasemantY - _capacitorHeight / 2 + displacement.Y),
                new Point(_capacitorFirstPlatePosition + displacement.X,
                    _lineDisplasemantY + _capacitorHeight / 2 + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(_capacitorSecondPlatePosition + displacement.X,
                    _lineDisplasemantY - _capacitorHeight / 2 + displacement.Y),
                new Point(_capacitorSecondPlatePosition + displacement.X,
                    _lineDisplasemantY + _capacitorHeight / 2 + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(displacement.X, _lineDisplasemantY + displacement.Y),
                new Point(_capacitorFirstPlatePosition + displacement.X,
                    _lineDisplasemantY + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(_capacitorSecondPlatePosition + displacement.X,
                    _lineDisplasemantY + displacement.Y),
                new Point(_elementLengthX + displacement.X,
                    _lineDisplasemantY + displacement.Y));
        }

        /// <summary>
        ///     Drawing capacitor
        /// </summary>
        /// <param name="displacement">Displacement</param>
        private static void DrawInductor(Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement),
                    "Displacement is null");
            }

            for (var i = 0; i < _arcCount; i++)
            {
                Graphics.DrawArc(Pen,
                    _inductorPositionX + i * _arcDiameter + displacement.X,
                    _inductorPositionY + displacement.Y,
                    _arcDiameter, _arcDiameter, 0, -180);
            }

            Graphics.DrawLine(Pen,
                new Point(displacement.X, _lineDisplasemantY + displacement.Y),
                new Point(_inductorPositionX + displacement.X,
                    _lineDisplasemantY + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(
                    _inductorPositionX + _arcCount * _arcDiameter +
                    displacement.X,
                    _lineDisplasemantY + displacement.Y),
                new Point(_elementLengthX + displacement.X,
                    _lineDisplasemantY + displacement.Y));
        }
        #endregion

        #region Public methods

        /// <summary>
        ///     Drawing electrical circuit
        /// </summary>
        /// <param name="root">Root of tree</param>
        /// <returns>Full image of the entire electrical circuit</returns>
        public static Bitmap DrawCircuit(INode root)
        {
            var background = new Bitmap(_sizeBackgroundX, _sizeBackgroundY);

            Graphics = Graphics.FromImage(background);
            Pen = new Pen(Color.Black, 1);
            Font = new Font("Times new Roman", 10);
            var displacement = new Point(10, 0);

            DrawSubcircuit(root, displacement);
            return background;
        }

        #endregion
    }
}