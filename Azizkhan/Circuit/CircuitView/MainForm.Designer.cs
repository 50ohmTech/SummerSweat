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
            this.AddElementButton = new System.Windows.Forms.Button();
            this.FrequencyGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // AddElementButton
            // 
            this.AddElementButton.Location = new System.Drawing.Point(673, 415);
            this.AddElementButton.Name = "AddElementButton";
            this.AddElementButton.Size = new System.Drawing.Size(115, 23);
            this.AddElementButton.TabIndex = 1;
            this.AddElementButton.Text = "Добавить элемент";
            this.AddElementButton.UseVisualStyleBackColor = true;
            this.AddElementButton.Click += new System.EventHandler(this.AddElementButton_Click);
            // 
            // FrequencyGrid
            // 
            this.FrequencyGrid.Location = new System.Drawing.Point(13, 235);
            this.FrequencyGrid.Name = "FrequencyGrid";
            this.FrequencyGrid.Size = new System.Drawing.Size(187, 204);
            this.FrequencyGrid.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FrequencyGrid);
            this.Controls.Add(this.AddElementButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Импеданс";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddElementButton;
        private System.Windows.Forms.PropertyGrid FrequencyGrid;
    }
}

