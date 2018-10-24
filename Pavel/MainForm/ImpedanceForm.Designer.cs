namespace MainForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.StartTextBox = new System.Windows.Forms.NumericUpDown();
            this.FinishTextBox = new System.Windows.Forms.NumericUpDown();
            this.StepTextBox = new System.Windows.Forms.NumericUpDown();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinishTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(16, 11);
            this.StartLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(58, 17);
            this.StartLabel.TabIndex = 0;
            this.StartLabel.Text = "Начало";
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(16, 43);
            this.EndLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(49, 17);
            this.EndLabel.TabIndex = 1;
            this.EndLabel.Text = "Конец";
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Location = new System.Drawing.Point(16, 75);
            this.StepLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(32, 17);
            this.StepLabel.TabIndex = 2;
            this.StepLabel.Text = "Шаг";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView.Location = new System.Drawing.Point(20, 103);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(232, 151);
            this.dataGridView.TabIndex = 6;
            // 
            // StartTextBox
            // 
            this.StartTextBox.Location = new System.Drawing.Point(106, 6);
            this.StartTextBox.Name = "StartTextBox";
            this.StartTextBox.Size = new System.Drawing.Size(146, 22);
            this.StartTextBox.TabIndex = 7;
            // 
            // FinishTextBox
            // 
            this.FinishTextBox.Location = new System.Drawing.Point(106, 38);
            this.FinishTextBox.Name = "FinishTextBox";
            this.FinishTextBox.Size = new System.Drawing.Size(146, 22);
            this.FinishTextBox.TabIndex = 8;
            // 
            // StepTextBox
            // 
            this.StepTextBox.Location = new System.Drawing.Point(106, 70);
            this.StepTextBox.Name = "StepTextBox";
            this.StepTextBox.Size = new System.Drawing.Size(146, 22);
            this.StepTextBox.TabIndex = 1;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(20, 262);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(232, 23);
            this.CalculateButton.TabIndex = 9;
            this.CalculateButton.Text = "Рассчитать импеданс";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Частота";
            this.Column1.Name = "Column1";
            this.Column1.Width = 116;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Импеданс";
            this.Column2.Name = "Column2";
            this.Column2.Width = 116;
            // 
            // ImpedanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 298);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.StepTextBox);
            this.Controls.Add(this.FinishTextBox);
            this.Controls.Add(this.StartTextBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.StepLabel);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(287, 298);
            this.Name = "ImpedanceForm";
            this.Text = "ImpedanceForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinishTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.NumericUpDown StartTextBox;
        private System.Windows.Forms.NumericUpDown FinishTextBox;
        private System.Windows.Forms.NumericUpDown StepTextBox;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}