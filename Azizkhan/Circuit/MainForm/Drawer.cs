using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CircuitLibrary;
using CircuitLibrary.Elements;
using CircuitLibrary.Subcircuits;

namespace CircuitView
{
    /// <summary>
    ///     Рисовальщик цепи.
    /// </summary>
    public static class Drawer
    {
        #region - - Поля - -

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Размер bitmap по X.
        /// </summary>
        private const int _sizeX = 1000;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Размер bitmap по Y.
        /// </summary>
        private const int _sizeY = 1000;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Начальная координата Х.
        /// </summary>
        private const int _startX = 1;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Начальная координата Y.
        /// </summary>
        private const int _startY = 1;

        //TODO: статик ридонли - это константа. Поменять
        //+
        //TODO: ошибка
        //+
        /// <summary>
        ///     Сдвиг по X для отрисовки имени.
        /// </summary>
        private const int _nameDisplacementX = 15;

        //TODO: статик ридонли - это константа. Поменять
        //+
        //TODO: ошибка
        //+
        /// <summary>
        ///     Сдвиг по Y для отрисовки имени.
        /// </summary>
        private const int _nameDisplacementY = 40;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Координата X резистора.
        /// </summary>
        private const int _resistorPositionX = 10;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Координата Y резистора.
        /// </summary>
        private const int _resistorPositionY = 20;

        //TODO: статик ридонли - это константа. Поменять
        //+
        //TODO: ошибка
        //+
        /// <summary>
        ///     Высота резистора.
        /// </summary>
        private const int _resistorHeight = 10;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Ширина резистора.
        /// </summary>
        private const int _resistorWidth = 30;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Координата X первой пластины конденсатора.
        /// </summary>
        private const int _firstPlatePosition = 20;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Координата X второй пластины конденсатора.
        /// </summary>
        private const int _secondPlatePosition = 30;

        //TODO: статик ридонли - это константа. Поменять
        //+
        //TODO: ошибка
        //+
        /// <summary>
        ///     Высота конденсатора.
        /// </summary>
        private const int _capacitorHeight = 20;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Количество дуг катушки.
        /// </summary>
        private const int _arcCount = 3;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Диаметр дуги.
        /// </summary>
        private const int _arcDiameter = 10;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Координата X катушки.
        /// </summary>
        private const int _inductorPositionX = 10;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Координата Y катушки.
        /// </summary>
        private const int _inductorPositionY = 20;

        //TODO: статик ридонли - это константа. Поменять
        //+
        //TODO: ошибка
        //+
        /// <summary>
        ///     Сдвиг линий по Y.
        /// </summary>
        private const int _lineDisplacementY = 25;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Длина добавочной линии по X.
        /// </summary>
        private const int _lineLengthX = 25;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Длина добавочной линии по Y.
        /// </summary>
        private const int _lineLengthY = 40;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Длина элемента цепи по X.
        /// </summary>
        private const int _elementLengthX = 50;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Формат текста.
        /// </summary>
        private static Font _font;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Поверхность рисования.
        /// </summary>
        private static Graphics _graphics;

        //TODO: статик ридонли - это константа. Поменять
        //+
        /// <summary>
        ///     Ручка.
        /// </summary>
        private static Pen _pen;

        #endregion

        #region - - Свойства - -

        /// <summary>
        ///     Формат текста.
        /// </summary>
        public static Font Font
        {
            get => _font;
            set => _font = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        ///     Поверхность рисования.
        /// </summary>
        public static Graphics Graphics
        {
            get => _graphics;
            set => _graphics = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        ///     Ручка.
        /// </summary>
        public static Pen Pen
        {
            get => _pen;
            set => _pen = value ?? throw new ArgumentNullException(nameof(value));
        }

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        ///     Рисовать схему электрической цепи
        /// </summary>
        /// <param name="circuit">электрическая цепь</param>
        /// <returns>Изображение электрической цепи</returns>
        public static Bitmap DrawCircuit(Circuit circuit)
        {
            var bitmapBackground = new Bitmap(_sizeX, _sizeY);
            Graphics = Graphics.FromImage(bitmapBackground);
            Pen = new Pen(Color.Black, 1);
            Font = new Font("Arial", 8);

            var displacement = new Point(15, 0);
            DrawSubcircuit(circuit.Root, displacement);
            return bitmapBackground;
        }

        /// <summary>
        ///     Рисовать подсхемы электрической цепи.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="displacement">Смещение.</param>
        /// <returns>Размер поддерева.</returns>
        public static Point DrawSubcircuit(INode root,
            Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement));
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

        #endregion

        #region - - Приватные методы - -

        /// <summary>
        ///     Рисовать последовательное соединение.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="displacement">Смещение.</param>
        /// <returns>Размер поддерева.</returns>
        private static Point DrawSerialConnection(INode root,
            Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement));
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
        ///     Рисовать параллельное соединение.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="displacement">Смещение.</param>
        /// <returns>Размер поддерева.</returns>
        private static Point DrawParallelConnection(INode root,
            Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement));
            }

            //TODO: количество чего?
            var maxCount = 0;

            //TODO: шаги чего? Почему список?
            var steps = new List<int>();

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(displacement.X,
                    _lineDisplacementY + displacement.Y),
                new Point(_lineLengthX + displacement.X,
                    _lineDisplacementY + displacement.Y));

            for (var i = 0; i < root.Nodes.Count; i++)
            {
                //TODO: что за каунт и чем он отличается от макскаунт?
                //TODO: почему наверху макскаунт это int, а здесь каунт это point? Одинаковые имена для разных типов данных - неправильно!
                var count = DrawSubcircuit(root.Nodes[i],
                    new Point(_lineLengthX + displacement.X,
                        steps.Sum() * _lineLengthY +
                        displacement.Y)); //TODO: почему степс суммируются?

                //TODO: почему в шаги добавляется Y какого-то каунта?
                steps.Add(count.Y);

                //TODO: что означает это условие? В чем его смысл? Как это отлаживать?
                if (maxCount < count.X)
                {
                    var step = 0;

                    //TODO: зачем этот цикл?
                    for (var j = 0; j < i; j++)
                    {
                        //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
                        Graphics.DrawLine(Pen,
                            new Point(
                                _lineLengthX + maxCount * _elementLengthX +
                                displacement.X,
                                _lineDisplacementY + step * _lineLengthY +
                                displacement.Y),
                            new Point(
                                _lineLengthX + count.X * _elementLengthX +
                                displacement.X,
                                _lineDisplacementY + step * _lineLengthY +
                                displacement.Y));

                        //TODO: зачем мы суммируем степы?
                        step += steps[j];
                    }

                    maxCount = count.X;
                }
                else
                {
                    //TODO: аналогично
                    var step = 0;
                    for (var j = 0; j < i; j++)
                    {
                        step += steps[j];
                    }

                    //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
                    Graphics.DrawLine(Pen,
                        new Point(
                            _lineLengthX + count.X * _elementLengthX +
                            displacement.X,
                            _lineDisplacementY + step * _lineLengthY +
                            displacement.Y),
                        new Point(
                            _lineLengthX + maxCount * _elementLengthX +
                            displacement.X,
                            _lineDisplacementY + step * _lineLengthY +
                            displacement.Y));
                }
            }

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(
                    _lineLengthX + maxCount * _elementLengthX + displacement.X,
                    _lineDisplacementY + displacement.Y),
                new Point(
                    2 * _lineLengthX + maxCount * _elementLengthX +
                    displacement.X, _lineDisplacementY + displacement.Y));

            //в случае, когда у ParallelSubcircuit всего 1 элемент, алгоритм неправильно отрабатывает отрисовку, поэтому здесь есть это странное условие.
            if (root.Nodes.Count < 2)
            {
                //TODO: что здесь вообще происходит и что за условие?
                //выше написал
                return new Point(maxCount + 1, steps.Sum());
            }

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(_lineLengthX + displacement.X,
                    _lineDisplacementY + displacement.Y),
                new Point(_lineLengthX + displacement.X,

                    //TODO: почему сумма шагов, а индекс минус один?
                    _lineDisplacementY + (steps.Sum() - steps[steps.Count - 1]) *
                    _lineLengthY +
                    displacement.Y));

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(
                    _lineLengthX + maxCount * _elementLengthX + displacement.X,
                    _lineDisplacementY + displacement.Y),
                new Point(
                    _lineLengthX + maxCount * _elementLengthX + displacement.X,

                    //TODO: аналогично
                    _lineDisplacementY + (steps.Sum() - steps[steps.Count - 1]) *
                    _lineLengthY +
                    displacement.Y));

            //TODO: аналогично
            return new Point(maxCount + 1, steps.Sum());
        }

        /// <summary>
        ///     Рисовать элемент электрической цепи.
        /// </summary>
        /// <param name="element">Элемент электрической цепи.</param>
        /// <param name="displacement">Смещение.</param>
        private static void DrawElement(ElementBase element,
            Point displacement)
        {
            //TODO: убрать лишние проверки
            //+
            //TODO: зачем brush, если у тебя есть Pen?
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
        ///     Рисовать резистор.
        /// </summary>
        /// <param name="displacement">Смещение.</param>
        private static void DrawResistor(Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement));
            }

            //TODO: заменить на метод отрисовки прямоугольника
            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + displacement.X,
                    _resistorPositionY + displacement.Y),
                new Point(_resistorPositionX + displacement.X,
                    _resistorPositionY + _resistorHeight + displacement.Y));

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + displacement.X,
                    _resistorPositionY + _resistorHeight + displacement.Y),
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _resistorPositionY + _resistorHeight + displacement.Y));

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _resistorPositionY + displacement.Y),
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _resistorPositionY + _resistorHeight + displacement.Y));

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _resistorPositionY + displacement.Y),
                new Point(_resistorPositionX + displacement.X,
                    _resistorPositionY + displacement.Y));

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(displacement.X, _lineDisplacementY + displacement.Y),
                new Point(_resistorPositionX + displacement.X,
                    _lineDisplacementY + displacement.Y));

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _lineDisplacementY + displacement.Y),
                new Point(_elementLengthX + displacement.X,
                    _lineDisplacementY + displacement.Y));
        }

        /// <summary>
        ///     Рисовать конденсатор.
        /// </summary>
        /// <param name="displacement">Смещение.</param>
        private static void DrawCapacitor(Point displacement)
        {
            //TODO: displacement передается внутри класса. Как он может быть null? Избавиться от ненужных проверок
            //+
            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(_firstPlatePosition + displacement.X,
                    _lineDisplacementY - _capacitorHeight / 2 + displacement.Y),
                new Point(_firstPlatePosition + displacement.X,
                    _lineDisplacementY + _capacitorHeight / 2 + displacement.Y));

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(_secondPlatePosition + displacement.X,
                    _lineDisplacementY - _capacitorHeight / 2 + displacement.Y),
                new Point(_secondPlatePosition + displacement.X,
                    _lineDisplacementY + _capacitorHeight / 2 + displacement.Y));

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(displacement.X, _lineDisplacementY + displacement.Y),
                new Point(_firstPlatePosition + displacement.X,
                    _lineDisplacementY + displacement.Y));

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(_secondPlatePosition + displacement.X,
                    _lineDisplacementY + displacement.Y),
                new Point(_elementLengthX + displacement.X,
                    _lineDisplacementY + displacement.Y));
        }

        /// <summary>
        ///     Рисовать катушку.
        /// </summary>
        /// <param name="displacement">Смещение.</param>
        private static void DrawInductor(Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement));
            }

            for (var i = 0; i < _arcCount; i++)
            {
                //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
                Graphics.DrawArc(Pen,
                    _inductorPositionX + i * _arcDiameter + displacement.X,
                    _inductorPositionY + displacement.Y,
                    _arcDiameter, _arcDiameter, 0, -180);
            }

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(displacement.X, _lineDisplacementY + displacement.Y),
                new Point(_inductorPositionX + displacement.X,
                    _lineDisplacementY + displacement.Y));

            //TODO: подписать, какую именно линию рисует этот Draw, иначе невозможно отлаживать
            Graphics.DrawLine(Pen,
                new Point(
                    _inductorPositionX + _arcCount * _arcDiameter +
                    displacement.X,
                    _lineDisplacementY + displacement.Y),
                new Point(_elementLengthX + displacement.X,
                    _lineDisplacementY + displacement.Y));
        }

        #endregion
    }
}