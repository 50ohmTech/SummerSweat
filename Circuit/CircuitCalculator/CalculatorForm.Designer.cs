namespace CircuitCalculator
{
	partial class CalculatorForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.instrumentsGroupBox = new System.Windows.Forms.GroupBox();
			this.resetButton = new System.Windows.Forms.Button();
			this.calculateButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.circuitListComboBox = new System.Windows.Forms.ComboBox();
			this.FrequenciesGridView = new System.Windows.Forms.DataGridView();
			this.Frequencies = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Impedances = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.instrumentsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FrequenciesGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// instrumentsGroupBox
			// 
			this.instrumentsGroupBox.Controls.Add(this.resetButton);
			this.instrumentsGroupBox.Controls.Add(this.calculateButton);
			this.instrumentsGroupBox.Controls.Add(this.label1);
			this.instrumentsGroupBox.Controls.Add(this.circuitListComboBox);
			this.instrumentsGroupBox.Controls.Add(this.FrequenciesGridView);
			this.instrumentsGroupBox.Location = new System.Drawing.Point(12, 12);
			this.instrumentsGroupBox.Name = "instrumentsGroupBox";
			this.instrumentsGroupBox.Size = new System.Drawing.Size(431, 283);
			this.instrumentsGroupBox.TabIndex = 3;
			this.instrumentsGroupBox.TabStop = false;
			this.instrumentsGroupBox.Text = "Инструменты";
			// 
			// resetButton
			// 
			this.resetButton.Location = new System.Drawing.Point(121, 250);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(75, 25);
			this.resetButton.TabIndex = 9;
			this.resetButton.Text = "Сброс";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
			// 
			// calculateButton
			// 
			this.calculateButton.Location = new System.Drawing.Point(6, 250);
			this.calculateButton.Name = "calculateButton";
			this.calculateButton.Size = new System.Drawing.Size(109, 27);
			this.calculateButton.TabIndex = 8;
			this.calculateButton.Text = "Расчитать";
			this.calculateButton.UseVisualStyleBackColor = true;
			this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "Выберите цепь";
			// 
			// circuitListComboBox
			// 
			this.circuitListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.circuitListComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.circuitListComboBox.FormattingEnabled = true;
			this.circuitListComboBox.Location = new System.Drawing.Point(121, 21);
			this.circuitListComboBox.Name = "circuitListComboBox";
			this.circuitListComboBox.Size = new System.Drawing.Size(176, 24);
			this.circuitListComboBox.TabIndex = 6;
			this.circuitListComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// FrequenciesGridView
			// 
			this.FrequenciesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.FrequenciesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frequencies,
            this.Impedances});
			this.FrequenciesGridView.Location = new System.Drawing.Point(6, 51);
			this.FrequenciesGridView.Name = "FrequenciesGridView";
			this.FrequenciesGridView.RowTemplate.Height = 24;
			this.FrequenciesGridView.Size = new System.Drawing.Size(419, 193);
			this.FrequenciesGridView.TabIndex = 5;
			this.FrequenciesGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.FrequenciesGridView_CellValidating);
			// 
			// Frequencies
			// 
			this.Frequencies.HeaderText = "Частоты";
			this.Frequencies.Name = "Frequencies";
			this.Frequencies.Width = 160;
			// 
			// Impedances
			// 
			this.Impedances.HeaderText = "Импедансы";
			this.Impedances.Name = "Impedances";
			this.Impedances.ReadOnly = true;
			this.Impedances.Width = 215;
			// 
			// CalculatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(457, 303);
			this.Controls.Add(this.instrumentsGroupBox);
			this.Name = "CalculatorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Калькулятор";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CalculatorForm_FormClosed);
			this.instrumentsGroupBox.ResumeLayout(false);
			this.instrumentsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.FrequenciesGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox instrumentsGroupBox;
		private System.Windows.Forms.DataGridView FrequenciesGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn Frequencies;
		private System.Windows.Forms.DataGridViewTextBoxColumn Impedances;
		private System.Windows.Forms.ComboBox circuitListComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button calculateButton;
		private System.Windows.Forms.Button resetButton;
	}
}

