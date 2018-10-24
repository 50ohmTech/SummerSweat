namespace MainForm
{
    partial class CircuitMainForm
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
            this.SelectingCircuitComboBox = new System.Windows.Forms.ComboBox();
            this.SelectingCircuitLabel = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.NodeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ValueTextBox = new System.Windows.Forms.NumericUpDown();
            this.EditFormButton = new System.Windows.Forms.Button();
            this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ValueTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(20, 273);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(109, 28);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(137, 273);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(108, 28);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CalculateImpedanceButton
            // 
            this.CalculateImpedanceButton.Location = new System.Drawing.Point(20, 343);
            this.CalculateImpedanceButton.Margin = new System.Windows.Forms.Padding(4);
            this.CalculateImpedanceButton.Name = "CalculateImpedanceButton";
            this.CalculateImpedanceButton.Size = new System.Drawing.Size(225, 28);
            this.CalculateImpedanceButton.TabIndex = 2;
            this.CalculateImpedanceButton.Text = "Рассчитать импеданс";
            this.CalculateImpedanceButton.UseVisualStyleBackColor = true;
            this.CalculateImpedanceButton.Click += new System.EventHandler(this.CalculateImpedanceButton_Click);
            // 
            // SelectingCircuitComboBox
            // 
            this.SelectingCircuitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectingCircuitComboBox.FormattingEnabled = true;
            this.SelectingCircuitComboBox.Items.AddRange(new object[] {
            "Моя цепь",
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
            this.NodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NodeComboBox.FormattingEnabled = true;
            this.NodeComboBox.Items.AddRange(new object[] {
            "Последовательное",
            "Параллельное",
            "R",
            "C",
            "I"});
            this.NodeComboBox.Location = new System.Drawing.Point(20, 213);
            this.NodeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.NodeComboBox.Name = "NodeComboBox";
            this.NodeComboBox.Size = new System.Drawing.Size(225, 24);
            this.NodeComboBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 193);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Добавить элемент";
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(19, 244);
            this.ValueTextBox.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(226, 22);
            this.ValueTextBox.TabIndex = 9;
            this.ValueTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // EditFormButton
            // 
            this.EditFormButton.Location = new System.Drawing.Point(20, 308);
            this.EditFormButton.Name = "EditFormButton";
            this.EditFormButton.Size = new System.Drawing.Size(225, 28);
            this.EditFormButton.TabIndex = 10;
            this.EditFormButton.Text = "Изменить номинал элемента";
            this.EditFormButton.UseVisualStyleBackColor = true;
            this.EditFormButton.Click += new System.EventHandler(this.EditFormButton_Click);
            // 
            // CircuitPictureBox
            // 
            this.CircuitPictureBox.Location = new System.Drawing.Point(252, 11);
            this.CircuitPictureBox.Name = "CircuitPictureBox";
            this.CircuitPictureBox.Size = new System.Drawing.Size(453, 361);
            this.CircuitPictureBox.TabIndex = 11;
            this.CircuitPictureBox.TabStop = false;
            // 
            // CircuitMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 384);
            this.Controls.Add(this.CircuitPictureBox);
            this.Controls.Add(this.EditFormButton);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NodeComboBox);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.SelectingCircuitLabel);
            this.Controls.Add(this.SelectingCircuitComboBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CalculateImpedanceButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(733, 409);
            this.Name = "CircuitMainForm";
            this.Text = "CircuitMainForm";
            ((System.ComponentModel.ISupportInitialize)(this.ValueTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CalculateImpedanceButton;
        private System.Windows.Forms.ComboBox SelectingCircuitComboBox;
        private System.Windows.Forms.Label SelectingCircuitLabel;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ComboBox NodeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ValueTextBox;
        private System.Windows.Forms.Button EditFormButton;
        private System.Windows.Forms.PictureBox CircuitPictureBox;
    }
}

