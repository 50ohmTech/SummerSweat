﻿namespace MainForm
{
    partial class ImpedanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartLabel = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.StepLabel = new System.Windows.Forms.Label();
            this.StartTextBox = new System.Windows.Forms.TextBox();
            this.FinishTextBox = new System.Windows.Forms.TextBox();
            this.StepTextBox = new System.Windows.Forms.TextBox();
            this.impedancesGridView = new System.Windows.Forms.DataGridView();
            this.calculateButton = new System.Windows.Forms.Button();
            this.frequencies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impendances = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.impedancesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(12, 9);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(44, 13);
            this.StartLabel.TabIndex = 0;
            this.StartLabel.Text = "Начало";
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(12, 35);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(38, 13);
            this.EndLabel.TabIndex = 1;
            this.EndLabel.Text = "Конец";
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Location = new System.Drawing.Point(12, 61);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(27, 13);
            this.StepLabel.TabIndex = 2;
            this.StepLabel.Text = "Шаг";
            // 
            // StartTextBox
            // 
            this.StartTextBox.Location = new System.Drawing.Point(89, 6);
            this.StartTextBox.Name = "StartTextBox";
            this.StartTextBox.Size = new System.Drawing.Size(100, 20);
            this.StartTextBox.TabIndex = 3;
            this.StartTextBox.TextChanged += new System.EventHandler(this.StartTextBox_TextChanged);
            // 
            // FinishTextBox
            // 
            this.FinishTextBox.Location = new System.Drawing.Point(89, 32);
            this.FinishTextBox.Name = "FinishTextBox";
            this.FinishTextBox.Size = new System.Drawing.Size(100, 20);
            this.FinishTextBox.TabIndex = 4;
            this.FinishTextBox.TextChanged += new System.EventHandler(this.FinishTextBox_TextChanged);
            // 
            // StepTextBox
            // 
            this.StepTextBox.Location = new System.Drawing.Point(89, 58);
            this.StepTextBox.Name = "StepTextBox";
            this.StepTextBox.Size = new System.Drawing.Size(100, 20);
            this.StepTextBox.TabIndex = 5;
            this.StepTextBox.TextChanged += new System.EventHandler(this.StepTextBox_TextChanged);
            // 
            // impedancesGridView
            // 
            this.impedancesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.impedancesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.impedancesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.frequencies,
            this.impendances});
            this.impedancesGridView.Location = new System.Drawing.Point(15, 117);
            this.impedancesGridView.Name = "impedancesGridView";
            this.impedancesGridView.Size = new System.Drawing.Size(174, 258);
            this.impedancesGridView.TabIndex = 6;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(63, 88);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 7;
            this.calculateButton.Text = "Рассчитать";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // frequencies
            // 
            this.frequencies.HeaderText = "Частота";
            this.frequencies.Name = "frequencies";
            // 
            // impendances
            // 
            this.impendances.HeaderText = "Импедансы";
            this.impendances.Name = "impendances";
            // 
            // ImpedanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 387);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.impedancesGridView);
            this.Controls.Add(this.StepTextBox);
            this.Controls.Add(this.FinishTextBox);
            this.Controls.Add(this.StartTextBox);
            this.Controls.Add(this.StepLabel);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(220, 251);
            this.Name = "ImpedanceForm";
            this.Text = "ImpedanceForm";
            ((System.ComponentModel.ISupportInitialize)(this.impedancesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.TextBox StartTextBox;
        private System.Windows.Forms.TextBox FinishTextBox;
        private System.Windows.Forms.TextBox StepTextBox;
        private System.Windows.Forms.DataGridView impedancesGridView;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequencies;
        private System.Windows.Forms.DataGridViewTextBoxColumn impendances;
    }
}