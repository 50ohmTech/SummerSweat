using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Model
{
    //TODO: Класс нарушает принципы ООП: Один класс - одна задача!
    // Здесь же солянка методов для разных классов без какого-либо принципа
    /// <summary>
    ///     Функции для NodeType
    /// </summary>
    public class Tools
    {
        #region Nested class

        //TODO: Для этого существует стандартный класс Tuple
        /// <summary>
        ///     Тип данных, который хранит 2 переменных.
        ///     На подобие vector<pair> из C++.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        public class Pair<T, U>
        {
            #region Properties

            public T First { get; }
            public U Second { get; }

            #endregion

            #region Constructor

            public Pair()
            {
            }

            public Pair(T first, U second)
            {
                First = first;
                Second = second;
            }

            #endregion
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Получить атрибут "Описание"
        /// </summary>
        public static string GetDescription(NodeType value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[]) fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return value.ToString();
        }

        /// <summary>
        /// Проверка на корректность веденных данных
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool IsCellCorrect(string e)
        {
            var formatingString = e.Replace('.', ',');

            //Если число входит в рамки входных данных
            if (double.TryParse(formatingString, out var newValue) 
                && !(newValue < 0.1) && newValue <= 1e12)
            {
                //Если число начинаеться с нуля и после нуля нету запятой
                if (formatingString.Length > 1 && formatingString[0] == '0' &&
                    formatingString[1] != ',')
                {
                    return false;
                }

                if (formatingString[0] == ',' || formatingString[0] == '.')
                {
                    return false;
                }

                if (e.Contains(" "))
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        //TODO: Почему класс бизнес-логики знает что-то про пользовательский интерфейс?
        public static void ShowError(TextBox textBox)
        {
            if (textBox.Text != "")
            {
                MessageBox.Show(
                    "Вы ввели: " + textBox.Text + "\n" +
                    "Вводимое значение должно удовлетворять следующим условиям:\n " +
                    "-быть положительным числом\n " +
                    "-быть вещественным или натуральным числом\n " +
                    "-быть большим 0,1 по модулю\n " +
                    "-быть меньше 1e12 (1000000000000)\n " +
                    "-запись не должна содержать пробелов\n " +
                    "-запись должна начинаться с цифры\n " +
                    "-использование экспоненциальной записи не допускается\n " +
                    "-eсли первой цифрой числа являтся ноль, значит после него обязательно должна быть запятая.",
                    "Ошибка ввода значения частоты", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        ///     Создание имени для элемента
        /// </summary>
        /// <param name="nameElements">Латинская буква элемента</param>
        /// <param name="vectorOfElements">Список имен</param>
        /// <returns></returns>
        public static Pair<char, int> CreateName(char nameElements,
            List<Pair<char, int>> vectorOfElements)
        {
            vectorOfElements.Sort((p1, p2) => p1.Second.CompareTo(p2.Second));
            var j = 1;
            for (var i = 0; i < vectorOfElements.Count; i++)
            {
                if (vectorOfElements[i].First == nameElements)
                {
                    if (vectorOfElements[i].Second > j)
                    {
                        return new Pair<char, int>(nameElements, j);
                    }

                    j++;
                }
            }

            return new Pair<char, int>(nameElements, j);
            ;
        }

        //TODO: бизнес-логика использует GUI - неправильно!
        public static void IsCorrectStartFinish(TextBox startTextBox,
            TextBox finishTextBox)
        {
            if (startTextBox.Text.Length != 0 && finishTextBox.Text.Length != 0)
            {
                if ((double.Parse(startTextBox.Text) > double.Parse(finishTextBox.Text)))
                {
                    MessageBox.Show("Начало должно быть меньше границы!");
                    startTextBox.Text = null;
                    finishTextBox.Text = null;
                }
            }
        }

        public static void IsCorrectStep(TextBox startTextBox, TextBox finishTextBox,
            TextBox stepTextBox)
        {
            if (startTextBox.Text.Length != 0 && finishTextBox.Text.Length != 0 &&
                stepTextBox.Text.Length != 0)
            {
                if ((double.Parse(finishTextBox.Text) - double.Parse(startTextBox.Text) <
                     double.Parse(stepTextBox.Text)))
                {
                    MessageBox.Show(
                        "Разница между началом и концов по модулю не может быть меньше шага!");
                    startTextBox.Text = null;
                    finishTextBox.Text = null;
                    stepTextBox.Text = null;

                }
            }
        }

        #endregion
    }
}