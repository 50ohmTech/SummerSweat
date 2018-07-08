namespace ImpedanceView
{
    partial class AddElementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddElementForm));
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.addFormControl = new ImpedanceView.EnterElementControl();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.CancelButton.Location = new System.Drawing.Point(115, 84);
            this.CancelButton.Name = "Cancel";
            this.CancelButton.Size = new System.Drawing.Size(87, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OK
            // 
            this.OKButton.Location = new System.Drawing.Point(12, 84);
            this.OKButton.Name = "OK";
            this.OKButton.Size = new System.Drawing.Size(97, 23);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // addFormControl1
            // 
            this.addFormControl.Location = new System.Drawing.Point(12, 12);
            this.addFormControl.Name = "addFormControl1";
            this.addFormControl.Size = new System.Drawing.Size(190, 66);
            this.addFormControl.TabIndex = 6;
            // 
            // AddElementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 126);
            this.Controls.Add(this.addFormControl);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(227, 165);
            this.MinimumSize = new System.Drawing.Size(227, 165);
            this.Name = "AddElementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Modify window";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private EnterElementControl addFormControl;
    }
}