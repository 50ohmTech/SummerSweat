namespace CircuitView
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
            this.CircuitComboBox = new System.Windows.Forms.ComboBox();
            this.NewElementGroupBox = new System.Windows.Forms.GroupBox();
            this.EnterNominalLabel = new System.Windows.Forms.Label();
            this.NominalTextBox = new System.Windows.Forms.NumericUpDown();
            this.InductorRadioButton = new System.Windows.Forms.RadioButton();
            this.CapacitorRadioButton = new System.Windows.Forms.RadioButton();
            this.ResistorRadioButton = new System.Windows.Forms.RadioButton();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.ElementsGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.NewElementGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NominalTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CircuitComboBox
            // 
            this.CircuitComboBox.FormattingEnabled = true;
            this.CircuitComboBox.Items.AddRange(new object[] {
            "Новая цепь",
            "Цепь №1",
            "Цепь №2",
            "Цепь №3"});
            this.CircuitComboBox.Location = new System.Drawing.Point(12, 29);
            this.CircuitComboBox.Name = "CircuitComboBox";
            this.CircuitComboBox.Size = new System.Drawing.Size(245, 24);
            this.CircuitComboBox.TabIndex = 0;
            this.CircuitComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitComboBox_SelectedIndexChanged);
            // 
            // NewElementGroupBox
            // 
            this.NewElementGroupBox.Controls.Add(this.EnterNominalLabel);
            this.NewElementGroupBox.Controls.Add(this.NominalTextBox);
            this.NewElementGroupBox.Controls.Add(this.InductorRadioButton);
            this.NewElementGroupBox.Controls.Add(this.CapacitorRadioButton);
            this.NewElementGroupBox.Controls.Add(this.ResistorRadioButton);
            this.NewElementGroupBox.Location = new System.Drawing.Point(12, 63);
            this.NewElementGroupBox.Name = "NewElementGroupBox";
            this.NewElementGroupBox.Size = new System.Drawing.Size(243, 152);
            this.NewElementGroupBox.TabIndex = 1;
            this.NewElementGroupBox.TabStop = false;
            this.NewElementGroupBox.Text = "Свойства нового элемента";
            // 
            // EnterNominalLabel
            // 
            this.EnterNominalLabel.AutoSize = true;
            this.EnterNominalLabel.Location = new System.Drawing.Point(6, 102);
            this.EnterNominalLabel.Name = "EnterNominalLabel";
            this.EnterNominalLabel.Size = new System.Drawing.Size(124, 17);
            this.EnterNominalLabel.TabIndex = 4;
            this.EnterNominalLabel.Text = "Введите номинал";
            // 
            // NominalTextBox
            // 
            this.NominalTextBox.DecimalPlaces = 3;
            this.NominalTextBox.Location = new System.Drawing.Point(9, 122);
            this.NominalTextBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NominalTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.NominalTextBox.Name = "NominalTextBox";
            this.NominalTextBox.Size = new System.Drawing.Size(120, 22);
            this.NominalTextBox.TabIndex = 3;
            this.NominalTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // InductorRadioButton
            // 
            this.InductorRadioButton.AutoSize = true;
            this.InductorRadioButton.Location = new System.Drawing.Point(7, 78);
            this.InductorRadioButton.Name = "InductorRadioButton";
            this.InductorRadioButton.Size = new System.Drawing.Size(188, 21);
            this.InductorRadioButton.TabIndex = 2;
            this.InductorRadioButton.TabStop = true;
            this.InductorRadioButton.Text = "Катушка индуктивности";
            this.InductorRadioButton.UseVisualStyleBackColor = true;
            // 
            // CapacitorRadioButton
            // 
            this.CapacitorRadioButton.AutoSize = true;
            this.CapacitorRadioButton.Location = new System.Drawing.Point(7, 50);
            this.CapacitorRadioButton.Name = "CapacitorRadioButton";
            this.CapacitorRadioButton.Size = new System.Drawing.Size(116, 21);
            this.CapacitorRadioButton.TabIndex = 1;
            this.CapacitorRadioButton.TabStop = true;
            this.CapacitorRadioButton.Text = "Конденсатор";
            this.CapacitorRadioButton.UseVisualStyleBackColor = true;
            // 
            // ResistorRadioButton
            // 
            this.ResistorRadioButton.AutoSize = true;
            this.ResistorRadioButton.Location = new System.Drawing.Point(7, 22);
            this.ResistorRadioButton.Name = "ResistorRadioButton";
            this.ResistorRadioButton.Size = new System.Drawing.Size(91, 21);
            this.ResistorRadioButton.TabIndex = 0;
            this.ResistorRadioButton.TabStop = true;
            this.ResistorRadioButton.Text = "Резистор";
            this.ResistorRadioButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Location = new System.Drawing.Point(12, 221);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(118, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.Location = new System.Drawing.Point(134, 221);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(121, 23);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CalculateButton.Location = new System.Drawing.Point(12, 250);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(243, 23);
            this.CalculateButton.TabIndex = 5;
            this.CalculateButton.Text = "Расчитать импеданс";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // ElementsGridView
            // 
            this.ElementsGridView.AllowUserToAddRows = false;
            this.ElementsGridView.AllowUserToDeleteRows = false;
            this.ElementsGridView.AllowUserToResizeColumns = false;
            this.ElementsGridView.AllowUserToResizeRows = false;
            this.ElementsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ElementsGridView.AutoGenerateColumns = false;
            this.ElementsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElementsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.ElementsGridView.DataSource = this.ElementsBindingSource;
            this.ElementsGridView.Location = new System.Drawing.Point(265, 28);
            this.ElementsGridView.Name = "ElementsGridView";
            this.ElementsGridView.RowHeadersVisible = false;
            this.ElementsGridView.RowTemplate.Height = 24;
            this.ElementsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ElementsGridView.Size = new System.Drawing.Size(390, 245);
            this.ElementsGridView.TabIndex = 6;
            this.ElementsGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ElementsGridView_DataError);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "Название";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "Value";
            this.Column2.HeaderText = "Номинал";
            this.Column2.Name = "Column2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Выбор цепи";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 285);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ElementsGridView);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.NewElementGroupBox);
            this.Controls.Add(this.CircuitComboBox);
            this.MinimumSize = new System.Drawing.Size(685, 332);
            this.Name = "MainForm";
            this.NewElementGroupBox.ResumeLayout(false);
            this.NewElementGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NominalTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CircuitComboBox;
        private System.Windows.Forms.GroupBox NewElementGroupBox;
        private System.Windows.Forms.Label EnterNominalLabel;
        private System.Windows.Forms.NumericUpDown NominalTextBox;
        private System.Windows.Forms.RadioButton InductorRadioButton;
        private System.Windows.Forms.RadioButton CapacitorRadioButton;
        private System.Windows.Forms.RadioButton ResistorRadioButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.BindingSource ElementsBindingSource;
        private System.Windows.Forms.DataGridView ElementsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label1;
    }
}

