namespace View
{
    sealed partial class Element
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
            this._contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _labelValue
            // 
            this._labelValue.AutoSize = true;
            this._labelValue.Location = new System.Drawing.Point(25, 44);
            this._labelValue.Name = "_labelValue";
            this._labelValue.Size = new System.Drawing.Size(35, 13);
            this._labelValue.TabIndex = 0;
            this._labelValue.Text = "V 777";
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
            this._toolStripMenuEdit.Click += new System.EventHandler(this.ToolStripMenuAddClick);
            // 
            // _toolStripMenuDelete
            // 
            this._toolStripMenuDelete.Name = "_toolStripMenuDelete";
            this._toolStripMenuDelete.Size = new System.Drawing.Size(103, 22);
            this._toolStripMenuDelete.Text = "Удалить";
            this._toolStripMenuDelete.Click += new System.EventHandler(this.ToolStripMenuDeleteClick);
            // 
            // Element
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ContextMenuStrip = this._contextMenuStrip;
            this.Controls.Add(this._labelValue);
            this.Name = "Element";
            this.Size = new System.Drawing.Size(83, 60);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElementMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ElementMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ElementMouseUp);
            this._contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelValue;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuDelete;
    }
}
