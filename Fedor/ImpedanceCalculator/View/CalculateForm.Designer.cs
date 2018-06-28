namespace View
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
            this.circuitGridView = new System.Windows.Forms.DataGridView();
            this.CircuitImpedance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CircuitFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculateButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.circuitGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // circuitGridView
            // 
            this.circuitGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.circuitGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CircuitImpedance,
            this.CircuitFrequency});
            this.circuitGridView.Location = new System.Drawing.Point(12, 12);
            this.circuitGridView.Name = "circuitGridView";
            this.circuitGridView.RowHeadersVisible = false;
            this.circuitGridView.RowTemplate.Height = 24;
            this.circuitGridView.Size = new System.Drawing.Size(268, 326);
            this.circuitGridView.TabIndex = 0;
            // 
            // CircuitImpedance
            // 
            this.CircuitImpedance.Frozen = true;
            this.CircuitImpedance.HeaderText = "Impedance";
            this.CircuitImpedance.Name = "CircuitImpedance";
            this.CircuitImpedance.ReadOnly = true;
            // 
            // CircuitFrequency
            // 
            this.CircuitFrequency.Frozen = true;
            this.CircuitFrequency.HeaderText = "Frequency";
            this.CircuitFrequency.Name = "CircuitFrequency";
            this.CircuitFrequency.ReadOnly = true;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(149, 344);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(131, 39);
            this.calculateButton.TabIndex = 1;
            this.calculateButton.Text = "Расчитать";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // backButton
            // 
            this.backButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.backButton.Location = new System.Drawing.Point(12, 344);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(131, 39);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Создать цепь";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // CalculateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 395);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.circuitGridView);
            this.Name = "CalculateForm";
            this.Text = "Circuit Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.circuitGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView circuitGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CircuitImpedance;
        private System.Windows.Forms.DataGridViewTextBoxColumn CircuitFrequency;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Button backButton;
    }
}