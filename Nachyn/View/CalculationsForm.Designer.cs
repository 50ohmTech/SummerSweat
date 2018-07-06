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
            this._calculationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._buttonCalculate = new System.Windows.Forms.Button();
            this._buttonDeleteCurrent = new System.Windows.Forms.Button();
            this.frequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impedanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.frequencyDataGridViewTextBoxColumn,
            this.impedanceDataGridViewTextBoxColumn});
            this._dataGridViewCalculations.DataSource = this._calculationsBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chartreuse;
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
            // 
            // _calculationsBindingSource
            // 
            this._calculationsBindingSource.DataSource = typeof(Model.Calculations.Calculations);
            // 
            // _buttonCalculate
            // 
            this._buttonCalculate.Location = new System.Drawing.Point(123, 243);
            this._buttonCalculate.Name = "_buttonCalculate";
            this._buttonCalculate.Size = new System.Drawing.Size(111, 23);
            this._buttonCalculate.TabIndex = 2;
            this._buttonCalculate.Text = "Расчитать";
            this._buttonCalculate.UseVisualStyleBackColor = true;
            this._buttonCalculate.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // _buttonDeleteCurrent
            // 
            this._buttonDeleteCurrent.Location = new System.Drawing.Point(12, 243);
            this._buttonDeleteCurrent.Name = "_buttonDeleteCurrent";
            this._buttonDeleteCurrent.Size = new System.Drawing.Size(105, 23);
            this._buttonDeleteCurrent.TabIndex = 3;
            this._buttonDeleteCurrent.Text = "Удалить";
            this._buttonDeleteCurrent.UseVisualStyleBackColor = true;
            this._buttonDeleteCurrent.Click += new System.EventHandler(this.ButtonDeleteCurrent_Click);
            // 
            // frequencyDataGridViewTextBoxColumn
            // 
            this.frequencyDataGridViewTextBoxColumn.DataPropertyName = "Frequency";
            this.frequencyDataGridViewTextBoxColumn.HeaderText = "Частота";
            this.frequencyDataGridViewTextBoxColumn.Name = "frequencyDataGridViewTextBoxColumn";
            this.frequencyDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // impedanceDataGridViewTextBoxColumn
            // 
            this.impedanceDataGridViewTextBoxColumn.DataPropertyName = "Impedance";
            this.impedanceDataGridViewTextBoxColumn.HeaderText = "Импеданс";
            this.impedanceDataGridViewTextBoxColumn.Name = "impedanceDataGridViewTextBoxColumn";
            this.impedanceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.impedanceDataGridViewTextBoxColumn.Width = 120;
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
        private System.Windows.Forms.DataGridView _dataGridViewCalculations;
        private System.Windows.Forms.BindingSource _calculationsBindingSource;
        private System.Windows.Forms.Button _buttonCalculate;
        private System.Windows.Forms.Button _buttonDeleteCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impedanceDataGridViewTextBoxColumn;
    }
}