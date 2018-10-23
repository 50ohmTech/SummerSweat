namespace MainForm
{
    partial class MainForm
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
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CalculateImpedanceButton = new System.Windows.Forms.Button();
            this.NominalTextBox = new System.Windows.Forms.TextBox();
            this.SelectingCircuitComboBox = new System.Windows.Forms.ComboBox();
            this.NodeComboBox = new System.Windows.Forms.ComboBox();
            this.AddElementLable = new System.Windows.Forms.Label();
            this.ConnectionComboBox = new System.Windows.Forms.ComboBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(15, 258);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(80, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(105, 258);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(80, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // CalculateImpedanceButton
            // 
            this.CalculateImpedanceButton.Location = new System.Drawing.Point(15, 287);
            this.CalculateImpedanceButton.Name = "CalculateImpedanceButton";
            this.CalculateImpedanceButton.Size = new System.Drawing.Size(170, 23);
            this.CalculateImpedanceButton.TabIndex = 2;
            this.CalculateImpedanceButton.Text = "Рассчитать импеданс";
            this.CalculateImpedanceButton.UseVisualStyleBackColor = true;
            this.CalculateImpedanceButton.Click += new System.EventHandler(this.CalculateImpedanceButton_Click);
            // 
            // NominalTextBox
            // 
            this.NominalTextBox.Location = new System.Drawing.Point(15, 200);
            this.NominalTextBox.Name = "NominalTextBox";
            this.NominalTextBox.Size = new System.Drawing.Size(170, 20);
            this.NominalTextBox.TabIndex = 3;
            this.NominalTextBox.Text = "Введите номинал";
            // 
            // SelectingCircuitComboBox
            // 
            this.SelectingCircuitComboBox.FormattingEnabled = true;
            this.SelectingCircuitComboBox.Location = new System.Drawing.Point(15, 9);
            this.SelectingCircuitComboBox.Name = "SelectingCircuitComboBox";
            this.SelectingCircuitComboBox.Size = new System.Drawing.Size(170, 21);
            this.SelectingCircuitComboBox.TabIndex = 4;
            this.SelectingCircuitComboBox.Text = "Выберите цепь";
            this.SelectingCircuitComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectingCircuitComboBox_SelectedIndexChanged);
            // 
            // NodeComboBox
            // 
            this.NodeComboBox.FormattingEnabled = true;
            this.NodeComboBox.Items.AddRange(new object[] {
            "Резистор",
            "Катушка",
            "Конденсатор"});
            this.NodeComboBox.Location = new System.Drawing.Point(15, 173);
            this.NodeComboBox.Name = "NodeComboBox";
            this.NodeComboBox.Size = new System.Drawing.Size(170, 21);
            this.NodeComboBox.TabIndex = 7;
            this.NodeComboBox.Text = "Выберите тип элемента";
            // 
            // AddElementLable
            // 
            this.AddElementLable.AutoSize = true;
            this.AddElementLable.Location = new System.Drawing.Point(12, 157);
            this.AddElementLable.Name = "AddElementLable";
            this.AddElementLable.Size = new System.Drawing.Size(103, 13);
            this.AddElementLable.TabIndex = 8;
            this.AddElementLable.Text = "Добавить элемент";
            // 
            // ConnectionComboBox
            // 
            this.ConnectionComboBox.FormattingEnabled = true;
            this.ConnectionComboBox.Items.AddRange(new object[] {
            "Последовательно",
            "Параллельно"});
            this.ConnectionComboBox.Location = new System.Drawing.Point(15, 226);
            this.ConnectionComboBox.Name = "ConnectionComboBox";
            this.ConnectionComboBox.Size = new System.Drawing.Size(170, 21);
            this.ConnectionComboBox.TabIndex = 9;
            this.ConnectionComboBox.Text = "Выберите тип связи";
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(15, 36);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(170, 118);
            this.treeView.TabIndex = 11;
            // 
            // CircuitPictureBox
            // 
            this.CircuitPictureBox.Location = new System.Drawing.Point(193, 12);
            this.CircuitPictureBox.Name = "CircuitPictureBox";
            this.CircuitPictureBox.Size = new System.Drawing.Size(333, 297);
            this.CircuitPictureBox.TabIndex = 12;
            this.CircuitPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 324);
            this.Controls.Add(this.CircuitPictureBox);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.ConnectionComboBox);
            this.Controls.Add(this.AddElementLable);
            this.Controls.Add(this.NodeComboBox);
            this.Controls.Add(this.SelectingCircuitComboBox);
            this.Controls.Add(this.NominalTextBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CalculateImpedanceButton);
            this.MaximumSize = new System.Drawing.Size(554, 363);
            this.MinimumSize = new System.Drawing.Size(554, 363);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CircuitMainForm";
            ((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CalculateImpedanceButton;
        private System.Windows.Forms.TextBox NominalTextBox;
        private System.Windows.Forms.ComboBox SelectingCircuitComboBox;
        private System.Windows.Forms.ComboBox NodeComboBox;
        private System.Windows.Forms.Label AddElementLable;
        private System.Windows.Forms.ComboBox ConnectionComboBox;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.PictureBox CircuitPictureBox;
    }
}

