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
			this.SelectingCircuitLabel = new System.Windows.Forms.Label();
			this.treeView = new System.Windows.Forms.TreeView();
			this.NadeComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.CircuitDraw = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(12, 537);
			this.AddButton.Margin = new System.Windows.Forms.Padding(4);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(112, 28);
			this.AddButton.TabIndex = 0;
			this.AddButton.Text = "Добавить";
			this.AddButton.UseVisualStyleBackColor = true;
			// 
			// DeleteButton
			// 
			this.DeleteButton.Location = new System.Drawing.Point(173, 537);
			this.DeleteButton.Margin = new System.Windows.Forms.Padding(4);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(112, 28);
			this.DeleteButton.TabIndex = 1;
			this.DeleteButton.Text = "Удалить";
			this.DeleteButton.UseVisualStyleBackColor = true;
			// 
			// CalculateImpedanceButton
			// 
			this.CalculateImpedanceButton.Location = new System.Drawing.Point(40, 573);
			this.CalculateImpedanceButton.Margin = new System.Windows.Forms.Padding(4);
			this.CalculateImpedanceButton.Name = "CalculateImpedanceButton";
			this.CalculateImpedanceButton.Size = new System.Drawing.Size(227, 28);
			this.CalculateImpedanceButton.TabIndex = 2;
			this.CalculateImpedanceButton.Text = "Рассчитать импеданс";
			this.CalculateImpedanceButton.UseVisualStyleBackColor = true;
			this.CalculateImpedanceButton.Click += new System.EventHandler(this.CalculateImpedanceButton_Click);
			// 
			// NominalTextBox
			// 
			this.NominalTextBox.Location = new System.Drawing.Point(13, 493);
			this.NominalTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.NominalTextBox.Name = "NominalTextBox";
			this.NominalTextBox.Size = new System.Drawing.Size(272, 22);
			this.NominalTextBox.TabIndex = 3;
			// 
			// SelectingCircuitComboBox
			// 
			this.SelectingCircuitComboBox.FormattingEnabled = true;
			this.SelectingCircuitComboBox.Location = new System.Drawing.Point(113, 11);
			this.SelectingCircuitComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.SelectingCircuitComboBox.Name = "SelectingCircuitComboBox";
			this.SelectingCircuitComboBox.Size = new System.Drawing.Size(172, 24);
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
			this.treeView.Size = new System.Drawing.Size(265, 392);
			this.treeView.TabIndex = 6;
			// 
			// NadeComboBox
			// 
			this.NadeComboBox.FormattingEnabled = true;
			this.NadeComboBox.Location = new System.Drawing.Point(13, 460);
			this.NadeComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.NadeComboBox.Name = "NadeComboBox";
			this.NadeComboBox.Size = new System.Drawing.Size(272, 24);
			this.NadeComboBox.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 440);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(131, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "Добавить элемент";
			// 
			// CircuitDraw
			// 
			this.CircuitDraw.AutoScroll = true;
			this.CircuitDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.CircuitDraw.Location = new System.Drawing.Point(292, 12);
			this.CircuitDraw.Name = "CircuitDraw";
			this.CircuitDraw.Size = new System.Drawing.Size(804, 590);
			this.CircuitDraw.TabIndex = 9;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1108, 614);
			this.Controls.Add(this.CircuitDraw);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.NadeComboBox);
			this.Controls.Add(this.treeView);
			this.Controls.Add(this.SelectingCircuitLabel);
			this.Controls.Add(this.SelectingCircuitComboBox);
			this.Controls.Add(this.NominalTextBox);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.DeleteButton);
			this.Controls.Add(this.CalculateImpedanceButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(733, 409);
			this.Name = "MainForm";
			this.Text = "CircuitMainForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CalculateImpedanceButton;
        private System.Windows.Forms.TextBox NominalTextBox;
        private System.Windows.Forms.ComboBox SelectingCircuitComboBox;
        private System.Windows.Forms.Label SelectingCircuitLabel;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ComboBox NadeComboBox;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel CircuitDraw;
	}
}

