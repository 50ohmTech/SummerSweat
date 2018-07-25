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
            this.dataGridViewCalculation = new System.Windows.Forms.DataGridView();
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonDeleteAll = new System.Windows.Forms.Button();
            this.buttonСalculation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalculation)).BeginInit();
            this.groupBoxButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCalculation
            // 
            this.dataGridViewCalculation.AllowUserToDeleteRows = false;
            this.dataGridViewCalculation.AllowUserToResizeColumns = false;
            this.dataGridViewCalculation.AllowUserToResizeRows = false;
            this.dataGridViewCalculation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCalculation.Location = new System.Drawing.Point(6, 12);
            this.dataGridViewCalculation.Name = "dataGridViewCalculation";
            this.dataGridViewCalculation.Size = new System.Drawing.Size(255, 240);
            this.dataGridViewCalculation.TabIndex = 0;
            this.dataGridViewCalculation.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridViewCalculation_CellBeginEdit);
            this.dataGridViewCalculation.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCalculation_CellEnter);
            this.dataGridViewCalculation.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridViewCalculation_CellValidating);
            this.dataGridViewCalculation.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewCalculationForm_EditingControlShowing);
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.buttonDelete);
            this.groupBoxButtons.Controls.Add(this.buttonDeleteAll);
            this.groupBoxButtons.Controls.Add(this.buttonСalculation);
            this.groupBoxButtons.Location = new System.Drawing.Point(6, 258);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(255, 56);
            this.groupBoxButtons.TabIndex = 1;
            this.groupBoxButtons.TabStop = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(89, 19);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(77, 25);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonDeleteAll
            // 
            this.buttonDeleteAll.Location = new System.Drawing.Point(172, 19);
            this.buttonDeleteAll.Name = "buttonDeleteAll";
            this.buttonDeleteAll.Size = new System.Drawing.Size(77, 25);
            this.buttonDeleteAll.TabIndex = 1;
            this.buttonDeleteAll.Text = "Delete All";
            this.buttonDeleteAll.UseVisualStyleBackColor = true;
            this.buttonDeleteAll.Click += new System.EventHandler(this.ButtonDeleteAll_Click);
            // 
            // buttonСalculation
            // 
            this.buttonСalculation.Location = new System.Drawing.Point(6, 19);
            this.buttonСalculation.Name = "buttonСalculation";
            this.buttonСalculation.Size = new System.Drawing.Size(77, 25);
            this.buttonСalculation.TabIndex = 0;
            this.buttonСalculation.Text = "Сalculation";
            this.buttonСalculation.UseVisualStyleBackColor = true;
            this.buttonСalculation.Click += new System.EventHandler(this.ButtonСalculation_Click);
            // 
            // CalculationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 326);
            this.Controls.Add(this.groupBoxButtons);
            this.Controls.Add(this.dataGridViewCalculation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CalculationForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalculation)).EndInit();
            this.groupBoxButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCalculation;
        private System.Windows.Forms.GroupBox groupBoxButtons;
        private System.Windows.Forms.Button buttonDeleteAll;
        private System.Windows.Forms.Button buttonСalculation;
        private System.Windows.Forms.Button buttonDelete;
    }
}