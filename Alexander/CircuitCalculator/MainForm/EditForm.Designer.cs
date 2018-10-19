namespace View
{
    partial class EditForm
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
            this.EditButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.NominalLabel = new System.Windows.Forms.Label();
            this.EditNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.EditNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(15, 45);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(97, 28);
            this.EditButton.TabIndex = 0;
            this.EditButton.Text = "Изменить";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(220, 45);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(97, 28);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NominalLabel
            // 
            this.NominalLabel.AutoSize = true;
            this.NominalLabel.Location = new System.Drawing.Point(12, 19);
            this.NominalLabel.Name = "NominalLabel";
            this.NominalLabel.Size = new System.Drawing.Size(179, 17);
            this.NominalLabel.TabIndex = 2;
            this.NominalLabel.Text = "Новый номинал элемента";
            // 
            // EditNumericUpDown
            // 
            this.EditNumericUpDown.DecimalPlaces = 2;
            this.EditNumericUpDown.Location = new System.Drawing.Point(197, 17);
            this.EditNumericUpDown.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.EditNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.EditNumericUpDown.Name = "EditNumericUpDown";
            this.EditNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.EditNumericUpDown.TabIndex = 4;
            this.EditNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.EditNumericUpDown.ValueChanged += new System.EventHandler(this.EditNumericUpDown_ValueChanged);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 92);
            this.Controls.Add(this.EditNumericUpDown);
            this.Controls.Add(this.NominalLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.EditButton);
            this.MaximumSize = new System.Drawing.Size(351, 139);
            this.MinimumSize = new System.Drawing.Size(351, 139);
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditForm";
            ((System.ComponentModel.ISupportInitialize)(this.EditNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label NominalLabel;
        private System.Windows.Forms.NumericUpDown EditNumericUpDown;
    }
}