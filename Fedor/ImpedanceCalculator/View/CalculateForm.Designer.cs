using System.Windows.Forms;

namespace View
{
    partial class CalculateForm
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
            this.circuitGridView = new System.Windows.Forms.DataGridView();
            this.circuitButton = new System.Windows.Forms.Button();
            this.frequencyBox = new System.Windows.Forms.GroupBox();
            this.countBox = new System.Windows.Forms.TextBox();
            this.intervalBox = new System.Windows.Forms.TextBox();
            this.startValueBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.createFrequencyButton = new System.Windows.Forms.Button();
            this.frequencyColomn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impedanceColomn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.circuitGridView)).BeginInit();
            this.frequencyBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // circuitGridView
            // 
            this.circuitGridView.AllowUserToAddRows = false;
            this.circuitGridView.AllowUserToDeleteRows = false;
            this.circuitGridView.AllowUserToResizeColumns = false;
            this.circuitGridView.AllowUserToResizeRows = false;
            this.circuitGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.circuitGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.frequencyColomn,
            this.impedanceColomn});
            this.circuitGridView.Location = new System.Drawing.Point(317, 12);
            this.circuitGridView.Name = "circuitGridView";
            this.circuitGridView.RowHeadersVisible = false;
            this.circuitGridView.RowTemplate.Height = 24;
            this.circuitGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.circuitGridView.Size = new System.Drawing.Size(568, 219);
            this.circuitGridView.TabIndex = 0;
            // 
            // circuitButton
            // 
            this.circuitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.circuitButton.Location = new System.Drawing.Point(149, 192);
            this.circuitButton.Name = "circuitButton";
            this.circuitButton.Size = new System.Drawing.Size(131, 39);
            this.circuitButton.TabIndex = 2;
            this.circuitButton.Text = "Назад";
            this.circuitButton.UseVisualStyleBackColor = true;
            // 
            // frequencyBox
            // 
            this.frequencyBox.Controls.Add(this.countBox);
            this.frequencyBox.Controls.Add(this.intervalBox);
            this.frequencyBox.Controls.Add(this.startValueBox);
            this.frequencyBox.Controls.Add(this.label3);
            this.frequencyBox.Controls.Add(this.label2);
            this.frequencyBox.Controls.Add(this.label1);
            this.frequencyBox.Location = new System.Drawing.Point(12, 12);
            this.frequencyBox.Name = "frequencyBox";
            this.frequencyBox.Size = new System.Drawing.Size(268, 175);
            this.frequencyBox.TabIndex = 3;
            this.frequencyBox.TabStop = false;
            this.frequencyBox.Text = "Задайте диапазон частот";
            // 
            // countBox
            // 
            this.countBox.Location = new System.Drawing.Point(6, 141);
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(100, 22);
            this.countBox.TabIndex = 5;
            this.countBox.Text = "0";
            this.countBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.countBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntTextBox_KeyPress);
            this.countBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // intervalBox
            // 
            this.intervalBox.Location = new System.Drawing.Point(6, 93);
            this.intervalBox.Name = "intervalBox";
            this.intervalBox.Size = new System.Drawing.Size(100, 22);
            this.intervalBox.TabIndex = 4;
            this.intervalBox.Text = "0";
            this.intervalBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.intervalBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this.intervalBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // startValueBox
            // 
            this.startValueBox.Location = new System.Drawing.Point(6, 48);
            this.startValueBox.Name = "startValueBox";
            this.startValueBox.Size = new System.Drawing.Size(100, 22);
            this.startValueBox.TabIndex = 3;
            this.startValueBox.Text = "0";
            this.startValueBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.startValueBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleTextBox_KeyPress);
            this.startValueBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Количество значений";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Интервал";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Начальное значение";
            // 
            // createFrequencyButton
            // 
            this.createFrequencyButton.Location = new System.Drawing.Point(12, 193);
            this.createFrequencyButton.Name = "createFrequencyButton";
            this.createFrequencyButton.Size = new System.Drawing.Size(131, 39);
            this.createFrequencyButton.TabIndex = 4;
            this.createFrequencyButton.Text = "Расчитать";
            this.createFrequencyButton.UseVisualStyleBackColor = true;
            this.createFrequencyButton.Click += new System.EventHandler(this.CreateFrequencyButton_Click);
            // 
            // frequencyColomn
            // 
            this.frequencyColomn.Frozen = true;
            this.frequencyColomn.HeaderText = "Частота";
            this.frequencyColomn.Name = "frequencyColomn";
            this.frequencyColomn.ReadOnly = true;
            this.frequencyColomn.Width = 120;
            // 
            // impedanceColomn
            // 
            this.impedanceColomn.Frozen = true;
            this.impedanceColomn.HeaderText = "Импеданс";
            this.impedanceColomn.Name = "impedanceColomn";
            this.impedanceColomn.ReadOnly = true;
            this.impedanceColomn.Width = 310;
            // 
            // CalculateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 243);
            this.Controls.Add(this.createFrequencyButton);
            this.Controls.Add(this.frequencyBox);
            this.Controls.Add(this.circuitButton);
            this.Controls.Add(this.circuitGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(915, 290);
            this.MinimumSize = new System.Drawing.Size(915, 290);
            this.Name = "CalculateForm";
            this.Text = "Circuit Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.circuitGridView)).EndInit();
            this.frequencyBox.ResumeLayout(false);
            this.frequencyBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView circuitGridView;
        private System.Windows.Forms.Button circuitButton;
        private System.Windows.Forms.GroupBox frequencyBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox countBox;
        private System.Windows.Forms.TextBox intervalBox;
        private System.Windows.Forms.TextBox startValueBox;
        private System.Windows.Forms.Button createFrequencyButton;
        private DataGridViewTextBoxColumn frequencyColomn;
        private DataGridViewTextBoxColumn impedanceColomn;
    }
}