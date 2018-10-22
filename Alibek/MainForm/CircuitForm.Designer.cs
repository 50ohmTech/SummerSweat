namespace MainForm
{
    partial class CircuitForm
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.TestCircuitsComboBox = new System.Windows.Forms.ComboBox();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(16, 45);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(169, 114);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDoubleClick);
            // 
            // TestCircuitsComboBox
            // 
            this.TestCircuitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TestCircuitsComboBox.FormattingEnabled = true;
            this.TestCircuitsComboBox.Items.AddRange(new object[] {
            "Выберите цепь"});
            this.TestCircuitsComboBox.Location = new System.Drawing.Point(86, 9);
            this.TestCircuitsComboBox.Name = "TestCircuitsComboBox";
            this.TestCircuitsComboBox.Size = new System.Drawing.Size(99, 21);
            this.TestCircuitsComboBox.TabIndex = 1;
            this.TestCircuitsComboBox.SelectedIndexChanged += new System.EventHandler(this.TestCircuitsComboBox_SelectedIndexChanged);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(16, 165);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(167, 30);
            this.CalculateButton.TabIndex = 6;
            this.CalculateButton.Text = "Расчитать импеданс";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Выбор цепи";
            // 
            // CircuitPictureBox
            // 
            this.CircuitPictureBox.Location = new System.Drawing.Point(213, 12);
            this.CircuitPictureBox.Name = "CircuitPictureBox";
            this.CircuitPictureBox.Size = new System.Drawing.Size(318, 296);
            this.CircuitPictureBox.TabIndex = 10;
            this.CircuitPictureBox.TabStop = false;
            // 
            // CircuitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 320);
            this.Controls.Add(this.CircuitPictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.TestCircuitsComboBox);
            this.Controls.Add(this.treeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CircuitForm";
            this.Text = "CircuitForm";
            ((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ComboBox TestCircuitsComboBox;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox CircuitPictureBox;
    }
}