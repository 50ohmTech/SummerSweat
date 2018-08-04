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
			this.isRedactorVisibleButton = new System.Windows.Forms.Button();
			this.resetButton = new System.Windows.Forms.Button();
			this.calculateButton = new System.Windows.Forms.Button();
			this.frequenciesGridView = new System.Windows.Forms.DataGridView();
			this.Frequencies = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Impedances = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.instrumentsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.frequenciesGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// instrumentsGroupBox
			// 
			this.instrumentsGroupBox.Controls.Add(this.isRedactorVisibleButton);
			this.instrumentsGroupBox.Controls.Add(this.resetButton);
			this.instrumentsGroupBox.Controls.Add(this.calculateButton);
			this.instrumentsGroupBox.Controls.Add(this.frequenciesGridView);
			this.instrumentsGroupBox.Location = new System.Drawing.Point(12, 12);
			this.instrumentsGroupBox.Name = "instrumentsGroupBox";
			this.instrumentsGroupBox.Size = new System.Drawing.Size(431, 283);
			this.instrumentsGroupBox.TabIndex = 3;
			this.instrumentsGroupBox.TabStop = false;
			this.instrumentsGroupBox.Text = "Инструменты";
			// 
			// isRedactorVisibleButton
			// 
			this.isRedactorVisibleButton.Location = new System.Drawing.Point(264, 250);
			this.isRedactorVisibleButton.Name = "isRedactorVisibleButton";
			this.isRedactorVisibleButton.Size = new System.Drawing.Size(160, 29);
			this.isRedactorVisibleButton.TabIndex = 10;
			this.isRedactorVisibleButton.Text = "Показать редактор цепи";
			this.isRedactorVisibleButton.UseVisualStyleBackColor = true;
			this.isRedactorVisibleButton.Click += new System.EventHandler(this.IsRedactorVisible_Click);
			// 
			// resetButton
			// 
			this.resetButton.Location = new System.Drawing.Point(121, 250);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(75, 29);
			this.resetButton.TabIndex = 9;
			this.resetButton.Text = "Сброс";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// calculateButton
			// 
			this.calculateButton.Location = new System.Drawing.Point(6, 250);
			this.calculateButton.Name = "calculateButton";
			this.calculateButton.Size = new System.Drawing.Size(109, 29);
			this.calculateButton.TabIndex = 8;
			this.calculateButton.Text = "Расчитать";
			this.calculateButton.UseVisualStyleBackColor = true;
			this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
			// 
			// frequenciesGridView
			// 
			this.frequenciesGridView.AllowUserToResizeColumns = false;
			this.frequenciesGridView.AllowUserToResizeRows = false;
			this.frequenciesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.frequenciesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frequencies,
            this.Impedances});
			this.frequenciesGridView.Location = new System.Drawing.Point(6, 21);
			this.frequenciesGridView.Name = "frequenciesGridView";
			this.frequenciesGridView.RowHeadersVisible = false;
			this.frequenciesGridView.RowTemplate.Height = 24;
			this.frequenciesGridView.Size = new System.Drawing.Size(419, 223);
			this.frequenciesGridView.TabIndex = 5;
			this.frequenciesGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.FrequenciesGridView_CellValidating);
			// 
			// Frequencies
			// 
			this.Frequencies.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Frequencies.HeaderText = "Частоты";
			this.Frequencies.Name = "Frequencies";
			this.Frequencies.Width = 155;
			// 
			// Impedances
			// 
			this.Impedances.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Impedances.HeaderText = "Импедансы";
			this.Impedances.Name = "Impedances";
			this.Impedances.ReadOnly = true;
			this.Impedances.Width = 155;
			// 
			// CalculatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(457, 303);
			this.Controls.Add(this.instrumentsGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "CalculatorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Калькулятор";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CalculatorForm_FormClosed);
			this.instrumentsGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.frequenciesGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox instrumentsGroupBox;
		private System.Windows.Forms.DataGridView frequenciesGridView;
		private System.Windows.Forms.Button calculateButton;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.Button isRedactorVisibleButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn Frequencies;
		private System.Windows.Forms.DataGridViewTextBoxColumn Impedances;
	}
}

