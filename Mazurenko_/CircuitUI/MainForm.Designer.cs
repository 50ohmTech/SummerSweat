namespace CircuitUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.addElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewValueDisplay = new System.Windows.Forms.DataGridView();
            this.bindingSourceContainer = new System.Windows.Forms.BindingSource(this.components);
            this.buttonRandomElement = new System.Windows.Forms.Button();
            this.comboBoxCircuitsAll = new System.Windows.Forms.ComboBox();
            this.labelCurrentCircuit = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewValueDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addElementToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.calculationToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(235, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // addElementToolStripMenuItem
            // 
            this.addElementToolStripMenuItem.Name = "addElementToolStripMenuItem";
            this.addElementToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.addElementToolStripMenuItem.Text = "Add Element";
            this.addElementToolStripMenuItem.Click += new System.EventHandler(this.AddElementToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.deleteAllToolStripMenuItem});
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.deleteToolStripMenuItem.Text = "Delete ";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.deleteAllToolStripMenuItem.Text = "Delete All";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.DeleteAllToolStripMenuItem_Click);
            // 
            // calculationToolStripMenuItem
            // 
            this.calculationToolStripMenuItem.Name = "calculationToolStripMenuItem";
            this.calculationToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.calculationToolStripMenuItem.Text = "Сalculation";
            this.calculationToolStripMenuItem.Click += new System.EventHandler(this.CalculationToolStripMenuItem_Click);
            // 
            // dataGridViewValueDisplay
            // 
            this.dataGridViewValueDisplay.AllowUserToAddRows = false;
            this.dataGridViewValueDisplay.AllowUserToDeleteRows = false;
            this.dataGridViewValueDisplay.AllowUserToResizeColumns = false;
            this.dataGridViewValueDisplay.AllowUserToResizeRows = false;
            this.dataGridViewValueDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewValueDisplay.Location = new System.Drawing.Point(12, 75);
            this.dataGridViewValueDisplay.Name = "dataGridViewValueDisplay";
            this.dataGridViewValueDisplay.Size = new System.Drawing.Size(211, 207);
            this.dataGridViewValueDisplay.TabIndex = 2;
            this.dataGridViewValueDisplay.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridViewValueDisplay_CellBeginEdit);
            this.dataGridViewValueDisplay.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewValueDisplay_CellMouseEnter);
            this.dataGridViewValueDisplay.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridViewValueDisplay_CellValidating);
            this.dataGridViewValueDisplay.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewValueDisplay_EditingControlShowing);
            // 
            // buttonRandomElement
            // 
            this.buttonRandomElement.Location = new System.Drawing.Point(62, 288);
            this.buttonRandomElement.Name = "buttonRandomElement";
            this.buttonRandomElement.Size = new System.Drawing.Size(100, 23);
            this.buttonRandomElement.TabIndex = 3;
            this.buttonRandomElement.Text = "Random Element";
            this.buttonRandomElement.UseVisualStyleBackColor = true;
            this.buttonRandomElement.Click += new System.EventHandler(this.ButtonRandomElement_Click);
            // 
            // comboBoxCircuitsAll
            // 
            this.comboBoxCircuitsAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxCircuitsAll.FormattingEnabled = true;
            this.comboBoxCircuitsAll.Location = new System.Drawing.Point(43, 46);
            this.comboBoxCircuitsAll.Name = "comboBoxCircuitsAll";
            this.comboBoxCircuitsAll.Size = new System.Drawing.Size(154, 23);
            this.comboBoxCircuitsAll.TabIndex = 4;
            this.comboBoxCircuitsAll.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAllCircuit_SelectedIndexChanged);
            // 
            // labelCurrentCircuit
            // 
            this.labelCurrentCircuit.AutoSize = true;
            this.labelCurrentCircuit.Location = new System.Drawing.Point(45, 30);
            this.labelCurrentCircuit.Name = "labelCurrentCircuit";
            this.labelCurrentCircuit.Size = new System.Drawing.Size(117, 13);
            this.labelCurrentCircuit.TabIndex = 5;
            this.labelCurrentCircuit.Text = "Current electrical circuit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 323);
            this.Controls.Add(this.labelCurrentCircuit);
            this.Controls.Add(this.comboBoxCircuitsAll);
            this.Controls.Add(this.buttonRandomElement);
            this.Controls.Add(this.dataGridViewValueDisplay);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Electrical circuit [ver. 0.1]";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewValueDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculationToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSourceContainer;
        private System.Windows.Forms.DataGridView dataGridViewValueDisplay;
        private System.Windows.Forms.Button buttonRandomElement;
        private System.Windows.Forms.ComboBox comboBoxCircuitsAll;
        private System.Windows.Forms.Label labelCurrentCircuit;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
    }
}

