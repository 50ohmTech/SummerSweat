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
            this.elementsGridView = new System.Windows.Forms.DataGridView();
            this.bindingSourceContainer = new System.Windows.Forms.BindingSource(this.components);
            this.randomElementButton = new System.Windows.Forms.Button();
            this.circuitsComboBox = new System.Windows.Forms.ComboBox();
            this.currentCircuitLabel = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementsGridView)).BeginInit();
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
            this.mainMenuStrip.ShowItemToolTips = true;
            this.mainMenuStrip.Size = new System.Drawing.Size(235, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // addElementToolStripMenuItem
            // 
            this.addElementToolStripMenuItem.Name = "addElementToolStripMenuItem";
            this.addElementToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addElementToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.addElementToolStripMenuItem.Text = "Add Element";
            this.addElementToolStripMenuItem.ToolTipText = "Adding a new electrical circuit element\r\n( Ctrl + A )";
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
            this.clearToolStripMenuItem.ToolTipText = "To choose how to delete rows";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.deleteToolStripMenuItem.Text = "Delete ";
            this.deleteToolStripMenuItem.ToolTipText = "Delete the selected row";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.deleteAllToolStripMenuItem.Text = "Delete All";
            this.deleteAllToolStripMenuItem.ToolTipText = "Remove all values of this electrical circuit";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.DeleteAllToolStripMenuItem_Click);
            // 
            // calculationToolStripMenuItem
            // 
            this.calculationToolStripMenuItem.Name = "calculationToolStripMenuItem";
            this.calculationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.calculationToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.calculationToolStripMenuItem.Text = "Сalculation";
            this.calculationToolStripMenuItem.ToolTipText = "To open the window to calculate the total complex\r\nresistance of the selected ele" +
    "ctrical circuit \r\n( Ctrl + C )";
            this.calculationToolStripMenuItem.Click += new System.EventHandler(this.CalculationToolStripMenuItem_Click);
            // 
            // elementsGridView
            // 
            this.elementsGridView.AllowUserToAddRows = false;
            this.elementsGridView.AllowUserToDeleteRows = false;
            this.elementsGridView.AllowUserToResizeColumns = false;
            this.elementsGridView.AllowUserToResizeRows = false;
            this.elementsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elementsGridView.Location = new System.Drawing.Point(12, 75);
            this.elementsGridView.MultiSelect = false;
            this.elementsGridView.Name = "elementsGridView";
            this.elementsGridView.RowHeadersVisible = false;
            this.elementsGridView.Size = new System.Drawing.Size(211, 207);
            this.elementsGridView.TabIndex = 2;
            this.elementsGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ElementsGridView_CellBeginEdit);
            this.elementsGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ElementsGridView_CellMouseEnter);
            this.elementsGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ElementsGridView_CellValidating);
            this.elementsGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ElementsGridView_EditingControlShowing);
            // 
            // randomElementButton
            // 
            this.randomElementButton.Location = new System.Drawing.Point(62, 288);
            this.randomElementButton.Name = "randomElementButton";
            this.randomElementButton.Size = new System.Drawing.Size(100, 23);
            this.randomElementButton.TabIndex = 3;
            this.randomElementButton.Text = "Random Element";
            this.randomElementButton.UseVisualStyleBackColor = true;
            this.randomElementButton.Click += new System.EventHandler(this.RandomElementButton_Click);
            // 
            // circuitsComboBox
            // 
            this.circuitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.circuitsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.circuitsComboBox.FormattingEnabled = true;
            this.circuitsComboBox.Location = new System.Drawing.Point(43, 46);
            this.circuitsComboBox.Name = "circuitsComboBox";
            this.circuitsComboBox.Size = new System.Drawing.Size(154, 23);
            this.circuitsComboBox.TabIndex = 1;
            this.circuitsComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitsComboBox_SelectedIndexChanged);
            // 
            // currentCircuitLabel
            // 
            this.currentCircuitLabel.AutoSize = true;
            this.currentCircuitLabel.Location = new System.Drawing.Point(45, 30);
            this.currentCircuitLabel.Name = "currentCircuitLabel";
            this.currentCircuitLabel.Size = new System.Drawing.Size(117, 13);
            this.currentCircuitLabel.TabIndex = 5;
            this.currentCircuitLabel.Text = "Current electrical circuit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 323);
            this.Controls.Add(this.currentCircuitLabel);
            this.Controls.Add(this.circuitsComboBox);
            this.Controls.Add(this.randomElementButton);
            this.Controls.Add(this.elementsGridView);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Electrical circuit [ver. 0.1]";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementsGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView elementsGridView;
        private System.Windows.Forms.Button randomElementButton;
        private System.Windows.Forms.ComboBox circuitsComboBox;
        private System.Windows.Forms.Label currentCircuitLabel;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
    }
}

