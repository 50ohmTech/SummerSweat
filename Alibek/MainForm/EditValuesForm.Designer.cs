namespace MainForm
{
    partial class EditValuesForm
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
            this.EditValuesTextBox = new System.Windows.Forms.TextBox();
            this.EditValueButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EditValuesTextBox
            // 
            this.EditValuesTextBox.Location = new System.Drawing.Point(23, 30);
            this.EditValuesTextBox.Name = "EditValuesTextBox";
            this.EditValuesTextBox.Size = new System.Drawing.Size(100, 20);
            this.EditValuesTextBox.TabIndex = 0;
            this.EditValuesTextBox.Text = "0";
            this.EditValuesTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.EditValuesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this.EditValuesTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // EditValueButton
            // 
            this.EditValueButton.Location = new System.Drawing.Point(23, 72);
            this.EditValueButton.Name = "EditValueButton";
            this.EditValueButton.Size = new System.Drawing.Size(100, 23);
            this.EditValueButton.TabIndex = 1;
            this.EditValueButton.Text = "Изменить";
            this.EditValueButton.UseVisualStyleBackColor = true;
            this.EditValueButton.Click += new System.EventHandler(this.EditValueButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(23, 111);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(100, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Выйти";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditValuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(151, 168);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.EditValueButton);
            this.Controls.Add(this.EditValuesTextBox);
            this.Name = "EditValuesForm";
            this.Text = "EditValuesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EditValuesTextBox;
        private System.Windows.Forms.Button EditValueButton;
        private System.Windows.Forms.Button CancelButton;
    }
}