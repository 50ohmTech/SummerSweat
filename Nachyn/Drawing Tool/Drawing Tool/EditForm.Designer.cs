namespace DrawingTool
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
            this._textBoxName = new System.Windows.Forms.TextBox();
            this._textBoxValue = new System.Windows.Forms.TextBox();
            this._labelName = new System.Windows.Forms.Label();
            this._labelValue = new System.Windows.Forms.Label();
            this._buttonEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _textBoxName
            // 
            this._textBoxName.Enabled = false;
            this._textBoxName.Location = new System.Drawing.Point(71, 38);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(91, 20);
            this._textBoxName.TabIndex = 11;
            // 
            // _textBoxValue
            // 
            this._textBoxValue.Location = new System.Drawing.Point(71, 12);
            this._textBoxValue.Name = "_textBoxValue";
            this._textBoxValue.Size = new System.Drawing.Size(91, 20);
            this._textBoxValue.TabIndex = 7;
            this._textBoxValue.TextChanged += new System.EventHandler(this.TextBoxValue_TextChanged);
            // 
            // _labelName
            // 
            this._labelName.AutoSize = true;
            this._labelName.Location = new System.Drawing.Point(8, 41);
            this._labelName.Name = "_labelName";
            this._labelName.Size = new System.Drawing.Size(29, 13);
            this._labelName.TabIndex = 10;
            this._labelName.Text = "Имя";
            // 
            // _labelValue
            // 
            this._labelValue.AutoSize = true;
            this._labelValue.Location = new System.Drawing.Point(8, 15);
            this._labelValue.Name = "_labelValue";
            this._labelValue.Size = new System.Drawing.Size(53, 13);
            this._labelValue.TabIndex = 8;
            this._labelValue.Text = "Номинал";
            // 
            // _buttonEdit
            // 
            this._buttonEdit.Enabled = false;
            this._buttonEdit.Location = new System.Drawing.Point(71, 64);
            this._buttonEdit.Name = "_buttonEdit";
            this._buttonEdit.Size = new System.Drawing.Size(91, 23);
            this._buttonEdit.TabIndex = 9;
            this._buttonEdit.Text = "Изменить";
            this._buttonEdit.UseVisualStyleBackColor = true;
            this._buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(175, 96);
            this.Controls.Add(this._textBoxName);
            this.Controls.Add(this._textBoxValue);
            this.Controls.Add(this._labelName);
            this.Controls.Add(this._labelValue);
            this.Controls.Add(this._buttonEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textBoxName;
        private System.Windows.Forms.TextBox _textBoxValue;
        private System.Windows.Forms.Label _labelName;
        private System.Windows.Forms.Label _labelValue;
        private System.Windows.Forms.Button _buttonEdit;
    }
}