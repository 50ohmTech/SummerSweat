namespace CircuitCalculator.Controls.ElementsOfCircuit
{
	partial class InductorControl
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
			((System.ComponentModel.ISupportInitialize)(this.elementPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// elementPictureBox
			// 
			this.elementPictureBox.Image = global::CircuitCalculator.Properties.Resources.inductor;
			this.elementPictureBox.Size = new System.Drawing.Size(83, 52);
			// 
			// InductorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "InductorControl";
			this.Size = new System.Drawing.Size(81, 82);
			((System.ComponentModel.ISupportInitialize)(this.elementPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
	}
}
