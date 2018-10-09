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
            this._buttonEdit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this._textBoxValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _buttonEdit
            // 
            this._buttonEdit.Location = new System.Drawing.Point(12, 78);
            this._buttonEdit.Name = "_buttonEdit";
            this._buttonEdit.Size = new System.Drawing.Size(130, 23);
            this._buttonEdit.TabIndex = 0;
            this._buttonEdit.Text = "Изменить";
            this._buttonEdit.UseVisualStyleBackColor = true;
            this._buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // _textBoxValue
            // 
            this._textBoxValue.Location = new System.Drawing.Point(12, 36);
            this._textBoxValue.Name = "_textBoxValue";
            this._textBoxValue.Size = new System.Drawing.Size(130, 22);
            this._textBoxValue.TabIndex = 2;
            this._textBoxValue.TextChanged += new System.EventHandler(this.TextBoxValue_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Значение";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 164);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._textBoxValue);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._buttonEdit);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonEdit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox _textBoxValue;
        private System.Windows.Forms.Label label1;
    }
}