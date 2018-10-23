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
            this.editValuesTextBox = new System.Windows.Forms.TextBox();
            this.editValueButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editValuesTextBox
            // 
            this.editValuesTextBox.Location = new System.Drawing.Point(23, 30);
            this.editValuesTextBox.Name = "editValuesTextBox";
            this.editValuesTextBox.Size = new System.Drawing.Size(100, 20);
            this.editValuesTextBox.TabIndex = 0;
            this.editValuesTextBox.Text = "0";
            this.editValuesTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.editValuesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this.editValuesTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // editValueButton
            // 
            this.editValueButton.Location = new System.Drawing.Point(23, 72);
            this.editValueButton.Name = "editValueButton";
            this.editValueButton.Size = new System.Drawing.Size(100, 23);
            this.editValueButton.TabIndex = 1;
            this.editValueButton.Text = "Изменить";
            this.editValueButton.UseVisualStyleBackColor = true;
            this.editValueButton.Click += new System.EventHandler(this.EditValueButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(23, 111);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Выйти";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditValuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(151, 168);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.editValueButton);
            this.Controls.Add(this.editValuesTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditValuesForm";
            this.Text = "EditValuesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox editValuesTextBox;
        private System.Windows.Forms.Button editValueButton;
        private System.Windows.Forms.Button cancelButton;
    }
}