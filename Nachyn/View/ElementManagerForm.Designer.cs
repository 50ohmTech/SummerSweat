namespace View
{
    partial class ElementManagerForm
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
            this._comboBoxType = new System.Windows.Forms.ComboBox();
            this._labelSelectType = new System.Windows.Forms.Label();
            this._textBoxValue = new System.Windows.Forms.TextBox();
            this._labelValue = new System.Windows.Forms.Label();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._labelName = new System.Windows.Forms.Label();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this._dataGridViewBranches = new System.Windows.Forms.DataGridView();
            this._groupBoxAddElement = new System.Windows.Forms.GroupBox();
            this._groupBoxEditBranch = new System.Windows.Forms.GroupBox();
            this._labelValidateBranch = new System.Windows.Forms.Label();
            this._buttonAddBranch = new System.Windows.Forms.Button();
            this._textBoxNodeIn = new System.Windows.Forms.TextBox();
            this._buttonDeleteBranchSelected = new System.Windows.Forms.Button();
            this._labelNodeIn = new System.Windows.Forms.Label();
            this._labelInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._labelInfoGreenColor = new System.Windows.Forms.Label();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._branchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewBranches)).BeginInit();
            this._groupBoxAddElement.SuspendLayout();
            this._groupBoxEditBranch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._branchBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // _labelSelectType
            // 
            this._labelSelectType.AutoSize = true;
            this._labelSelectType.Location = new System.Drawing.Point(8, 18);
            this._labelSelectType.Name = "_labelSelectType";
            this._labelSelectType.Size = new System.Drawing.Size(57, 26);
            this._labelSelectType.TabIndex = 1;
            this._labelSelectType.Text = "Выберите\r\nэлемент";
            // 
            // _textBoxValue
            // 
            this._textBoxValue.Location = new System.Drawing.Point(71, 50);
            this._textBoxValue.Name = "_textBoxValue";
            this._textBoxValue.Size = new System.Drawing.Size(91, 20);
            this._textBoxValue.TabIndex = 2;
            this._textBoxValue.TextChanged += new System.EventHandler(this.TextBoxValue_TextChanged);
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
            // _labelName
            // 
            this._labelName.AutoSize = true;
            this._labelName.Location = new System.Drawing.Point(8, 79);
            this._labelName.Name = "_labelName";
            this._labelName.Size = new System.Drawing.Size(29, 13);
            this._labelName.TabIndex = 5;
            this._labelName.Text = "Имя";
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(71, 76);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(91, 20);
            this._textBoxName.TabIndex = 6;
            this._textBoxName.TextChanged += new System.EventHandler(this.TextBoxValue_TextChanged);
            // 
            // _dataGridViewBranches
            // 
            this._dataGridViewBranches.AllowUserToAddRows = false;
            this._dataGridViewBranches.AllowUserToDeleteRows = false;
            this._dataGridViewBranches.AutoGenerateColumns = false;
            this._dataGridViewBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewBranches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyDataGridViewTextBoxColumn});
            this._dataGridViewBranches.DataSource = this._branchBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewBranches.DefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridViewBranches.Location = new System.Drawing.Point(190, 18);
            this._dataGridViewBranches.MultiSelect = false;
            this._dataGridViewBranches.Name = "_dataGridViewBranches";
            this._dataGridViewBranches.ReadOnly = true;
            this._dataGridViewBranches.RowHeadersVisible = false;
            this._dataGridViewBranches.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._dataGridViewBranches.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LawnGreen;
            this._dataGridViewBranches.RowTemplate.ReadOnly = true;
            this._dataGridViewBranches.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewBranches.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._dataGridViewBranches.ShowCellErrors = false;
            this._dataGridViewBranches.ShowCellToolTips = false;
            this._dataGridViewBranches.ShowEditingIcon = false;
            this._dataGridViewBranches.ShowRowErrors = false;
            this._dataGridViewBranches.Size = new System.Drawing.Size(143, 281);
            this._dataGridViewBranches.TabIndex = 7;
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
            this._groupBoxAddElement.Location = new System.Drawing.Point(12, 12);
            this._groupBoxAddElement.Name = "_groupBoxAddElement";
            this._groupBoxAddElement.Size = new System.Drawing.Size(173, 135);
            this._groupBoxAddElement.TabIndex = 8;
            this._groupBoxAddElement.TabStop = false;
            this._groupBoxAddElement.Text = "Добавить элемент";
            // 
            // _groupBoxEditBranch
            // 
            this._groupBoxEditBranch.Controls.Add(this._labelValidateBranch);
            this._groupBoxEditBranch.Controls.Add(this._buttonAddBranch);
            this._groupBoxEditBranch.Controls.Add(this._textBoxNodeIn);
            this._groupBoxEditBranch.Controls.Add(this._buttonDeleteBranchSelected);
            this._groupBoxEditBranch.Controls.Add(this._labelNodeIn);
            this._groupBoxEditBranch.Location = new System.Drawing.Point(12, 153);
            this._groupBoxEditBranch.Name = "_groupBoxEditBranch";
            this._groupBoxEditBranch.Size = new System.Drawing.Size(173, 146);
            this._groupBoxEditBranch.TabIndex = 9;
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
            // _labelInfo
            // 
            this._labelInfo.AutoSize = true;
            this._labelInfo.Location = new System.Drawing.Point(44, 302);
            this._labelInfo.Name = "_labelInfo";
            this._labelInfo.Size = new System.Drawing.Size(289, 52);
            this._labelInfo.TabIndex = 10;
            this._labelInfo.Text = "Добавление элементов происходит в текущий узел, \r\nкоторый выделен зеленым  цветом" +
    ".\r\nДля создания параллельного соединения используйте\r\nветви с одинаковыми узлами" +
    ".";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::View.Properties.Resources.Info;
            this.pictureBox1.Location = new System.Drawing.Point(12, 305);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // _labelInfoGreenColor
            // 
            this._labelInfoGreenColor.AutoSize = true;
            this._labelInfoGreenColor.ForeColor = System.Drawing.Color.Green;
            this._labelInfoGreenColor.Location = new System.Drawing.Point(137, 315);
            this._labelInfoGreenColor.Name = "_labelInfoGreenColor";
            this._labelInfoGreenColor.Size = new System.Drawing.Size(53, 13);
            this._labelInfoGreenColor.TabIndex = 8;
            this._labelInfoGreenColor.Text = "зеленым";
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
            // ElementManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 363);
            this.Controls.Add(this._labelInfoGreenColor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._labelInfo);
            this.Controls.Add(this._groupBoxEditBranch);
            this.Controls.Add(this._groupBoxAddElement);
            this.Controls.Add(this._dataGridViewBranches);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ElementManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление элементами";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewBranches)).EndInit();
            this._groupBoxAddElement.ResumeLayout(false);
            this._groupBoxAddElement.PerformLayout();
            this._groupBoxEditBranch.ResumeLayout(false);
            this._groupBoxEditBranch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._branchBindingSource)).EndInit();
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
        private System.Windows.Forms.DataGridView _dataGridViewBranches;
        private System.Windows.Forms.BindingSource _branchBindingSource;
        private System.Windows.Forms.GroupBox _groupBoxAddElement;
        private System.Windows.Forms.GroupBox _groupBoxEditBranch;
        private System.Windows.Forms.Button _buttonAddBranch;
        private System.Windows.Forms.TextBox _textBoxNodeIn;
        private System.Windows.Forms.Label _labelNodeIn;
        private System.Windows.Forms.Button _buttonDeleteBranchSelected;
        private System.Windows.Forms.Label _labelValidateBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label _labelInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label _labelInfoGreenColor;
    }
}