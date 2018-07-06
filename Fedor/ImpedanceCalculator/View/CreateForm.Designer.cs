﻿using System.Windows.Forms;

namespace View
{
    partial class CreateForm
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
            this.circuitComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.circuitPictureBox = new System.Windows.Forms.PictureBox();
            this.addGroupBox = new System.Windows.Forms.GroupBox();
            this.elementComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.connectionComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.elementGridView = new View.MyDataGridView();
            this.nameColomn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColomn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.circuitGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.circuitPictureBox)).BeginInit();
            this.addGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementGridView)).BeginInit();
            this.circuitGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // circuitComboBox
            // 
            this.circuitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.circuitComboBox.FormattingEnabled = true;
            this.circuitComboBox.Items.AddRange(new object[] {
            "Создать цепь",
            "Цепь 1",
            "Цепь 2",
            "Цепь 3",
            "Цепь 4",
            "Цепь 5"});
            this.circuitComboBox.Location = new System.Drawing.Point(124, 16);
            this.circuitComboBox.Name = "circuitComboBox";
            this.circuitComboBox.Size = new System.Drawing.Size(121, 24);
            this.circuitComboBox.TabIndex = 0;
            this.circuitComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите цепь";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(7, 637);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(238, 39);
            this.calculateButton.TabIndex = 3;
            this.calculateButton.Text = "Рассчитать цепь";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // circuitPictureBox
            // 
            this.circuitPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.circuitPictureBox.Location = new System.Drawing.Point(269, 12);
            this.circuitPictureBox.Name = "circuitPictureBox";
            this.circuitPictureBox.Size = new System.Drawing.Size(951, 676);
            this.circuitPictureBox.TabIndex = 4;
            this.circuitPictureBox.TabStop = false;
            // 
            // addGroupBox
            // 
            this.addGroupBox.Controls.Add(this.elementComboBox);
            this.addGroupBox.Controls.Add(this.label5);
            this.addGroupBox.Controls.Add(this.connectionComboBox);
            this.addGroupBox.Controls.Add(this.label4);
            this.addGroupBox.Controls.Add(this.label2);
            this.addGroupBox.Controls.Add(this.label3);
            this.addGroupBox.Controls.Add(this.valueBox);
            this.addGroupBox.Location = new System.Drawing.Point(7, 381);
            this.addGroupBox.Name = "addGroupBox";
            this.addGroupBox.Size = new System.Drawing.Size(238, 204);
            this.addGroupBox.TabIndex = 7;
            this.addGroupBox.TabStop = false;
            this.addGroupBox.Text = "Параметры нового элемента";
            // 
            // elementComboBox
            // 
            this.elementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.elementComboBox.FormattingEnabled = true;
            this.elementComboBox.Items.AddRange(new object[] {
            "Резистор",
            "Конденсатор",
            "Катушка"});
            this.elementComboBox.Location = new System.Drawing.Point(6, 44);
            this.elementComboBox.Name = "elementComboBox";
            this.elementComboBox.Size = new System.Drawing.Size(168, 24);
            this.elementComboBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 34);
            this.label5.TabIndex = 6;
            this.label5.Text = "и элемент из списка, с которым хотите соеденить";
            this.label5.Visible = false;
            // 
            // connectionComboBox
            // 
            this.connectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.connectionComboBox.FormattingEnabled = true;
            this.connectionComboBox.Items.AddRange(new object[] {
            "Последовательное",
            "Параллельное"});
            this.connectionComboBox.Location = new System.Drawing.Point(6, 137);
            this.connectionComboBox.Name = "connectionComboBox";
            this.connectionComboBox.Size = new System.Drawing.Size(168, 24);
            this.connectionComboBox.TabIndex = 5;
            this.connectionComboBox.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Выберите тип соединения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выберите тип элемента";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Введите номинал элемента";
            // 
            // valueBox
            // 
            this.valueBox.Location = new System.Drawing.Point(6, 92);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(168, 22);
            this.valueBox.TabIndex = 1;
            this.valueBox.Text = "0";
            this.valueBox.Enter += new System.EventHandler(this.ValueBox_Enter);
            this.valueBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueBox_KeyPress);
            this.valueBox.Leave += new System.EventHandler(this.ValueBox_Leave);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(128, 591);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(117, 40);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 591);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(115, 40);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // elementGridView
            // 
            this.elementGridView.AllowUserToAddRows = false;
            this.elementGridView.AllowUserToDeleteRows = false;
            this.elementGridView.AllowUserToResizeColumns = false;
            this.elementGridView.AllowUserToResizeRows = false;
            this.elementGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elementGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColomn,
            this.valueColomn});
            this.elementGridView.Location = new System.Drawing.Point(7, 46);
            this.elementGridView.MultiSelect = false;
            this.elementGridView.Name = "elementGridView";
            this.elementGridView.RowHeadersVisible = false;
            this.elementGridView.RowTemplate.Height = 24;
            this.elementGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.elementGridView.Size = new System.Drawing.Size(238, 329);
            this.elementGridView.StandardTab = true;
            this.elementGridView.TabIndex = 8;
            this.elementGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ElementGridView_EditingControlShowing);
            // 
            // nameColomn
            // 
            this.nameColomn.DataPropertyName = "Name";
            this.nameColomn.Frozen = true;
            this.nameColomn.HeaderText = "Name";
            this.nameColomn.Name = "nameColomn";
            this.nameColomn.ReadOnly = true;
            this.nameColomn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nameColomn.Width = 70;
            // 
            // valueColomn
            // 
            this.valueColomn.DataPropertyName = "Value";
            this.valueColomn.Frozen = true;
            this.valueColomn.HeaderText = "Value";
            this.valueColomn.Name = "valueColomn";
            this.valueColomn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.valueColomn.Width = 110;
            // 
            // circuitGroupBox
            // 
            this.circuitGroupBox.Controls.Add(this.calculateButton);
            this.circuitGroupBox.Controls.Add(this.elementGridView);
            this.circuitGroupBox.Controls.Add(this.circuitComboBox);
            this.circuitGroupBox.Controls.Add(this.label1);
            this.circuitGroupBox.Controls.Add(this.addButton);
            this.circuitGroupBox.Controls.Add(this.addGroupBox);
            this.circuitGroupBox.Controls.Add(this.deleteButton);
            this.circuitGroupBox.Location = new System.Drawing.Point(12, 6);
            this.circuitGroupBox.Name = "circuitGroupBox";
            this.circuitGroupBox.Size = new System.Drawing.Size(251, 682);
            this.circuitGroupBox.TabIndex = 9;
            this.circuitGroupBox.TabStop = false;
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 693);
            this.Controls.Add(this.circuitGroupBox);
            this.Controls.Add(this.circuitPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(1250, 740);
            this.MinimumSize = new System.Drawing.Size(1250, 740);
            this.Name = "CreateForm";
            this.Text = "Circuit Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.circuitPictureBox)).EndInit();
            this.addGroupBox.ResumeLayout(false);
            this.addGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementGridView)).EndInit();
            this.circuitGroupBox.ResumeLayout(false);
            this.circuitGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox circuitComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.PictureBox circuitPictureBox;
        private MyDataGridView elementGridView;
        private GroupBox addGroupBox;
        private Label label2;
        private Label label3;
        private TextBox valueBox;
        private Button deleteButton;
        private Button addButton;
        private Label label5;
        private ComboBox connectionComboBox;
        private Label label4;
        private ComboBox elementComboBox;
        private DataGridViewTextBoxColumn nameColomn;
        private DataGridViewTextBoxColumn valueColomn;
        private GroupBox circuitGroupBox;
    }
}

