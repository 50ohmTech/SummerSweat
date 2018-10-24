namespace CircuitView
{
    partial class EditElementForm
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
            this.EditGroupBox = new System.Windows.Forms.GroupBox();
            this.NameElementLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.EditGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditGroupBox
            // 
            this.EditGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditGroupBox.Controls.Add(this.NameElementLabel);
            this.EditGroupBox.Controls.Add(this.NameLabel);
            this.EditGroupBox.Controls.Add(this.CancelButton);
            this.EditGroupBox.Controls.Add(this.OKButton);
            this.EditGroupBox.Controls.Add(this.ValueTextBox);
            this.EditGroupBox.Controls.Add(this.ValueLabel);
            this.EditGroupBox.Location = new System.Drawing.Point(10, 12);
            this.EditGroupBox.Name = "EditGroupBox";
            this.EditGroupBox.Size = new System.Drawing.Size(178, 111);
            this.EditGroupBox.TabIndex = 0;
            this.EditGroupBox.TabStop = false;
            // 
            // NameElementLabel
            // 
            this.NameElementLabel.AutoSize = true;
            this.NameElementLabel.Location = new System.Drawing.Point(84, 19);
            this.NameElementLabel.Name = "NameElementLabel";
            this.NameElementLabel.Size = new System.Drawing.Size(86, 16);
            this.NameElementLabel.TabIndex = 4;
            this.NameElementLabel.Text = "NameElement";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(6, 19);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(41, 16);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "Name";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(87, 78);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(6, 78);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(87, 46);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(75, 23);
            this.ValueTextBox.TabIndex = 1;
            this.ValueTextBox.TextChanged += new System.EventHandler(this.ValueTextBox_TextChanged);
            this.ValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTextBox_KeyPress);
            this.ValueTextBox.Leave += new System.EventHandler(this.ValueTextBox_Leave);
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(6, 49);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(37, 16);
            this.ValueLabel.TabIndex = 0;
            this.ValueLabel.Text = "Value";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 135);
            this.Controls.Add(this.EditGroupBox);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit value";
            this.EditGroupBox.ResumeLayout(false);
            this.EditGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox EditGroupBox;
        private System.Windows.Forms.Label ValueLabel;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.Label NameElementLabel;
        private System.Windows.Forms.Label NameLabel;
    }
}