﻿namespace View
{
    partial class ElementManager
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
            this._dataGridViewBranches = new System.Windows.Forms.DataGridView();
            this._groupBoxAddElement = new System.Windows.Forms.GroupBox();
            this._groupBoxEditBranch = new System.Windows.Forms.GroupBox();
            this._labelValidateBranch = new System.Windows.Forms.Label();
            this._buttonDeleteBranchSelected = new System.Windows.Forms.Button();
            this._buttonAddBranch = new System.Windows.Forms.Button();
            this._textBoxNodeIn = new System.Windows.Forms.TextBox();
            this._labelNodeIn = new System.Windows.Forms.Label();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._branchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewBranches)).BeginInit();
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
            this._dataGridViewBranches.Location = new System.Drawing.Point(191, 18);
            this._dataGridViewBranches.MultiSelect = false;
            this._dataGridViewBranches.Name = "_dataGridViewBranches";
            this._dataGridViewBranches.ReadOnly = true;
            this._dataGridViewBranches.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._dataGridViewBranches.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LawnGreen;
            this._dataGridViewBranches.RowTemplate.ReadOnly = true;
            this._dataGridViewBranches.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewBranches.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._dataGridViewBranches.ShowCellErrors = false;
            this._dataGridViewBranches.ShowCellToolTips = false;
            this._dataGridViewBranches.ShowEditingIcon = false;
            this._dataGridViewBranches.ShowRowErrors = false;
            this._dataGridViewBranches.Size = new System.Drawing.Size(180, 288);
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
            this._groupBoxEditBranch.Controls.Add(this._buttonDeleteBranchSelected);
            this._groupBoxEditBranch.Controls.Add(this._buttonAddBranch);
            this._groupBoxEditBranch.Controls.Add(this._textBoxNodeIn);
            this._groupBoxEditBranch.Controls.Add(this._labelNodeIn);
            this._groupBoxEditBranch.Location = new System.Drawing.Point(12, 153);
            this._groupBoxEditBranch.Name = "_groupBoxEditBranch";
            this._groupBoxEditBranch.Size = new System.Drawing.Size(173, 153);
            this._groupBoxEditBranch.TabIndex = 9;
            this._groupBoxEditBranch.TabStop = false;
            this._groupBoxEditBranch.Text = "Действия с ветвью";
            // 
            // _labelValidateBranch
            // 
            this._labelValidateBranch.AutoSize = true;
            this._labelValidateBranch.Location = new System.Drawing.Point(8, 104);
            this._labelValidateBranch.Name = "_labelValidateBranch";
            this._labelValidateBranch.Size = new System.Drawing.Size(98, 13);
            this._labelValidateBranch.TabIndex = 7;
            this._labelValidateBranch.Text = "Статус валидации";
            // 
            // _buttonDeleteBranchSelected
            // 
            this._buttonDeleteBranchSelected.Location = new System.Drawing.Point(11, 78);
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
            this._buttonAddBranch.Location = new System.Drawing.Point(11, 49);
            this._buttonAddBranch.Name = "_buttonAddBranch";
            this._buttonAddBranch.Size = new System.Drawing.Size(151, 23);
            this._buttonAddBranch.TabIndex = 4;
            this._buttonAddBranch.Text = "Добавить";
            this._buttonAddBranch.UseVisualStyleBackColor = true;
            this._buttonAddBranch.Click += new System.EventHandler(this.ButtonAddBranch_Click);
            // 
            // _textBoxNodeIn
            // 
            this._textBoxNodeIn.Location = new System.Drawing.Point(89, 23);
            this._textBoxNodeIn.Name = "_textBoxNodeIn";
            this._textBoxNodeIn.Size = new System.Drawing.Size(73, 20);
            this._textBoxNodeIn.TabIndex = 1;
            this._textBoxNodeIn.TextChanged += new System.EventHandler(this.TextBoxNodeIn_TextChanged);
            // 
            // _labelNodeIn
            // 
            this._labelNodeIn.AutoSize = true;
            this._labelNodeIn.Location = new System.Drawing.Point(8, 26);
            this._labelNodeIn.Name = "_labelNodeIn";
            this._labelNodeIn.Size = new System.Drawing.Size(75, 13);
            this._labelNodeIn.TabIndex = 0;
            this._labelNodeIn.Text = "Входной узел";
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
            // ElementManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 315);
            this.Controls.Add(this._groupBoxEditBranch);
            this.Controls.Add(this._groupBoxAddElement);
            this.Controls.Add(this._dataGridViewBranches);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ElementManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление элементами";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewBranches)).EndInit();
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
    }
}