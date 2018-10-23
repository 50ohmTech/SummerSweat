namespace MainForm
{
    partial class ImpedanceCalculatorForm
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
            this._calculatorDataGridView = new System.Windows.Forms.DataGridView();
            this._startValueLabel = new System.Windows.Forms.Label();
            this._endValueLabel = new System.Windows.Forms.Label();
            this._stepValueLabel = new System.Windows.Forms.Label();
            this._startValueTextBox = new System.Windows.Forms.TextBox();
            this._endValueTextBox = new System.Windows.Forms.TextBox();
            this._stepValueTextBox = new System.Windows.Forms.TextBox();
            this._calculateButton = new System.Windows.Forms.Button();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impedance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._calculatorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _calculatorDataGridView
            // 
            this._calculatorDataGridView.AllowUserToAddRows = false;
            this._calculatorDataGridView.AllowUserToDeleteRows = false;
            this._calculatorDataGridView.AllowUserToResizeColumns = false;
            this._calculatorDataGridView.AllowUserToResizeRows = false;
            this._calculatorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._calculatorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frequency,
            this.Impedance});
            this._calculatorDataGridView.Location = new System.Drawing.Point(10, 94);
            this._calculatorDataGridView.Name = "_calculatorDataGridView";
            this._calculatorDataGridView.RowHeadersVisible = false;
            this._calculatorDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._calculatorDataGridView.Size = new System.Drawing.Size(225, 150);
            this._calculatorDataGridView.TabIndex = 0;
            // 
            // _startValueLabel
            // 
            this._startValueLabel.AutoSize = true;
            this._startValueLabel.Location = new System.Drawing.Point(13, 13);
            this._startValueLabel.Name = "_startValueLabel";
            this._startValueLabel.Size = new System.Drawing.Size(44, 13);
            this._startValueLabel.TabIndex = 1;
            this._startValueLabel.Text = "Начало";
            // 
            // _endValueLabel
            // 
            this._endValueLabel.AutoSize = true;
            this._endValueLabel.Location = new System.Drawing.Point(12, 40);
            this._endValueLabel.Name = "_endValueLabel";
            this._endValueLabel.Size = new System.Drawing.Size(38, 13);
            this._endValueLabel.TabIndex = 2;
            this._endValueLabel.Text = "Конец";
            // 
            // _stepValueLabel
            // 
            this._stepValueLabel.AutoSize = true;
            this._stepValueLabel.Location = new System.Drawing.Point(12, 68);
            this._stepValueLabel.Name = "_stepValueLabel";
            this._stepValueLabel.Size = new System.Drawing.Size(27, 13);
            this._stepValueLabel.TabIndex = 3;
            this._stepValueLabel.Text = "Шаг";
            // 
            // _startValueTextBox
            // 
            this._startValueTextBox.Location = new System.Drawing.Point(93, 13);
            this._startValueTextBox.Name = "_startValueTextBox";
            this._startValueTextBox.Size = new System.Drawing.Size(112, 20);
            this._startValueTextBox.TabIndex = 4;
            this._startValueTextBox.Text = "0";
            this._startValueTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this._startValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this._startValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // _endValueTextBox
            // 
            this._endValueTextBox.Location = new System.Drawing.Point(93, 40);
            this._endValueTextBox.Name = "_endValueTextBox";
            this._endValueTextBox.Size = new System.Drawing.Size(112, 20);
            this._endValueTextBox.TabIndex = 5;
            this._endValueTextBox.Text = "0";
            this._endValueTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this._endValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntTextBox_KeyPress);
            this._endValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // _stepValueTextBox
            // 
            this._stepValueTextBox.Location = new System.Drawing.Point(93, 68);
            this._stepValueTextBox.Name = "_stepValueTextBox";
            this._stepValueTextBox.Size = new System.Drawing.Size(112, 20);
            this._stepValueTextBox.TabIndex = 6;
            this._stepValueTextBox.Text = "0";
            this._stepValueTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this._stepValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this._stepValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // _calculateButton
            // 
            this._calculateButton.Location = new System.Drawing.Point(10, 250);
            this._calculateButton.Name = "_calculateButton";
            this._calculateButton.Size = new System.Drawing.Size(195, 23);
            this._calculateButton.TabIndex = 7;
            this._calculateButton.Text = "Расчитать";
            this._calculateButton.UseVisualStyleBackColor = true;
            this._calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // Frequency
            // 
            this.Frequency.Frozen = true;
            this.Frequency.HeaderText = "Частота";
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            // 
            // Impedance
            // 
            this.Impedance.Frozen = true;
            this.Impedance.HeaderText = "Импеданс";
            this.Impedance.Name = "Impedance";
            this.Impedance.ReadOnly = true;
            this.Impedance.Width = 150;
            // 
            // ImpedanceCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 280);
            this.Controls.Add(this._calculateButton);
            this.Controls.Add(this._stepValueTextBox);
            this.Controls.Add(this._endValueTextBox);
            this.Controls.Add(this._startValueTextBox);
            this.Controls.Add(this._stepValueLabel);
            this.Controls.Add(this._endValueLabel);
            this.Controls.Add(this._startValueLabel);
            this.Controls.Add(this._calculatorDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImpedanceCalculatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impedance calculator";
            ((System.ComponentModel.ISupportInitialize)(this._calculatorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _calculatorDataGridView;
        private System.Windows.Forms.Label _startValueLabel;
        private System.Windows.Forms.Label _endValueLabel;
        private System.Windows.Forms.Label _stepValueLabel;
        private System.Windows.Forms.TextBox _startValueTextBox;
        private System.Windows.Forms.TextBox _endValueTextBox;
        private System.Windows.Forms.TextBox _stepValueTextBox;
        private System.Windows.Forms.Button _calculateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impedance;
    }
}

