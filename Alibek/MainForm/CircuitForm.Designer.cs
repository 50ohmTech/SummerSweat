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
            this.testCircuitsComboBox = new System.Windows.Forms.ComboBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.circuitPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.circuitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(16, 45);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(169, 114);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.treeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TreeView_MouseDoubleClick);
            // 
            // testCircuitsComboBox
            // 
            this.testCircuitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.testCircuitsComboBox.FormattingEnabled = true;
            this.testCircuitsComboBox.Items.AddRange(new object[] {
            "Выберите цепь"});
            this.testCircuitsComboBox.Location = new System.Drawing.Point(86, 9);
            this.testCircuitsComboBox.Name = "testCircuitsComboBox";
            this.testCircuitsComboBox.Size = new System.Drawing.Size(99, 21);
            this.testCircuitsComboBox.TabIndex = 1;
            this.testCircuitsComboBox.SelectedIndexChanged += new System.EventHandler(this.TestCircuitsComboBox_SelectedIndexChanged);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(16, 165);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(167, 30);
            this.calculateButton.TabIndex = 6;
            this.calculateButton.Text = "Расчитать импеданс";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
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
            // circuitPictureBox
            // 
            this.circuitPictureBox.Location = new System.Drawing.Point(213, 12);
            this.circuitPictureBox.Name = "circuitPictureBox";
            this.circuitPictureBox.Size = new System.Drawing.Size(318, 296);
            this.circuitPictureBox.TabIndex = 10;
            this.circuitPictureBox.TabStop = false;
            // 
            // CircuitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 320);
            this.Controls.Add(this.circuitPictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.testCircuitsComboBox);
            this.Controls.Add(this.treeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CircuitForm";
            this.Text = "CircuitForm";
            ((System.ComponentModel.ISupportInitialize)(this.circuitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ComboBox testCircuitsComboBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox circuitPictureBox;
    }
}