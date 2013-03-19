namespace MapEditor
{
	partial class CMapExitPreviewForm
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
			this.picMapPreview = new System.Windows.Forms.PictureBox();
			this.comboMap = new System.Windows.Forms.ComboBox();
			this.labelMap = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textEntranceId = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.picMapPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// picMapPreview
			// 
			this.picMapPreview.Location = new System.Drawing.Point(12, 32);
			this.picMapPreview.Name = "picMapPreview";
			this.picMapPreview.Size = new System.Drawing.Size(642, 642);
			this.picMapPreview.TabIndex = 0;
			this.picMapPreview.TabStop = false;
			this.picMapPreview.Click += new System.EventHandler(this.picMapPreview_Click);
			// 
			// comboMap
			// 
			this.comboMap.DisplayMember = "Item2";
			this.comboMap.FormattingEnabled = true;
			this.comboMap.Location = new System.Drawing.Point(50, 5);
			this.comboMap.Name = "comboMap";
			this.comboMap.Size = new System.Drawing.Size(121, 21);
			this.comboMap.TabIndex = 1;
			this.comboMap.ValueMember = "Item1";
			this.comboMap.SelectedIndexChanged += new System.EventHandler(this.comboMap_SelectedIndexChanged);
			// 
			// labelMap
			// 
			this.labelMap.AutoSize = true;
			this.labelMap.Location = new System.Drawing.Point(13, 9);
			this.labelMap.Name = "labelMap";
			this.labelMap.Size = new System.Drawing.Size(31, 13);
			this.labelMap.TabIndex = 2;
			this.labelMap.Text = "Map:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(177, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Entrance:";
			// 
			// textEntranceId
			// 
			this.textEntranceId.Location = new System.Drawing.Point(236, 5);
			this.textEntranceId.Name = "textEntranceId";
			this.textEntranceId.ReadOnly = true;
			this.textEntranceId.Size = new System.Drawing.Size(100, 20);
			this.textEntranceId.TabIndex = 4;
			// 
			// CMapExitPreviewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(666, 686);
			this.Controls.Add(this.textEntranceId);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelMap);
			this.Controls.Add(this.comboMap);
			this.Controls.Add(this.picMapPreview);
			this.Name = "CMapExitPreviewForm";
			this.Text = "CMapExitPreviewForm";
			((System.ComponentModel.ISupportInitialize)(this.picMapPreview)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picMapPreview;
		private System.Windows.Forms.ComboBox comboMap;
		private System.Windows.Forms.Label labelMap;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textEntranceId;
	}
}