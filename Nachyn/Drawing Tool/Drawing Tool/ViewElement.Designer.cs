namespace DrawingTool
{
    sealed partial class ViewElement
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
            this.components = new System.ComponentModel.Container();
            this._labelValue = new System.Windows.Forms.Label();
            this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._toolStripMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this._labelName = new System.Windows.Forms.Label();
            this._contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _labelValue
            // 
            this._labelValue.AutoSize = true;
            this._labelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._labelValue.Location = new System.Drawing.Point(3, 53);
            this._labelValue.Name = "_labelValue";
            this._labelValue.Size = new System.Drawing.Size(64, 12);
            this._labelValue.TabIndex = 0;
            this._labelValue.Text = "Номинал: 777";
            // 
            // _contextMenuStrip
            // 
            this._contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuEdit,
            this._toolStripMenuDelete});
            this._contextMenuStrip.Name = "_contextMenuStrip";
            this._contextMenuStrip.ShowImageMargin = false;
            this._contextMenuStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // _toolStripMenuEdit
            // 
            this._toolStripMenuEdit.Name = "_toolStripMenuEdit";
            this._toolStripMenuEdit.Size = new System.Drawing.Size(103, 22);
            this._toolStripMenuEdit.Text = "Изменить";
            this._toolStripMenuEdit.Click += new System.EventHandler(this.ToolStripMenuAdd_Click);
            // 
            // _toolStripMenuDelete
            // 
            this._toolStripMenuDelete.Name = "_toolStripMenuDelete";
            this._toolStripMenuDelete.Size = new System.Drawing.Size(103, 22);
            this._toolStripMenuDelete.Text = "Удалить";
            this._toolStripMenuDelete.Click += new System.EventHandler(this.ToolStripMenuDelete_Click);
            // 
            // _labelName
            // 
            this._labelName.AutoSize = true;
            this._labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._labelName.Location = new System.Drawing.Point(3, 41);
            this._labelName.Name = "_labelName";
            this._labelName.Size = new System.Drawing.Size(50, 12);
            this._labelName.TabIndex = 1;
            this._labelName.Text = "Имя: C123";
            // 
            // ViewElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DrawingTool.Properties.Resources.Capacitor;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ContextMenuStrip = this._contextMenuStrip;
            this.Controls.Add(this._labelName);
            this.Controls.Add(this._labelValue);
            this.DoubleBuffered = true;
            this.Name = "ViewElement";
            this.Size = new System.Drawing.Size(80, 67);
            this._contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelValue;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuDelete;
        private System.Windows.Forms.Label _labelName;
    }
}
