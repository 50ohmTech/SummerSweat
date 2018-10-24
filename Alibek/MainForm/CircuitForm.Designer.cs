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
            this._treeView = new System.Windows.Forms.TreeView();
            this._testCircuitsComboBox = new System.Windows.Forms.ComboBox();
            this._calculateButton = new System.Windows.Forms.Button();
            this._selectCircuitLabel = new System.Windows.Forms.Label();
            this._circuitPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._circuitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _treeView
            // 
            this._treeView.Location = new System.Drawing.Point(16, 45);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(169, 114);
            this._treeView.TabIndex = 0;
            this._treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this._treeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TreeView_MouseDoubleClick);
            // 
            // _testCircuitsComboBox
            // 
            this._testCircuitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._testCircuitsComboBox.FormattingEnabled = true;
            this._testCircuitsComboBox.Location = new System.Drawing.Point(86, 9);
            this._testCircuitsComboBox.Name = "_testCircuitsComboBox";
            this._testCircuitsComboBox.Size = new System.Drawing.Size(99, 21);
            this._testCircuitsComboBox.TabIndex = 1;
            this._testCircuitsComboBox.SelectedIndexChanged += new System.EventHandler(this.TestCircuitsComboBox_SelectedIndexChanged);
            // 
            // _calculateButton
            // 
            this._calculateButton.Location = new System.Drawing.Point(16, 165);
            this._calculateButton.Name = "_calculateButton";
            this._calculateButton.Size = new System.Drawing.Size(169, 52);
            this._calculateButton.TabIndex = 6;
            this._calculateButton.Text = "Расчитать импеданс";
            this._calculateButton.UseVisualStyleBackColor = true;
            this._calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // _selectCircuitLabel
            // 
            this._selectCircuitLabel.AutoSize = true;
            this._selectCircuitLabel.Location = new System.Drawing.Point(13, 12);
            this._selectCircuitLabel.Name = "_selectCircuitLabel";
            this._selectCircuitLabel.Size = new System.Drawing.Size(67, 13);
            this._selectCircuitLabel.TabIndex = 7;
            this._selectCircuitLabel.Text = "Выбор цепи";
            // 
            // _circuitPictureBox
            // 
            this._circuitPictureBox.Location = new System.Drawing.Point(213, 12);
            this._circuitPictureBox.Name = "_circuitPictureBox";
            this._circuitPictureBox.Size = new System.Drawing.Size(318, 233);
            this._circuitPictureBox.TabIndex = 10;
            this._circuitPictureBox.TabStop = false;
            // 
            // CircuitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 257);
            this.Controls.Add(this._circuitPictureBox);
            this.Controls.Add(this._selectCircuitLabel);
            this.Controls.Add(this._calculateButton);
            this.Controls.Add(this._testCircuitsComboBox);
            this.Controls.Add(this._treeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CircuitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CircuitForm";
            ((System.ComponentModel.ISupportInitialize)(this._circuitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView _treeView;
        private System.Windows.Forms.ComboBox _testCircuitsComboBox;
        private System.Windows.Forms.Button _calculateButton;
        private System.Windows.Forms.Label _selectCircuitLabel;
        private System.Windows.Forms.PictureBox _circuitPictureBox;
    }
}