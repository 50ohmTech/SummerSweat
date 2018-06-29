namespace CircuitView
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
            this.CircuitsComboBox = new System.Windows.Forms.ComboBox();
            this.FrequenciesGridView = new System.Windows.Forms.DataGridView();
            this.ChangesGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ResistorRadioButton = new System.Windows.Forms.RadioButton();
            this.CapacitorRadioButton = new System.Windows.Forms.RadioButton();
            this.InductorRadioButton = new System.Windows.Forms.RadioButton();
            this.NominalTextBox = new System.Windows.Forms.NumericUpDown();
            this.NominalLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FrequenciesGridView)).BeginInit();
            this.ChangesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NominalTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CircuitsComboBox
            // 
            this.CircuitsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CircuitsComboBox.FormattingEnabled = true;
            this.CircuitsComboBox.Location = new System.Drawing.Point(13, 12);
            this.CircuitsComboBox.Name = "CircuitsComboBox";
            this.CircuitsComboBox.Size = new System.Drawing.Size(295, 24);
            this.CircuitsComboBox.TabIndex = 0;
            // 
            // FrequenciesGridView
            // 
            this.FrequenciesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrequenciesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FrequenciesGridView.Location = new System.Drawing.Point(12, 42);
            this.FrequenciesGridView.Name = "FrequenciesGridView";
            this.FrequenciesGridView.RowTemplate.Height = 24;
            this.FrequenciesGridView.Size = new System.Drawing.Size(296, 245);
            this.FrequenciesGridView.TabIndex = 1;
            // 
            // ChangesGroupBox
            // 
            this.ChangesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangesGroupBox.Controls.Add(this.NominalLabel);
            this.ChangesGroupBox.Controls.Add(this.NominalTextBox);
            this.ChangesGroupBox.Controls.Add(this.InductorRadioButton);
            this.ChangesGroupBox.Controls.Add(this.CapacitorRadioButton);
            this.ChangesGroupBox.Controls.Add(this.ResistorRadioButton);
            this.ChangesGroupBox.Location = new System.Drawing.Point(12, 293);
            this.ChangesGroupBox.Name = "ChangesGroupBox";
            this.ChangesGroupBox.Size = new System.Drawing.Size(296, 166);
            this.ChangesGroupBox.TabIndex = 2;
            this.ChangesGroupBox.TabStop = false;
            this.ChangesGroupBox.Text = "Выберите тип элемента";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(314, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(401, 476);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ResistorRadioButton
            // 
            this.ResistorRadioButton.AutoSize = true;
            this.ResistorRadioButton.Location = new System.Drawing.Point(6, 22);
            this.ResistorRadioButton.Name = "ResistorRadioButton";
            this.ResistorRadioButton.Size = new System.Drawing.Size(91, 21);
            this.ResistorRadioButton.TabIndex = 0;
            this.ResistorRadioButton.TabStop = true;
            this.ResistorRadioButton.Text = "Резистор";
            this.ResistorRadioButton.UseVisualStyleBackColor = true;
            // 
            // CapacitorRadioButton
            // 
            this.CapacitorRadioButton.AutoSize = true;
            this.CapacitorRadioButton.Location = new System.Drawing.Point(6, 49);
            this.CapacitorRadioButton.Name = "CapacitorRadioButton";
            this.CapacitorRadioButton.Size = new System.Drawing.Size(116, 21);
            this.CapacitorRadioButton.TabIndex = 1;
            this.CapacitorRadioButton.TabStop = true;
            this.CapacitorRadioButton.Text = "Конденсатор";
            this.CapacitorRadioButton.UseVisualStyleBackColor = true;
            // 
            // InductorRadioButton
            // 
            this.InductorRadioButton.AutoSize = true;
            this.InductorRadioButton.Location = new System.Drawing.Point(6, 76);
            this.InductorRadioButton.Name = "InductorRadioButton";
            this.InductorRadioButton.Size = new System.Drawing.Size(188, 21);
            this.InductorRadioButton.TabIndex = 2;
            this.InductorRadioButton.TabStop = true;
            this.InductorRadioButton.Text = "Катушка индуктивности";
            this.InductorRadioButton.UseVisualStyleBackColor = true;
            // 
            // NominalTextBox
            // 
            this.NominalTextBox.Location = new System.Drawing.Point(7, 128);
            this.NominalTextBox.Name = "NominalTextBox";
            this.NominalTextBox.Size = new System.Drawing.Size(90, 22);
            this.NominalTextBox.TabIndex = 3;
            // 
            // NominalLabel
            // 
            this.NominalLabel.AutoSize = true;
            this.NominalLabel.Location = new System.Drawing.Point(6, 100);
            this.NominalLabel.Name = "NominalLabel";
            this.NominalLabel.Size = new System.Drawing.Size(191, 17);
            this.NominalLabel.TabIndex = 4;
            this.NominalLabel.Text = "Введите номинал элемента";
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Location = new System.Drawing.Point(12, 465);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(91, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.Location = new System.Drawing.Point(205, 465);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(103, 23);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 500);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ChangesGroupBox);
            this.Controls.Add(this.FrequenciesGridView);
            this.Controls.Add(this.CircuitsComboBox);
            this.MinimumSize = new System.Drawing.Size(745, 547);
            this.Name = "CalculatorForm";
            this.Text = "Circuit Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.FrequenciesGridView)).EndInit();
            this.ChangesGroupBox.ResumeLayout(false);
            this.ChangesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NominalTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CircuitsComboBox;
        private System.Windows.Forms.DataGridView FrequenciesGridView;
        private System.Windows.Forms.GroupBox ChangesGroupBox;
        private System.Windows.Forms.Label NominalLabel;
        private System.Windows.Forms.NumericUpDown NominalTextBox;
        private System.Windows.Forms.RadioButton InductorRadioButton;
        private System.Windows.Forms.RadioButton CapacitorRadioButton;
        private System.Windows.Forms.RadioButton ResistorRadioButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}

