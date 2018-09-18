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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
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
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(119, 7);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(132, 22);
			this.textBox1.TabIndex = 3;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(119, 39);
			this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(132, 22);
			this.textBox2.TabIndex = 4;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(119, 71);
			this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(132, 22);
			this.textBox3.TabIndex = 5;
			// 
			// dataGridView
			// 
			this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(20, 103);
			this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(232, 143);
			this.dataGridView.TabIndex = 6;
			// 
			// ImpedanceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(272, 261);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.StepLabel);
			this.Controls.Add(this.EndLabel);
			this.Controls.Add(this.StartLabel);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MinimumSize = new System.Drawing.Size(287, 298);
			this.Name = "ImpedanceForm";
			this.Text = "ImpedanceForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImpedanceForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}