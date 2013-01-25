namespace MapEditor
{
	partial class CNewMapForm
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
			this.labelWidth = new System.Windows.Forms.Label();
			this.labelHeight = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.numWidth = new System.Windows.Forms.NumericUpDown();
			this.numHeight = new System.Windows.Forms.NumericUpDown();
			this.labelTileSet = new System.Windows.Forms.Label();
			this.comboTileSet = new System.Windows.Forms.ComboBox();
			this.labelName = new System.Windows.Forms.Label();
			this.textName = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// labelWidth
			// 
			this.labelWidth.AutoSize = true;
			this.labelWidth.Location = new System.Drawing.Point(10, 42);
			this.labelWidth.Name = "labelWidth";
			this.labelWidth.Size = new System.Drawing.Size(38, 13);
			this.labelWidth.TabIndex = 0;
			this.labelWidth.Text = "Width:";
			// 
			// labelHeight
			// 
			this.labelHeight.AutoSize = true;
			this.labelHeight.Location = new System.Drawing.Point(10, 68);
			this.labelHeight.Name = "labelHeight";
			this.labelHeight.Size = new System.Drawing.Size(41, 13);
			this.labelHeight.TabIndex = 1;
			this.labelHeight.Text = "Height:";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(58, 120);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(139, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// numWidth
			// 
			this.numWidth.Location = new System.Drawing.Point(54, 38);
			this.numWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numWidth.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.numWidth.Name = "numWidth";
			this.numWidth.Size = new System.Drawing.Size(83, 20);
			this.numWidth.TabIndex = 0;
			this.numWidth.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			// 
			// numHeight
			// 
			this.numHeight.Location = new System.Drawing.Point(54, 64);
			this.numHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numHeight.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.numHeight.Name = "numHeight";
			this.numHeight.Size = new System.Drawing.Size(83, 20);
			this.numHeight.TabIndex = 1;
			this.numHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			// 
			// labelTileSet
			// 
			this.labelTileSet.AutoSize = true;
			this.labelTileSet.Location = new System.Drawing.Point(10, 94);
			this.labelTileSet.Name = "labelTileSet";
			this.labelTileSet.Size = new System.Drawing.Size(43, 13);
			this.labelTileSet.TabIndex = 4;
			this.labelTileSet.Text = "TileSet:";
			// 
			// comboTileSet
			// 
			this.comboTileSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboTileSet.FormattingEnabled = true;
			this.comboTileSet.Location = new System.Drawing.Point(54, 90);
			this.comboTileSet.Name = "comboTileSet";
			this.comboTileSet.Size = new System.Drawing.Size(199, 21);
			this.comboTileSet.TabIndex = 5;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(10, 16);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(38, 13);
			this.labelName.TabIndex = 6;
			this.labelName.Text = "Name:";
			// 
			// textName
			// 
			this.textName.Location = new System.Drawing.Point(54, 12);
			this.textName.MaxLength = 32;
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(199, 20);
			this.textName.TabIndex = 7;
			// 
			// CNewMapForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(262, 155);
			this.Controls.Add(this.textName);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.comboTileSet);
			this.Controls.Add(this.labelTileSet);
			this.Controls.Add(this.numHeight);
			this.Controls.Add(this.numWidth);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.labelHeight);
			this.Controls.Add(this.labelWidth);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CNewMapForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Map";
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelWidth;
		private System.Windows.Forms.Label labelHeight;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label labelTileSet;
		private System.Windows.Forms.NumericUpDown numWidth;
		private System.Windows.Forms.NumericUpDown numHeight;
		private System.Windows.Forms.ComboBox comboTileSet;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textName;
	}
}