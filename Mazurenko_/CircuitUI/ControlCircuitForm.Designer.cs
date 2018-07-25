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
            this.groupBoxElementsCircuit = new System.Windows.Forms.GroupBox();
            this.pictureBoxElementCircuit = new System.Windows.Forms.PictureBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelNominalValue = new System.Windows.Forms.Label();
            this.labelCircuitElementType = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBoxElementsCircuit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxElementCircuit)).BeginInit();
            this.groupBoxButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxElementsCircuit
            // 
            this.groupBoxElementsCircuit.Controls.Add(this.pictureBoxElementCircuit);
            this.groupBoxElementsCircuit.Controls.Add(this.textBoxValue);
            this.groupBoxElementsCircuit.Controls.Add(this.textBoxName);
            this.groupBoxElementsCircuit.Controls.Add(this.labelNominalValue);
            this.groupBoxElementsCircuit.Controls.Add(this.labelCircuitElementType);
            this.groupBoxElementsCircuit.Controls.Add(this.labelName);
            this.groupBoxElementsCircuit.Controls.Add(this.comboBoxType);
            this.groupBoxElementsCircuit.Location = new System.Drawing.Point(12, 12);
            this.groupBoxElementsCircuit.Name = "groupBoxElementsCircuit";
            this.groupBoxElementsCircuit.Size = new System.Drawing.Size(291, 125);
            this.groupBoxElementsCircuit.TabIndex = 4;
            this.groupBoxElementsCircuit.TabStop = false;
            this.groupBoxElementsCircuit.Text = "The action with the circuit elements";
            // 
            // pictureBoxElementCircuit
            // 
            this.pictureBoxElementCircuit.Location = new System.Drawing.Point(178, 40);
            this.pictureBoxElementCircuit.Name = "pictureBoxElementCircuit";
            this.pictureBoxElementCircuit.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxElementCircuit.TabIndex = 8;
            this.pictureBoxElementCircuit.TabStop = false;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(88, 83);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(84, 20);
            this.textBoxValue.TabIndex = 7;
            this.textBoxValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxValue_KeyPress);
            this.textBoxValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxValue_KeyUp);
            this.textBoxValue.Leave += new System.EventHandler(this.TextBoxValue_Leave);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(88, 53);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(84, 20);
            this.textBoxName.TabIndex = 5;
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxName_KeyPress);
            this.textBoxName.Leave += new System.EventHandler(this.TextBoxName_Leave);
            // 
            // labelNominalValue
            // 
            this.labelNominalValue.AutoSize = true;
            this.labelNominalValue.Location = new System.Drawing.Point(6, 86);
            this.labelNominalValue.Name = "labelNominalValue";
            this.labelNominalValue.Size = new System.Drawing.Size(74, 13);
            this.labelNominalValue.TabIndex = 6;
            this.labelNominalValue.Text = "Nominal value";
            // 
            // labelCircuitElementType
            // 
            this.labelCircuitElementType.AutoSize = true;
            this.labelCircuitElementType.Location = new System.Drawing.Point(6, 22);
            this.labelCircuitElementType.Name = "labelCircuitElementType";
            this.labelCircuitElementType.Size = new System.Drawing.Size(76, 26);
            this.labelCircuitElementType.TabIndex = 5;
            this.labelCircuitElementType.Text = "Circuit element\r\ntype";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 56);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Name";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Resistor",
            "Inductor",
            "Capacitor"});
            this.comboBoxType.Location = new System.Drawing.Point(88, 26);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(84, 21);
            this.comboBoxType.TabIndex = 5;
            this.comboBoxType.SelectedValueChanged += new System.EventHandler(this.ComboBoxType_SelectedValueChanged);
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.buttonCancel);
            this.groupBoxButtons.Controls.Add(this.buttonOK);
            this.groupBoxButtons.Location = new System.Drawing.Point(12, 141);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(206, 59);
            this.groupBoxButtons.TabIndex = 5;
            this.groupBoxButtons.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(101, 19);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 27);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(9, 19);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(81, 27);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ControlCircuitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 207);
            this.Controls.Add(this.groupBoxButtons);
            this.Controls.Add(this.groupBoxElementsCircuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControlCircuitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Circuit";
            this.groupBoxElementsCircuit.ResumeLayout(false);
            this.groupBoxElementsCircuit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxElementCircuit)).EndInit();
            this.groupBoxButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxElementsCircuit;
        private System.Windows.Forms.Label labelCircuitElementType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelNominalValue;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pictureBoxElementCircuit;
        private System.Windows.Forms.GroupBox groupBoxButtons;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
    }
}