﻿using Model;
using System;
using System.Globalization;
using System.Windows.Forms;
using View.Properties;

namespace View
{
    public class MyDataGridView : DataGridView
    {
        private void ResetCell(Keys keyData)
        {
            if (keyData != Keys.Enter && keyData != Keys.Tab && keyData != Keys.Up &&
                keyData != Keys.Down && keyData != Keys.Left || EditingControl == null)
            {
                return;
            }

            var index = ((DataGridViewTextBoxEditingControl)EditingControl)
                .EditingControlRowIndex;
            var name = Rows[index].Cells[0].Value.ToString();

            Circuit circuit;
            if (Form.ActiveForm is CreateForm createForm)
            {
                circuit = createForm.Circuit;
            }
            else
            {
                throw new ArgumentException(nameof(circuit));
            }

            ElementBase element;
            if (circuit != null)
            {
                element = circuit.Elements.Search(circuit.Elements.Root, name)
                    .Element;
            }
            else
            {
                throw new ArgumentNullException(nameof(circuit));
            }

            if (!double.TryParse(EditingControl.Text, out var value))
            {
                EditingControl.Text =
                    element.Value.ToString(CultureInfo.InvariantCulture);

                return;
            }

            if (value < double.Parse(Resources.minElementValue) ||
                value > double.Parse(Resources.maxElementValue))
            {
                EditingControl.Text =
                    element.Value.ToString(CultureInfo.InvariantCulture);

                return;
            }

            EditingControl.Text =
                value.ToString(CultureInfo.InvariantCulture);

            element.Value = value;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            ResetCell(keyData);
            return base.ProcessDialogKey(keyData);
        }

        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            ResetCell(e.KeyCode);
            return base.ProcessDataGridViewKey(e);
        }
    }
}
