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
            this._addElementButton = new System.Windows.Forms.Button();
            this._frequencyGrid = new System.Windows.Forms.PropertyGrid();
            this._circuitComboBox = new System.Windows.Forms.ComboBox();
            this._addCircuitButton = new System.Windows.Forms.Button();
            this._circuitPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _addElementButton
            // 
            this._addElementButton.Location = new System.Drawing.Point(673, 415);
            this._addElementButton.Name = "_addElementButton";
            this._addElementButton.Size = new System.Drawing.Size(115, 23);
            this._addElementButton.TabIndex = 1;
            this._addElementButton.Text = "Добавить элемент";
            this._addElementButton.UseVisualStyleBackColor = true;
            this._addElementButton.Click += new System.EventHandler(this.AddElementButton_Click);
            // 
            // _frequencyGrid
            // 
            this._frequencyGrid.Location = new System.Drawing.Point(607, 13);
            this._frequencyGrid.Name = "_frequencyGrid";
            this._frequencyGrid.Size = new System.Drawing.Size(187, 204);
            this._frequencyGrid.TabIndex = 2;
            // 
            // _circuitComboBox
            // 
            this._circuitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._circuitComboBox.FormattingEnabled = true;
            this._circuitComboBox.Location = new System.Drawing.Point(673, 359);
            this._circuitComboBox.Name = "_circuitComboBox";
            this._circuitComboBox.Size = new System.Drawing.Size(121, 21);
            this._circuitComboBox.TabIndex = 3;
            this._circuitComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitComboBox_SelectedIndexChanged);
            // 
            // _addCircuitButton
            // 
            this._addCircuitButton.Location = new System.Drawing.Point(673, 386);
            this._addCircuitButton.Name = "_addCircuitButton";
            this._addCircuitButton.Size = new System.Drawing.Size(115, 23);
            this._addCircuitButton.TabIndex = 4;
            this._addCircuitButton.Text = "Добавить цепь";
            this._addCircuitButton.UseVisualStyleBackColor = true;
            this._addCircuitButton.Click += new System.EventHandler(this.AddCircuitButton_Click);
            // 
            // _circuitPanel
            // 
            this._circuitPanel.Location = new System.Drawing.Point(13, 13);
            this._circuitPanel.Name = "_circuitPanel";
            this._circuitPanel.Size = new System.Drawing.Size(576, 425);
            this._circuitPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._circuitPanel);
            this.Controls.Add(this._addCircuitButton);
            this.Controls.Add(this._circuitComboBox);
            this.Controls.Add(this._frequencyGrid);
            this.Controls.Add(this._addElementButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Импеданс";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _addElementButton;
        private System.Windows.Forms.PropertyGrid _frequencyGrid;
        private System.Windows.Forms.ComboBox _circuitComboBox;
        private System.Windows.Forms.Button _addCircuitButton;
        private System.Windows.Forms.Panel _circuitPanel;
    }
}

