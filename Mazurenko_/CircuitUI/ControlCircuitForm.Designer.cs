namespace CircuitUI
{
    partial class ControlCircuitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCircuitForm));
            this.elementsCircuitGroupBox = new System.Windows.Forms.GroupBox();
            this.elementCircuitPictureBox = new System.Windows.Forms.PictureBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nominalValueLabel = new System.Windows.Forms.Label();
            this.circuitElementTypeLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.buttonsGroupBox = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.elementsCircuitGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementCircuitPictureBox)).BeginInit();
            this.buttonsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // elementsCircuitGroupBox
            // 
            this.elementsCircuitGroupBox.Controls.Add(this.elementCircuitPictureBox);
            this.elementsCircuitGroupBox.Controls.Add(this.valueTextBox);
            this.elementsCircuitGroupBox.Controls.Add(this.nameTextBox);
            this.elementsCircuitGroupBox.Controls.Add(this.nominalValueLabel);
            this.elementsCircuitGroupBox.Controls.Add(this.circuitElementTypeLabel);
            this.elementsCircuitGroupBox.Controls.Add(this.nameLabel);
            this.elementsCircuitGroupBox.Controls.Add(this.typeComboBox);
            this.elementsCircuitGroupBox.Location = new System.Drawing.Point(10, 10);
            this.elementsCircuitGroupBox.Name = "elementsCircuitGroupBox";
            this.elementsCircuitGroupBox.Size = new System.Drawing.Size(274, 114);
            this.elementsCircuitGroupBox.TabIndex = 4;
            this.elementsCircuitGroupBox.TabStop = false;
            this.elementsCircuitGroupBox.Text = "The action with the circuit elements";
            // 
            // elementCircuitPictureBox
            // 
            this.elementCircuitPictureBox.Location = new System.Drawing.Point(178, 35);
            this.elementCircuitPictureBox.Name = "elementCircuitPictureBox";
            this.elementCircuitPictureBox.Size = new System.Drawing.Size(89, 50);
            this.elementCircuitPictureBox.TabIndex = 8;
            this.elementCircuitPictureBox.TabStop = false;
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(88, 83);
            this.valueTextBox.MaxLength = 13;
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(84, 20);
            this.valueTextBox.TabIndex = 3;
            this.valueTextBox.TextChanged += new System.EventHandler(this.ValueTextBox_TextChanged);
            this.valueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTextBox_KeyPress);
            this.valueTextBox.Leave += new System.EventHandler(this.ValueTextBox_Leave);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(88, 53);
            this.nameTextBox.MaxLength = 10;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(84, 20);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameTextBox_KeyPress);
            this.nameTextBox.Leave += new System.EventHandler(this.NameTextBox_Leave);
            // 
            // nominalValueLabel
            // 
            this.nominalValueLabel.AutoSize = true;
            this.nominalValueLabel.Location = new System.Drawing.Point(6, 86);
            this.nominalValueLabel.Name = "nominalValueLabel";
            this.nominalValueLabel.Size = new System.Drawing.Size(74, 13);
            this.nominalValueLabel.TabIndex = 6;
            this.nominalValueLabel.Text = "Nominal value";
            // 
            // circuitElementTypeLabel
            // 
            this.circuitElementTypeLabel.AutoSize = true;
            this.circuitElementTypeLabel.Location = new System.Drawing.Point(6, 22);
            this.circuitElementTypeLabel.Name = "circuitElementTypeLabel";
            this.circuitElementTypeLabel.Size = new System.Drawing.Size(76, 26);
            this.circuitElementTypeLabel.TabIndex = 5;
            this.circuitElementTypeLabel.Text = "Circuit element\r\ntype";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 56);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Name";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Resistor",
            "Inductor",
            "Capacitor"});
            this.typeComboBox.Location = new System.Drawing.Point(88, 26);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(84, 21);
            this.typeComboBox.TabIndex = 1;
            this.typeComboBox.SelectedValueChanged += new System.EventHandler(this.TypeComboBox_SelectedValueChanged);
            // 
            // buttonsGroupBox
            // 
            this.buttonsGroupBox.Controls.Add(this.cancelButton);
            this.buttonsGroupBox.Controls.Add(this.OKButton);
            this.buttonsGroupBox.Location = new System.Drawing.Point(63, 125);
            this.buttonsGroupBox.Name = "buttonsGroupBox";
            this.buttonsGroupBox.Size = new System.Drawing.Size(184, 52);
            this.buttonsGroupBox.TabIndex = 5;
            this.buttonsGroupBox.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(93, 14);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(81, 27);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(6, 14);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(81, 27);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ControlCircuitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 182);
            this.Controls.Add(this.buttonsGroupBox);
            this.Controls.Add(this.elementsCircuitGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControlCircuitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Circuit";
            this.elementsCircuitGroupBox.ResumeLayout(false);
            this.elementsCircuitGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementCircuitPictureBox)).EndInit();
            this.buttonsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox elementsCircuitGroupBox;
        private System.Windows.Forms.Label circuitElementTypeLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nominalValueLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox elementCircuitPictureBox;
        private System.Windows.Forms.GroupBox buttonsGroupBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
    }
}