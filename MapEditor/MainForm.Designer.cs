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
			this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layer1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layer2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layer3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layer4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.walkLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.entrancesExitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.textStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.scrollMapV = new System.Windows.Forms.VScrollBar();
			this.scrollMapH = new System.Windows.Forms.HScrollBar();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.splitMap = new System.Windows.Forms.SplitContainer();
			this.splitLog = new System.Windows.Forms.SplitContainer();
			this.tabTools = new System.Windows.Forms.TabControl();
			this.tabTiles = new System.Windows.Forms.TabPage();
			this.panelTiles = new System.Windows.Forms.Panel();
			this.comboBrushSize = new System.Windows.Forms.ComboBox();
			this.comboLayers = new System.Windows.Forms.ComboBox();
			this.tabEntrances = new System.Windows.Forms.TabPage();
			this.buttonDeleteEntrance = new System.Windows.Forms.Button();
			this.buttonUpdateEntrance = new System.Windows.Forms.Button();
			this.numericEntranceId = new System.Windows.Forms.NumericUpDown();
			this.labelEntranceId = new System.Windows.Forms.Label();
			this.tabExits = new System.Windows.Forms.TabPage();
			this.picMiniMap = new System.Windows.Forms.PictureBox();
			this.comboExitMapName = new System.Windows.Forms.ComboBox();
			this.labelExitMapName = new System.Windows.Forms.Label();
			this.labelExitMapEntrance = new System.Windows.Forms.Label();
			this.buttonUpdateExit = new System.Windows.Forms.Button();
			this.buttonPreviewExit = new System.Windows.Forms.Button();
			this.buttonDeleteExit = new System.Windows.Forms.Button();
			this.numericExitEntranceId = new System.Windows.Forms.NumericUpDown();
			this.panelMap = new MapEditor.MapPanel();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitMap)).BeginInit();
			this.splitMap.Panel1.SuspendLayout();
			this.splitMap.Panel2.SuspendLayout();
			this.splitMap.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitLog)).BeginInit();
			this.splitLog.Panel1.SuspendLayout();
			this.splitLog.Panel2.SuspendLayout();
			this.splitLog.SuspendLayout();
			this.tabTools.SuspendLayout();
			this.tabTiles.SuspendLayout();
			this.tabEntrances.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericEntranceId)).BeginInit();
			this.tabExits.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picMiniMap)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericExitEntranceId)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.layersToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(997, 24);
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
			this.openToolStripMenuItem.Text = "&Open...";
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
			this.gridToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.gridToolStripMenuItem.Text = "&Grid";
			this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
			// 
			// gridColorToolStripMenuItem
			// 
			this.gridColorToolStripMenuItem.Name = "gridColorToolStripMenuItem";
			this.gridColorToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.gridColorToolStripMenuItem.Text = "Grid &Color...";
			this.gridColorToolStripMenuItem.Click += new System.EventHandler(this.gridColorToolStripMenuItem_Click);
			// 
			// mapToolStripMenuItem
			// 
			this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.resizeToolStripMenuItem});
			this.mapToolStripMenuItem.Enabled = false;
			this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
			this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.mapToolStripMenuItem.Text = "&Map";
			// 
			// renameToolStripMenuItem
			// 
			this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			this.renameToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.renameToolStripMenuItem.Text = "&Rename...";
			this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
			// 
			// resizeToolStripMenuItem
			// 
			this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
			this.resizeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.resizeToolStripMenuItem.Text = "Re&size...";
			this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
			// 
			// layersToolStripMenuItem
			// 
			this.layersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layer1ToolStripMenuItem,
            this.layer2ToolStripMenuItem,
            this.layer3ToolStripMenuItem,
            this.layer4ToolStripMenuItem,
            this.walkLayerToolStripMenuItem,
            this.entrancesExitsToolStripMenuItem});
			this.layersToolStripMenuItem.Name = "layersToolStripMenuItem";
			this.layersToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.layersToolStripMenuItem.Text = "&Layers";
			// 
			// layer1ToolStripMenuItem
			// 
			this.layer1ToolStripMenuItem.Checked = true;
			this.layer1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.layer1ToolStripMenuItem.Name = "layer1ToolStripMenuItem";
			this.layer1ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.layer1ToolStripMenuItem.Text = "Layer &1";
			this.layer1ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.layer1ToolStripMenuItem_CheckedChanged);
			this.layer1ToolStripMenuItem.Click += new System.EventHandler(this.layer1ToolStripMenuItem_Click);
			// 
			// layer2ToolStripMenuItem
			// 
			this.layer2ToolStripMenuItem.Checked = true;
			this.layer2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.layer2ToolStripMenuItem.Name = "layer2ToolStripMenuItem";
			this.layer2ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.layer2ToolStripMenuItem.Text = "Layer &2";
			this.layer2ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.layer2ToolStripMenuItem_CheckedChanged);
			this.layer2ToolStripMenuItem.Click += new System.EventHandler(this.layer2ToolStripMenuItem_Click);
			// 
			// layer3ToolStripMenuItem
			// 
			this.layer3ToolStripMenuItem.Checked = true;
			this.layer3ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.layer3ToolStripMenuItem.Name = "layer3ToolStripMenuItem";
			this.layer3ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.layer3ToolStripMenuItem.Text = "Layer &3";
			this.layer3ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.layer3ToolStripMenuItem_CheckedChanged);
			this.layer3ToolStripMenuItem.Click += new System.EventHandler(this.layer3ToolStripMenuItem_Click);
			// 
			// layer4ToolStripMenuItem
			// 
			this.layer4ToolStripMenuItem.Checked = true;
			this.layer4ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.layer4ToolStripMenuItem.Name = "layer4ToolStripMenuItem";
			this.layer4ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.layer4ToolStripMenuItem.Text = "Layer &4";
			this.layer4ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.layer4ToolStripMenuItem_CheckedChanged);
			this.layer4ToolStripMenuItem.Click += new System.EventHandler(this.layer4ToolStripMenuItem_Click);
			// 
			// walkLayerToolStripMenuItem
			// 
			this.walkLayerToolStripMenuItem.Checked = true;
			this.walkLayerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.walkLayerToolStripMenuItem.Name = "walkLayerToolStripMenuItem";
			this.walkLayerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.walkLayerToolStripMenuItem.Text = "&Walk Layer";
			this.walkLayerToolStripMenuItem.CheckedChanged += new System.EventHandler(this.walkLayerToolStripMenuItem_CheckedChanged);
			this.walkLayerToolStripMenuItem.Click += new System.EventHandler(this.walkLayerToolStripMenuItem_Click);
			// 
			// entrancesExitsToolStripMenuItem
			// 
			this.entrancesExitsToolStripMenuItem.Checked = true;
			this.entrancesExitsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.entrancesExitsToolStripMenuItem.Name = "entrancesExitsToolStripMenuItem";
			this.entrancesExitsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.entrancesExitsToolStripMenuItem.Text = "&Entrances && Exits";
			this.entrancesExitsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.entrancesExitsToolStripMenuItem_CheckedChanged);
			this.entrancesExitsToolStripMenuItem.Click += new System.EventHandler(this.entrancesExitsToolStripMenuItem_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(997, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 681);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(997, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// textStatus
			// 
			this.textStatus.Name = "textStatus";
			this.textStatus.Size = new System.Drawing.Size(0, 17);
			// 
			// scrollMapV
			// 
			this.scrollMapV.Dock = System.Windows.Forms.DockStyle.Right;
			this.scrollMapV.Enabled = false;
			this.scrollMapV.Location = new System.Drawing.Point(783, 0);
			this.scrollMapV.Name = "scrollMapV";
			this.scrollMapV.Size = new System.Drawing.Size(17, 566);
			this.scrollMapV.TabIndex = 2;
			this.scrollMapV.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollMapV_Scroll);
			// 
			// scrollMapH
			// 
			this.scrollMapH.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.scrollMapH.Enabled = false;
			this.scrollMapH.Location = new System.Drawing.Point(0, 549);
			this.scrollMapH.Name = "scrollMapH";
			this.scrollMapH.Size = new System.Drawing.Size(783, 17);
			this.scrollMapH.TabIndex = 1;
			this.scrollMapH.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollMapH_Scroll);
			// 
			// txtLog
			// 
			this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtLog.Location = new System.Drawing.Point(0, 0);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(800, 62);
			this.txtLog.TabIndex = 0;
			this.txtLog.TabStop = false;
			// 
			// splitMap
			// 
			this.splitMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitMap.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitMap.IsSplitterFixed = true;
			this.splitMap.Location = new System.Drawing.Point(0, 49);
			this.splitMap.Name = "splitMap";
			// 
			// splitMap.Panel1
			// 
			this.splitMap.Panel1.Controls.Add(this.splitLog);
			// 
			// splitMap.Panel2
			// 
			this.splitMap.Panel2.Controls.Add(this.tabTools);
			this.splitMap.Panel2.Controls.Add(this.picMiniMap);
			this.splitMap.Size = new System.Drawing.Size(997, 632);
			this.splitMap.SplitterDistance = 800;
			this.splitMap.TabIndex = 4;
			// 
			// splitLog
			// 
			this.splitLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitLog.Location = new System.Drawing.Point(0, 0);
			this.splitLog.Name = "splitLog";
			this.splitLog.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitLog.Panel1
			// 
			this.splitLog.Panel1.Controls.Add(this.scrollMapH);
			this.splitLog.Panel1.Controls.Add(this.panelMap);
			this.splitLog.Panel1.Controls.Add(this.scrollMapV);
			// 
			// splitLog.Panel2
			// 
			this.splitLog.Panel2.Controls.Add(this.txtLog);
			this.splitLog.Size = new System.Drawing.Size(800, 632);
			this.splitLog.SplitterDistance = 566;
			this.splitLog.TabIndex = 0;
			// 
			// tabTools
			// 
			this.tabTools.Controls.Add(this.tabTiles);
			this.tabTools.Controls.Add(this.tabEntrances);
			this.tabTools.Controls.Add(this.tabExits);
			this.tabTools.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabTools.Location = new System.Drawing.Point(0, 193);
			this.tabTools.Name = "tabTools";
			this.tabTools.SelectedIndex = 0;
			this.tabTools.Size = new System.Drawing.Size(193, 439);
			this.tabTools.TabIndex = 5;
			this.tabTools.SelectedIndexChanged += new System.EventHandler(this.tabTools_SelectedIndexChanged);
			// 
			// tabTiles
			// 
			this.tabTiles.BackColor = System.Drawing.SystemColors.Control;
			this.tabTiles.Controls.Add(this.panelTiles);
			this.tabTiles.Controls.Add(this.comboBrushSize);
			this.tabTiles.Controls.Add(this.comboLayers);
			this.tabTiles.Location = new System.Drawing.Point(4, 22);
			this.tabTiles.Name = "tabTiles";
			this.tabTiles.Padding = new System.Windows.Forms.Padding(3);
			this.tabTiles.Size = new System.Drawing.Size(185, 413);
			this.tabTiles.TabIndex = 0;
			this.tabTiles.Text = "Tiles";
			// 
			// panelTiles
			// 
			this.panelTiles.AutoScroll = true;
			this.panelTiles.AutoSize = true;
			this.panelTiles.BackColor = System.Drawing.SystemColors.Control;
			this.panelTiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTiles.Location = new System.Drawing.Point(3, 45);
			this.panelTiles.Name = "panelTiles";
			this.panelTiles.Size = new System.Drawing.Size(179, 365);
			this.panelTiles.TabIndex = 1;
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
			this.comboBrushSize.Size = new System.Drawing.Size(179, 21);
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
            "Layer 4",
            "Walk Layer"});
			this.comboLayers.Location = new System.Drawing.Point(3, 3);
			this.comboLayers.Name = "comboLayers";
			this.comboLayers.Size = new System.Drawing.Size(179, 21);
			this.comboLayers.TabIndex = 0;
			this.comboLayers.SelectedIndexChanged += new System.EventHandler(this.comboLayers_SelectedIndexChanged);
			// 
			// tabEntrances
			// 
			this.tabEntrances.BackColor = System.Drawing.SystemColors.Control;
			this.tabEntrances.Controls.Add(this.buttonDeleteEntrance);
			this.tabEntrances.Controls.Add(this.buttonUpdateEntrance);
			this.tabEntrances.Controls.Add(this.numericEntranceId);
			this.tabEntrances.Controls.Add(this.labelEntranceId);
			this.tabEntrances.Location = new System.Drawing.Point(4, 22);
			this.tabEntrances.Name = "tabEntrances";
			this.tabEntrances.Padding = new System.Windows.Forms.Padding(3);
			this.tabEntrances.Size = new System.Drawing.Size(185, 413);
			this.tabEntrances.TabIndex = 1;
			this.tabEntrances.Text = "Entrances";
			// 
			// buttonDeleteEntrance
			// 
			this.buttonDeleteEntrance.Enabled = false;
			this.buttonDeleteEntrance.Location = new System.Drawing.Point(6, 30);
			this.buttonDeleteEntrance.Name = "buttonDeleteEntrance";
			this.buttonDeleteEntrance.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteEntrance.TabIndex = 4;
			this.buttonDeleteEntrance.Text = "Delete";
			this.buttonDeleteEntrance.UseVisualStyleBackColor = true;
			this.buttonDeleteEntrance.Click += new System.EventHandler(this.buttonDeleteEntrance_Click);
			// 
			// buttonUpdateEntrance
			// 
			this.buttonUpdateEntrance.Enabled = false;
			this.buttonUpdateEntrance.Location = new System.Drawing.Point(106, 3);
			this.buttonUpdateEntrance.Name = "buttonUpdateEntrance";
			this.buttonUpdateEntrance.Size = new System.Drawing.Size(75, 23);
			this.buttonUpdateEntrance.TabIndex = 2;
			this.buttonUpdateEntrance.Text = "Update";
			this.buttonUpdateEntrance.UseVisualStyleBackColor = true;
			this.buttonUpdateEntrance.Click += new System.EventHandler(this.buttonUpdateEntrance_Click);
			// 
			// numericEntranceId
			// 
			this.numericEntranceId.Enabled = false;
			this.numericEntranceId.Location = new System.Drawing.Point(28, 4);
			this.numericEntranceId.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.numericEntranceId.Name = "numericEntranceId";
			this.numericEntranceId.Size = new System.Drawing.Size(72, 20);
			this.numericEntranceId.TabIndex = 1;
			// 
			// labelEntranceId
			// 
			this.labelEntranceId.AutoSize = true;
			this.labelEntranceId.Location = new System.Drawing.Point(3, 8);
			this.labelEntranceId.Name = "labelEntranceId";
			this.labelEntranceId.Size = new System.Drawing.Size(19, 13);
			this.labelEntranceId.TabIndex = 0;
			this.labelEntranceId.Text = "Id:";
			// 
			// tabExits
			// 
			this.tabExits.BackColor = System.Drawing.SystemColors.Control;
			this.tabExits.Controls.Add(this.numericExitEntranceId);
			this.tabExits.Controls.Add(this.buttonDeleteExit);
			this.tabExits.Controls.Add(this.buttonPreviewExit);
			this.tabExits.Controls.Add(this.buttonUpdateExit);
			this.tabExits.Controls.Add(this.labelExitMapEntrance);
			this.tabExits.Controls.Add(this.labelExitMapName);
			this.tabExits.Controls.Add(this.comboExitMapName);
			this.tabExits.Location = new System.Drawing.Point(4, 22);
			this.tabExits.Name = "tabExits";
			this.tabExits.Size = new System.Drawing.Size(185, 413);
			this.tabExits.TabIndex = 2;
			this.tabExits.Text = "Exits";
			// 
			// picMiniMap
			// 
			this.picMiniMap.Dock = System.Windows.Forms.DockStyle.Top;
			this.picMiniMap.Location = new System.Drawing.Point(0, 0);
			this.picMiniMap.Name = "picMiniMap";
			this.picMiniMap.Size = new System.Drawing.Size(193, 193);
			this.picMiniMap.TabIndex = 1;
			this.picMiniMap.TabStop = false;
			// 
			// comboExitMapName
			// 
			this.comboExitMapName.DisplayMember = "Item2";
			this.comboExitMapName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboExitMapName.Enabled = false;
			this.comboExitMapName.FormattingEnabled = true;
			this.comboExitMapName.Location = new System.Drawing.Point(56, 6);
			this.comboExitMapName.Name = "comboExitMapName";
			this.comboExitMapName.Size = new System.Drawing.Size(121, 21);
			this.comboExitMapName.TabIndex = 0;
			this.comboExitMapName.ValueMember = "Item1";
			// 
			// labelExitMapName
			// 
			this.labelExitMapName.AutoSize = true;
			this.labelExitMapName.Location = new System.Drawing.Point(4, 10);
			this.labelExitMapName.Name = "labelExitMapName";
			this.labelExitMapName.Size = new System.Drawing.Size(31, 13);
			this.labelExitMapName.TabIndex = 2;
			this.labelExitMapName.Text = "Map:";
			// 
			// labelExitMapEntrance
			// 
			this.labelExitMapEntrance.AutoSize = true;
			this.labelExitMapEntrance.Location = new System.Drawing.Point(4, 33);
			this.labelExitMapEntrance.Name = "labelExitMapEntrance";
			this.labelExitMapEntrance.Size = new System.Drawing.Size(53, 13);
			this.labelExitMapEntrance.TabIndex = 3;
			this.labelExitMapEntrance.Text = "Entrance:";
			// 
			// buttonUpdateExit
			// 
			this.buttonUpdateExit.Enabled = false;
			this.buttonUpdateExit.Location = new System.Drawing.Point(7, 55);
			this.buttonUpdateExit.Name = "buttonUpdateExit";
			this.buttonUpdateExit.Size = new System.Drawing.Size(75, 23);
			this.buttonUpdateExit.TabIndex = 4;
			this.buttonUpdateExit.Text = "Update";
			this.buttonUpdateExit.UseVisualStyleBackColor = true;
			this.buttonUpdateExit.Click += new System.EventHandler(this.buttonUpdateExit_Click);
			// 
			// buttonPreviewExit
			// 
			this.buttonPreviewExit.Enabled = false;
			this.buttonPreviewExit.Location = new System.Drawing.Point(7, 84);
			this.buttonPreviewExit.Name = "buttonPreviewExit";
			this.buttonPreviewExit.Size = new System.Drawing.Size(75, 23);
			this.buttonPreviewExit.TabIndex = 5;
			this.buttonPreviewExit.Text = "Preview";
			this.buttonPreviewExit.UseVisualStyleBackColor = true;
			this.buttonPreviewExit.Click += new System.EventHandler(this.buttonPreviewExit_Click);
			// 
			// buttonDeleteExit
			// 
			this.buttonDeleteExit.Enabled = false;
			this.buttonDeleteExit.Location = new System.Drawing.Point(7, 114);
			this.buttonDeleteExit.Name = "buttonDeleteExit";
			this.buttonDeleteExit.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteExit.TabIndex = 6;
			this.buttonDeleteExit.Text = "Delete";
			this.buttonDeleteExit.UseVisualStyleBackColor = true;
			this.buttonDeleteExit.Click += new System.EventHandler(this.buttonDeleteExit_Click);
			// 
			// numericExitEntranceId
			// 
			this.numericExitEntranceId.Enabled = false;
			this.numericExitEntranceId.Location = new System.Drawing.Point(57, 31);
			this.numericExitEntranceId.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.numericExitEntranceId.Name = "numericExitEntranceId";
			this.numericExitEntranceId.Size = new System.Drawing.Size(120, 20);
			this.numericExitEntranceId.TabIndex = 7;
			// 
			// panelMap
			// 
			this.panelMap.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.panelMap.BackColor = System.Drawing.SystemColors.Control;
			this.panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMap.Location = new System.Drawing.Point(0, 0);
			this.panelMap.Name = "panelMap";
			this.panelMap.Size = new System.Drawing.Size(783, 566);
			this.panelMap.TabIndex = 3;
			this.panelMap.SizeChanged += new System.EventHandler(this.panelMap_SizeChanged);
			this.panelMap.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMap_Paint);
			this.panelMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelMap_MouseClick);
			this.panelMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMap_MouseMove);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(997, 703);
			this.Controls.Add(this.splitMap);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "MapEditor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitMap.Panel1.ResumeLayout(false);
			this.splitMap.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitMap)).EndInit();
			this.splitMap.ResumeLayout(false);
			this.splitLog.Panel1.ResumeLayout(false);
			this.splitLog.Panel2.ResumeLayout(false);
			this.splitLog.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitLog)).EndInit();
			this.splitLog.ResumeLayout(false);
			this.tabTools.ResumeLayout(false);
			this.tabTiles.ResumeLayout(false);
			this.tabTiles.PerformLayout();
			this.tabEntrances.ResumeLayout(false);
			this.tabEntrances.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericEntranceId)).EndInit();
			this.tabExits.ResumeLayout(false);
			this.tabExits.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picMiniMap)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericExitEntranceId)).EndInit();
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
		private System.Windows.Forms.TextBox txtLog;
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
		private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem walkLayerToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitMap;
		private System.Windows.Forms.SplitContainer splitLog;
		private System.Windows.Forms.TabControl tabTools;
		private System.Windows.Forms.TabPage tabTiles;
		private System.Windows.Forms.Panel panelTiles;
		private System.Windows.Forms.ComboBox comboBrushSize;
		private System.Windows.Forms.ComboBox comboLayers;
		private System.Windows.Forms.TabPage tabEntrances;
		private System.Windows.Forms.PictureBox picMiniMap;
		private System.Windows.Forms.ToolStripMenuItem entrancesExitsToolStripMenuItem;
		private System.Windows.Forms.TabPage tabExits;
		private System.Windows.Forms.Button buttonDeleteEntrance;
		private System.Windows.Forms.Button buttonUpdateEntrance;
		private System.Windows.Forms.NumericUpDown numericEntranceId;
		private System.Windows.Forms.Label labelEntranceId;
		private System.Windows.Forms.Label labelExitMapEntrance;
		private System.Windows.Forms.Label labelExitMapName;
		private System.Windows.Forms.ComboBox comboExitMapName;
		private System.Windows.Forms.NumericUpDown numericExitEntranceId;
		private System.Windows.Forms.Button buttonDeleteExit;
		private System.Windows.Forms.Button buttonPreviewExit;
		private System.Windows.Forms.Button buttonUpdateExit;
    }
}

