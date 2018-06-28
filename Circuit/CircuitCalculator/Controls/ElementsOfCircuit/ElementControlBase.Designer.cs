namespace CircuitCalculator.Controls.ElementsOfCircuit
{
	partial class ElementControlBase
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
			this.valueTextBox = new System.Windows.Forms.TextBox();
			this.elementName = new System.Windows.Forms.Label();
			this.elementPictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.elementPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// valueTextBox
			// 
			this.valueTextBox.Enabled = false;
			this.valueTextBox.Location = new System.Drawing.Point(14, 53);
			this.valueTextBox.Name = "valueTextBox";
			this.valueTextBox.Size = new System.Drawing.Size(55, 22);
			this.valueTextBox.TabIndex = 5;
			this.valueTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
			this.valueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valueTextBox_KeyPress);
			// 
			// elementName
			// 
			this.elementName.AutoSize = true;
			this.elementName.Location = new System.Drawing.Point(28, 4);
			this.elementName.Name = "elementName";
			this.elementName.Size = new System.Drawing.Size(58, 17);
			this.elementName.TabIndex = 4;
			this.elementName.Text = "element";
			this.elementName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.elementName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseDown);
			this.elementName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseMove);
			this.elementName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseUp);
			// 
			// elementPictureBox
			// 
			this.elementPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.elementPictureBox.Location = new System.Drawing.Point(0, 10);
			this.elementPictureBox.Name = "elementPictureBox";
			this.elementPictureBox.Size = new System.Drawing.Size(100, 70);
			this.elementPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.elementPictureBox.TabIndex = 3;
			this.elementPictureBox.TabStop = false;
			this.elementPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseDown);
			this.elementPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseMove);
			this.elementPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseUp);
			// 
			// ElementControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.Controls.Add(this.valueTextBox);
			this.Controls.Add(this.elementName);
			this.Controls.Add(this.elementPictureBox);
			this.Name = "ElementControlBase";
			this.Size = new System.Drawing.Size(101, 90);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ElementControl_MouseUp);
			((System.ComponentModel.ISupportInitialize)(this.elementPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.TextBox valueTextBox;
		protected System.Windows.Forms.Label elementName;
		protected System.Windows.Forms.PictureBox elementPictureBox;
	}
}
