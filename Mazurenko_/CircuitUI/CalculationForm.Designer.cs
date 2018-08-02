namespace CircuitUI
{
    partial class CalculationForm
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
            this.calculationGridView = new System.Windows.Forms.DataGridView();
            this.columnFrequenies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnImpendances = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteAllButton = new System.Windows.Forms.Button();
            this.calculationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.calculationGridView)).BeginInit();
            this.groupBoxButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // calculationGridView
            // 
            this.calculationGridView.AllowUserToDeleteRows = false;
            this.calculationGridView.AllowUserToResizeColumns = false;
            this.calculationGridView.AllowUserToResizeRows = false;
            this.calculationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.calculationGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnFrequenies,
            this.columnImpendances});
            this.calculationGridView.Location = new System.Drawing.Point(6, 12);
            this.calculationGridView.MultiSelect = false;
            this.calculationGridView.Name = "calculationGridView";
            this.calculationGridView.RowHeadersVisible = false;
            this.calculationGridView.Size = new System.Drawing.Size(255, 240);
            this.calculationGridView.TabIndex = 0;
            this.calculationGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.CalculationGridView_CellBeginEdit);
            this.calculationGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CalculationGridView_CellEnter);
            this.calculationGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.CalculationGridView_CellValidating);
            this.calculationGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.CalculationGridView_EditingControlShowing);
            // 
            // columnFrequenies
            // 
            this.columnFrequenies.Frozen = true;
            this.columnFrequenies.HeaderText = "Frequenies";
            this.columnFrequenies.Name = "columnFrequenies";
            // 
            // columnImpendances
            // 
            this.columnImpendances.Frozen = true;
            this.columnImpendances.HeaderText = "Impendances";
            this.columnImpendances.Name = "columnImpendances";
            this.columnImpendances.ReadOnly = true;
            this.columnImpendances.Width = 150;
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.deleteButton);
            this.groupBoxButtons.Controls.Add(this.deleteAllButton);
            this.groupBoxButtons.Controls.Add(this.calculationButton);
            this.groupBoxButtons.Location = new System.Drawing.Point(6, 254);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(255, 48);
            this.groupBoxButtons.TabIndex = 1;
            this.groupBoxButtons.TabStop = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(89, 15);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(77, 25);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // deleteAllButton
            // 
            this.deleteAllButton.Location = new System.Drawing.Point(172, 15);
            this.deleteAllButton.Name = "deleteAllButton";
            this.deleteAllButton.Size = new System.Drawing.Size(77, 25);
            this.deleteAllButton.TabIndex = 3;
            this.deleteAllButton.Text = "Delete All";
            this.deleteAllButton.UseVisualStyleBackColor = true;
            this.deleteAllButton.Click += new System.EventHandler(this.DeleteAllButton_Click);
            // 
            // calculationButton
            // 
            this.calculationButton.Location = new System.Drawing.Point(6, 15);
            this.calculationButton.Name = "calculationButton";
            this.calculationButton.Size = new System.Drawing.Size(77, 25);
            this.calculationButton.TabIndex = 1;
            this.calculationButton.Text = "Сalculation";
            this.calculationButton.UseVisualStyleBackColor = true;
            this.calculationButton.Click += new System.EventHandler(this.СalculationButton_Click);
            // 
            // CalculationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 310);
            this.Controls.Add(this.groupBoxButtons);
            this.Controls.Add(this.calculationGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculation Form";
            ((System.ComponentModel.ISupportInitialize)(this.calculationGridView)).EndInit();
            this.groupBoxButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView calculationGridView;
        private System.Windows.Forms.GroupBox groupBoxButtons;
        private System.Windows.Forms.Button deleteAllButton;
        private System.Windows.Forms.Button calculationButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFrequenies;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnImpendances;
    }
}