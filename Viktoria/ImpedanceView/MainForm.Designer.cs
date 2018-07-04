namespace ImpedanceView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.circuitType = new System.Windows.Forms.ComboBox();
            this.frequencyControl = new System.Windows.Forms.GroupBox();
            this.maxFrequency = new System.Windows.Forms.TextBox();
            this.minFrequency = new System.Windows.Forms.TextBox();
            this.Step = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.angularFrequency = new System.Windows.Forms.RadioButton();
            this.frequency = new System.Windows.Forms.RadioButton();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.RandomButton = new System.Windows.Forms.Button();
            this.Remove_button = new System.Windows.Forms.Button();
            this.Add_button = new System.Windows.Forms.Button();
            this.ElementStorage = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ImpedanceStorage = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.frequencyControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElementStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpedanceStorage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ImpedanceStorage);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.circuitType);
            this.groupBox1.Controls.Add(this.frequencyControl);
            this.groupBox1.Controls.Add(this.RandomButton);
            this.groupBox1.Controls.Add(this.Remove_button);
            this.groupBox1.Controls.Add(this.Add_button);
            this.groupBox1.Controls.Add(this.ElementStorage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 446);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Выберите цепь для рассчета:";
            // 
            // circuitType
            // 
            this.circuitType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.circuitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.circuitType.FormattingEnabled = true;
            this.circuitType.Items.AddRange(new object[] {
            "R - L - C",
            "R - R - C - L - R - C",
            "L - R - L - R - C",
            "R - R -R - R",
            "C - L - L - R - L",
            "Своя цепь"});
            this.circuitType.Location = new System.Drawing.Point(442, 35);
            this.circuitType.Name = "circuitType";
            this.circuitType.Size = new System.Drawing.Size(185, 21);
            this.circuitType.TabIndex = 15;
            // 
            // frequencyControl
            // 
            this.frequencyControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.frequencyControl.Controls.Add(this.maxFrequency);
            this.frequencyControl.Controls.Add(this.minFrequency);
            this.frequencyControl.Controls.Add(this.Step);
            this.frequencyControl.Controls.Add(this.label3);
            this.frequencyControl.Controls.Add(this.label2);
            this.frequencyControl.Controls.Add(this.label1);
            this.frequencyControl.Controls.Add(this.angularFrequency);
            this.frequencyControl.Controls.Add(this.frequency);
            this.frequencyControl.Controls.Add(this.CalculateButton);
            this.frequencyControl.Location = new System.Drawing.Point(442, 142);
            this.frequencyControl.Name = "frequencyControl";
            this.frequencyControl.Size = new System.Drawing.Size(203, 134);
            this.frequencyControl.TabIndex = 14;
            this.frequencyControl.TabStop = false;
            this.frequencyControl.Text = "Настройка диапазона частот";
            // 
            // maxFrequency
            // 
            this.maxFrequency.Location = new System.Drawing.Point(122, 55);
            this.maxFrequency.Name = "maxFrequency";
            this.maxFrequency.Size = new System.Drawing.Size(53, 20);
            this.maxFrequency.TabIndex = 25;
            // 
            // minFrequency
            // 
            this.minFrequency.Location = new System.Drawing.Point(36, 55);
            this.minFrequency.Name = "minFrequency";
            this.minFrequency.Size = new System.Drawing.Size(52, 20);
            this.minFrequency.TabIndex = 24;
            // 
            // Step
            // 
            this.Step.Location = new System.Drawing.Point(76, 83);
            this.Step.Name = "Step";
            this.Step.Size = new System.Drawing.Size(53, 20);
            this.Step.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "С шагом";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "До";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "От";
            // 
            // angularFrequency
            // 
            this.angularFrequency.AutoSize = true;
            this.angularFrequency.Location = new System.Drawing.Point(6, 19);
            this.angularFrequency.Name = "angularFrequency";
            this.angularFrequency.Size = new System.Drawing.Size(131, 17);
            this.angularFrequency.TabIndex = 15;
            this.angularFrequency.TabStop = true;
            this.angularFrequency.Text = "Круговая частота (w)";
            this.angularFrequency.UseVisualStyleBackColor = true;
            // 
            // frequency
            // 
            this.frequency.AutoSize = true;
            this.frequency.Location = new System.Drawing.Point(6, 35);
            this.frequency.Name = "frequency";
            this.frequency.Size = new System.Drawing.Size(123, 17);
            this.frequency.TabIndex = 16;
            this.frequency.TabStop = true;
            this.frequency.Text = "Частота сигнала (f)";
            this.frequency.UseVisualStyleBackColor = true;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CalculateButton.Location = new System.Drawing.Point(63, 106);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(81, 22);
            this.CalculateButton.TabIndex = 5;
            this.CalculateButton.Text = "Рассчитать";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // RandomButton
            // 
            this.RandomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomButton.Location = new System.Drawing.Point(442, 109);
            this.RandomButton.Name = "RandomButton";
            this.RandomButton.Size = new System.Drawing.Size(185, 27);
            this.RandomButton.TabIndex = 10;
            this.RandomButton.Text = "Рандом";
            this.RandomButton.UseVisualStyleBackColor = true;
            this.RandomButton.Click += new System.EventHandler(this.RandomButton_Click);
            // 
            // Remove_button
            // 
            this.Remove_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Remove_button.Location = new System.Drawing.Point(541, 71);
            this.Remove_button.Name = "Remove_button";
            this.Remove_button.Size = new System.Drawing.Size(86, 27);
            this.Remove_button.TabIndex = 7;
            this.Remove_button.Text = "Удалить";
            this.Remove_button.UseVisualStyleBackColor = true;
            this.Remove_button.Click += new System.EventHandler(this.Remove_button_Click);
            // 
            // Add_button
            // 
            this.Add_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_button.Location = new System.Drawing.Point(442, 71);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(86, 27);
            this.Add_button.TabIndex = 1;
            this.Add_button.Text = "Добавить";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // ElementStorage
            // 
            this.ElementStorage.AllowUserToAddRows = false;
            this.ElementStorage.AllowUserToResizeRows = false;
            this.ElementStorage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ElementStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElementStorage.Location = new System.Drawing.Point(6, 19);
            this.ElementStorage.Name = "ElementStorage";
            this.ElementStorage.ReadOnly = true;
            this.ElementStorage.RowHeadersVisible = false;
            this.ElementStorage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ElementStorage.Size = new System.Drawing.Size(418, 417);
            this.ElementStorage.TabIndex = 0;
            this.ElementStorage.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Тип элемента"});
            this.comboBox1.Location = new System.Drawing.Point(6, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // ImpedanceStorage
            // 
            this.ImpedanceStorage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImpedanceStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ImpedanceStorage.Location = new System.Drawing.Point(442, 290);
            this.ImpedanceStorage.Name = "ImpedanceStorage";
            this.ImpedanceStorage.Size = new System.Drawing.Size(191, 146);
            this.ImpedanceStorage.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 446);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CalculatorView";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.frequencyControl.ResumeLayout(false);
            this.frequencyControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElementStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpedanceStorage)).EndInit();
            this.ResumeLayout(false);

        }

#endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.DataGridView ElementStorage;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Button Remove_button;
        private System.Windows.Forms.Button RandomButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox frequencyControl;
        private System.Windows.Forms.TextBox maxFrequency;
        private System.Windows.Forms.TextBox minFrequency;
        private System.Windows.Forms.TextBox Step;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton angularFrequency;
        private System.Windows.Forms.RadioButton frequency;
        private System.Windows.Forms.ComboBox circuitType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView ImpedanceStorage;
    }
}

