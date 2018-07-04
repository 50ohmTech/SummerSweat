namespace View
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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemChain1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemChain2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemChain3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemChain4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemChain5 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PictureBoxCircuitDiagram = new System.Windows.Forms.PictureBox();
            this.ButtonCalculate = new System.Windows.Forms.Button();
            this.ButtonChange = new System.Windows.Forms.Button();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCircuitDiagram)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(570, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemChain1,
            this.ToolStripMenuItemChain2,
            this.ToolStripMenuItemChain3,
            this.ToolStripMenuItemChain4,
            this.ToolStripMenuItemChain5});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.ToolStripMenuItem.Text = "Выбрать цепь";
            this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemChain1
            // 
            this.ToolStripMenuItemChain1.Name = "ToolStripMenuItemChain1";
            this.ToolStripMenuItemChain1.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemChain1.Text = "Цепь №1";
            // 
            // ToolStripMenuItemChain2
            // 
            this.ToolStripMenuItemChain2.Name = "ToolStripMenuItemChain2";
            this.ToolStripMenuItemChain2.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemChain2.Text = "Цепь №2";
            // 
            // ToolStripMenuItemChain3
            // 
            this.ToolStripMenuItemChain3.Name = "ToolStripMenuItemChain3";
            this.ToolStripMenuItemChain3.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemChain3.Text = "Цепь №3";
            // 
            // ToolStripMenuItemChain4
            // 
            this.ToolStripMenuItemChain4.Name = "ToolStripMenuItemChain4";
            this.ToolStripMenuItemChain4.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemChain4.Text = "Цепь №4";
            // 
            // ToolStripMenuItemChain5
            // 
            this.ToolStripMenuItemChain5.Name = "ToolStripMenuItemChain5";
            this.ToolStripMenuItemChain5.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemChain5.Text = "Цепь №5";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(226, 146);
            this.dataGridView1.TabIndex = 1;
            // 
            // PictureBoxCircuitDiagram
            // 
            this.PictureBoxCircuitDiagram.Location = new System.Drawing.Point(280, 40);
            this.PictureBoxCircuitDiagram.Name = "PictureBoxCircuitDiagram";
            this.PictureBoxCircuitDiagram.Size = new System.Drawing.Size(267, 223);
            this.PictureBoxCircuitDiagram.TabIndex = 2;
            this.PictureBoxCircuitDiagram.TabStop = false;
            // 
            // ButtonCalculate
            // 
            this.ButtonCalculate.Location = new System.Drawing.Point(12, 230);
            this.ButtonCalculate.Name = "ButtonCalculate";
            this.ButtonCalculate.Size = new System.Drawing.Size(95, 23);
            this.ButtonCalculate.TabIndex = 3;
            this.ButtonCalculate.Text = "Рассчитать";
            this.ButtonCalculate.UseVisualStyleBackColor = true;
            // 
            // ButtonChange
            // 
            this.ButtonChange.Location = new System.Drawing.Point(143, 230);
            this.ButtonChange.Name = "ButtonChange";
            this.ButtonChange.Size = new System.Drawing.Size(95, 23);
            this.ButtonChange.TabIndex = 4;
            this.ButtonChange.Text = "Изменить";
            this.ButtonChange.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 277);
            this.Controls.Add(this.ButtonChange);
            this.Controls.Add(this.ButtonCalculate);
            this.Controls.Add(this.PictureBoxCircuitDiagram);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.MenuStrip);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCircuitDiagram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChain1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChain2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChain3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChain4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChain5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox PictureBoxCircuitDiagram;
        private System.Windows.Forms.Button ButtonCalculate;
        private System.Windows.Forms.Button ButtonChange;
    }
}

