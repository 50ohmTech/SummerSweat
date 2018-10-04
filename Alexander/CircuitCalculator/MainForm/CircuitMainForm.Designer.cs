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
            this.PaintGroupBox = new System.Windows.Forms.GroupBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CalculateImpedanceButton = new System.Windows.Forms.Button();
            this.NominalTextBox = new System.Windows.Forms.TextBox();
            this.SelectingCircuitComboBox = new System.Windows.Forms.ComboBox();
            this.SelectingCircuitLabel = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.NodeComboBox = new System.Windows.Forms.ComboBox();
            this.AddElementLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PaintGroupBox
            // 
            this.PaintGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PaintGroupBox.Location = new System.Drawing.Point(255, 15);
            this.PaintGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.PaintGroupBox.Name = "PaintGroupBox";
            this.PaintGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.PaintGroupBox.Size = new System.Drawing.Size(440, 340);
            this.PaintGroupBox.TabIndex = 0;
            this.PaintGroupBox.TabStop = false;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(20, 290);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(107, 28);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(140, 290);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(107, 28);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CalculateImpedanceButton
            // 
            this.CalculateImpedanceButton.Location = new System.Drawing.Point(20, 326);
            this.CalculateImpedanceButton.Margin = new System.Windows.Forms.Padding(4);
            this.CalculateImpedanceButton.Name = "CalculateImpedanceButton";
            this.CalculateImpedanceButton.Size = new System.Drawing.Size(227, 28);
            this.CalculateImpedanceButton.TabIndex = 2;
            this.CalculateImpedanceButton.Text = "Рассчитать импеданс";
            this.CalculateImpedanceButton.UseVisualStyleBackColor = true;
            // 
            // NominalTextBox
            // 
            this.NominalTextBox.Location = new System.Drawing.Point(20, 246);
            this.NominalTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NominalTextBox.Name = "NominalTextBox";
            this.NominalTextBox.Size = new System.Drawing.Size(225, 22);
            this.NominalTextBox.TabIndex = 3;
            // 
            // SelectingCircuitComboBox
            // 
            this.SelectingCircuitComboBox.FormattingEnabled = true;
            this.SelectingCircuitComboBox.Items.AddRange(new object[] {
            "Новая цепь",
            "Цепь №1",
            "Цепь №2",
            "Цепь №3",
            "Цепь №4",
            "Цепь №5"});
            this.SelectingCircuitComboBox.Location = new System.Drawing.Point(113, 11);
            this.SelectingCircuitComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.SelectingCircuitComboBox.Name = "SelectingCircuitComboBox";
            this.SelectingCircuitComboBox.Size = new System.Drawing.Size(132, 24);
            this.SelectingCircuitComboBox.TabIndex = 4;
            this.SelectingCircuitComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectingCircuitComboBox_SelectedIndexChanged);
            // 
            // SelectingCircuitLabel
            // 
            this.SelectingCircuitLabel.AutoSize = true;
            this.SelectingCircuitLabel.Location = new System.Drawing.Point(16, 15);
            this.SelectingCircuitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectingCircuitLabel.Name = "SelectingCircuitLabel";
            this.SelectingCircuitLabel.Size = new System.Drawing.Size(87, 17);
            this.SelectingCircuitLabel.TabIndex = 5;
            this.SelectingCircuitLabel.Text = "Выбор цепи";
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(20, 44);
            this.treeView.Margin = new System.Windows.Forms.Padding(4);
            this.treeView.MinimumSize = new System.Drawing.Size(225, 136);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(225, 136);
            this.treeView.TabIndex = 6;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // NodeComboBox
            // 
            this.NodeComboBox.FormattingEnabled = true;
            this.NodeComboBox.Items.AddRange(new object[] {
            "Параллельно",
            "Последовательно",
            "R",
            "L",
            "C"});
            this.NodeComboBox.Location = new System.Drawing.Point(20, 213);
            this.NodeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.NodeComboBox.Name = "NodeComboBox";
            this.NodeComboBox.Size = new System.Drawing.Size(225, 24);
            this.NodeComboBox.TabIndex = 7;
            // 
            // AddElementLabel
            // 
            this.AddElementLabel.AutoSize = true;
            this.AddElementLabel.Location = new System.Drawing.Point(16, 193);
            this.AddElementLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddElementLabel.Name = "AddElementLabel";
            this.AddElementLabel.Size = new System.Drawing.Size(131, 17);
            this.AddElementLabel.TabIndex = 8;
            this.AddElementLabel.Text = "Добавить элемент";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 372);
            this.Controls.Add(this.AddElementLabel);
            this.Controls.Add(this.NodeComboBox);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.SelectingCircuitLabel);
            this.Controls.Add(this.SelectingCircuitComboBox);
            this.Controls.Add(this.NominalTextBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CalculateImpedanceButton);
            this.Controls.Add(this.PaintGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(733, 409);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CircuitMainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PaintGroupBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CalculateImpedanceButton;
        private System.Windows.Forms.TextBox NominalTextBox;
        private System.Windows.Forms.ComboBox SelectingCircuitComboBox;
        private System.Windows.Forms.Label SelectingCircuitLabel;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ComboBox NodeComboBox;
        private System.Windows.Forms.Label AddElementLabel;
    }
}

