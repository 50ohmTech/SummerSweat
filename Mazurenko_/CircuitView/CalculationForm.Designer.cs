namespace CircuitView
{
    partial class CalculationForm
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
            this.StartValueLabel = new System.Windows.Forms.Label();
            this.EndValueLabel = new System.Windows.Forms.Label();
            this.StepLabel = new System.Windows.Forms.Label();
            this.StartValueTextBox = new System.Windows.Forms.TextBox();
            this.EndValueTextBox = new System.Windows.Forms.TextBox();
            this.StepTextBox = new System.Windows.Forms.TextBox();
            this.CalculationGridView = new System.Windows.Forms.DataGridView();
            this.columnFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnImpedance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImpedanceGroupBox = new System.Windows.Forms.GroupBox();
            this.CalculationButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ButtonGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.CalculationGridView)).BeginInit();
            this.ImpedanceGroupBox.SuspendLayout();
            this.ButtonGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartValueLabel
            // 
            this.StartValueLabel.AutoSize = true;
            this.StartValueLabel.Location = new System.Drawing.Point(6, 16);
            this.StartValueLabel.Name = "StartValueLabel";
            this.StartValueLabel.Size = new System.Drawing.Size(68, 16);
            this.StartValueLabel.TabIndex = 0;
            this.StartValueLabel.Text = "Start value";
            // 
            // EndValueLabel
            // 
            this.EndValueLabel.AutoSize = true;
            this.EndValueLabel.Location = new System.Drawing.Point(6, 61);
            this.EndValueLabel.Name = "EndValueLabel";
            this.EndValueLabel.Size = new System.Drawing.Size(63, 16);
            this.EndValueLabel.TabIndex = 1;
            this.EndValueLabel.Text = "End value";
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Location = new System.Drawing.Point(6, 106);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(33, 16);
            this.StepLabel.TabIndex = 2;
            this.StepLabel.Text = "Step";
            // 
            // StartValueTextBox
            // 
            this.StartValueTextBox.Location = new System.Drawing.Point(6, 35);
            this.StartValueTextBox.Name = "StartValueTextBox";
            this.StartValueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.StartValueTextBox.Size = new System.Drawing.Size(116, 23);
            this.StartValueTextBox.TabIndex = 1;
            this.StartValueTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.StartValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_DoubleKeyPress);
            this.StartValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // EndValueTextBox
            // 
            this.EndValueTextBox.Location = new System.Drawing.Point(6, 80);
            this.EndValueTextBox.Name = "EndValueTextBox";
            this.EndValueTextBox.Size = new System.Drawing.Size(116, 23);
            this.EndValueTextBox.TabIndex = 2;
            this.EndValueTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.EndValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_DoubleKeyPress);
            this.EndValueTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // StepTextBox
            // 
            this.StepTextBox.Location = new System.Drawing.Point(6, 125);
            this.StepTextBox.MaxLength = 13;
            this.StepTextBox.Name = "StepTextBox";
            this.StepTextBox.Size = new System.Drawing.Size(116, 23);
            this.StepTextBox.TabIndex = 3;
            this.StepTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_DoubleKeyPress);
            // 
            // CalculationGridView
            // 
            this.CalculationGridView.AllowUserToAddRows = false;
            this.CalculationGridView.AllowUserToDeleteRows = false;
            this.CalculationGridView.AllowUserToResizeColumns = false;
            this.CalculationGridView.AllowUserToResizeRows = false;
            this.CalculationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CalculationGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnFrequency,
            this.columnImpedance});
            this.CalculationGridView.Location = new System.Drawing.Point(167, 12);
            this.CalculationGridView.MultiSelect = false;
            this.CalculationGridView.Name = "CalculationGridView";
            this.CalculationGridView.RowHeadersVisible = false;
            this.CalculationGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CalculationGridView.Size = new System.Drawing.Size(381, 260);
            this.CalculationGridView.TabIndex = 6;
            // 
            // columnFrequency
            // 
            this.columnFrequency.Frozen = true;
            this.columnFrequency.HeaderText = "Frequency";
            this.columnFrequency.MaxInputLength = 13;
            this.columnFrequency.Name = "columnFrequency";
            this.columnFrequency.ReadOnly = true;
            this.columnFrequency.Width = 93;
            // 
            // columnImpedance
            // 
            this.columnImpedance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnImpedance.HeaderText = "Impedance";
            this.columnImpedance.MaxInputLength = 13;
            this.columnImpedance.Name = "columnImpedance";
            this.columnImpedance.ReadOnly = true;
            // 
            // ImpedanceGroupBox
            // 
            this.ImpedanceGroupBox.Controls.Add(this.StartValueTextBox);
            this.ImpedanceGroupBox.Controls.Add(this.StartValueLabel);
            this.ImpedanceGroupBox.Controls.Add(this.StepTextBox);
            this.ImpedanceGroupBox.Controls.Add(this.EndValueLabel);
            this.ImpedanceGroupBox.Controls.Add(this.EndValueTextBox);
            this.ImpedanceGroupBox.Controls.Add(this.StepLabel);
            this.ImpedanceGroupBox.Location = new System.Drawing.Point(12, 5);
            this.ImpedanceGroupBox.Name = "ImpedanceGroupBox";
            this.ImpedanceGroupBox.Size = new System.Drawing.Size(134, 168);
            this.ImpedanceGroupBox.TabIndex = 7;
            this.ImpedanceGroupBox.TabStop = false;
            // 
            // CalculationButton
            // 
            this.CalculationButton.Enabled = false;
            this.CalculationButton.Location = new System.Drawing.Point(6, 18);
            this.CalculationButton.Name = "CalculationButton";
            this.CalculationButton.Size = new System.Drawing.Size(116, 32);
            this.CalculationButton.TabIndex = 4;
            this.CalculationButton.Text = "Calculation";
            this.CalculationButton.UseVisualStyleBackColor = true;
            this.CalculationButton.Click += new System.EventHandler(this.CalculationButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(6, 56);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(116, 30);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ButtonGroupBox
            // 
            this.ButtonGroupBox.Controls.Add(this.CalculationButton);
            this.ButtonGroupBox.Controls.Add(this.CancelButton);
            this.ButtonGroupBox.Location = new System.Drawing.Point(12, 175);
            this.ButtonGroupBox.Name = "ButtonGroupBox";
            this.ButtonGroupBox.Size = new System.Drawing.Size(134, 97);
            this.ButtonGroupBox.TabIndex = 8;
            this.ButtonGroupBox.TabStop = false;
            // 
            // CalculationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 279);
            this.Controls.Add(this.ButtonGroupBox);
            this.Controls.Add(this.ImpedanceGroupBox);
            this.Controls.Add(this.CalculationGridView);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 250);
            this.Name = "CalculationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculation Form";
            ((System.ComponentModel.ISupportInitialize)(this.CalculationGridView)).EndInit();
            this.ImpedanceGroupBox.ResumeLayout(false);
            this.ImpedanceGroupBox.PerformLayout();
            this.ButtonGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StartValueLabel;
        private System.Windows.Forms.Label EndValueLabel;
        private System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.TextBox StartValueTextBox;
        private System.Windows.Forms.TextBox EndValueTextBox;
        private System.Windows.Forms.TextBox StepTextBox;
        private System.Windows.Forms.DataGridView CalculationGridView;
        private System.Windows.Forms.GroupBox ImpedanceGroupBox;
        private System.Windows.Forms.Button CalculationButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnImpedance;
        private System.Windows.Forms.GroupBox ButtonGroupBox;
    }
}