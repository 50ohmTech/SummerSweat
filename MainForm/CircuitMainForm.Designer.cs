namespace MainForm
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
            this._addButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._calculateImpedanceButton = new System.Windows.Forms.Button();
            this._nominalTextBox = new System.Windows.Forms.TextBox();
            this._selectingCircuitComboBox = new System.Windows.Forms.ComboBox();
            this._nodeComboBox = new System.Windows.Forms.ComboBox();
            this._addElementLable = new System.Windows.Forms.Label();
            this._connectionComboBox = new System.Windows.Forms.ComboBox();
            this._treeView = new System.Windows.Forms.TreeView();
            this._circuitPictureBox = new System.Windows.Forms.PictureBox();
            this._choiceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._circuitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(15, 258);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(80, 23);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "Добавить";
            this._addButton.UseVisualStyleBackColor = true;
            // 
            // _deleteButton
            // 
            this._deleteButton.Location = new System.Drawing.Point(105, 258);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(80, 23);
            this._deleteButton.TabIndex = 1;
            this._deleteButton.Text = "Удалить";
            this._deleteButton.UseVisualStyleBackColor = true;
            // 
            // _calculateImpedanceButton
            // 
            this._calculateImpedanceButton.Location = new System.Drawing.Point(15, 287);
            this._calculateImpedanceButton.Name = "_calculateImpedanceButton";
            this._calculateImpedanceButton.Size = new System.Drawing.Size(170, 23);
            this._calculateImpedanceButton.TabIndex = 2;
            this._calculateImpedanceButton.Text = "Рассчитать импеданс";
            this._calculateImpedanceButton.UseVisualStyleBackColor = true;
            this._calculateImpedanceButton.Click += new System.EventHandler(this.CalculateImpedanceButton_Click);
            // 
            // _nominalTextBox
            // 
            this._nominalTextBox.Location = new System.Drawing.Point(15, 200);
            this._nominalTextBox.Name = "_nominalTextBox";
            this._nominalTextBox.Size = new System.Drawing.Size(170, 20);
            this._nominalTextBox.TabIndex = 3;
            this._nominalTextBox.Text = "Введите номинал";
            // 
            // _selectingCircuitComboBox
            // 
            this._selectingCircuitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._selectingCircuitComboBox.FormattingEnabled = true;
            this._selectingCircuitComboBox.Location = new System.Drawing.Point(94, 9);
            this._selectingCircuitComboBox.Name = "_selectingCircuitComboBox";
            this._selectingCircuitComboBox.Size = new System.Drawing.Size(91, 21);
            this._selectingCircuitComboBox.TabIndex = 4;
            this._selectingCircuitComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectingCircuitComboBox_SelectedIndexChanged);
            // 
            // _nodeComboBox
            // 
            this._nodeComboBox.FormattingEnabled = true;
            this._nodeComboBox.Items.AddRange(new object[] {
            "Резистор",
            "Катушка",
            "Конденсатор"});
            this._nodeComboBox.Location = new System.Drawing.Point(15, 173);
            this._nodeComboBox.Name = "_nodeComboBox";
            this._nodeComboBox.Size = new System.Drawing.Size(170, 21);
            this._nodeComboBox.TabIndex = 7;
            this._nodeComboBox.Text = "Выберите тип элемента";
            // 
            // _addElementLable
            // 
            this._addElementLable.AutoSize = true;
            this._addElementLable.Location = new System.Drawing.Point(12, 157);
            this._addElementLable.Name = "_addElementLable";
            this._addElementLable.Size = new System.Drawing.Size(103, 13);
            this._addElementLable.TabIndex = 8;
            this._addElementLable.Text = "Добавить элемент";
            // 
            // _connectionComboBox
            // 
            this._connectionComboBox.FormattingEnabled = true;
            this._connectionComboBox.Items.AddRange(new object[] {
            "Последовательно",
            "Параллельно"});
            this._connectionComboBox.Location = new System.Drawing.Point(15, 226);
            this._connectionComboBox.Name = "_connectionComboBox";
            this._connectionComboBox.Size = new System.Drawing.Size(170, 21);
            this._connectionComboBox.TabIndex = 9;
            this._connectionComboBox.Text = "Выберите тип связи";
            // 
            // _treeView
            // 
            this._treeView.Location = new System.Drawing.Point(15, 36);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(170, 118);
            this._treeView.TabIndex = 11;
            // 
            // _circuitPictureBox
            // 
            this._circuitPictureBox.Location = new System.Drawing.Point(193, 12);
            this._circuitPictureBox.Name = "_circuitPictureBox";
            this._circuitPictureBox.Size = new System.Drawing.Size(333, 297);
            this._circuitPictureBox.TabIndex = 12;
            this._circuitPictureBox.TabStop = false;
            // 
            // _choiceLabel
            // 
            this._choiceLabel.AutoSize = true;
            this._choiceLabel.Location = new System.Drawing.Point(12, 12);
            this._choiceLabel.Name = "_choiceLabel";
            this._choiceLabel.Size = new System.Drawing.Size(87, 13);
            this._choiceLabel.TabIndex = 13;
            this._choiceLabel.Text = "Выберите цепь:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 324);
            this.Controls.Add(this._choiceLabel);
            this.Controls.Add(this._circuitPictureBox);
            this.Controls.Add(this._treeView);
            this.Controls.Add(this._connectionComboBox);
            this.Controls.Add(this._addElementLable);
            this.Controls.Add(this._nodeComboBox);
            this.Controls.Add(this._selectingCircuitComboBox);
            this.Controls.Add(this._nominalTextBox);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this._deleteButton);
            this.Controls.Add(this._calculateImpedanceButton);
            this.MaximumSize = new System.Drawing.Size(554, 363);
            this.MinimumSize = new System.Drawing.Size(554, 363);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CircuitMainForm";
            ((System.ComponentModel.ISupportInitialize)(this._circuitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.Button _calculateImpedanceButton;
        private System.Windows.Forms.TextBox _nominalTextBox;
        private System.Windows.Forms.ComboBox _selectingCircuitComboBox;
        private System.Windows.Forms.ComboBox _nodeComboBox;
        private System.Windows.Forms.Label _addElementLable;
        private System.Windows.Forms.ComboBox _connectionComboBox;
        private System.Windows.Forms.TreeView _treeView;
        private System.Windows.Forms.PictureBox _circuitPictureBox;
        private System.Windows.Forms.Label _choiceLabel;
    }
}

