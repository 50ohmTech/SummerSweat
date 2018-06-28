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
            this._addElementButton = new System.Windows.Forms.Button();
            this._frequencyGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // _addElementButton
            // 
            this._addElementButton.Location = new System.Drawing.Point(673, 415);
            this._addElementButton.Name = "_addElementButton";
            this._addElementButton.Size = new System.Drawing.Size(115, 23);
            this._addElementButton.TabIndex = 1;
            this._addElementButton.Text = "Добавить элемент";
            this._addElementButton.UseVisualStyleBackColor = true;
            this._addElementButton.Click += new System.EventHandler(this.AddElementButton_Click);
            // 
            // _frequencyGrid
            // 
            this._frequencyGrid.Location = new System.Drawing.Point(13, 235);
            this._frequencyGrid.Name = "_frequencyGrid";
            this._frequencyGrid.Size = new System.Drawing.Size(187, 204);
            this._frequencyGrid.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._frequencyGrid);
            this.Controls.Add(this._addElementButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Импеданс";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _addElementButton;
        private System.Windows.Forms.PropertyGrid _frequencyGrid;
    }
}

