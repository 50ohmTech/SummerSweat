namespace View
{
    partial class CircuitControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.typePanel = new System.Windows.Forms.Panel();
            this.inductorRadioButton = new System.Windows.Forms.RadioButton();
            this.capacitorRadioButton = new System.Windows.Forms.RadioButton();
            this.resistorRadioButton = new System.Windows.Forms.RadioButton();
            this.elementGridView = new System.Windows.Forms.DataGridView();
            this.elementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ElementName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.addBox.SuspendLayout();
            this.typePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(247, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(681, 472);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(3, 481);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(175, 39);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(184, 481);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(175, 39);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // addBox
            // 
            this.addBox.Controls.Add(this.label1);
            this.addBox.Controls.Add(this.label2);
            this.addBox.Controls.Add(this.valueBox);
            this.addBox.Controls.Add(this.typePanel);
            this.addBox.Location = new System.Drawing.Point(3, 291);
            this.addBox.Name = "addBox";
            this.addBox.Size = new System.Drawing.Size(223, 184);
            this.addBox.TabIndex = 3;
            this.addBox.TabStop = false;
            this.addBox.Text = "Параметры нового элемента";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выберите тип элемента";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите значение элемента";
            // 
            // valueBox
            // 
            this.valueBox.Location = new System.Drawing.Point(6, 149);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(107, 22);
            this.valueBox.TabIndex = 1;
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
            this.capacitorRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
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
            // elementGridView
            // 
            this.elementGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elementGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElementName,
            this.ElementValue});
            this.elementGridView.Location = new System.Drawing.Point(3, 3);
            this.elementGridView.Name = "elementGridView";
            this.elementGridView.RowHeadersVisible = false;
            this.elementGridView.RowTemplate.Height = 24;
            this.elementGridView.Size = new System.Drawing.Size(238, 282);
            this.elementGridView.TabIndex = 4;
            this.elementGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.elementGridView_CellContentClick);
            // 
            // ElementName
            // 
            this.ElementName.DataPropertyName = "Name";
            this.ElementName.Frozen = true;
            this.ElementName.HeaderText = "Name";
            this.ElementName.Name = "ElementName";
            this.ElementName.ReadOnly = true;
            // 
            // ElementValue
            // 
            this.ElementValue.DataPropertyName = "Value";
            this.ElementValue.Frozen = true;
            this.ElementValue.HeaderText = "Value";
            this.ElementValue.Name = "ElementValue";
            // 
            // CircuitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.elementGridView);
            this.Controls.Add(this.addBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CircuitControl";
            this.Size = new System.Drawing.Size(931, 524);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.addBox.ResumeLayout(false);
            this.addBox.PerformLayout();
            this.typePanel.ResumeLayout(false);
            this.typePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.GroupBox addBox;
        private System.Windows.Forms.Panel typePanel;
        private System.Windows.Forms.RadioButton inductorRadioButton;
        private System.Windows.Forms.RadioButton capacitorRadioButton;
        private System.Windows.Forms.RadioButton resistorRadioButton;
        private System.Windows.Forms.DataGridView elementGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox valueBox;
        private System.Windows.Forms.BindingSource elementBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementValue;
    }
}
