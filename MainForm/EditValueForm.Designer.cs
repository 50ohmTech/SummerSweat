namespace MainForm
{
    partial class EditValueForm
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
            this._editValueButton = new System.Windows.Forms.Button();
            this._editValueLabel = new System.Windows.Forms.Label();
            this._editValueTextBox = new System.Windows.Forms.TextBox();
            this._closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _editValueButton
            // 
            this._editValueButton.Location = new System.Drawing.Point(15, 51);
            this._editValueButton.Name = "_editValueButton";
            this._editValueButton.Size = new System.Drawing.Size(67, 23);
            this._editValueButton.TabIndex = 0;
            this._editValueButton.Text = "Изменить";
            this._editValueButton.UseVisualStyleBackColor = true;
            this._editValueButton.Click += new System.EventHandler(this._editValueButton_Click);
            // 
            // _editValueLabel
            // 
            this._editValueLabel.AutoSize = true;
            this._editValueLabel.Location = new System.Drawing.Point(12, 9);
            this._editValueLabel.Name = "_editValueLabel";
            this._editValueLabel.Size = new System.Drawing.Size(144, 13);
            this._editValueLabel.TabIndex = 1;
            this._editValueLabel.Text = "Новое значение элемента:";
            // 
            // _editValueTextBox
            // 
            this._editValueTextBox.Location = new System.Drawing.Point(15, 25);
            this._editValueTextBox.Name = "_editValueTextBox";
            this._editValueTextBox.Size = new System.Drawing.Size(141, 20);
            this._editValueTextBox.TabIndex = 2;
            this._editValueTextBox.TextChanged += new System.EventHandler(this._editValueTextBox_TextChanged);
            // 
            // _closeButton
            // 
            this._closeButton.Location = new System.Drawing.Point(88, 51);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(68, 23);
            this._closeButton.TabIndex = 3;
            this._closeButton.Text = "Закрыть";
            this._closeButton.UseVisualStyleBackColor = true;
            this._closeButton.Click += new System.EventHandler(this._closeButton_Click);
            // 
            // EditValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 92);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._editValueTextBox);
            this.Controls.Add(this._editValueLabel);
            this.Controls.Add(this._editValueButton);
            this.MaximumSize = new System.Drawing.Size(188, 131);
            this.MinimumSize = new System.Drawing.Size(188, 131);
            this.Name = "EditValueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditValuesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _editValueButton;
        private System.Windows.Forms.Label _editValueLabel;
        private System.Windows.Forms.TextBox _editValueTextBox;
        private System.Windows.Forms.Button _closeButton;
    }
}