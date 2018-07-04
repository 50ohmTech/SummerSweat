using System.Windows.Forms;

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
            this.elementGridView = new System.Windows.Forms.DataGridView();
            this.nameColomn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColomn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.typePanel = new System.Windows.Forms.Panel();
            this.inductorRadioButton = new System.Windows.Forms.RadioButton();
            this.capacitorRadioButton = new System.Windows.Forms.RadioButton();
            this.resistorRadioButton = new System.Windows.Forms.RadioButton();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.circuitPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementGridView)).BeginInit();
            this.addBox.SuspendLayout();
            this.typePanel.SuspendLayout();
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
            "Цепь 3"});
            this.circuitComboBox.Location = new System.Drawing.Point(127, 6);
            this.circuitComboBox.Name = "circuitComboBox";
            this.circuitComboBox.Size = new System.Drawing.Size(121, 24);
            this.circuitComboBox.TabIndex = 0;
            this.circuitComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите цепь";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(912, 556);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(158, 36);
            this.calculateButton.TabIndex = 3;
            this.calculateButton.Text = "Расчитать импеданс";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // circuitPictureBox
            // 
            this.circuitPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.circuitPictureBox.Location = new System.Drawing.Point(256, 6);
            this.circuitPictureBox.Name = "circuitPictureBox";
            this.circuitPictureBox.Size = new System.Drawing.Size(814, 529);
            this.circuitPictureBox.TabIndex = 4;
            this.circuitPictureBox.TabStop = false;
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
            this.elementGridView.Location = new System.Drawing.Point(10, 36);
            this.elementGridView.Name = "elementGridView";
            this.elementGridView.RowHeadersVisible = false;
            this.elementGridView.RowTemplate.Height = 24;
            this.elementGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.elementGridView.Size = new System.Drawing.Size(238, 282);
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
            this.nameColomn.Width = 70;
            // 
            // valueColomn
            // 
            this.valueColomn.DataPropertyName = "Value";
            this.valueColomn.Frozen = true;
            this.valueColomn.HeaderText = "Value";
            this.valueColomn.Name = "valueColomn";
            this.valueColomn.Width = 110;
            // 
            // addBox
            // 
            this.addBox.Controls.Add(this.label2);
            this.addBox.Controls.Add(this.label3);
            this.addBox.Controls.Add(this.valueBox);
            this.addBox.Controls.Add(this.typePanel);
            this.addBox.Location = new System.Drawing.Point(12, 324);
            this.addBox.Name = "addBox";
            this.addBox.Size = new System.Drawing.Size(238, 225);
            this.addBox.TabIndex = 7;
            this.addBox.TabStop = false;
            this.addBox.Text = "Параметры нового элемента";
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
            this.label3.Location = new System.Drawing.Point(6, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Введите номинал элемента";
            // 
            // valueBox
            // 
            this.valueBox.Location = new System.Drawing.Point(6, 149);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(107, 22);
            this.valueBox.TabIndex = 1;
            this.valueBox.Text = "0";
            this.valueBox.Enter += new System.EventHandler(this.ValueBox_Enter);
            this.valueBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueBox_KeyPress);
            this.valueBox.Leave += new System.EventHandler(this.ValueBox_Leave);
            // 
            // typePanel
            // 
            this.typePanel.Controls.Add(this.inductorRadioButton);
            this.typePanel.Controls.Add(this.capacitorRadioButton);
            this.typePanel.Controls.Add(this.resistorRadioButton);
            this.typePanel.Location = new System.Drawing.Point(7, 44);
            this.typePanel.Name = "typePanel";
            this.typePanel.Size = new System.Drawing.Size(200, 82);
            this.typePanel.TabIndex = 0;
            // 
            // inductorRadioButton
            // 
            this.inductorRadioButton.AutoSize = true;
            this.inductorRadioButton.Location = new System.Drawing.Point(3, 57);
            this.inductorRadioButton.Name = "inductorRadioButton";
            this.inductorRadioButton.Size = new System.Drawing.Size(188, 21);
            this.inductorRadioButton.TabIndex = 2;
            this.inductorRadioButton.TabStop = true;
            this.inductorRadioButton.Text = "Катушка индуктивности";
            this.inductorRadioButton.UseVisualStyleBackColor = true;
            // 
            // capacitorRadioButton
            // 
            this.capacitorRadioButton.AutoSize = true;
            this.capacitorRadioButton.Location = new System.Drawing.Point(3, 30);
            this.capacitorRadioButton.Name = "capacitorRadioButton";
            this.capacitorRadioButton.Size = new System.Drawing.Size(116, 21);
            this.capacitorRadioButton.TabIndex = 1;
            this.capacitorRadioButton.TabStop = true;
            this.capacitorRadioButton.Text = "Конденсатор";
            this.capacitorRadioButton.UseVisualStyleBackColor = true;
            // 
            // resistorRadioButton
            // 
            this.resistorRadioButton.AutoSize = true;
            this.resistorRadioButton.Location = new System.Drawing.Point(3, 3);
            this.resistorRadioButton.Name = "resistorRadioButton";
            this.resistorRadioButton.Size = new System.Drawing.Size(91, 21);
            this.resistorRadioButton.TabIndex = 0;
            this.resistorRadioButton.TabStop = true;
            this.resistorRadioButton.Text = "Резистор";
            this.resistorRadioButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(134, 555);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(116, 39);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 555);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(116, 39);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 606);
            this.Controls.Add(this.elementGridView);
            this.Controls.Add(this.addBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.circuitPictureBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.circuitComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(1100, 653);
            this.MinimumSize = new System.Drawing.Size(1100, 653);
            this.Name = "CreateForm";
            this.Text = "Circuit Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.circuitPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementGridView)).EndInit();
            this.addBox.ResumeLayout(false);
            this.addBox.PerformLayout();
            this.typePanel.ResumeLayout(false);
            this.typePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox circuitComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.PictureBox circuitPictureBox;
        private DataGridView elementGridView;
        private DataGridViewTextBoxColumn nameColomn;
        private DataGridViewTextBoxColumn valueColomn;
        private GroupBox addBox;
        private Label label2;
        private Label label3;
        private TextBox valueBox;
        private Panel typePanel;
        private RadioButton inductorRadioButton;
        private RadioButton capacitorRadioButton;
        private RadioButton resistorRadioButton;
        private Button deleteButton;
        private Button addButton;
    }
}

