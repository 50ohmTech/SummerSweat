namespace MainForm
{
    partial class ImpedanceCalculator
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
            this.calculatorDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startValueTextBox = new System.Windows.Forms.TextBox();
            this.endValueTextBox = new System.Windows.Forms.TextBox();
            this.stepValueTextBox = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impedance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.calculatorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // calculatorDataGridView
            // 
            this.calculatorDataGridView.AllowUserToAddRows = false;
            this.calculatorDataGridView.AllowUserToDeleteRows = false;
            this.calculatorDataGridView.AllowUserToResizeColumns = false;
            this.calculatorDataGridView.AllowUserToResizeRows = false;
            this.calculatorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.calculatorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frequency,
            this.Impedance});
            this.calculatorDataGridView.Location = new System.Drawing.Point(10, 94);
            this.calculatorDataGridView.Name = "calculatorDataGridView";
            this.calculatorDataGridView.RowHeadersVisible = false;
            this.calculatorDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.calculatorDataGridView.Size = new System.Drawing.Size(195, 150);
            this.calculatorDataGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Начало";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Конец";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Шаг";
            // 
            // startValueTextBox
            // 
            this.startValueTextBox.Location = new System.Drawing.Point(93, 13);
            this.startValueTextBox.Name = "startValueTextBox";
            this.startValueTextBox.Size = new System.Drawing.Size(112, 20);
            this.startValueTextBox.TabIndex = 4;
            this.startValueTextBox.Text = "0";
            this.startValueTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.startValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this.startValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // endValueTextBox
            // 
            this.endValueTextBox.Location = new System.Drawing.Point(93, 40);
            this.endValueTextBox.Name = "endValueTextBox";
            this.endValueTextBox.Size = new System.Drawing.Size(112, 20);
            this.endValueTextBox.TabIndex = 5;
            this.endValueTextBox.Text = "0";
            this.endValueTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.endValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this.endValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // stepValueTextBox
            // 
            this.stepValueTextBox.Location = new System.Drawing.Point(93, 68);
            this.stepValueTextBox.Name = "stepValueTextBox";
            this.stepValueTextBox.Size = new System.Drawing.Size(112, 20);
            this.stepValueTextBox.TabIndex = 6;
            this.stepValueTextBox.Text = "0";
            this.stepValueTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.stepValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntTextBox_KeyPress);
            this.stepValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(10, 250);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(195, 23);
            this.calculateButton.TabIndex = 7;
            this.calculateButton.Text = "Расчитать";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
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
            // 
            // ImpedanceCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 280);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.stepValueTextBox);
            this.Controls.Add(this.endValueTextBox);
            this.Controls.Add(this.startValueTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calculatorDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImpedanceCalculator";
            this.Text = "Impedance calculator";
            ((System.ComponentModel.ISupportInitialize)(this.calculatorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView calculatorDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox startValueTextBox;
        private System.Windows.Forms.TextBox endValueTextBox;
        private System.Windows.Forms.TextBox stepValueTextBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impedance;
    }
}

