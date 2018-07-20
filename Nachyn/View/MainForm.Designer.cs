namespace View
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._panelCircuit = new System.Windows.Forms.Panel();
            this._menu = new System.Windows.Forms.MenuStrip();
            this._menuCircuit = new System.Windows.Forms.ToolStripMenuItem();
            this._menuCircuitRandomize = new System.Windows.Forms.ToolStripMenuItem();
            this._menuCircuitClear = new System.Windows.Forms.ToolStripMenuItem();
            this._menuCalculations = new System.Windows.Forms.ToolStripMenuItem();
            this._menuManual = new System.Windows.Forms.ToolStripMenuItem();
            this._labelInfoGreenColor = new System.Windows.Forms.Label();
            this._pictureBoxInfo = new System.Windows.Forms.PictureBox();
            this._labelInfo = new System.Windows.Forms.Label();
            this._groupBoxEditBranch = new System.Windows.Forms.GroupBox();
            this._labelValidateBranch = new System.Windows.Forms.Label();
            this._buttonAddBranch = new System.Windows.Forms.Button();
            this._textBoxNodeIn = new System.Windows.Forms.TextBox();
            this._buttonDeleteBranchSelected = new System.Windows.Forms.Button();
            this._labelNodeIn = new System.Windows.Forms.Label();
            this._groupBoxAddElement = new System.Windows.Forms.GroupBox();
            this._labelSelectType = new System.Windows.Forms.Label();
            this._comboBoxType = new System.Windows.Forms.ComboBox();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this._textBoxValue = new System.Windows.Forms.TextBox();
            this._labelName = new System.Windows.Forms.Label();
            this._labelValue = new System.Windows.Forms.Label();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._dataGridViewBranches = new System.Windows.Forms.DataGridView();
            this._checkBoxDeleteEmptyBranches = new System.Windows.Forms.CheckBox();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._branchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxInfo)).BeginInit();
            this._groupBoxEditBranch.SuspendLayout();
            this._groupBoxAddElement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewBranches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._branchBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _panelCircuit
            // 
            this._panelCircuit.AutoScroll = true;
            this._panelCircuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._panelCircuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panelCircuit.Location = new System.Drawing.Point(339, 33);
            this._panelCircuit.Name = "_panelCircuit";
            this._panelCircuit.Size = new System.Drawing.Size(580, 281);
            this._panelCircuit.TabIndex = 0;
            // 
            // _menu
            // 
            this._menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuCircuit,
            this._menuCalculations,
            this._menuManual});
            this._menu.Location = new System.Drawing.Point(0, 0);
            this._menu.Name = "_menu";
            this._menu.Size = new System.Drawing.Size(931, 24);
            this._menu.TabIndex = 1;
            this._menu.Text = "menuStrip1";
            // 
            // _menuCircuit
            // 
            this._menuCircuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._menuCircuit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuCircuitRandomize,
            this._menuCircuitClear});
            this._menuCircuit.Name = "_menuCircuit";
            this._menuCircuit.Size = new System.Drawing.Size(47, 20);
            this._menuCircuit.Text = "Цепь";
            // 
            // _menuCircuitRandomize
            // 
            this._menuCircuitRandomize.AutoSize = false;
            this._menuCircuitRandomize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._menuCircuitRandomize.Name = "_menuCircuitRandomize";
            this._menuCircuitRandomize.Size = new System.Drawing.Size(180, 22);
            this._menuCircuitRandomize.Text = "Сгенерировать";
            this._menuCircuitRandomize.Click += new System.EventHandler(this.MenuButtonRandomizeCircuit_Click);
            // 
            // _menuCircuitClear
            // 
            this._menuCircuitClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._menuCircuitClear.Name = "_menuCircuitClear";
            this._menuCircuitClear.Size = new System.Drawing.Size(157, 22);
            this._menuCircuitClear.Text = "Очистить";
            this._menuCircuitClear.Click += new System.EventHandler(this.MenuButtonClearCircuit_Click);
            // 
            // _menuCalculations
            // 
            this._menuCalculations.Name = "_menuCalculations";
            this._menuCalculations.Size = new System.Drawing.Size(65, 20);
            this._menuCalculations.Text = "Расчеты";
            this._menuCalculations.Click += new System.EventHandler(this.MenuButtonCalculate_Click);
            // 
            // _menuManual
            // 
            this._menuManual.Name = "_menuManual";
            this._menuManual.Size = new System.Drawing.Size(85, 20);
            this._menuManual.Text = "Инструкция";
            this._menuManual.Click += new System.EventHandler(this.MenuButtonHelp_Click);
            // 
            // _labelInfoGreenColor
            // 
            this._labelInfoGreenColor.AutoSize = true;
            this._labelInfoGreenColor.ForeColor = System.Drawing.SystemColors.Highlight;
            this._labelInfoGreenColor.Location = new System.Drawing.Point(394, 320);
            this._labelInfoGreenColor.Name = "_labelInfoGreenColor";
            this._labelInfoGreenColor.Size = new System.Drawing.Size(39, 13);
            this._labelInfoGreenColor.TabIndex = 13;
            this._labelInfoGreenColor.Text = "синим";
            // 
            // _pictureBoxInfo
            // 
            this._pictureBoxInfo.Image = global::View.Properties.Resources.Info;
            this._pictureBoxInfo.Location = new System.Drawing.Point(12, 320);
            this._pictureBoxInfo.Name = "_pictureBoxInfo";
            this._pictureBoxInfo.Size = new System.Drawing.Size(20, 15);
            this._pictureBoxInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._pictureBoxInfo.TabIndex = 17;
            this._pictureBoxInfo.TabStop = false;
            // 
            // _labelInfo
            // 
            this._labelInfo.AutoSize = true;
            this._labelInfo.Location = new System.Drawing.Point(30, 320);
            this._labelInfo.Name = "_labelInfo";
            this._labelInfo.Size = new System.Drawing.Size(889, 13);
            this._labelInfo.TabIndex = 16;
            this._labelInfo.Text = "Добавление элементов происходит в текущий узел, который выделен синим  цветом. Дл" +
    "я создания параллельного соединения используйте ветви с одинаковыми узлами.";
            // 
            // _groupBoxEditBranch
            // 
            this._groupBoxEditBranch.Controls.Add(this._labelValidateBranch);
            this._groupBoxEditBranch.Controls.Add(this._buttonAddBranch);
            this._groupBoxEditBranch.Controls.Add(this._textBoxNodeIn);
            this._groupBoxEditBranch.Controls.Add(this._buttonDeleteBranchSelected);
            this._groupBoxEditBranch.Controls.Add(this._labelNodeIn);
            this._groupBoxEditBranch.Location = new System.Drawing.Point(12, 27);
            this._groupBoxEditBranch.Name = "_groupBoxEditBranch";
            this._groupBoxEditBranch.Size = new System.Drawing.Size(173, 146);
            this._groupBoxEditBranch.TabIndex = 15;
            this._groupBoxEditBranch.TabStop = false;
            this._groupBoxEditBranch.Text = "Действия с ветвью";
            // 
            // _labelValidateBranch
            // 
            this._labelValidateBranch.AutoSize = true;
            this._labelValidateBranch.Location = new System.Drawing.Point(8, 100);
            this._labelValidateBranch.Name = "_labelValidateBranch";
            this._labelValidateBranch.Size = new System.Drawing.Size(98, 13);
            this._labelValidateBranch.TabIndex = 7;
            this._labelValidateBranch.Text = "Статус валидации";
            // 
            // _buttonAddBranch
            // 
            this._buttonAddBranch.Enabled = false;
            this._buttonAddBranch.Location = new System.Drawing.Point(71, 45);
            this._buttonAddBranch.Name = "_buttonAddBranch";
            this._buttonAddBranch.Size = new System.Drawing.Size(91, 23);
            this._buttonAddBranch.TabIndex = 4;
            this._buttonAddBranch.Text = "Добавить";
            this._buttonAddBranch.UseVisualStyleBackColor = true;
            this._buttonAddBranch.Click += new System.EventHandler(this.ButtonAddBranch_Click);
            // 
            // _textBoxNodeIn
            // 
            this._textBoxNodeIn.Location = new System.Drawing.Point(71, 19);
            this._textBoxNodeIn.Name = "_textBoxNodeIn";
            this._textBoxNodeIn.Size = new System.Drawing.Size(91, 20);
            this._textBoxNodeIn.TabIndex = 1;
            this._textBoxNodeIn.TextChanged += new System.EventHandler(this.TextBoxNodeIn_TextChanged);
            // 
            // _buttonDeleteBranchSelected
            // 
            this._buttonDeleteBranchSelected.Location = new System.Drawing.Point(71, 74);
            this._buttonDeleteBranchSelected.Name = "_buttonDeleteBranchSelected";
            this._buttonDeleteBranchSelected.Size = new System.Drawing.Size(91, 23);
            this._buttonDeleteBranchSelected.TabIndex = 5;
            this._buttonDeleteBranchSelected.Text = "Удалить";
            this._buttonDeleteBranchSelected.UseVisualStyleBackColor = true;
            this._buttonDeleteBranchSelected.Click += new System.EventHandler(this.ButtonDeleteBranchSelected_Click);
            // 
            // _labelNodeIn
            // 
            this._labelNodeIn.AutoSize = true;
            this._labelNodeIn.Location = new System.Drawing.Point(8, 22);
            this._labelNodeIn.Name = "_labelNodeIn";
            this._labelNodeIn.Size = new System.Drawing.Size(60, 13);
            this._labelNodeIn.TabIndex = 0;
            this._labelNodeIn.Text = "Вход. узел";
            // 
            // _groupBoxAddElement
            // 
            this._groupBoxAddElement.Controls.Add(this._labelSelectType);
            this._groupBoxAddElement.Controls.Add(this._comboBoxType);
            this._groupBoxAddElement.Controls.Add(this._textBoxName);
            this._groupBoxAddElement.Controls.Add(this._textBoxValue);
            this._groupBoxAddElement.Controls.Add(this._labelName);
            this._groupBoxAddElement.Controls.Add(this._labelValue);
            this._groupBoxAddElement.Controls.Add(this._buttonAdd);
            this._groupBoxAddElement.Location = new System.Drawing.Point(12, 179);
            this._groupBoxAddElement.Name = "_groupBoxAddElement";
            this._groupBoxAddElement.Size = new System.Drawing.Size(173, 135);
            this._groupBoxAddElement.TabIndex = 14;
            this._groupBoxAddElement.TabStop = false;
            this._groupBoxAddElement.Text = "Добавить элемент";
            // 
            // _labelSelectType
            // 
            this._labelSelectType.AutoSize = true;
            this._labelSelectType.Location = new System.Drawing.Point(8, 18);
            this._labelSelectType.Name = "_labelSelectType";
            this._labelSelectType.Size = new System.Drawing.Size(57, 26);
            this._labelSelectType.TabIndex = 1;
            this._labelSelectType.Text = "Выберите\r\nэлемент";
            // 
            // _comboBoxType
            // 
            this._comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxType.FormattingEnabled = true;
            this._comboBoxType.Location = new System.Drawing.Point(71, 23);
            this._comboBoxType.Name = "_comboBoxType";
            this._comboBoxType.Size = new System.Drawing.Size(91, 21);
            this._comboBoxType.TabIndex = 0;
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(71, 76);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(91, 20);
            this._textBoxName.TabIndex = 6;
            this._textBoxName.TextChanged += new System.EventHandler(this.TextBoxValue_TextChanged);
            // 
            // _textBoxValue
            // 
            this._textBoxValue.Location = new System.Drawing.Point(71, 50);
            this._textBoxValue.Name = "_textBoxValue";
            this._textBoxValue.Size = new System.Drawing.Size(91, 20);
            this._textBoxValue.TabIndex = 2;
            this._textBoxValue.TextChanged += new System.EventHandler(this.TextBoxValue_TextChanged);
            // 
            // _labelName
            // 
            this._labelName.AutoSize = true;
            this._labelName.Location = new System.Drawing.Point(8, 79);
            this._labelName.Name = "_labelName";
            this._labelName.Size = new System.Drawing.Size(29, 13);
            this._labelName.TabIndex = 5;
            this._labelName.Text = "Имя";
            // 
            // _labelValue
            // 
            this._labelValue.AutoSize = true;
            this._labelValue.Location = new System.Drawing.Point(8, 53);
            this._labelValue.Name = "_labelValue";
            this._labelValue.Size = new System.Drawing.Size(53, 13);
            this._labelValue.TabIndex = 3;
            this._labelValue.Text = "Номинал";
            // 
            // _buttonAdd
            // 
            this._buttonAdd.Enabled = false;
            this._buttonAdd.Location = new System.Drawing.Point(71, 102);
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Size = new System.Drawing.Size(91, 23);
            this._buttonAdd.TabIndex = 4;
            this._buttonAdd.Text = "Добавить";
            this._buttonAdd.UseVisualStyleBackColor = true;
            this._buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // _dataGridViewBranches
            // 
            this._dataGridViewBranches.AllowUserToAddRows = false;
            this._dataGridViewBranches.AllowUserToDeleteRows = false;
            this._dataGridViewBranches.AllowUserToResizeColumns = false;
            this._dataGridViewBranches.AllowUserToResizeRows = false;
            this._dataGridViewBranches.AutoGenerateColumns = false;
            this._dataGridViewBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewBranches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyDataGridViewTextBoxColumn});
            this._dataGridViewBranches.DataSource = this._branchBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewBranches.DefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridViewBranches.Location = new System.Drawing.Point(191, 33);
            this._dataGridViewBranches.MultiSelect = false;
            this._dataGridViewBranches.Name = "_dataGridViewBranches";
            this._dataGridViewBranches.ReadOnly = true;
            this._dataGridViewBranches.RowHeadersVisible = false;
            this._dataGridViewBranches.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._dataGridViewBranches.RowTemplate.ReadOnly = true;
            this._dataGridViewBranches.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewBranches.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._dataGridViewBranches.ShowCellErrors = false;
            this._dataGridViewBranches.ShowCellToolTips = false;
            this._dataGridViewBranches.ShowEditingIcon = false;
            this._dataGridViewBranches.ShowRowErrors = false;
            this._dataGridViewBranches.Size = new System.Drawing.Size(142, 258);
            this._dataGridViewBranches.TabIndex = 12;
            // 
            // _checkBoxDeleteEmptyBranches
            // 
            this._checkBoxDeleteEmptyBranches.AutoSize = true;
            this._checkBoxDeleteEmptyBranches.Checked = true;
            this._checkBoxDeleteEmptyBranches.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxDeleteEmptyBranches.Location = new System.Drawing.Point(191, 297);
            this._checkBoxDeleteEmptyBranches.Name = "_checkBoxDeleteEmptyBranches";
            this._checkBoxDeleteEmptyBranches.Size = new System.Drawing.Size(140, 17);
            this._checkBoxDeleteEmptyBranches.TabIndex = 18;
            this._checkBoxDeleteEmptyBranches.Text = "Удалять пустые ветви";
            this._checkBoxDeleteEmptyBranches.UseVisualStyleBackColor = true;
            this._checkBoxDeleteEmptyBranches.CheckedChanged += new System.EventHandler(this.CheckBoxDeleteEmptyBranches_CheckedChanged);
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "Ветвь между узлами";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.ReadOnly = true;
            this.keyDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.keyDataGridViewTextBoxColumn.Width = 140;
            // 
            // _branchBindingSource
            // 
            this._branchBindingSource.DataSource = typeof(Model.Branch);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 342);
            this.Controls.Add(this._checkBoxDeleteEmptyBranches);
            this.Controls.Add(this._dataGridViewBranches);
            this.Controls.Add(this._labelInfoGreenColor);
            this.Controls.Add(this._pictureBoxInfo);
            this.Controls.Add(this._labelInfo);
            this.Controls.Add(this._groupBoxEditBranch);
            this.Controls.Add(this._groupBoxAddElement);
            this.Controls.Add(this._panelCircuit);
            this.Controls.Add(this._menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this._menu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчет импедансов";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this._menu.ResumeLayout(false);
            this._menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxInfo)).EndInit();
            this._groupBoxEditBranch.ResumeLayout(false);
            this._groupBoxEditBranch.PerformLayout();
            this._groupBoxAddElement.ResumeLayout(false);
            this._groupBoxAddElement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewBranches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._branchBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _panelCircuit;
        private System.Windows.Forms.MenuStrip _menu;
        private System.Windows.Forms.ToolStripMenuItem _menuCircuit;
        private System.Windows.Forms.ToolStripMenuItem _menuCircuitRandomize;
        private System.Windows.Forms.ToolStripMenuItem _menuCircuitClear;
        private System.Windows.Forms.ToolStripMenuItem _menuCalculations;
        private System.Windows.Forms.ToolStripMenuItem _menuManual;
        private System.Windows.Forms.Label _labelInfoGreenColor;
        private System.Windows.Forms.PictureBox _pictureBoxInfo;
        private System.Windows.Forms.Label _labelInfo;
        private System.Windows.Forms.GroupBox _groupBoxEditBranch;
        private System.Windows.Forms.Label _labelValidateBranch;
        private System.Windows.Forms.Button _buttonAddBranch;
        private System.Windows.Forms.TextBox _textBoxNodeIn;
        private System.Windows.Forms.Button _buttonDeleteBranchSelected;
        private System.Windows.Forms.Label _labelNodeIn;
        private System.Windows.Forms.GroupBox _groupBoxAddElement;
        private System.Windows.Forms.Label _labelSelectType;
        private System.Windows.Forms.ComboBox _comboBoxType;
        private System.Windows.Forms.TextBox _textBoxName;
        private System.Windows.Forms.TextBox _textBoxValue;
        private System.Windows.Forms.Label _labelName;
        private System.Windows.Forms.Label _labelValue;
        private System.Windows.Forms.Button _buttonAdd;
        private System.Windows.Forms.BindingSource _branchBindingSource;
        private System.Windows.Forms.DataGridView _dataGridViewBranches;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox _checkBoxDeleteEmptyBranches;
    }
}