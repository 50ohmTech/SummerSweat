namespace View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._comboBoxSelectCircuit = new System.Windows.Forms.ComboBox();
            this._labelSelectCircuit = new System.Windows.Forms.Label();
            this._buttonClearCircuit = new System.Windows.Forms.Button();
            this._treeViewCircuit = new System.Windows.Forms.TreeView();
            this._labelAddElement = new System.Windows.Forms.Label();
            this._comboBoxAddElementType = new System.Windows.Forms.ComboBox();
            this._comboBoxAddElementConnectionType = new System.Windows.Forms.ComboBox();
            this._textBoxAddElementValue = new System.Windows.Forms.TextBox();
            this._buttonAddElement = new System.Windows.Forms.Button();
            this._buttonRemoveElement = new System.Windows.Forms.Button();
            this._buttonCalculateFormShow = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _comboBoxSelectCircuit
            // 
            this._comboBoxSelectCircuit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxSelectCircuit.FormattingEnabled = true;
            this._comboBoxSelectCircuit.Location = new System.Drawing.Point(88, 12);
            this._comboBoxSelectCircuit.Name = "_comboBoxSelectCircuit";
            this._comboBoxSelectCircuit.Size = new System.Drawing.Size(117, 21);
            this._comboBoxSelectCircuit.TabIndex = 0;
            // 
            // _labelSelectCircuit
            // 
            this._labelSelectCircuit.AutoSize = true;
            this._labelSelectCircuit.Location = new System.Drawing.Point(12, 15);
            this._labelSelectCircuit.Name = "_labelSelectCircuit";
            this._labelSelectCircuit.Size = new System.Drawing.Size(70, 13);
            this._labelSelectCircuit.TabIndex = 1;
            this._labelSelectCircuit.Text = "Выбор цепи:";
            // 
            // _buttonClearCircuit
            // 
            this._buttonClearCircuit.Location = new System.Drawing.Point(15, 39);
            this._buttonClearCircuit.Name = "_buttonClearCircuit";
            this._buttonClearCircuit.Size = new System.Drawing.Size(190, 23);
            this._buttonClearCircuit.TabIndex = 2;
            this._buttonClearCircuit.Text = "Очистить цепь";
            this._buttonClearCircuit.UseVisualStyleBackColor = true;
            // 
            // _treeViewCircuit
            // 
            this._treeViewCircuit.Location = new System.Drawing.Point(15, 68);
            this._treeViewCircuit.Name = "_treeViewCircuit";
            this._treeViewCircuit.Size = new System.Drawing.Size(190, 183);
            this._treeViewCircuit.TabIndex = 3;
            // 
            // _labelAddElement
            // 
            this._labelAddElement.AutoSize = true;
            this._labelAddElement.Location = new System.Drawing.Point(12, 260);
            this._labelAddElement.Name = "_labelAddElement";
            this._labelAddElement.Size = new System.Drawing.Size(103, 13);
            this._labelAddElement.TabIndex = 4;
            this._labelAddElement.Text = "Добавить элемент";
            // 
            // _comboBoxAddElementType
            // 
            this._comboBoxAddElementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxAddElementType.FormattingEnabled = true;
            this._comboBoxAddElementType.Location = new System.Drawing.Point(15, 303);
            this._comboBoxAddElementType.Name = "_comboBoxAddElementType";
            this._comboBoxAddElementType.Size = new System.Drawing.Size(190, 21);
            this._comboBoxAddElementType.TabIndex = 5;
            // 
            // _comboBoxAddElementConnectionType
            // 
            this._comboBoxAddElementConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxAddElementConnectionType.FormattingEnabled = true;
            this._comboBoxAddElementConnectionType.Location = new System.Drawing.Point(15, 276);
            this._comboBoxAddElementConnectionType.Name = "_comboBoxAddElementConnectionType";
            this._comboBoxAddElementConnectionType.Size = new System.Drawing.Size(190, 21);
            this._comboBoxAddElementConnectionType.TabIndex = 6;
            // 
            // _textBoxAddElementValue
            // 
            this._textBoxAddElementValue.Location = new System.Drawing.Point(15, 330);
            this._textBoxAddElementValue.Name = "_textBoxAddElementValue";
            this._textBoxAddElementValue.Size = new System.Drawing.Size(190, 20);
            this._textBoxAddElementValue.TabIndex = 7;
            // 
            // _buttonAddElement
            // 
            this._buttonAddElement.Location = new System.Drawing.Point(15, 356);
            this._buttonAddElement.Name = "_buttonAddElement";
            this._buttonAddElement.Size = new System.Drawing.Size(92, 23);
            this._buttonAddElement.TabIndex = 8;
            this._buttonAddElement.Text = "Добавить";
            this._buttonAddElement.UseVisualStyleBackColor = true;
            // 
            // _buttonRemoveElement
            // 
            this._buttonRemoveElement.Location = new System.Drawing.Point(113, 356);
            this._buttonRemoveElement.Name = "_buttonRemoveElement";
            this._buttonRemoveElement.Size = new System.Drawing.Size(92, 23);
            this._buttonRemoveElement.TabIndex = 9;
            this._buttonRemoveElement.Text = "Удалить";
            this._buttonRemoveElement.UseVisualStyleBackColor = true;
            // 
            // _buttonCalculateFormShow
            // 
            this._buttonCalculateFormShow.Location = new System.Drawing.Point(15, 390);
            this._buttonCalculateFormShow.Name = "_buttonCalculateFormShow";
            this._buttonCalculateFormShow.Size = new System.Drawing.Size(190, 23);
            this._buttonCalculateFormShow.TabIndex = 10;
            this._buttonCalculateFormShow.Text = "Открыть калькулятор";
            this._buttonCalculateFormShow.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(211, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(577, 401);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 427);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._buttonCalculateFormShow);
            this.Controls.Add(this._buttonRemoveElement);
            this.Controls.Add(this._buttonAddElement);
            this.Controls.Add(this._textBoxAddElementValue);
            this.Controls.Add(this._comboBoxAddElementConnectionType);
            this.Controls.Add(this._comboBoxAddElementType);
            this.Controls.Add(this._labelAddElement);
            this.Controls.Add(this._treeViewCircuit);
            this.Controls.Add(this._buttonClearCircuit);
            this.Controls.Add(this._labelSelectCircuit);
            this.Controls.Add(this._comboBoxSelectCircuit);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _comboBoxSelectCircuit;
        private System.Windows.Forms.Label _labelSelectCircuit;
        private System.Windows.Forms.Button _buttonClearCircuit;
        private System.Windows.Forms.TreeView _treeViewCircuit;
        private System.Windows.Forms.Label _labelAddElement;
        private System.Windows.Forms.ComboBox _comboBoxAddElementType;
        private System.Windows.Forms.ComboBox _comboBoxAddElementConnectionType;
        private System.Windows.Forms.TextBox _textBoxAddElementValue;
        private System.Windows.Forms.Button _buttonAddElement;
        private System.Windows.Forms.Button _buttonRemoveElement;
        private System.Windows.Forms.Button _buttonCalculateFormShow;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

