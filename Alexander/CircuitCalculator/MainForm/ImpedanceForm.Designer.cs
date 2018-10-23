namespace View
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
            this.components = new System.ComponentModel.Container();
            this.StartLabel = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.StepLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.StartNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FinishNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.StepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._calculationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinishNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._calculationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(17, 11);
            this.StartLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(58, 17);
            this.StartLabel.TabIndex = 0;
            this.StartLabel.Text = "Начало";
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(17, 43);
            this.EndLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(49, 17);
            this.EndLabel.TabIndex = 1;
            this.EndLabel.Text = "Конец";
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Location = new System.Drawing.Point(17, 75);
            this.StepLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(32, 17);
            this.StepLabel.TabIndex = 2;
            this.StepLabel.Text = "Шаг";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView.Location = new System.Drawing.Point(20, 103);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(232, 143);
            this.dataGridView.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Частота";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Импеданс";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(19, 253);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(233, 25);
            this.CalculateButton.TabIndex = 7;
            this.CalculateButton.Text = "Рассчитать";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // StartNumericUpDown
            // 
            this.StartNumericUpDown.DecimalPlaces = 2;
            this.StartNumericUpDown.Location = new System.Drawing.Point(119, 9);
            this.StartNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.StartNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.StartNumericUpDown.Name = "StartNumericUpDown";
            this.StartNumericUpDown.Size = new System.Drawing.Size(133, 22);
            this.StartNumericUpDown.TabIndex = 8;
            this.StartNumericUpDown.ThousandsSeparator = true;
            this.StartNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // FinishNumericUpDown
            // 
            this.FinishNumericUpDown.DecimalPlaces = 2;
            this.FinishNumericUpDown.Location = new System.Drawing.Point(119, 41);
            this.FinishNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.FinishNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.FinishNumericUpDown.Name = "FinishNumericUpDown";
            this.FinishNumericUpDown.Size = new System.Drawing.Size(133, 22);
            this.FinishNumericUpDown.TabIndex = 9;
            this.FinishNumericUpDown.ThousandsSeparator = true;
            this.FinishNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // StepNumericUpDown
            // 
            this.StepNumericUpDown.DecimalPlaces = 2;
            this.StepNumericUpDown.Location = new System.Drawing.Point(119, 73);
            this.StepNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.StepNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.StepNumericUpDown.Name = "StepNumericUpDown";
            this.StepNumericUpDown.Size = new System.Drawing.Size(133, 22);
            this.StepNumericUpDown.TabIndex = 10;
            this.StepNumericUpDown.ThousandsSeparator = true;
            this.StepNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // ImpedanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 284);
            this.Controls.Add(this.StepNumericUpDown);
            this.Controls.Add(this.FinishNumericUpDown);
            this.Controls.Add(this.StartNumericUpDown);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.StepLabel);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(290, 331);
            this.MinimumSize = new System.Drawing.Size(290, 331);
            this.Name = "ImpedanceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImpedanceForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinishNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._calculationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.NumericUpDown StartNumericUpDown;
        private System.Windows.Forms.NumericUpDown FinishNumericUpDown;
        private System.Windows.Forms.NumericUpDown StepNumericUpDown;
        private System.Windows.Forms.BindingSource _calculationBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}