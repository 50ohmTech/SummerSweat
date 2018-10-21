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
            this.NadeComboBox = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NominalTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(16, 45);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(169, 114);
            this.treeView.TabIndex = 0;
            // 
            // TestCircuitsComboBox
            // 
            this.TestCircuitsComboBox.FormattingEnabled = true;
            this.TestCircuitsComboBox.Location = new System.Drawing.Point(86, 9);
            this.TestCircuitsComboBox.Name = "TestCircuitsComboBox";
            this.TestCircuitsComboBox.Size = new System.Drawing.Size(99, 21);
            this.TestCircuitsComboBox.TabIndex = 1;
            this.TestCircuitsComboBox.SelectedIndexChanged += new System.EventHandler(this.TestCircuitsComboBox_SelectedIndexChanged);
            // 
            // NadeComboBox
            // 
            this.NadeComboBox.FormattingEnabled = true;
            this.NadeComboBox.Location = new System.Drawing.Point(16, 189);
            this.NadeComboBox.Name = "NadeComboBox";
            this.NadeComboBox.Size = new System.Drawing.Size(169, 21);
            this.NadeComboBox.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(18, 255);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(110, 255);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 5;
            this.RemoveButton.Text = "Удалить";
            this.RemoveButton.UseVisualStyleBackColor = true;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(18, 284);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(167, 23);
            this.CalculateButton.TabIndex = 6;
            this.CalculateButton.Text = "Расчитать импеданс";
            this.CalculateButton.UseVisualStyleBackColor = true;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Добавить элемент";
            // 
            // NominalTextBox
            // 
            this.NominalTextBox.Location = new System.Drawing.Point(16, 217);
            this.NominalTextBox.Name = "NominalTextBox";
            this.NominalTextBox.Size = new System.Drawing.Size(169, 20);
            this.NominalTextBox.TabIndex = 9;
            // 
            // CircuitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 320);
            this.Controls.Add(this.NominalTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.NadeComboBox);
            this.Controls.Add(this.TestCircuitsComboBox);
            this.Controls.Add(this.treeView);
            this.Name = "CircuitForm";
            this.Text = "CircuitForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ComboBox TestCircuitsComboBox;
        private System.Windows.Forms.ComboBox NadeComboBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NominalTextBox;
    }
}