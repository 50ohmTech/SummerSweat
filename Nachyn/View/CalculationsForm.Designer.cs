namespace View
{
    partial class CalculationsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dataGridViewCalculations = new System.Windows.Forms.DataGridView();
            this._buttonCalculate = new System.Windows.Forms.Button();
            this._buttonDeleteCurrent = new System.Windows.Forms.Button();
            this._frequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._impedanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._calculationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCalculations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._calculationsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridViewCalculations
            // 
            this._dataGridViewCalculations.AllowUserToDeleteRows = false;
            this._dataGridViewCalculations.AllowUserToResizeColumns = false;
            this._dataGridViewCalculations.AllowUserToResizeRows = false;
            this._dataGridViewCalculations.AutoGenerateColumns = false;
            this._dataGridViewCalculations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._dataGridViewCalculations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._frequencyDataGridViewTextBoxColumn,
            this._impedanceDataGridViewTextBoxColumn});
            this._dataGridViewCalculations.DataSource = this._calculationsBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewCalculations.DefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridViewCalculations.Location = new System.Drawing.Point(12, 12);
            this._dataGridViewCalculations.MultiSelect = false;
            this._dataGridViewCalculations.Name = "_dataGridViewCalculations";
            this._dataGridViewCalculations.RowHeadersVisible = false;
            this._dataGridViewCalculations.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this._dataGridViewCalculations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._dataGridViewCalculations.Size = new System.Drawing.Size(222, 225);
            this._dataGridViewCalculations.TabIndex = 1;
            this._dataGridViewCalculations.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridViewCalculations_DataError);
            // 
            // _buttonCalculate
            // 
            this._buttonCalculate.Location = new System.Drawing.Point(12, 243);
            this._buttonCalculate.Name = "_buttonCalculate";
            this._buttonCalculate.Size = new System.Drawing.Size(111, 23);
            this._buttonCalculate.TabIndex = 2;
            this._buttonCalculate.Text = "Расчитать";
            this._buttonCalculate.UseVisualStyleBackColor = true;
            this._buttonCalculate.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // _buttonDeleteCurrent
            // 
            this._buttonDeleteCurrent.Location = new System.Drawing.Point(129, 243);
            this._buttonDeleteCurrent.Name = "_buttonDeleteCurrent";
            this._buttonDeleteCurrent.Size = new System.Drawing.Size(105, 23);
            this._buttonDeleteCurrent.TabIndex = 3;
            this._buttonDeleteCurrent.Text = "Удалить";
            this._buttonDeleteCurrent.UseVisualStyleBackColor = true;
            this._buttonDeleteCurrent.Click += new System.EventHandler(this.ButtonDeleteCurrent_Click);
            // 
            // _frequencyDataGridViewTextBoxColumn
            // 
            this._frequencyDataGridViewTextBoxColumn.DataPropertyName = "Frequency";
            this._frequencyDataGridViewTextBoxColumn.HeaderText = "Частота";
            this._frequencyDataGridViewTextBoxColumn.MaxInputLength = 13;
            this._frequencyDataGridViewTextBoxColumn.Name = "_frequencyDataGridViewTextBoxColumn";
            this._frequencyDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._frequencyDataGridViewTextBoxColumn.Width = 80;
            // 
            // _impedanceDataGridViewTextBoxColumn
            // 
            this._impedanceDataGridViewTextBoxColumn.DataPropertyName = "Impedance";
            this._impedanceDataGridViewTextBoxColumn.HeaderText = "Импеданс";
            this._impedanceDataGridViewTextBoxColumn.MaxInputLength = 13;
            this._impedanceDataGridViewTextBoxColumn.Name = "_impedanceDataGridViewTextBoxColumn";
            this._impedanceDataGridViewTextBoxColumn.ReadOnly = true;
            this._impedanceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._impedanceDataGridViewTextBoxColumn.Width = 140;
            // 
            // _calculationsBindingSource
            // 
            this._calculationsBindingSource.DataSource = typeof(Model.Calculations.Calculations);
            // 
            // CalculationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 276);
            this.Controls.Add(this._buttonDeleteCurrent);
            this.Controls.Add(this._buttonCalculate);
            this.Controls.Add(this._dataGridViewCalculations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CalculationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчеты";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCalculations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._calculationsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        /// <summary>
        ///     Визуальный элемент управления расчетов.
        /// </summary>
        private System.Windows.Forms.DataGridView _dataGridViewCalculations;

        /// <summary>
        ///     Источник данных расчетов.
        /// </summary>
        private System.Windows.Forms.BindingSource _calculationsBindingSource;

        /// <summary>
        ///     Кнопка Расчитать
        /// </summary>
        private System.Windows.Forms.Button _buttonCalculate;

        /// <summary>
        ///     Кнопка удалить текущий расчет
        /// </summary>
        private System.Windows.Forms.Button _buttonDeleteCurrent;

        /// <summary>
        ///     Ячейка частоты в визуальном элементе
        ///     управления расчетов.
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn _frequencyDataGridViewTextBoxColumn;

        /// <summary>
        ///     Ячейка импеданса в визуальном элементе
        ///     управления расчетов.
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn _impedanceDataGridViewTextBoxColumn;
    }
}