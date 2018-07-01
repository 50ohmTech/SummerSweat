using System.Windows.Forms;

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
            this.label1 = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.circuitControl = new View.CircuitControl();
            this.circuitPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.circuitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // circuitComboBox
            // 
            this.circuitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.circuitComboBox.FormattingEnabled = true;
            this.circuitComboBox.Items.AddRange(new object[] {
            "Создать цепь",
            "Цепь 1",
            "Цепь 2",
            "Цепь 3"});
            this.circuitComboBox.Location = new System.Drawing.Point(127, 6);
            this.circuitComboBox.Name = "circuitComboBox";
            this.circuitComboBox.Size = new System.Drawing.Size(121, 24);
            this.circuitComboBox.TabIndex = 0;
            this.circuitComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите цепь";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(774, 565);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(158, 36);
            this.calculateButton.TabIndex = 3;
            this.calculateButton.Text = "Расчитать импеданс";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // circuitControl
            // 
            this.circuitControl.Location = new System.Drawing.Point(12, 36);
            this.circuitControl.Name = "circuitControl";
            this.circuitControl.Size = new System.Drawing.Size(246, 523);
            this.circuitControl.TabIndex = 1;
            // 
            // circuitPictureBox
            // 
            this.circuitPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.circuitPictureBox.Location = new System.Drawing.Point(264, 6);
            this.circuitPictureBox.Name = "circuitPictureBox";
            this.circuitPictureBox.Size = new System.Drawing.Size(668, 553);
            this.circuitPictureBox.TabIndex = 4;
            this.circuitPictureBox.TabStop = false;
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 653);
            this.MaximumSize = new System.Drawing.Size(962, 653);
            this.MinimumSize = new System.Drawing.Size(962, 653);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Controls.Add(this.circuitPictureBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.circuitControl);
            this.Controls.Add(this.circuitComboBox);
            this.Name = "CreateForm";
            this.Text = "Circuit Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.circuitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox circuitComboBox;
        private CircuitControl circuitControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.PictureBox circuitPictureBox;
    }
}

