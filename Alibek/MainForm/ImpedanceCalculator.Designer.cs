﻿namespace MainForm
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
            this.CalculatorDataGridView = new System.Windows.Forms.DataGridView();
            this.Частота = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Импеданс = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StartValueTextBox = new System.Windows.Forms.TextBox();
            this.EndValueTextBox = new System.Windows.Forms.TextBox();
            this.StepValueTextBox = new System.Windows.Forms.TextBox();
            this.CalculateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CalculatorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CalculatorDataGridView
            // 
            this.CalculatorDataGridView.AllowUserToAddRows = false;
            this.CalculatorDataGridView.AllowUserToDeleteRows = false;
            this.CalculatorDataGridView.AllowUserToResizeColumns = false;
            this.CalculatorDataGridView.AllowUserToResizeRows = false;
            this.CalculatorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CalculatorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Частота,
            this.Импеданс});
            this.CalculatorDataGridView.Location = new System.Drawing.Point(10, 94);
            this.CalculatorDataGridView.Name = "CalculatorDataGridView";
            this.CalculatorDataGridView.RowHeadersVisible = false;
            this.CalculatorDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CalculatorDataGridView.Size = new System.Drawing.Size(195, 150);
            this.CalculatorDataGridView.TabIndex = 0;
            // 
            // Частота
            // 
            this.Частота.Frozen = true;
            this.Частота.HeaderText = "Частота";
            this.Частота.Name = "Частота";
            this.Частота.ReadOnly = true;
            // 
            // Импеданс
            // 
            this.Импеданс.Frozen = true;
            this.Импеданс.HeaderText = "Импеданс";
            this.Импеданс.Name = "Импеданс";
            this.Импеданс.ReadOnly = true;
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
            // StartValueTextBox
            // 
            this.StartValueTextBox.Location = new System.Drawing.Point(93, 13);
            this.StartValueTextBox.Name = "StartValueTextBox";
            this.StartValueTextBox.Size = new System.Drawing.Size(112, 20);
            this.StartValueTextBox.TabIndex = 4;
            this.StartValueTextBox.Text = "0";
            this.StartValueTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.StartValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this.StartValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // EndValueTextBox
            // 
            this.EndValueTextBox.Location = new System.Drawing.Point(93, 40);
            this.EndValueTextBox.Name = "EndValueTextBox";
            this.EndValueTextBox.Size = new System.Drawing.Size(112, 20);
            this.EndValueTextBox.TabIndex = 5;
            this.EndValueTextBox.Text = "0";
            this.EndValueTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.EndValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this.EndValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // StepValueTextBox
            // 
            this.StepValueTextBox.Location = new System.Drawing.Point(93, 68);
            this.StepValueTextBox.Name = "StepValueTextBox";
            this.StepValueTextBox.Size = new System.Drawing.Size(112, 20);
            this.StepValueTextBox.TabIndex = 6;
            this.StepValueTextBox.Text = "0";
            this.StepValueTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.StepValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntTextBox_KeyPress);
            this.StepValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(10, 250);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(195, 23);
            this.CalculateButton.TabIndex = 7;
            this.CalculateButton.Text = "Расчитать";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // ImpedanceCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 280);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.StepValueTextBox);
            this.Controls.Add(this.EndValueTextBox);
            this.Controls.Add(this.StartValueTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CalculatorDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ImpedanceCalculator";
            this.Text = "Impedance calculator";
            ((System.ComponentModel.ISupportInitialize)(this.CalculatorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CalculatorDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox StartValueTextBox;
        private System.Windows.Forms.TextBox EndValueTextBox;
        private System.Windows.Forms.TextBox StepValueTextBox;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Частота;
        private System.Windows.Forms.DataGridViewTextBoxColumn Импеданс;
    }
}

