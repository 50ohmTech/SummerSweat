using CircuitCalculator.Controls;

namespace CircuitCalculator
{
	partial class CircuitEditorForm
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
			this.addInductorButton = new System.Windows.Forms.Button();
			this.addCapacitorButton = new System.Windows.Forms.Button();
			this.resistorNameTextBox = new System.Windows.Forms.TextBox();
			this.capacitorNameTextBox = new System.Windows.Forms.TextBox();
			this.inductorNameTextBox = new System.Windows.Forms.TextBox();
			this.instrumentsGroupBox = new System.Windows.Forms.GroupBox();
			this.testButton = new System.Windows.Forms.Button();
			this.addLabel = new System.Windows.Forms.Label();
			this.valueLabel = new System.Windows.Forms.Label();
			this.nameLabel = new System.Windows.Forms.Label();
			this.inductorValueTextBox = new System.Windows.Forms.TextBox();
			this.capacitorValueTextBox = new System.Windows.Forms.TextBox();
			this.resistorValueTextBox = new System.Windows.Forms.TextBox();
			this.addResistorButton = new System.Windows.Forms.Button();
			this.elementGridView = new System.Windows.Forms.DataGridView();
			this.redactorPanel = new CircuitCalculator.Controls.RedactorPanel();
			this.elementNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.elementValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.instrumentsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.elementGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// addInductorButton
			// 
			this.addInductorButton.Enabled = false;
			this.addInductorButton.Location = new System.Drawing.Point(291, 77);
			this.addInductorButton.Name = "addInductorButton";
			this.addInductorButton.Size = new System.Drawing.Size(129, 59);
			this.addInductorButton.TabIndex = 7;
			this.addInductorButton.Text = "Катушка индуктивности";
			this.addInductorButton.UseVisualStyleBackColor = true;
			this.addInductorButton.Click += new System.EventHandler(this.AddInductorButton_Click);
			// 
			// addCapacitorButton
			// 
			this.addCapacitorButton.Enabled = false;
			this.addCapacitorButton.Location = new System.Drawing.Point(175, 77);
			this.addCapacitorButton.Name = "addCapacitorButton";
			this.addCapacitorButton.Size = new System.Drawing.Size(110, 59);
			this.addCapacitorButton.TabIndex = 8;
			this.addCapacitorButton.Text = "Конденсатор";
			this.addCapacitorButton.UseVisualStyleBackColor = true;
			this.addCapacitorButton.Click += new System.EventHandler(this.AddCapacitorButton_Click);
			// 
			// resistorNameTextBox
			// 
			this.resistorNameTextBox.Enabled = false;
			this.resistorNameTextBox.Location = new System.Drawing.Point(84, 21);
			this.resistorNameTextBox.Name = "resistorNameTextBox";
			this.resistorNameTextBox.Size = new System.Drawing.Size(85, 22);
			this.resistorNameTextBox.TabIndex = 9;
			this.resistorNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// capacitorNameTextBox
			// 
			this.capacitorNameTextBox.Enabled = false;
			this.capacitorNameTextBox.Location = new System.Drawing.Point(175, 21);
			this.capacitorNameTextBox.Name = "capacitorNameTextBox";
			this.capacitorNameTextBox.Size = new System.Drawing.Size(110, 22);
			this.capacitorNameTextBox.TabIndex = 10;
			this.capacitorNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// inductorNameTextBox
			// 
			this.inductorNameTextBox.Enabled = false;
			this.inductorNameTextBox.Location = new System.Drawing.Point(291, 21);
			this.inductorNameTextBox.Name = "inductorNameTextBox";
			this.inductorNameTextBox.Size = new System.Drawing.Size(129, 22);
			this.inductorNameTextBox.TabIndex = 11;
			this.inductorNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// instrumentsGroupBox
			// 
			this.instrumentsGroupBox.Controls.Add(this.testButton);
			this.instrumentsGroupBox.Controls.Add(this.addLabel);
			this.instrumentsGroupBox.Controls.Add(this.valueLabel);
			this.instrumentsGroupBox.Controls.Add(this.nameLabel);
			this.instrumentsGroupBox.Controls.Add(this.inductorValueTextBox);
			this.instrumentsGroupBox.Controls.Add(this.capacitorValueTextBox);
			this.instrumentsGroupBox.Controls.Add(this.resistorValueTextBox);
			this.instrumentsGroupBox.Controls.Add(this.inductorNameTextBox);
			this.instrumentsGroupBox.Controls.Add(this.addCapacitorButton);
			this.instrumentsGroupBox.Controls.Add(this.capacitorNameTextBox);
			this.instrumentsGroupBox.Controls.Add(this.addInductorButton);
			this.instrumentsGroupBox.Controls.Add(this.addResistorButton);
			this.instrumentsGroupBox.Controls.Add(this.resistorNameTextBox);
			this.instrumentsGroupBox.Location = new System.Drawing.Point(12, 15);
			this.instrumentsGroupBox.Name = "instrumentsGroupBox";
			this.instrumentsGroupBox.Size = new System.Drawing.Size(432, 350);
			this.instrumentsGroupBox.TabIndex = 12;
			this.instrumentsGroupBox.TabStop = false;
			this.instrumentsGroupBox.Text = "Инструменты редактирования цепи";
			// 
			// testButton
			// 
			this.testButton.Location = new System.Drawing.Point(6, 314);
			this.testButton.Name = "testButton";
			this.testButton.Size = new System.Drawing.Size(220, 30);
			this.testButton.TabIndex = 21;
			this.testButton.Text = "Тестирование элементов";
			this.testButton.UseVisualStyleBackColor = true;
			this.testButton.Click += new System.EventHandler(this.TestButton_Click);
			// 
			// addLabel
			// 
			this.addLabel.AutoSize = true;
			this.addLabel.Location = new System.Drawing.Point(6, 98);
			this.addLabel.Name = "addLabel";
			this.addLabel.Size = new System.Drawing.Size(72, 17);
			this.addLabel.TabIndex = 20;
			this.addLabel.Text = "Добавить";
			// 
			// valueLabel
			// 
			this.valueLabel.AutoSize = true;
			this.valueLabel.Location = new System.Drawing.Point(6, 52);
			this.valueLabel.Name = "valueLabel";
			this.valueLabel.Size = new System.Drawing.Size(65, 17);
			this.valueLabel.TabIndex = 19;
			this.valueLabel.Text = "Значние";
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(6, 24);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(72, 17);
			this.nameLabel.TabIndex = 18;
			this.nameLabel.Text = "Название";
			// 
			// inductorValueTextBox
			// 
			this.inductorValueTextBox.Enabled = false;
			this.inductorValueTextBox.Location = new System.Drawing.Point(291, 49);
			this.inductorValueTextBox.Name = "inductorValueTextBox";
			this.inductorValueTextBox.Size = new System.Drawing.Size(129, 22);
			this.inductorValueTextBox.TabIndex = 17;
			this.inductorValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// capacitorValueTextBox
			// 
			this.capacitorValueTextBox.Enabled = false;
			this.capacitorValueTextBox.Location = new System.Drawing.Point(175, 49);
			this.capacitorValueTextBox.Name = "capacitorValueTextBox";
			this.capacitorValueTextBox.Size = new System.Drawing.Size(110, 22);
			this.capacitorValueTextBox.TabIndex = 16;
			this.capacitorValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// resistorValueTextBox
			// 
			this.resistorValueTextBox.Enabled = false;
			this.resistorValueTextBox.Location = new System.Drawing.Point(84, 49);
			this.resistorValueTextBox.Name = "resistorValueTextBox";
			this.resistorValueTextBox.Size = new System.Drawing.Size(85, 22);
			this.resistorValueTextBox.TabIndex = 15;
			this.resistorValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// addResistorButton
			// 
			this.addResistorButton.Enabled = false;
			this.addResistorButton.Location = new System.Drawing.Point(84, 77);
			this.addResistorButton.Name = "addResistorButton";
			this.addResistorButton.Size = new System.Drawing.Size(85, 59);
			this.addResistorButton.TabIndex = 6;
			this.addResistorButton.Text = "Резистор";
			this.addResistorButton.UseVisualStyleBackColor = true;
			this.addResistorButton.Click += new System.EventHandler(this.AddResistorButton_Click);
			// 
			// elementGridView
			// 
			this.elementGridView.AllowUserToAddRows = false;
			this.elementGridView.AllowUserToDeleteRows = false;
			this.elementGridView.AllowUserToResizeColumns = false;
			this.elementGridView.AllowUserToResizeRows = false;
			this.elementGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.elementGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.elementNameColumn,
            this.elementValueColumn});
			this.elementGridView.Location = new System.Drawing.Point(18, 36);
			this.elementGridView.Name = "elementGridView";
			this.elementGridView.RowHeadersVisible = false;
			this.elementGridView.RowTemplate.Height = 24;
			this.elementGridView.Size = new System.Drawing.Size(414, 288);
			this.elementGridView.TabIndex = 22;
			this.elementGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ElementGridView_CellValidating);
			// 
			// redactorPanel
			// 
			this.redactorPanel.Location = new System.Drawing.Point(450, 12);
			this.redactorPanel.Name = "redactorPanel";
			this.redactorPanel.Size = new System.Drawing.Size(635, 353);
			this.redactorPanel.TabIndex = 13;
			// 
			// elementNameColumn
			// 
			this.elementNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.elementNameColumn.HeaderText = "Имя элемента";
			this.elementNameColumn.Name = "elementNameColumn";
			this.elementNameColumn.ReadOnly = true;
			this.elementNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.elementNameColumn.Width = 153;
			// 
			// elementValueColumn
			// 
			this.elementValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.elementValueColumn.HeaderText = "Значение элемента";
			this.elementValueColumn.Name = "elementValueColumn";
			this.elementValueColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.elementValueColumn.Width = 153;
			// 
			// CircuitRedactorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1083, 377);
			this.Controls.Add(this.elementGridView);
			this.Controls.Add(this.redactorPanel);
			this.Controls.Add(this.instrumentsGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CircuitRedactorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Редактор цепи";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CircuitRedactorForm_FormClosing);
			this.instrumentsGroupBox.ResumeLayout(false);
			this.instrumentsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.elementGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button addInductorButton;
		private System.Windows.Forms.Button addCapacitorButton;
		private System.Windows.Forms.TextBox resistorNameTextBox;
		private System.Windows.Forms.TextBox capacitorNameTextBox;
		private System.Windows.Forms.TextBox inductorNameTextBox;
		private System.Windows.Forms.GroupBox instrumentsGroupBox;
		private System.Windows.Forms.Label addLabel;
		private System.Windows.Forms.Label valueLabel;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.TextBox inductorValueTextBox;
		private System.Windows.Forms.TextBox capacitorValueTextBox;
		private System.Windows.Forms.TextBox resistorValueTextBox;
		private System.Windows.Forms.Button addResistorButton;
		private System.Windows.Forms.Button testButton;
		private RedactorPanel redactorPanel;
		private System.Windows.Forms.DataGridView elementGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn elementNameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn elementValueColumn;
	}
}