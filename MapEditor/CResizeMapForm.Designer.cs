namespace MapEditor
{
	partial class CResizeMapForm
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
			this.groupDimensions = new System.Windows.Forms.GroupBox();
			this.numNewHeight = new System.Windows.Forms.NumericUpDown();
			this.numNewWidth = new System.Windows.Forms.NumericUpDown();
			this.labelCurrentHeightValue = new System.Windows.Forms.Label();
			this.labelCurrentWidthValue = new System.Windows.Forms.Label();
			this.labelNewHeight = new System.Windows.Forms.Label();
			this.labelNewWidth = new System.Windows.Forms.Label();
			this.labelCurrentHeight = new System.Windows.Forms.Label();
			this.labelCurrentWidth = new System.Windows.Forms.Label();
			this.groupPlacement = new System.Windows.Forms.GroupBox();
			this.checkCenterH = new System.Windows.Forms.CheckBox();
			this.checkCentrV = new System.Windows.Forms.CheckBox();
			this.labelTop = new System.Windows.Forms.Label();
			this.labelLeft = new System.Windows.Forms.Label();
			this.numTop = new System.Windows.Forms.NumericUpDown();
			this.numLeft = new System.Windows.Forms.NumericUpDown();
			this.groupDimensions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numNewHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numNewWidth)).BeginInit();
			this.groupPlacement.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numLeft)).BeginInit();
			this.SuspendLayout();
			// 
			// groupDimensions
			// 
			this.groupDimensions.Controls.Add(this.numNewHeight);
			this.groupDimensions.Controls.Add(this.numNewWidth);
			this.groupDimensions.Controls.Add(this.labelCurrentHeightValue);
			this.groupDimensions.Controls.Add(this.labelCurrentWidthValue);
			this.groupDimensions.Controls.Add(this.labelNewHeight);
			this.groupDimensions.Controls.Add(this.labelNewWidth);
			this.groupDimensions.Controls.Add(this.labelCurrentHeight);
			this.groupDimensions.Controls.Add(this.labelCurrentWidth);
			this.groupDimensions.Location = new System.Drawing.Point(12, 12);
			this.groupDimensions.Name = "groupDimensions";
			this.groupDimensions.Size = new System.Drawing.Size(201, 119);
			this.groupDimensions.TabIndex = 0;
			this.groupDimensions.TabStop = false;
			this.groupDimensions.Text = "Dimensions";
			// 
			// numNewHeight
			// 
			this.numNewHeight.Location = new System.Drawing.Point(103, 85);
			this.numNewHeight.Name = "numNewHeight";
			this.numNewHeight.Size = new System.Drawing.Size(89, 20);
			this.numNewHeight.TabIndex = 7;
			this.numNewHeight.ValueChanged += new System.EventHandler(this.numNewHeight_ValueChanged);
			// 
			// numNewWidth
			// 
			this.numNewWidth.Location = new System.Drawing.Point(103, 62);
			this.numNewWidth.Name = "numNewWidth";
			this.numNewWidth.Size = new System.Drawing.Size(89, 20);
			this.numNewWidth.TabIndex = 6;
			this.numNewWidth.ValueChanged += new System.EventHandler(this.numNewWidth_ValueChanged);
			// 
			// labelCurrentHeightValue
			// 
			this.labelCurrentHeightValue.AutoSize = true;
			this.labelCurrentHeightValue.Location = new System.Drawing.Point(103, 43);
			this.labelCurrentHeightValue.Name = "labelCurrentHeightValue";
			this.labelCurrentHeightValue.Size = new System.Drawing.Size(75, 13);
			this.labelCurrentHeightValue.TabIndex = 5;
			this.labelCurrentHeightValue.Text = "Current Height";
			// 
			// labelCurrentWidthValue
			// 
			this.labelCurrentWidthValue.AutoSize = true;
			this.labelCurrentWidthValue.Location = new System.Drawing.Point(103, 20);
			this.labelCurrentWidthValue.Name = "labelCurrentWidthValue";
			this.labelCurrentWidthValue.Size = new System.Drawing.Size(72, 13);
			this.labelCurrentWidthValue.TabIndex = 4;
			this.labelCurrentWidthValue.Text = "Current Width";
			// 
			// labelNewHeight
			// 
			this.labelNewHeight.AutoSize = true;
			this.labelNewHeight.Location = new System.Drawing.Point(7, 89);
			this.labelNewHeight.Name = "labelNewHeight";
			this.labelNewHeight.Size = new System.Drawing.Size(66, 13);
			this.labelNewHeight.TabIndex = 3;
			this.labelNewHeight.Text = "New Height:";
			// 
			// labelNewWidth
			// 
			this.labelNewWidth.AutoSize = true;
			this.labelNewWidth.Location = new System.Drawing.Point(7, 66);
			this.labelNewWidth.Name = "labelNewWidth";
			this.labelNewWidth.Size = new System.Drawing.Size(63, 13);
			this.labelNewWidth.TabIndex = 2;
			this.labelNewWidth.Text = "New Width:";
			// 
			// labelCurrentHeight
			// 
			this.labelCurrentHeight.AutoSize = true;
			this.labelCurrentHeight.Location = new System.Drawing.Point(7, 43);
			this.labelCurrentHeight.Name = "labelCurrentHeight";
			this.labelCurrentHeight.Size = new System.Drawing.Size(78, 13);
			this.labelCurrentHeight.TabIndex = 1;
			this.labelCurrentHeight.Text = "Current Height:";
			// 
			// labelCurrentWidth
			// 
			this.labelCurrentWidth.AutoSize = true;
			this.labelCurrentWidth.Location = new System.Drawing.Point(7, 20);
			this.labelCurrentWidth.Name = "labelCurrentWidth";
			this.labelCurrentWidth.Size = new System.Drawing.Size(75, 13);
			this.labelCurrentWidth.TabIndex = 0;
			this.labelCurrentWidth.Text = "Current Width:";
			// 
			// groupPlacement
			// 
			this.groupPlacement.Controls.Add(this.numLeft);
			this.groupPlacement.Controls.Add(this.numTop);
			this.groupPlacement.Controls.Add(this.labelLeft);
			this.groupPlacement.Controls.Add(this.labelTop);
			this.groupPlacement.Controls.Add(this.checkCentrV);
			this.groupPlacement.Controls.Add(this.checkCenterH);
			this.groupPlacement.Location = new System.Drawing.Point(12, 137);
			this.groupPlacement.Name = "groupPlacement";
			this.groupPlacement.Size = new System.Drawing.Size(201, 117);
			this.groupPlacement.TabIndex = 1;
			this.groupPlacement.TabStop = false;
			this.groupPlacement.Text = "Placement";
			// 
			// checkCenterH
			// 
			this.checkCenterH.AutoSize = true;
			this.checkCenterH.Checked = true;
			this.checkCenterH.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkCenterH.Location = new System.Drawing.Point(7, 20);
			this.checkCenterH.Name = "checkCenterH";
			this.checkCenterH.Size = new System.Drawing.Size(114, 17);
			this.checkCenterH.TabIndex = 0;
			this.checkCenterH.Text = "Center Horizontally";
			this.checkCenterH.UseVisualStyleBackColor = true;
			this.checkCenterH.CheckedChanged += new System.EventHandler(this.checkCenterH_CheckedChanged);
			// 
			// checkCentrV
			// 
			this.checkCentrV.AutoSize = true;
			this.checkCentrV.Checked = true;
			this.checkCentrV.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkCentrV.Location = new System.Drawing.Point(7, 43);
			this.checkCentrV.Name = "checkCentrV";
			this.checkCentrV.Size = new System.Drawing.Size(102, 17);
			this.checkCentrV.TabIndex = 1;
			this.checkCentrV.Text = "Center Vertically";
			this.checkCentrV.UseVisualStyleBackColor = true;
			this.checkCentrV.CheckedChanged += new System.EventHandler(this.checkCentrV_CheckedChanged);
			// 
			// labelTop
			// 
			this.labelTop.AutoSize = true;
			this.labelTop.Location = new System.Drawing.Point(7, 66);
			this.labelTop.Name = "labelTop";
			this.labelTop.Size = new System.Drawing.Size(29, 13);
			this.labelTop.TabIndex = 2;
			this.labelTop.Text = "Top:";
			// 
			// labelLeft
			// 
			this.labelLeft.AutoSize = true;
			this.labelLeft.Location = new System.Drawing.Point(7, 89);
			this.labelLeft.Name = "labelLeft";
			this.labelLeft.Size = new System.Drawing.Size(28, 13);
			this.labelLeft.TabIndex = 4;
			this.labelLeft.Text = "Left:";
			// 
			// numTop
			// 
			this.numTop.Enabled = false;
			this.numTop.Location = new System.Drawing.Point(103, 62);
			this.numTop.Name = "numTop";
			this.numTop.Size = new System.Drawing.Size(89, 20);
			this.numTop.TabIndex = 6;
			this.numTop.ValueChanged += new System.EventHandler(this.numTop_ValueChanged);
			// 
			// numLeft
			// 
			this.numLeft.Enabled = false;
			this.numLeft.Location = new System.Drawing.Point(103, 85);
			this.numLeft.Name = "numLeft";
			this.numLeft.Size = new System.Drawing.Size(89, 20);
			this.numLeft.TabIndex = 8;
			this.numLeft.ValueChanged += new System.EventHandler(this.numLeft_ValueChanged);
			// 
			// CResizeMapForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(937, 632);
			this.Controls.Add(this.groupPlacement);
			this.Controls.Add(this.groupDimensions);
			this.Name = "CResizeMapForm";
			this.Text = "CResizeMapForm";
			this.groupDimensions.ResumeLayout(false);
			this.groupDimensions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numNewHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numNewWidth)).EndInit();
			this.groupPlacement.ResumeLayout(false);
			this.groupPlacement.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numLeft)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupDimensions;
		private System.Windows.Forms.NumericUpDown numNewHeight;
		private System.Windows.Forms.NumericUpDown numNewWidth;
		private System.Windows.Forms.Label labelCurrentHeightValue;
		private System.Windows.Forms.Label labelCurrentWidthValue;
		private System.Windows.Forms.Label labelNewHeight;
		private System.Windows.Forms.Label labelNewWidth;
		private System.Windows.Forms.Label labelCurrentHeight;
		private System.Windows.Forms.Label labelCurrentWidth;
		private System.Windows.Forms.GroupBox groupPlacement;
		private System.Windows.Forms.CheckBox checkCenterH;
		private System.Windows.Forms.CheckBox checkCentrV;
		private System.Windows.Forms.NumericUpDown numLeft;
		private System.Windows.Forms.NumericUpDown numTop;
		private System.Windows.Forms.Label labelLeft;
		private System.Windows.Forms.Label labelTop;

	}
}