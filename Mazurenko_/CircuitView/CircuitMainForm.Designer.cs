using System.Drawing;

namespace CircuitView
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
            this.PaintGroupBox = new System.Windows.Forms.GroupBox();
            this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CalculateImpedanceButton = new System.Windows.Forms.Button();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.CircuitsComboBox = new System.Windows.Forms.ComboBox();
            this.SelectingCircuitLabel = new System.Windows.Forms.Label();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.NodeComboBox = new System.Windows.Forms.ComboBox();
            this.NodeComboBoxLabel = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.PaintGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PaintGroupBox
            // 
            this.PaintGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PaintGroupBox.Controls.Add(this.CircuitPictureBox);
            this.PaintGroupBox.Location = new System.Drawing.Point(223, 12);
            this.PaintGroupBox.Name = "PaintGroupBox";
            this.PaintGroupBox.Size = new System.Drawing.Size(507, 402);
            this.PaintGroupBox.TabIndex = 0;
            this.PaintGroupBox.TabStop = false;
            // 
            // CircuitPictureBox
            // 
            this.CircuitPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CircuitPictureBox.Location = new System.Drawing.Point(16, 22);
            this.CircuitPictureBox.Name = "CircuitPictureBox";
            this.CircuitPictureBox.Size = new System.Drawing.Size(476, 364);
            this.CircuitPictureBox.TabIndex = 0;
            this.CircuitPictureBox.TabStop = false;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButton.Location = new System.Drawing.Point(17, 310);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(198, 27);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteButton.Location = new System.Drawing.Point(17, 343);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(93, 27);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CalculateImpedanceButton
            // 
            this.CalculateImpedanceButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CalculateImpedanceButton.Location = new System.Drawing.Point(17, 376);
            this.CalculateImpedanceButton.Name = "CalculateImpedanceButton";
            this.CalculateImpedanceButton.Size = new System.Drawing.Size(198, 27);
            this.CalculateImpedanceButton.TabIndex = 8;
            this.CalculateImpedanceButton.Text = "Calculation of impedance";
            this.CalculateImpedanceButton.UseVisualStyleBackColor = true;
            this.CalculateImpedanceButton.Click += new System.EventHandler(this.CalculateImpedanceButton_Click);
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ValueTextBox.Location = new System.Drawing.Point(17, 276);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(198, 23);
            this.ValueTextBox.TabIndex = 4;
            this.ValueTextBox.TextChanged += new System.EventHandler(this.ValueTextBox_TextChanged);
            this.ValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTextBox_KeyPress);
            this.ValueTextBox.Leave += new System.EventHandler(this.ValueTextBox_Leave);
            // 
            // CircuitsComboBox
            // 
            this.CircuitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CircuitsComboBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CircuitsComboBox.FormattingEnabled = true;
            this.CircuitsComboBox.Items.AddRange(new object[] {
            "New electrical circuit",
            "Electrical circuit №1",
            "Electrical circuit №2",
            "Electrical circuit №3",
            "Electrical circuit №4",
            "Electrical circuit №5"});
            this.CircuitsComboBox.Location = new System.Drawing.Point(17, 41);
            this.CircuitsComboBox.Name = "CircuitsComboBox";
            this.CircuitsComboBox.Size = new System.Drawing.Size(198, 23);
            this.CircuitsComboBox.TabIndex = 1;
            this.CircuitsComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectingCircuitComboBox_SelectedIndexChanged);
            // 
            // SelectingCircuitLabel
            // 
            this.SelectingCircuitLabel.AutoSize = true;
            this.SelectingCircuitLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectingCircuitLabel.Location = new System.Drawing.Point(14, 18);
            this.SelectingCircuitLabel.Name = "SelectingCircuitLabel";
            this.SelectingCircuitLabel.Size = new System.Drawing.Size(99, 16);
            this.SelectingCircuitLabel.TabIndex = 5;
            this.SelectingCircuitLabel.Text = "Selection circuit";
            // 
            // TreeView
            // 
            this.TreeView.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TreeView.Location = new System.Drawing.Point(17, 72);
            this.TreeView.MinimumSize = new System.Drawing.Size(198, 127);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(198, 127);
            this.TreeView.TabIndex = 2;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.TreeView.DoubleClick += new System.EventHandler(this.EditValue);
            // 
            // NodeComboBox
            // 
            this.NodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NodeComboBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NodeComboBox.FormattingEnabled = true;
            this.NodeComboBox.Items.AddRange(new object[] {
            "Serial",
            "Parallel",
            "Resistor",
            "Capacitor",
            "Inductor"});
            this.NodeComboBox.Location = new System.Drawing.Point(17, 225);
            this.NodeComboBox.Name = "NodeComboBox";
            this.NodeComboBox.Size = new System.Drawing.Size(198, 23);
            this.NodeComboBox.TabIndex = 3;
            this.NodeComboBox.SelectedIndexChanged += new System.EventHandler(this.NodeComboBox_SelectedIndexChanged);
            // 
            // NodeComboBoxLabel
            // 
            this.NodeComboBoxLabel.AutoSize = true;
            this.NodeComboBoxLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NodeComboBoxLabel.Location = new System.Drawing.Point(14, 204);
            this.NodeComboBoxLabel.Name = "NodeComboBoxLabel";
            this.NodeComboBoxLabel.Size = new System.Drawing.Size(78, 16);
            this.NodeComboBoxLabel.TabIndex = 8;
            this.NodeComboBoxLabel.Text = "Add element";
            // 
            // EditButton
            // 
            this.EditButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditButton.Location = new System.Drawing.Point(122, 343);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(93, 27);
            this.EditButton.TabIndex = 7;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditValue);
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ValueLabel.Location = new System.Drawing.Point(14, 255);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(37, 16);
            this.ValueLabel.TabIndex = 9;
            this.ValueLabel.Text = "Value";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 430);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.NodeComboBoxLabel);
            this.Controls.Add(this.NodeComboBox);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.SelectingCircuitLabel);
            this.Controls.Add(this.CircuitsComboBox);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CalculateImpedanceButton);
            this.Controls.Add(this.PaintGroupBox);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(643, 387);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Electrical circuit";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PaintGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PaintGroupBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CalculateImpedanceButton;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.ComboBox CircuitsComboBox;
        private System.Windows.Forms.Label SelectingCircuitLabel;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.ComboBox NodeComboBox;
        private System.Windows.Forms.Label NodeComboBoxLabel;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.PictureBox CircuitPictureBox;
    }
}

