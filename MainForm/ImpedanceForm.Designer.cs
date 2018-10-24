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
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._impedance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._startLabel = new System.Windows.Forms.Label();
            this._endLabel = new System.Windows.Forms.Label();
            this._stepLabel = new System.Windows.Forms.Label();
            this._startValueTextBox = new System.Windows.Forms.TextBox();
            this._endValueTextBox = new System.Windows.Forms.TextBox();
            this._stepValueTextBox = new System.Windows.Forms.TextBox();
            this._closeButton = new System.Windows.Forms.Button();
            this._calculateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.AllowUserToResizeColumns = false;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._frequency,
            this._impedance});
            this._dataGridView.Location = new System.Drawing.Point(15, 113);
            this._dataGridView.Name = "dataGridView";
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridView.Size = new System.Drawing.Size(174, 124);
            this._dataGridView.TabIndex = 6;
            // 
            // Frequency
            // 
            this._frequency.Frozen = true;
            this._frequency.HeaderText = "Частота";
            this._frequency.Name = "Frequency";
            this._frequency.ReadOnly = true;
            this._frequency.Width = 80;
            // 
            // Impedance
            // 
            this._impedance.Frozen = true;
            this._impedance.HeaderText = "Импеданс";
            this._impedance.Name = "Impedance";
            this._impedance.ReadOnly = true;
            this._impedance.Width = 94;
            // 
            // StartLabel
            // 
            this._startLabel.AutoSize = true;
            this._startLabel.Location = new System.Drawing.Point(12, 9);
            this._startLabel.Name = "StartLabel";
            this._startLabel.Size = new System.Drawing.Size(44, 13);
            this._startLabel.TabIndex = 0;
            this._startLabel.Text = "Начало";
            // 
            // EndLabel
            // 
            this._endLabel.AutoSize = true;
            this._endLabel.Location = new System.Drawing.Point(12, 35);
            this._endLabel.Name = "EndLabel";
            this._endLabel.Size = new System.Drawing.Size(38, 13);
            this._endLabel.TabIndex = 1;
            this._endLabel.Text = "Конец";
            // 
            // StepLabel
            // 
            this._stepLabel.AutoSize = true;
            this._stepLabel.Location = new System.Drawing.Point(12, 61);
            this._stepLabel.Name = "StepLabel";
            this._stepLabel.Size = new System.Drawing.Size(27, 13);
            this._stepLabel.TabIndex = 2;
            this._stepLabel.Text = "Шаг";
            // 
            // StartValueTextBox
            // 
            this._startValueTextBox.Location = new System.Drawing.Point(89, 6);
            this._startValueTextBox.Name = "StartValueTextBox";
            this._startValueTextBox.Size = new System.Drawing.Size(100, 20);
            this._startValueTextBox.TabIndex = 3;
            this._startValueTextBox.Text = "0";
            this._startValueTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this._startValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this._startValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // EndValueTextBox
            // 
            this._endValueTextBox.Location = new System.Drawing.Point(89, 32);
            this._endValueTextBox.Name = "EndValueTextBox";
            this._endValueTextBox.Size = new System.Drawing.Size(100, 20);
            this._endValueTextBox.TabIndex = 4;
            this._endValueTextBox.Text = "0";
            this._endValueTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this._endValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this._endValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // StepValueTextBox
            // 
            this._stepValueTextBox.Location = new System.Drawing.Point(89, 58);
            this._stepValueTextBox.Name = "StepValueTextBox";
            this._stepValueTextBox.Size = new System.Drawing.Size(100, 20);
            this._stepValueTextBox.TabIndex = 5;
            this._stepValueTextBox.Text = "0";
            this._stepValueTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this._stepValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this._stepValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // CloseButton
            // 
            this._closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._closeButton.Location = new System.Drawing.Point(55, 243);
            this._closeButton.Name = "CloseButton";
            this._closeButton.Size = new System.Drawing.Size(95, 22);
            this._closeButton.TabIndex = 7;
            this._closeButton.Text = "Закрыть";
            this._closeButton.UseVisualStyleBackColor = true;
            this._closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CalculateButton
            // 
            this._calculateButton.Location = new System.Drawing.Point(15, 84);
            this._calculateButton.Name = "CalculateButton";
            this._calculateButton.Size = new System.Drawing.Size(174, 23);
            this._calculateButton.TabIndex = 8;
            this._calculateButton.Text = "Расчитать";
            this._calculateButton.UseVisualStyleBackColor = true;
            this._calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // ImpedanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 271);
            this.Controls.Add(this._calculateButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._stepValueTextBox);
            this.Controls.Add(this._endValueTextBox);
            this.Controls.Add(this._startValueTextBox);
            this.Controls.Add(this._stepLabel);
            this.Controls.Add(this._endLabel);
            this.Controls.Add(this._startLabel);
            this.MaximumSize = new System.Drawing.Size(220, 410);
            this.MinimumSize = new System.Drawing.Size(220, 310);
            this.Name = "ImpedanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImpedanceForm";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _startLabel;
        private System.Windows.Forms.Label _endLabel;
        private System.Windows.Forms.Label _stepLabel;
        private System.Windows.Forms.TextBox _startValueTextBox;
        private System.Windows.Forms.TextBox _endValueTextBox;
        private System.Windows.Forms.TextBox _stepValueTextBox;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _calculateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn _impedance;
    }
}