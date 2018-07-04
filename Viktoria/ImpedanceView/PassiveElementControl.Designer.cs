namespace ImpedanceView
{
    partial class PassiveElementControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.FirstTextView = new System.Windows.Forms.TextBox();
            this.ElementTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // FirstTextView
            // 
            this.FirstTextView.Location = new System.Drawing.Point(3, 35);
            this.FirstTextView.Name = "FirstTextView";
            this.FirstTextView.Size = new System.Drawing.Size(184, 20);
            this.FirstTextView.TabIndex = 3;
            this.FirstTextView.Click += new System.EventHandler(this.FirstTextView_Click);
            this.FirstTextView.Leave += new System.EventHandler(this.FirstTextView_Leave);
            // 
            // ElementTypeComboBox
            // 
            this.ElementTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ElementTypeComboBox.FormattingEnabled = true;
            this.ElementTypeComboBox.Items.AddRange(new object[] {
            "Катушка индуктивности",
            "Резистор",
            "Конденсатор"});
            this.ElementTypeComboBox.Location = new System.Drawing.Point(3, 8);
            this.ElementTypeComboBox.Name = "ElementTypeComboBox";
            this.ElementTypeComboBox.Size = new System.Drawing.Size(184, 21);
            this.ElementTypeComboBox.TabIndex = 2;
            this.ElementTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.ElementTypeComboBox_SelectionChangeCommitted);
            // 
            // PassiveElementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FirstTextView);
            this.Controls.Add(this.ElementTypeComboBox);
            this.Name = "PassiveElementControl";
            this.Size = new System.Drawing.Size(190, 66);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirstTextView;
        private System.Windows.Forms.ComboBox ElementTypeComboBox;
    }
}
