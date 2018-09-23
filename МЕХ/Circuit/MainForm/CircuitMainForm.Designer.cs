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
			this.components = new System.ComponentModel.Container();
			this.AddButton = new System.Windows.Forms.Button();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.CalculateImpedanceButton = new System.Windows.Forms.Button();
			this.SelectingCircuitComboBox = new System.Windows.Forms.ComboBox();
			this.SelectingCircuitLabel = new System.Windows.Forms.Label();
			this.treeView = new System.Windows.Forms.TreeView();
			this.NadeComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this._textBoxAddElementName = new System.Windows.Forms.TextBox();
			this._textBoxAddElementValue = new System.Windows.Forms.TextBox();
			this.circuitDrawLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.ModufyButton = new System.Windows.Forms.Button();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(157, 492);
			this.AddButton.Margin = new System.Windows.Forms.Padding(4);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(128, 52);
			this.AddButton.TabIndex = 0;
			this.AddButton.Text = "Добавить";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// DeleteButton
			// 
			this.DeleteButton.Location = new System.Drawing.Point(157, 552);
			this.DeleteButton.Margin = new System.Windows.Forms.Padding(4);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(128, 28);
			this.DeleteButton.TabIndex = 1;
			this.DeleteButton.Text = "Удалить";
			this.DeleteButton.UseVisualStyleBackColor = true;
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// CalculateImpedanceButton
			// 
			this.CalculateImpedanceButton.Location = new System.Drawing.Point(13, 588);
			this.CalculateImpedanceButton.Margin = new System.Windows.Forms.Padding(4);
			this.CalculateImpedanceButton.Name = "CalculateImpedanceButton";
			this.CalculateImpedanceButton.Size = new System.Drawing.Size(272, 28);
			this.CalculateImpedanceButton.TabIndex = 2;
			this.CalculateImpedanceButton.Text = "Рассчитать импеданс";
			this.CalculateImpedanceButton.UseVisualStyleBackColor = true;
			this.CalculateImpedanceButton.Click += new System.EventHandler(this.CalculateImpedanceButton_Click);
			// 
			// SelectingCircuitComboBox
			// 
			this.SelectingCircuitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SelectingCircuitComboBox.FormattingEnabled = true;
			this.SelectingCircuitComboBox.Location = new System.Drawing.Point(113, 11);
			this.SelectingCircuitComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.SelectingCircuitComboBox.Name = "SelectingCircuitComboBox";
			this.SelectingCircuitComboBox.Size = new System.Drawing.Size(172, 24);
			this.SelectingCircuitComboBox.TabIndex = 4;
			this.SelectingCircuitComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectingCircuitComboBox_SelectedIndexChanged);
			// 
			// SelectingCircuitLabel
			// 
			this.SelectingCircuitLabel.AutoSize = true;
			this.SelectingCircuitLabel.Location = new System.Drawing.Point(16, 15);
			this.SelectingCircuitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.SelectingCircuitLabel.Name = "SelectingCircuitLabel";
			this.SelectingCircuitLabel.Size = new System.Drawing.Size(87, 17);
			this.SelectingCircuitLabel.TabIndex = 5;
			this.SelectingCircuitLabel.Text = "Выбор цепи";
			// 
			// treeView
			// 
			this.treeView.Location = new System.Drawing.Point(20, 44);
			this.treeView.Margin = new System.Windows.Forms.Padding(4);
			this.treeView.MinimumSize = new System.Drawing.Size(225, 136);
			this.treeView.Name = "treeView";
			this.treeView.Size = new System.Drawing.Size(265, 392);
			this.treeView.TabIndex = 6;
			// 
			// NadeComboBox
			// 
			this.NadeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.NadeComboBox.Items.AddRange(new object[] {
            "Резистор",
            "Катушка индуктивности",
            "Конденсатор",
            "Параллельное соединение",
            "Последовательное соединение"});
			this.NadeComboBox.Location = new System.Drawing.Point(13, 460);
			this.NadeComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.NadeComboBox.Name = "NadeComboBox";
			this.NadeComboBox.Size = new System.Drawing.Size(272, 24);
			this.NadeComboBox.TabIndex = 7;
			this.NadeComboBox.SelectedIndexChanged += new System.EventHandler(this.NadeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 440);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(131, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "Добавить элемент";
			// 
			// _textBoxAddElementName
			// 
			this._textBoxAddElementName.ForeColor = System.Drawing.SystemColors.GrayText;
			this._textBoxAddElementName.Location = new System.Drawing.Point(13, 492);
			this._textBoxAddElementName.Margin = new System.Windows.Forms.Padding(4);
			this._textBoxAddElementName.Name = "_textBoxAddElementName";
			this._textBoxAddElementName.Size = new System.Drawing.Size(121, 22);
			this._textBoxAddElementName.TabIndex = 13;
			this._textBoxAddElementName.Text = "Имя";
			this._textBoxAddElementName.TextChanged += new System.EventHandler(this._textBox_TextChanged);
			this._textBoxAddElementName.Enter += new System.EventHandler(this._textBoxAddElementName_Enter);
			// 
			// _textBoxAddElementValue
			// 
			this._textBoxAddElementValue.ForeColor = System.Drawing.SystemColors.GrayText;
			this._textBoxAddElementValue.Location = new System.Drawing.Point(13, 522);
			this._textBoxAddElementValue.Margin = new System.Windows.Forms.Padding(4);
			this._textBoxAddElementValue.Name = "_textBoxAddElementValue";
			this._textBoxAddElementValue.Size = new System.Drawing.Size(121, 22);
			this._textBoxAddElementValue.TabIndex = 14;
			this._textBoxAddElementValue.Text = "Номинал";
			this._textBoxAddElementValue.TextChanged += new System.EventHandler(this._textBox_TextChanged);
			this._textBoxAddElementValue.Enter += new System.EventHandler(this._textBoxAddElementValue_Enter);
			// 
			// circuitDrawLayoutPanel
			// 
			this.circuitDrawLayoutPanel.AutoScroll = true;
			this.circuitDrawLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.circuitDrawLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.circuitDrawLayoutPanel.Location = new System.Drawing.Point(292, 11);
			this.circuitDrawLayoutPanel.Name = "circuitDrawLayoutPanel";
			this.circuitDrawLayoutPanel.Size = new System.Drawing.Size(804, 605);
			this.circuitDrawLayoutPanel.TabIndex = 15;
			// 
			// ModufyButton
			// 
			this.ModufyButton.Location = new System.Drawing.Point(12, 552);
			this.ModufyButton.Margin = new System.Windows.Forms.Padding(4);
			this.ModufyButton.Name = "ModufyButton";
			this.ModufyButton.Size = new System.Drawing.Size(122, 28);
			this.ModufyButton.TabIndex = 16;
			this.ModufyButton.Text = "Изменить";
			this.ModufyButton.UseVisualStyleBackColor = true;
			this.ModufyButton.Click += new System.EventHandler(this.ModufyButton_Click);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1108, 624);
			this.Controls.Add(this.ModufyButton);
			this.Controls.Add(this.circuitDrawLayoutPanel);
			this.Controls.Add(this._textBoxAddElementValue);
			this.Controls.Add(this._textBoxAddElementName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.NadeComboBox);
			this.Controls.Add(this.treeView);
			this.Controls.Add(this.SelectingCircuitLabel);
			this.Controls.Add(this.SelectingCircuitComboBox);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.DeleteButton);
			this.Controls.Add(this.CalculateImpedanceButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(733, 409);
			this.Name = "MainForm";
			this.Text = "CircuitMainForm";
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CalculateImpedanceButton;
        private System.Windows.Forms.ComboBox SelectingCircuitComboBox;
        private System.Windows.Forms.Label SelectingCircuitLabel;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ComboBox NadeComboBox;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox _textBoxAddElementName;
		private System.Windows.Forms.TextBox _textBoxAddElementValue;
		private System.Windows.Forms.FlowLayoutPanel circuitDrawLayoutPanel;
		private System.Windows.Forms.Button ModufyButton;
		private System.Windows.Forms.ErrorProvider errorProvider;
	}
}

