namespace MapEditor
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gridColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layer1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layer2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layer3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layer4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.textStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitLog = new System.Windows.Forms.SplitContainer();
			this.panelMap = new MapEditor.MapPanel();
			this.scrollMapV = new System.Windows.Forms.VScrollBar();
			this.scrollMapH = new System.Windows.Forms.HScrollBar();
			this.tabTools = new System.Windows.Forms.TabControl();
			this.tabTiles = new System.Windows.Forms.TabPage();
			this.comboBrushSize = new System.Windows.Forms.ComboBox();
			this.comboLayers = new System.Windows.Forms.ComboBox();
			this.panelTiles = new System.Windows.Forms.Panel();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitLog)).BeginInit();
			this.splitLog.Panel1.SuspendLayout();
			this.splitLog.Panel2.SuspendLayout();
			this.splitLog.SuspendLayout();
			this.tabTools.SuspendLayout();
			this.tabTiles.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.layersToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1023, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Enabled = false;
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripMenuItem,
            this.gridColorToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// gridToolStripMenuItem
			// 
			this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
			this.gridToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.gridToolStripMenuItem.Text = "&Grid";
			this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
			// 
			// gridColorToolStripMenuItem
			// 
			this.gridColorToolStripMenuItem.Name = "gridColorToolStripMenuItem";
			this.gridColorToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.gridColorToolStripMenuItem.Text = "Grid &Color";
			this.gridColorToolStripMenuItem.Click += new System.EventHandler(this.gridColorToolStripMenuItem_Click);
			// 
			// layersToolStripMenuItem
			// 
			this.layersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layer1ToolStripMenuItem,
            this.layer2ToolStripMenuItem,
            this.layer3ToolStripMenuItem,
            this.layer4ToolStripMenuItem});
			this.layersToolStripMenuItem.Name = "layersToolStripMenuItem";
			this.layersToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.layersToolStripMenuItem.Text = "&Layers";
			// 
			// layer1ToolStripMenuItem
			// 
			this.layer1ToolStripMenuItem.Checked = true;
			this.layer1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.layer1ToolStripMenuItem.Name = "layer1ToolStripMenuItem";
			this.layer1ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.layer1ToolStripMenuItem.Text = "Layer &1";
			this.layer1ToolStripMenuItem.Click += new System.EventHandler(this.layer1ToolStripMenuItem_Click);
			// 
			// layer2ToolStripMenuItem
			// 
			this.layer2ToolStripMenuItem.Checked = true;
			this.layer2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.layer2ToolStripMenuItem.Name = "layer2ToolStripMenuItem";
			this.layer2ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.layer2ToolStripMenuItem.Text = "Layer &2";
			this.layer2ToolStripMenuItem.Click += new System.EventHandler(this.layer2ToolStripMenuItem_Click);
			// 
			// layer3ToolStripMenuItem
			// 
			this.layer3ToolStripMenuItem.Checked = true;
			this.layer3ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.layer3ToolStripMenuItem.Name = "layer3ToolStripMenuItem";
			this.layer3ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.layer3ToolStripMenuItem.Text = "Layer &3";
			this.layer3ToolStripMenuItem.Click += new System.EventHandler(this.layer3ToolStripMenuItem_Click);
			// 
			// layer4ToolStripMenuItem
			// 
			this.layer4ToolStripMenuItem.Checked = true;
			this.layer4ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.layer4ToolStripMenuItem.Name = "layer4ToolStripMenuItem";
			this.layer4ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.layer4ToolStripMenuItem.Text = "Layer &4";
			this.layer4ToolStripMenuItem.Click += new System.EventHandler(this.layer4ToolStripMenuItem_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1023, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 730);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1023, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// textStatus
			// 
			this.textStatus.Name = "textStatus";
			this.textStatus.Size = new System.Drawing.Size(0, 17);
			// 
			// splitLog
			// 
			this.splitLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitLog.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitLog.Location = new System.Drawing.Point(0, 49);
			this.splitLog.Name = "splitLog";
			this.splitLog.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitLog.Panel1
			// 
			this.splitLog.Panel1.Controls.Add(this.panelMap);
			this.splitLog.Panel1.Controls.Add(this.scrollMapV);
			this.splitLog.Panel1.Controls.Add(this.scrollMapH);
			this.splitLog.Panel1.Controls.Add(this.tabTools);
			// 
			// splitLog.Panel2
			// 
			this.splitLog.Panel2.Controls.Add(this.txtLog);
			this.splitLog.Size = new System.Drawing.Size(1023, 681);
			this.splitLog.SplitterDistance = 585;
			this.splitLog.TabIndex = 3;
			// 
			// panelMap
			// 
			this.panelMap.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.panelMap.BackColor = System.Drawing.SystemColors.Control;
			this.panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMap.Location = new System.Drawing.Point(0, 0);
			this.panelMap.Name = "panelMap";
			this.panelMap.Size = new System.Drawing.Size(864, 568);
			this.panelMap.TabIndex = 3;
			this.panelMap.SizeChanged += new System.EventHandler(this.panelMap_SizeChanged);
			this.panelMap.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMap_Paint);
			this.panelMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelMap_MouseClick);
			this.panelMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMap_MouseMove);
			// 
			// scrollMapV
			// 
			this.scrollMapV.Dock = System.Windows.Forms.DockStyle.Right;
			this.scrollMapV.Location = new System.Drawing.Point(864, 0);
			this.scrollMapV.Name = "scrollMapV";
			this.scrollMapV.Size = new System.Drawing.Size(17, 568);
			this.scrollMapV.TabIndex = 2;
			this.scrollMapV.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollMapV_Scroll);
			// 
			// scrollMapH
			// 
			this.scrollMapH.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.scrollMapH.Location = new System.Drawing.Point(0, 568);
			this.scrollMapH.Name = "scrollMapH";
			this.scrollMapH.Size = new System.Drawing.Size(881, 17);
			this.scrollMapH.TabIndex = 1;
			this.scrollMapH.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollMapH_Scroll);
			// 
			// tabTools
			// 
			this.tabTools.Controls.Add(this.tabTiles);
			this.tabTools.Controls.Add(this.tabPage2);
			this.tabTools.Dock = System.Windows.Forms.DockStyle.Right;
			this.tabTools.Location = new System.Drawing.Point(881, 0);
			this.tabTools.Name = "tabTools";
			this.tabTools.SelectedIndex = 0;
			this.tabTools.Size = new System.Drawing.Size(142, 585);
			this.tabTools.TabIndex = 0;
			// 
			// tabTiles
			// 
			this.tabTiles.Controls.Add(this.panelTiles);
			this.tabTiles.Controls.Add(this.comboBrushSize);
			this.tabTiles.Controls.Add(this.comboLayers);
			this.tabTiles.Location = new System.Drawing.Point(4, 22);
			this.tabTiles.Name = "tabTiles";
			this.tabTiles.Padding = new System.Windows.Forms.Padding(3);
			this.tabTiles.Size = new System.Drawing.Size(134, 559);
			this.tabTiles.TabIndex = 0;
			this.tabTiles.Text = "Tiles";
			this.tabTiles.UseVisualStyleBackColor = true;
			// 
			// comboBrushSize
			// 
			this.comboBrushSize.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboBrushSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBrushSize.Enabled = false;
			this.comboBrushSize.FormattingEnabled = true;
			this.comboBrushSize.Items.AddRange(new object[] {
            "1x1",
            "3x3",
            "5x5",
            "7x7",
            "9x9"});
			this.comboBrushSize.Location = new System.Drawing.Point(3, 24);
			this.comboBrushSize.Name = "comboBrushSize";
			this.comboBrushSize.Size = new System.Drawing.Size(128, 21);
			this.comboBrushSize.TabIndex = 2;
			this.comboBrushSize.SelectedIndexChanged += new System.EventHandler(this.comboBrushSize_SelectedIndexChanged);
			// 
			// comboLayers
			// 
			this.comboLayers.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboLayers.Enabled = false;
			this.comboLayers.FormattingEnabled = true;
			this.comboLayers.Items.AddRange(new object[] {
            "Layer 1",
            "Layer 2",
            "Layer 3",
            "Layer 4"});
			this.comboLayers.Location = new System.Drawing.Point(3, 3);
			this.comboLayers.Name = "comboLayers";
			this.comboLayers.Size = new System.Drawing.Size(128, 21);
			this.comboLayers.TabIndex = 0;
			this.comboLayers.SelectedIndexChanged += new System.EventHandler(this.comboLayers_SelectedIndexChanged);
			// 
			// panelTiles
			// 
			this.panelTiles.BackColor = System.Drawing.SystemColors.Control;
			this.panelTiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTiles.Location = new System.Drawing.Point(3, 3);
			this.panelTiles.Name = "panelTiles";
			this.panelTiles.Size = new System.Drawing.Size(128, 553);
			this.panelTiles.TabIndex = 1;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(134, 559);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtLog
			// 
			this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtLog.Location = new System.Drawing.Point(0, 0);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.Size = new System.Drawing.Size(1023, 92);
			this.txtLog.TabIndex = 0;
			this.txtLog.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1023, 752);
			this.Controls.Add(this.splitLog);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "MapEditor";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitLog.Panel1.ResumeLayout(false);
			this.splitLog.Panel2.ResumeLayout(false);
			this.splitLog.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitLog)).EndInit();
			this.splitLog.ResumeLayout(false);
			this.tabTools.ResumeLayout(false);
			this.tabTiles.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.SplitContainer splitLog;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.TabControl tabTools;
		private System.Windows.Forms.TabPage tabTiles;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ComboBox comboLayers;
		private System.Windows.Forms.Panel panelTiles;
		private System.Windows.Forms.VScrollBar scrollMapV;
		private System.Windows.Forms.HScrollBar scrollMapH;
		private System.Windows.Forms.ToolStripStatusLabel textStatus;
		private MapPanel panelMap;
		private System.Windows.Forms.ToolStripMenuItem layersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem layer1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem layer2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem layer3ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem layer4ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gridColorToolStripMenuItem;
		private System.Windows.Forms.ComboBox comboBrushSize;
    }
}

