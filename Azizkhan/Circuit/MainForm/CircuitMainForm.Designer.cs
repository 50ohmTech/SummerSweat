namespace CircuitView
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
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.SelectingCircuitComboBox = new System.Windows.Forms.ComboBox();
            this.SelectingCircuitLabel = new System.Windows.Forms.Label();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.NodeComboBox = new System.Windows.Forms.ComboBox();
            this.Label = new System.Windows.Forms.Label();
            this.СircuitPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.СircuitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(15, 330);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(80, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(105, 330);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(80, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CalculateImpedanceButton
            // 
            this.CalculateImpedanceButton.Location = new System.Drawing.Point(15, 359);
            this.CalculateImpedanceButton.Name = "CalculateImpedanceButton";
            this.CalculateImpedanceButton.Size = new System.Drawing.Size(170, 23);
            this.CalculateImpedanceButton.TabIndex = 2;
            this.CalculateImpedanceButton.Text = "Открыть калькулятор";
            this.CalculateImpedanceButton.UseVisualStyleBackColor = true;
            this.CalculateImpedanceButton.Click += new System.EventHandler(this.CalculateImpedanceButton_Click);
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(15, 294);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(170, 20);
            this.ValueTextBox.TabIndex = 3;
            this.ValueTextBox.TextChanged += new System.EventHandler(this.ValueTextBox_TextChanged);
            this.ValueTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValueTextBox_Validating);
            // 
            // SelectingCircuitComboBox
            // 
            this.SelectingCircuitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectingCircuitComboBox.FormattingEnabled = true;
            this.SelectingCircuitComboBox.Location = new System.Drawing.Point(85, 9);
            this.SelectingCircuitComboBox.Name = "SelectingCircuitComboBox";
            this.SelectingCircuitComboBox.Size = new System.Drawing.Size(100, 21);
            this.SelectingCircuitComboBox.TabIndex = 4;
            this.SelectingCircuitComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectingCircuitComboBox_SelectedIndexChanged);
            // 
            // SelectingCircuitLabel
            // 
            this.SelectingCircuitLabel.AutoSize = true;
            this.SelectingCircuitLabel.Location = new System.Drawing.Point(12, 12);
            this.SelectingCircuitLabel.Name = "SelectingCircuitLabel";
            this.SelectingCircuitLabel.Size = new System.Drawing.Size(67, 13);
            this.SelectingCircuitLabel.TabIndex = 5;
            this.SelectingCircuitLabel.Text = "Выбор цепи";
            // 
            // TreeView
            // 
            this.TreeView.Location = new System.Drawing.Point(15, 36);
            this.TreeView.MinimumSize = new System.Drawing.Size(170, 111);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(170, 212);
            this.TreeView.TabIndex = 6;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.TreeView.DoubleClick += new System.EventHandler(this.TreeView_DoubleClick);
            // 
            // NodeComboBox
            // 
            this.NodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NodeComboBox.FormattingEnabled = true;
            this.NodeComboBox.Location = new System.Drawing.Point(15, 267);
            this.NodeComboBox.Name = "NodeComboBox";
            this.NodeComboBox.Size = new System.Drawing.Size(170, 21);
            this.NodeComboBox.TabIndex = 7;
            this.NodeComboBox.SelectedIndexChanged += new System.EventHandler(this.NodeComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(12, 251);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(103, 13);
            this.Label.TabIndex = 8;
            this.Label.Text = "Добавить элемент";
            // 
            // circuitPictureBox
            // 
            this.СircuitPictureBox.Location = new System.Drawing.Point(191, 13);
            this.СircuitPictureBox.Name = "СircuitPictureBox";
            this.СircuitPictureBox.Size = new System.Drawing.Size(695, 369);
            this.СircuitPictureBox.TabIndex = 9;
            this.СircuitPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 395);
            this.Controls.Add(this.СircuitPictureBox);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.NodeComboBox);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.SelectingCircuitLabel);
            this.Controls.Add(this.SelectingCircuitComboBox);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CalculateImpedanceButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(554, 341);
            this.Name = "MainForm";
            this.Text = "CircuitMainForm";
            ((System.ComponentModel.ISupportInitialize)(this.СircuitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CalculateImpedanceButton;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.ComboBox SelectingCircuitComboBox;
        private System.Windows.Forms.Label SelectingCircuitLabel;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.ComboBox NodeComboBox;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.PictureBox СircuitPictureBox;
    }
}

