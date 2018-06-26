namespace View
{
    partial class AddForm
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
            this._comboBoxType = new System.Windows.Forms.ComboBox();
            this._labelSelectType = new System.Windows.Forms.Label();
            this._textBoxValue = new System.Windows.Forms.TextBox();
            this._labelValue = new System.Windows.Forms.Label();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._labelName = new System.Windows.Forms.Label();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _comboBoxType
            // 
            this._comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxType.FormattingEnabled = true;
            this._comboBoxType.Location = new System.Drawing.Point(75, 12);
            this._comboBoxType.Name = "_comboBoxType";
            this._comboBoxType.Size = new System.Drawing.Size(91, 21);
            this._comboBoxType.TabIndex = 0;
            // 
            // _labelSelectType
            // 
            this._labelSelectType.AutoSize = true;
            this._labelSelectType.Location = new System.Drawing.Point(12, 9);
            this._labelSelectType.Name = "_labelSelectType";
            this._labelSelectType.Size = new System.Drawing.Size(57, 26);
            this._labelSelectType.TabIndex = 1;
            this._labelSelectType.Text = "Выберите\r\nэлемент";
            // 
            // _textBoxValue
            // 
            this._textBoxValue.Location = new System.Drawing.Point(75, 39);
            this._textBoxValue.Name = "_textBoxValue";
            this._textBoxValue.Size = new System.Drawing.Size(91, 20);
            this._textBoxValue.TabIndex = 2;
            this._textBoxValue.TextChanged += new System.EventHandler(this.TextBoxValueTextChanged);
            // 
            // _labelValue
            // 
            this._labelValue.AutoSize = true;
            this._labelValue.Location = new System.Drawing.Point(16, 42);
            this._labelValue.Name = "_labelValue";
            this._labelValue.Size = new System.Drawing.Size(53, 13);
            this._labelValue.TabIndex = 3;
            this._labelValue.Text = "Номинал";
            // 
            // _buttonAdd
            // 
            this._buttonAdd.Location = new System.Drawing.Point(15, 91);
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Size = new System.Drawing.Size(151, 23);
            this._buttonAdd.TabIndex = 4;
            this._buttonAdd.Text = "Добавить";
            this._buttonAdd.UseVisualStyleBackColor = true;
            this._buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // _labelName
            // 
            this._labelName.AutoSize = true;
            this._labelName.Location = new System.Drawing.Point(40, 68);
            this._labelName.Name = "_labelName";
            this._labelName.Size = new System.Drawing.Size(29, 13);
            this._labelName.TabIndex = 5;
            this._labelName.Text = "Имя";
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(75, 65);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(91, 20);
            this._textBoxName.TabIndex = 6;
            this._textBoxName.TextChanged += new System.EventHandler(this.TextBoxValueTextChanged);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 118);
            this.Controls.Add(this._textBoxName);
            this.Controls.Add(this._labelName);
            this.Controls.Add(this._buttonAdd);
            this.Controls.Add(this._labelValue);
            this.Controls.Add(this._textBoxValue);
            this.Controls.Add(this._labelSelectType);
            this.Controls.Add(this._comboBoxType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _comboBoxType;
        private System.Windows.Forms.Label _labelSelectType;
        private System.Windows.Forms.TextBox _textBoxValue;
        private System.Windows.Forms.Label _labelValue;
        private System.Windows.Forms.Button _buttonAdd;
        private System.Windows.Forms.Label _labelName;
        private System.Windows.Forms.TextBox _textBoxName;
    }
}