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
            this._editValuesTextBox = new System.Windows.Forms.TextBox();
            this._editValueButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._editValueFormLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _editValuesTextBox
            // 
            this._editValuesTextBox.Location = new System.Drawing.Point(23, 37);
            this._editValuesTextBox.Name = "_editValuesTextBox";
            this._editValuesTextBox.Size = new System.Drawing.Size(100, 20);
            this._editValuesTextBox.TabIndex = 0;
            this._editValuesTextBox.Text = "0";
            this._editValuesTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this._editValuesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this._editValuesTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // _editValueButton
            // 
            this._editValueButton.Location = new System.Drawing.Point(23, 72);
            this._editValueButton.Name = "_editValueButton";
            this._editValueButton.Size = new System.Drawing.Size(100, 23);
            this._editValueButton.TabIndex = 1;
            this._editValueButton.Text = "Изменить";
            this._editValueButton.UseVisualStyleBackColor = true;
            this._editValueButton.Click += new System.EventHandler(this.EditValueButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(23, 111);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(100, 23);
            this._cancelButton.TabIndex = 2;
            this._cancelButton.Text = "Выйти";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // _editValueFormLabel
            // 
            this._editValueFormLabel.AutoSize = true;
            this._editValueFormLabel.Location = new System.Drawing.Point(12, 9);
            this._editValueFormLabel.Name = "_editValueFormLabel";
            this._editValueFormLabel.Size = new System.Drawing.Size(132, 13);
            this._editValueFormLabel.TabIndex = 3;
            this._editValueFormLabel.Text = "Введите новое значение";
            // 
            // EditValuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(151, 168);
            this.Controls.Add(this._editValueFormLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._editValueButton);
            this.Controls.Add(this._editValuesTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditValuesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditValuesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _editValuesTextBox;
        private System.Windows.Forms.Button _editValueButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _editValueFormLabel;
    }
}