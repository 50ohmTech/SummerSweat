namespace View
{
    partial class ControlPanel
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
            this._comboBoxType = new System.Windows.Forms.ComboBox();
            this._labelSelectType = new System.Windows.Forms.Label();
            this._textBoxValue = new System.Windows.Forms.TextBox();
            this._labelValue = new System.Windows.Forms.Label();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._labelName = new System.Windows.Forms.Label();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this._groupBoxAddElement = new System.Windows.Forms.GroupBox();
            this._groupBoxEditBranch = new System.Windows.Forms.GroupBox();
            this._buttonDeleteBranchSelected = new System.Windows.Forms.Button();
            this._buttonAddBranch = new System.Windows.Forms.Button();
            this._labelNodeOut = new System.Windows.Forms.Label();
            this._textBoxNodeOut = new System.Windows.Forms.TextBox();
            this._textBoxNodeIn = new System.Windows.Forms.TextBox();
            this._labelNodeIn = new System.Windows.Forms.Label();
            this.nodeInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nodeOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._branchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
            this._groupBoxAddElement.SuspendLayout();
            this._groupBoxEditBranch.SuspendLayout();
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
            this._labelValue.Location = new System.Drawing.Point(12, 53);
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
            this._labelName.Location = new System.Drawing.Point(36, 79);
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
            // _dataGridView1
            // 
            this._dataGridView1.AllowUserToAddRows = false;
            this._dataGridView1.AllowUserToDeleteRows = false;
            this._dataGridView1.AutoGenerateColumns = false;
            this._dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nodeInDataGridViewTextBoxColumn,
            this.nodeOutDataGridViewTextBoxColumn,
            this.keyDataGridViewTextBoxColumn});
            this._dataGridView1.DataSource = this._branchBindingSource;
            this._dataGridView1.Location = new System.Drawing.Point(191, 18);
            this._dataGridView1.Name = "_dataGridView1";
            this._dataGridView1.ReadOnly = true;
            this._dataGridView1.Size = new System.Drawing.Size(362, 267);
            this._dataGridView1.TabIndex = 7;
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
            this._groupBoxAddElement.Text = "Действия с элементом";
            // 
            // _groupBoxEditBranch
            // 
            this._groupBoxEditBranch.Controls.Add(this._buttonDeleteBranchSelected);
            this._groupBoxEditBranch.Controls.Add(this._buttonAddBranch);
            this._groupBoxEditBranch.Controls.Add(this._labelNodeOut);
            this._groupBoxEditBranch.Controls.Add(this._textBoxNodeOut);
            this._groupBoxEditBranch.Controls.Add(this._textBoxNodeIn);
            this._groupBoxEditBranch.Controls.Add(this._labelNodeIn);
            this._groupBoxEditBranch.Location = new System.Drawing.Point(12, 153);
            this._groupBoxEditBranch.Name = "_groupBoxEditBranch";
            this._groupBoxEditBranch.Size = new System.Drawing.Size(173, 132);
            this._groupBoxEditBranch.TabIndex = 9;
            this._groupBoxEditBranch.TabStop = false;
            this._groupBoxEditBranch.Text = "Действия с ветвью";
            // 
            // _buttonDeleteBranchSelected
            // 
            this._buttonDeleteBranchSelected.Location = new System.Drawing.Point(11, 100);
            this._buttonDeleteBranchSelected.Name = "_buttonDeleteBranchSelected";
            this._buttonDeleteBranchSelected.Size = new System.Drawing.Size(151, 23);
            this._buttonDeleteBranchSelected.TabIndex = 5;
            this._buttonDeleteBranchSelected.Text = "Удалить выбранную ветвь";
            this._buttonDeleteBranchSelected.UseVisualStyleBackColor = true;
            this._buttonDeleteBranchSelected.Click += new System.EventHandler(this.ButtonDeleteBranchSelected_Click);
            // 
            // _buttonAddBranch
            // 
            this._buttonAddBranch.Enabled = false;
            this._buttonAddBranch.Location = new System.Drawing.Point(71, 71);
            this._buttonAddBranch.Name = "_buttonAddBranch";
            this._buttonAddBranch.Size = new System.Drawing.Size(91, 23);
            this._buttonAddBranch.TabIndex = 4;
            this._buttonAddBranch.Text = "Добавить";
            this._buttonAddBranch.UseVisualStyleBackColor = true;
            this._buttonAddBranch.Click += new System.EventHandler(this.ButtonAddBranch_Click);
            // 
            // _labelNodeOut
            // 
            this._labelNodeOut.AutoSize = true;
            this._labelNodeOut.Location = new System.Drawing.Point(-3, 48);
            this._labelNodeOut.Name = "_labelNodeOut";
            this._labelNodeOut.Size = new System.Drawing.Size(71, 13);
            this._labelNodeOut.TabIndex = 3;
            this._labelNodeOut.Text = "Выход. Узел";
            // 
            // _textBoxNodeOut
            // 
            this._textBoxNodeOut.Location = new System.Drawing.Point(71, 45);
            this._textBoxNodeOut.Name = "_textBoxNodeOut";
            this._textBoxNodeOut.Size = new System.Drawing.Size(91, 20);
            this._textBoxNodeOut.TabIndex = 2;
            this._textBoxNodeOut.TextChanged += new System.EventHandler(this.TextBoxNodeIn_TextChanged);
            // 
            // _textBoxNodeIn
            // 
            this._textBoxNodeIn.Location = new System.Drawing.Point(71, 19);
            this._textBoxNodeIn.Name = "_textBoxNodeIn";
            this._textBoxNodeIn.Size = new System.Drawing.Size(91, 20);
            this._textBoxNodeIn.TabIndex = 1;
            this._textBoxNodeIn.TextChanged += new System.EventHandler(this.TextBoxNodeIn_TextChanged);
            // 
            // _labelNodeIn
            // 
            this._labelNodeIn.AutoSize = true;
            this._labelNodeIn.Location = new System.Drawing.Point(2, 22);
            this._labelNodeIn.Name = "_labelNodeIn";
            this._labelNodeIn.Size = new System.Drawing.Size(63, 13);
            this._labelNodeIn.TabIndex = 0;
            this._labelNodeIn.Text = "Вход. Узел";
            // 
            // nodeInDataGridViewTextBoxColumn
            // 
            this.nodeInDataGridViewTextBoxColumn.DataPropertyName = "NodeIn";
            this.nodeInDataGridViewTextBoxColumn.HeaderText = "Вход. Узел";
            this.nodeInDataGridViewTextBoxColumn.Name = "nodeInDataGridViewTextBoxColumn";
            this.nodeInDataGridViewTextBoxColumn.ReadOnly = true;
            this.nodeInDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // nodeOutDataGridViewTextBoxColumn
            // 
            this.nodeOutDataGridViewTextBoxColumn.DataPropertyName = "NodeOut";
            this.nodeOutDataGridViewTextBoxColumn.HeaderText = "Выход. Узел";
            this.nodeOutDataGridViewTextBoxColumn.Name = "nodeOutDataGridViewTextBoxColumn";
            this.nodeOutDataGridViewTextBoxColumn.ReadOnly = true;
            this.nodeOutDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "Ключ";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.ReadOnly = true;
            this.keyDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // _branchBindingSource
            // 
            this._branchBindingSource.DataSource = typeof(Model.Branch);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 294);
            this.Controls.Add(this._groupBoxEditBranch);
            this.Controls.Add(this._groupBoxAddElement);
            this.Controls.Add(this._dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ControlPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель управления";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
            this._groupBoxAddElement.ResumeLayout(false);
            this._groupBoxAddElement.PerformLayout();
            this._groupBoxEditBranch.ResumeLayout(false);
            this._groupBoxEditBranch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._branchBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _comboBoxType;
        private System.Windows.Forms.Label _labelSelectType;
        private System.Windows.Forms.TextBox _textBoxValue;
        private System.Windows.Forms.Label _labelValue;
        private System.Windows.Forms.Button _buttonAdd;
        private System.Windows.Forms.Label _labelName;
        private System.Windows.Forms.TextBox _textBoxName;
        private System.Windows.Forms.DataGridView _dataGridView1;
        private System.Windows.Forms.BindingSource _branchBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox _groupBoxAddElement;
        private System.Windows.Forms.GroupBox _groupBoxEditBranch;
        private System.Windows.Forms.Button _buttonAddBranch;
        private System.Windows.Forms.Label _labelNodeOut;
        private System.Windows.Forms.TextBox _textBoxNodeOut;
        private System.Windows.Forms.TextBox _textBoxNodeIn;
        private System.Windows.Forms.Label _labelNodeIn;
        private System.Windows.Forms.Button _buttonDeleteBranchSelected;
    }
}