namespace View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._panelCircuit = new System.Windows.Forms.Panel();
            this._toolStripMainMenu = new System.Windows.Forms.ToolStrip();
            this._toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripButtonClearCircuit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripButtonCalculate = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this._propertyGrid = new System.Windows.Forms.PropertyGrid();
            this._toolStripMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelCircuit
            // 
            this._panelCircuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panelCircuit.Location = new System.Drawing.Point(12, 28);
            this._panelCircuit.Name = "_panelCircuit";
            this._panelCircuit.Size = new System.Drawing.Size(600, 202);
            this._panelCircuit.TabIndex = 0;
            // 
            // _toolStripMainMenu
            // 
            this._toolStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButtonAdd,
            this._toolStripSeparator1,
            this._toolStripButtonClearCircuit,
            this.toolStripSeparator1,
            this._toolStripButtonCalculate});
            this._toolStripMainMenu.Location = new System.Drawing.Point(0, 0);
            this._toolStripMainMenu.Name = "_toolStripMainMenu";
            this._toolStripMainMenu.Size = new System.Drawing.Size(703, 25);
            this._toolStripMainMenu.TabIndex = 1;
            this._toolStripMainMenu.Text = "_toolStripMainMenu";
            // 
            // _toolStripButtonAdd
            // 
            this._toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonAdd.Image")));
            this._toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonAdd.Name = "_toolStripButtonAdd";
            this._toolStripButtonAdd.Size = new System.Drawing.Size(63, 22);
            this._toolStripButtonAdd.Text = "Добавить";
            this._toolStripButtonAdd.Click += new System.EventHandler(this._toolStripButtonAdd_Click);
            // 
            // _toolStripSeparator1
            // 
            this._toolStripSeparator1.Name = "_toolStripSeparator1";
            this._toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _toolStripButtonClearCircuit
            // 
            this._toolStripButtonClearCircuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButtonClearCircuit.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonClearCircuit.Image")));
            this._toolStripButtonClearCircuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonClearCircuit.Name = "_toolStripButtonClearCircuit";
            this._toolStripButtonClearCircuit.Size = new System.Drawing.Size(92, 22);
            this._toolStripButtonClearCircuit.Text = "Очистить цепь";
            this._toolStripButtonClearCircuit.Click += new System.EventHandler(this._toolStripButtonClearCircuit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _toolStripButtonCalculate
            // 
            this._toolStripButtonCalculate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButtonCalculate.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonCalculate.Image")));
            this._toolStripButtonCalculate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonCalculate.Name = "_toolStripButtonCalculate";
            this._toolStripButtonCalculate.Size = new System.Drawing.Size(132, 22);
            this._toolStripButtonCalculate.Text = "Расчитать импедансы";
            this._toolStripButtonCalculate.Click += new System.EventHandler(this._toolStripButtonCalculate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _propertyGrid
            // 
            this._propertyGrid.Location = new System.Drawing.Point(12, 236);
            this._propertyGrid.Name = "_propertyGrid";
            this._propertyGrid.Size = new System.Drawing.Size(337, 140);
            this._propertyGrid.TabIndex = 3;
            this._propertyGrid.ToolbarVisible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 406);
            this.Controls.Add(this._propertyGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._toolStripMainMenu);
            this.Controls.Add(this._panelCircuit);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчет импедансов";
            this._toolStripMainMenu.ResumeLayout(false);
            this._toolStripMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _panelCircuit;
        private System.Windows.Forms.ToolStrip _toolStripMainMenu;
        private System.Windows.Forms.ToolStripButton _toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton _toolStripButtonClearCircuit;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PropertyGrid _propertyGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _toolStripButtonCalculate;
    }
}