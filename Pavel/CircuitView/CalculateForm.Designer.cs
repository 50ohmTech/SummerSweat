namespace CircuitView
{
    partial class CalculateForm
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
            this.FrequenciesGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalculateFreqButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.StartValueBox = new System.Windows.Forms.NumericUpDown();
            this.IntervalBox = new System.Windows.Forms.NumericUpDown();
            this.AmountBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FrequenciesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartValueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrequenciesGridView
            // 
            this.FrequenciesGridView.AllowUserToAddRows = false;
            this.FrequenciesGridView.AllowUserToDeleteRows = false;
            this.FrequenciesGridView.AllowUserToResizeColumns = false;
            this.FrequenciesGridView.AllowUserToResizeRows = false;
            this.FrequenciesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrequenciesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FrequenciesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.FrequenciesGridView.Location = new System.Drawing.Point(175, 12);
            this.FrequenciesGridView.Name = "FrequenciesGridView";
            this.FrequenciesGridView.ReadOnly = true;
            this.FrequenciesGridView.RowHeadersVisible = false;
            this.FrequenciesGridView.RowTemplate.Height = 24;
            this.FrequenciesGridView.Size = new System.Drawing.Size(354, 244);
            this.FrequenciesGridView.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Импеданс";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Частота";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // CalculateFreqButton
            // 
            this.CalculateFreqButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CalculateFreqButton.Location = new System.Drawing.Point(12, 198);
            this.CalculateFreqButton.Name = "CalculateFreqButton";
            this.CalculateFreqButton.Size = new System.Drawing.Size(157, 26);
            this.CalculateFreqButton.TabIndex = 1;
            this.CalculateFreqButton.Text = "Расчитать";
            this.CalculateFreqButton.UseVisualStyleBackColor = true;
            this.CalculateFreqButton.Click += new System.EventHandler(this.CalculateFrequenciesButton);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(12, 230);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(157, 26);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // StartValueBox
            // 
            this.StartValueBox.DecimalPlaces = 1;
            this.StartValueBox.Location = new System.Drawing.Point(9, 60);
            this.StartValueBox.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.StartValueBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StartValueBox.Name = "StartValueBox";
            this.StartValueBox.Size = new System.Drawing.Size(90, 22);
            this.StartValueBox.TabIndex = 3;
            this.StartValueBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // IntervalBox
            // 
            this.IntervalBox.DecimalPlaces = 2;
            this.IntervalBox.Location = new System.Drawing.Point(9, 105);
            this.IntervalBox.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.IntervalBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.IntervalBox.Name = "IntervalBox";
            this.IntervalBox.Size = new System.Drawing.Size(90, 22);
            this.IntervalBox.TabIndex = 4;
            this.IntervalBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // AmountBox
            // 
            this.AmountBox.Location = new System.Drawing.Point(9, 150);
            this.AmountBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AmountBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmountBox.Name = "AmountBox";
            this.AmountBox.Size = new System.Drawing.Size(90, 22);
            this.AmountBox.TabIndex = 5;
            this.AmountBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.StartValueBox);
            this.groupBox1.Controls.Add(this.AmountBox);
            this.groupBox1.Controls.Add(this.IntervalBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 181);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Введите диапазон частот";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Количество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Интервал";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Начальное значение";
            // 
            // CalculateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 268);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CalculateFreqButton);
            this.Controls.Add(this.FrequenciesGridView);
            this.MinimumSize = new System.Drawing.Size(559, 315);
            this.Name = "CalculateForm";
            this.Text = "Расчет импеданса";
            ((System.ComponentModel.ISupportInitialize)(this.FrequenciesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartValueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FrequenciesGridView;
        private System.Windows.Forms.Button CalculateFreqButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.NumericUpDown StartValueBox;
        private System.Windows.Forms.NumericUpDown IntervalBox;
        private System.Windows.Forms.NumericUpDown AmountBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}