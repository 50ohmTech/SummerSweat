using System.Windows.Forms;

namespace CircuitCalculator.Validation
{
	public static class ValidatingClass
	{
		/// <summary>
		///     Валидация ввода double значений в таблицу при изменении значений элементов
		/// </summary>
		public static bool IsCellCorrect(DataGridViewCellValidatingEventArgs e)
		{
			string formatingString = e.FormattedValue.ToString().Replace('.', ',');
			if (double.TryParse(formatingString,
				    out var newValue) && !(newValue < 0.000000001) && newValue <= 1000000000000)
			{
				if (formatingString.Length > 1 && formatingString[0] == '0' && formatingString[1] != ',')
				{
					return false;
				}

				if (formatingString[0] == ',' || formatingString[0] == '.')
				{
					return false;
				}

				if (e.FormattedValue.ToString().Contains(" "))
				{
					return false;
				}

				return true;
			}

			return false;
		}
	}
}
