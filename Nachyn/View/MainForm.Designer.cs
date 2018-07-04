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
            this._toolStripButtonControlPanel = new System.Windows.Forms.ToolStripButton();
            this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripButtonClearCircuit = new System.Windows.Forms.ToolStripButton();
            this._toolStripRandomizeCircuit = new System.Windows.Forms.ToolStripButton();
            this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripButtonCalculate = new System.Windows.Forms.ToolStripButton();
            this._propertyGrid = new System.Windows.Forms.PropertyGrid();
            this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripButtonHelp = new System.Windows.Forms.ToolStripButton();
            this._toolStripMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelCircuit
            // 
            this._panelCircuit.AutoScroll = true;
            this._panelCircuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._panelCircuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panelCircuit.Location = new System.Drawing.Point(12, 28);
            this._panelCircuit.Name = "_panelCircuit";
            this._panelCircuit.Size = new System.Drawing.Size(617, 304);
            this._panelCircuit.TabIndex = 0;
            // 
            // _toolStripMainMenu
            // 
            this._toolStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButtonControlPanel,
            this._toolStripSeparator1,
            this._toolStripButtonClearCircuit,
            this._toolStripRandomizeCircuit,
            this._toolStripSeparator2,
            this._toolStripButtonCalculate,
            this._toolStripSeparator3,
            this._toolStripButtonHelp});
            this._toolStripMainMenu.Location = new System.Drawing.Point(0, 0);
            this._toolStripMainMenu.Name = "_toolStripMainMenu";
            this._toolStripMainMenu.Size = new System.Drawing.Size(925, 25);
            this._toolStripMainMenu.TabIndex = 1;
            this._toolStripMainMenu.Text = "_toolStripMainMenu";
            // 
            // _toolStripButtonControlPanel
            // 
            this._toolStripButtonControlPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButtonControlPanel.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonControlPanel.Image")));
            this._toolStripButtonControlPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonControlPanel.Name = "_toolStripButtonControlPanel";
            this._toolStripButtonControlPanel.Size = new System.Drawing.Size(120, 22);
            this._toolStripButtonControlPanel.Text = "Панель управления";
            this._toolStripButtonControlPanel.Click += new System.EventHandler(this.ToolStripButtonAdd_Click);
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
            this._toolStripButtonClearCircuit.Click += new System.EventHandler(this.ToolStripButtonClearCircuit_Click);
            // 
            // _toolStripRandomizeCircuit
            // 
            this._toolStripRandomizeCircuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripRandomizeCircuit.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripRandomizeCircuit.Image")));
            this._toolStripRandomizeCircuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripRandomizeCircuit.Name = "_toolStripRandomizeCircuit";
            this._toolStripRandomizeCircuit.Size = new System.Drawing.Size(123, 22);
            this._toolStripRandomizeCircuit.Text = "Сгенерировать цепь";
            this._toolStripRandomizeCircuit.Click += new System.EventHandler(this.ToolStripRandomizeCircuit_Click);
            // 
            // _toolStripSeparator2
            // 
            this._toolStripSeparator2.Name = "_toolStripSeparator2";
            this._toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _toolStripButtonCalculate
            // 
            this._toolStripButtonCalculate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButtonCalculate.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonCalculate.Image")));
            this._toolStripButtonCalculate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonCalculate.Name = "_toolStripButtonCalculate";
            this._toolStripButtonCalculate.Size = new System.Drawing.Size(132, 22);
            this._toolStripButtonCalculate.Text = "Расчитать импедансы";
            this._toolStripButtonCalculate.Click += new System.EventHandler(this.ToolStripButtonCalculate_Click);
            // 
            // _propertyGrid
            // 
            this._propertyGrid.Location = new System.Drawing.Point(635, 28);
            this._propertyGrid.Name = "_propertyGrid";
            this._propertyGrid.Size = new System.Drawing.Size(278, 304);
            this._propertyGrid.TabIndex = 3;
            this._propertyGrid.ToolbarVisible = false;
            // 
            // _toolStripSeparator3
            // 
            this._toolStripSeparator3.Name = "_toolStripSeparator3";
            this._toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // _toolStripButtonHelp
            // 
            this._toolStripButtonHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButtonHelp.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonHelp.Image")));
            this._toolStripButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonHelp.Name = "_toolStripButtonHelp";
            this._toolStripButtonHelp.Size = new System.Drawing.Size(77, 22);
            this._toolStripButtonHelp.Text = "Инструкция";
            this._toolStripButtonHelp.Click += new System.EventHandler(this.ToolStripButtonHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 344);
            this.Controls.Add(this._panelCircuit);
            this.Controls.Add(this._propertyGrid);
            this.Controls.Add(this._toolStripMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
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
        private System.Windows.Forms.ToolStripButton _toolStripButtonControlPanel;
        private System.Windows.Forms.ToolStripButton _toolStripButtonClearCircuit;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
        private System.Windows.Forms.PropertyGrid _propertyGrid;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _toolStripButtonCalculate;
        private System.Windows.Forms.ToolStripButton _toolStripRandomizeCircuit;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton _toolStripButtonHelp;
    }
}