﻿namespace MainForm
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
            this.NadeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PaintGroupBox
            // 
            this.PaintGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PaintGroupBox.Location = new System.Drawing.Point(191, 12);
            this.PaintGroupBox.Name = "PaintGroupBox";
            this.PaintGroupBox.Size = new System.Drawing.Size(330, 276);
            this.PaintGroupBox.TabIndex = 0;
            this.PaintGroupBox.TabStop = false;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(15, 236);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(80, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(105, 236);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(80, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // CalculateImpedanceButton
            // 
            this.CalculateImpedanceButton.Location = new System.Drawing.Point(15, 265);
            this.CalculateImpedanceButton.Name = "CalculateImpedanceButton";
            this.CalculateImpedanceButton.Size = new System.Drawing.Size(170, 23);
            this.CalculateImpedanceButton.TabIndex = 2;
            this.CalculateImpedanceButton.Text = "Рассчитать импеданс";
            this.CalculateImpedanceButton.UseVisualStyleBackColor = true;
            // 
            // NominalTextBox
            // 
            this.NominalTextBox.Location = new System.Drawing.Point(15, 200);
            this.NominalTextBox.Name = "NominalTextBox";
            this.NominalTextBox.Size = new System.Drawing.Size(170, 20);
            this.NominalTextBox.TabIndex = 3;
            // 
            // SelectingCircuitComboBox
            // 
            this.SelectingCircuitComboBox.FormattingEnabled = true;
            this.SelectingCircuitComboBox.Location = new System.Drawing.Point(85, 9);
            this.SelectingCircuitComboBox.Name = "SelectingCircuitComboBox";
            this.SelectingCircuitComboBox.Size = new System.Drawing.Size(100, 21);
            this.SelectingCircuitComboBox.TabIndex = 4;
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
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(15, 36);
            this.treeView.MinimumSize = new System.Drawing.Size(170, 111);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(170, 111);
            this.treeView.TabIndex = 6;
            // 
            // NadeComboBox
            // 
            this.NadeComboBox.FormattingEnabled = true;
            this.NadeComboBox.Location = new System.Drawing.Point(15, 173);
            this.NadeComboBox.Name = "NadeComboBox";
            this.NadeComboBox.Size = new System.Drawing.Size(170, 21);
            this.NadeComboBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Добавить элемент";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 302);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NadeComboBox);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.SelectingCircuitLabel);
            this.Controls.Add(this.SelectingCircuitComboBox);
            this.Controls.Add(this.NominalTextBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CalculateImpedanceButton);
            this.Controls.Add(this.PaintGroupBox);
            this.MinimumSize = new System.Drawing.Size(554, 341);
            this.Name = "MainForm";
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
        private System.Windows.Forms.ComboBox NadeComboBox;
        private System.Windows.Forms.Label label2;
    }
}

