namespace MainForm
{
    partial class ImpedanceForm
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
			this.components = new System.ComponentModel.Container();
			this.StartLabel = new System.Windows.Forms.Label();
			this.EndLabel = new System.Windows.Forms.Label();
			this.StepLabel = new System.Windows.Forms.Label();
			this.initialValue = new System.Windows.Forms.TextBox();
			this.finalValue = new System.Windows.Forms.TextBox();
			this.step = new System.Windows.Forms.TextBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this._dataGridView = new System.Windows.Forms.DataGridView();
			this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Impedance = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// StartLabel
			// 
			this.StartLabel.AutoSize = true;
			this.StartLabel.Location = new System.Drawing.Point(16, 11);
			this.StartLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.StartLabel.Name = "StartLabel";
			this.StartLabel.Size = new System.Drawing.Size(58, 17);
			this.StartLabel.TabIndex = 0;
			this.StartLabel.Text = "Начало";
			// 
			// EndLabel
			// 
			this.EndLabel.AutoSize = true;
			this.EndLabel.Location = new System.Drawing.Point(16, 43);
			this.EndLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.EndLabel.Name = "EndLabel";
			this.EndLabel.Size = new System.Drawing.Size(49, 17);
			this.EndLabel.TabIndex = 1;
			this.EndLabel.Text = "Конец";
			// 
			// StepLabel
			// 
			this.StepLabel.AutoSize = true;
			this.StepLabel.Location = new System.Drawing.Point(16, 75);
			this.StepLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.StepLabel.Name = "StepLabel";
			this.StepLabel.Size = new System.Drawing.Size(32, 17);
			this.StepLabel.TabIndex = 2;
			this.StepLabel.Text = "Шаг";
			// 
			// initialValue
			// 
			this.initialValue.Location = new System.Drawing.Point(119, 7);
			this.initialValue.Margin = new System.Windows.Forms.Padding(4);
			this.initialValue.Name = "initialValue";
			this.initialValue.Size = new System.Drawing.Size(132, 22);
			this.initialValue.TabIndex = 3;
			this.initialValue.TextChanged += new System.EventHandler(this.initialValue_TextChanged);
			// 
			// finalValue
			// 
			this.finalValue.Location = new System.Drawing.Point(119, 39);
			this.finalValue.Margin = new System.Windows.Forms.Padding(4);
			this.finalValue.Name = "finalValue";
			this.finalValue.Size = new System.Drawing.Size(132, 22);
			this.finalValue.TabIndex = 4;
			this.finalValue.TextChanged += new System.EventHandler(this.finalValue_TextChanged);
			// 
			// step
			// 
			this.step.Location = new System.Drawing.Point(119, 71);
			this.step.Margin = new System.Windows.Forms.Padding(4);
			this.step.Name = "step";
			this.step.Size = new System.Drawing.Size(132, 22);
			this.step.TabIndex = 5;
			this.step.TextChanged += new System.EventHandler(this.step_TextChanged);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// _dataGridView
			// 
			this._dataGridView.AllowUserToAddRows = false;
			this._dataGridView.AllowUserToDeleteRows = false;
			this._dataGridView.AllowUserToResizeColumns = false;
			this._dataGridView.AllowUserToResizeRows = false;
			this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frequency,
            this.Impedance});
			this._dataGridView.EnableHeadersVisualStyles = false;
			this._dataGridView.Location = new System.Drawing.Point(13, 101);
			this._dataGridView.Margin = new System.Windows.Forms.Padding(4);
			this._dataGridView.MultiSelect = false;
			this._dataGridView.Name = "_dataGridView";
			this._dataGridView.ReadOnly = true;
			this._dataGridView.RowHeadersVisible = false;
			this._dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this._dataGridView.Size = new System.Drawing.Size(348, 147);
			this._dataGridView.TabIndex = 7;
			// 
			// Frequency
			// 
			this.Frequency.DataPropertyName = "Frequency";
			this.Frequency.Frozen = true;
			this.Frequency.HeaderText = "Частота";
			this.Frequency.Name = "Frequency";
			this.Frequency.ReadOnly = true;
			this.Frequency.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// Impedance
			// 
			this.Impedance.DataPropertyName = "Impedance";
			this.Impedance.Frozen = true;
			this.Impedance.HeaderText = "Импеданс";
			this.Impedance.Name = "Impedance";
			this.Impedance.ReadOnly = true;
			this.Impedance.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Impedance.Width = 200;
			// 
			// ImpedanceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(374, 261);
			this.Controls.Add(this._dataGridView);
			this.Controls.Add(this.step);
			this.Controls.Add(this.finalValue);
			this.Controls.Add(this.initialValue);
			this.Controls.Add(this.StepLabel);
			this.Controls.Add(this.EndLabel);
			this.Controls.Add(this.StartLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(287, 298);
			this.Name = "ImpedanceForm";
			this.Text = "ImpedanceForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImpedanceForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.TextBox initialValue;
        private System.Windows.Forms.TextBox finalValue;
        private System.Windows.Forms.TextBox step;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.DataGridView _dataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
		private System.Windows.Forms.DataGridViewTextBoxColumn Impedance;
	}
}