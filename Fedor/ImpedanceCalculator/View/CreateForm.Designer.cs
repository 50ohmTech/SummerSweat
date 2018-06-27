namespace View
{
    partial class CreateForm
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
            this.circuitComboBox = new System.Windows.Forms.ComboBox();
            this.circuitControl = new View.CircuitControl();
            this.SuspendLayout();
            // 
            // circuitComboBox
            // 
            this.circuitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.circuitComboBox.FormattingEnabled = true;
            this.circuitComboBox.Items.AddRange(new object[] {
            "Цепь 1",
            "Цепь 2",
            "Цепь 3",
            "Цепь 4",
            "Цепь 5"});
            this.circuitComboBox.Location = new System.Drawing.Point(12, 12);
            this.circuitComboBox.Name = "circuitComboBox";
            this.circuitComboBox.Size = new System.Drawing.Size(121, 24);
            this.circuitComboBox.TabIndex = 0;
            this.circuitComboBox.SelectedIndexChanged += new System.EventHandler(this.circuitComboBox_SelectedIndexChanged);
            // 
            // circuitControl
            // 
            this.circuitControl.Location = new System.Drawing.Point(12, 43);
            this.circuitControl.Name = "circuitControl";
            this.circuitControl.Size = new System.Drawing.Size(992, 523);
            this.circuitControl.TabIndex = 1;
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 600);
            this.Controls.Add(this.circuitControl);
            this.Controls.Add(this.circuitComboBox);
            this.Name = "CreateForm";
            this.Text = "Circuit Calculator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox circuitComboBox;
        private CircuitControl circuitControl;
    }
}

