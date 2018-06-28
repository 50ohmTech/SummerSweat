namespace CircuitCalculator.Controls
{
    partial class ElementControl
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
			this.NameLabel = new System.Windows.Forms.Label();
			this.ElementPictureBox = new System.Windows.Forms.PictureBox();
			this.ValueTextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.ElementPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(28, 4);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(58, 17);
			this.NameLabel.TabIndex = 1;
			this.NameLabel.Text = "element";
			this.NameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseDown);
			this.NameLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseMove);
			this.NameLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseUp);
			// 
			// ElementPictureBox
			// 
			this.ElementPictureBox.Location = new System.Drawing.Point(0, 10);
			this.ElementPictureBox.Name = "ElementPictureBox";
			this.ElementPictureBox.Size = new System.Drawing.Size(83, 52);
			this.ElementPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ElementPictureBox.TabIndex = 0;
			this.ElementPictureBox.TabStop = false;
			this.ElementPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseDown);
			this.ElementPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseMove);
			this.ElementPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseUp);
			// 
			// ValueTextBox
			// 
			this.ValueTextBox.Enabled = false;
			this.ValueTextBox.Location = new System.Drawing.Point(14, 53);
			this.ValueTextBox.Name = "ValueTextBox";
			this.ValueTextBox.Size = new System.Drawing.Size(55, 22);
			this.ValueTextBox.TabIndex = 2;
			this.ValueTextBox.TextChanged += new System.EventHandler(this.ValueTextBox_TextChanged);
			// 
			// ElementControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.Controls.Add(this.ValueTextBox);
			this.Controls.Add(this.NameLabel);
			this.Controls.Add(this.ElementPictureBox);
			this.Enabled = false;
			this.Name = "ElementControl";
			this.Size = new System.Drawing.Size(81, 83);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseUp);
			((System.ComponentModel.ISupportInitialize)(this.ElementPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.PictureBox ElementPictureBox;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.TextBox ValueTextBox;
	}
}
