using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Threading;

namespace MapEditor
{
	public delegate void DLogString(string message);

    public partial class MainForm : Form
    {
		/// <summary>
		/// A local copy of the TileSets singleton instance.
		/// </summary>
		protected TileSets tileSets;

		/// <summary>
		/// The current map opened for editing.
		/// </summary>
		protected CMap curMap = null;

		/// <summary>
		/// The filename of the current map.
		/// </summary>
		protected string curMapFilename = "";

		/// <summary>
		/// If the map has unsaved changes.
		/// </summary>
		protected bool _curMapDirty = false;
		protected bool curMapDirty
		{
			get { return _curMapDirty; }
			set
			{
				_curMapDirty = value;
				updateTitleBar();
				saveToolStripMenuItem.Enabled = value;
			}
		}

		/// <summary>
		/// The current layer being edited.
		/// </summary>
		protected int curLayer = 0;

		/// <summary>
		/// The tile to use as a brush when painting on the map.
		/// </summary>
		protected CTile curBrush = null;

		/// <summary>
		/// The size of the current tile brush.
		/// </summary>
		protected int curBrushSize = 1;

		/// <summary>
		/// Which layers are currently visible.
		/// </summary>
		protected bool[] layersVisible = new bool[] {true, true, true, true};

		/// <summary>
		/// Is the walkType layer visible.
		/// </summary>
		protected bool walkLayerVisible = true;

		/// <summary>
		/// Whether or not to draw the grid.
		/// </summary>
		protected bool drawGrid = false;

		/// <summary>
		/// The color of the grid.
		/// </summary>
		protected Color gridColor = Color.White;

		/// <summary>
		/// Tile images for walk types.
		/// </summary>
		protected CTile[] walkTypeTiles = new CTile[Enum.GetNames(typeof(EWalkType)).Length];

		/// <summary>
		/// Worker thread for updating the minimap.
		/// </summary>
		protected Thread updateMiniMapThread;

		/// <summary>
		/// Queue of copies of the current map to be used to update the minimap.
		/// </summary>
		protected Queue<CMap> updateMiniMapQueue = new Queue<CMap>();

		#region Form Functions
		public MainForm()
		{
			InitializeComponent();
			curMapDirty = false;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			try
			{
				// Load tileSets
				tileSets = TileSets.instance;
				foreach (CTileSet ts in tileSets)
				{
					logString("Loaded tileset " + ts);
				}

				// Load walkType tiles
				string walkImagesFilename = Globals.tileDir + "walktypes.png";
				for (ushort i = 0; i < Enum.GetNames(typeof(EWalkType)).Length; i++)
				{
					string tileName = Enum.GetNames(typeof(EWalkType))[i];
					walkTypeTiles[i] = new CTile(i, tileName, walkImagesFilename, i, 0);
				}
				
				comboLayers.SelectedIndex = 0;
				comboBrushSize.SelectedIndex = 0;

				// Start worker thread for updating the minimap
				updateMiniMapThread = new Thread(new ThreadStart(updateMiniMapThreadFunc));
				updateMiniMapThread.Start();

				//openMap(Globals.mapDir + "overworld1.map");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Cancel closing if map is dirty and user selects Cancel
			if (cancelActionIfDirty() == true)
				e.Cancel = true;

			// Stop the minimap worker thread
			updateMiniMapThread.Abort();
		}

		/// <summary>
		/// Updates the title bar with the map name, filename and whether the current map is dirty.
		/// </summary>
		private void updateTitleBar()
		{
			StringBuilder newTitle = new StringBuilder();
			newTitle.AppendFormat("MapEditor v{0}", Globals.version);

			if (curMap != null)
			{
				newTitle.AppendFormat(" - {0}", curMap.name);

				if (curMapFilename == "")
					newTitle.Append(" - unsaved map");
				else
					newTitle.AppendFormat(" - {0}", curMapFilename);

				if (curMapDirty == true)
					newTitle.Append(" *");
			}

			this.Text = newTitle.ToString();
		}
		#endregion

		#region Menu Events

		/// <summary>
		/// Shows dialog to create a new map.
		/// Triggered when the File->New menu item is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (cancelActionIfDirty() == true)
				return;

			CNewMapForm dialog = new CNewMapForm();
			DialogResult res = dialog.ShowDialog();

			if (res == DialogResult.OK)
			{
				newMap(dialog.name, dialog.width, dialog.height, dialog.tileSet);
			}
		}

		/// <summary>
		/// Opens an existing map.
		/// Triggered when the File->Open menu item is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (cancelActionIfDirty() == true)
				return;

			OpenFileDialog fd = new OpenFileDialog();
			fd.Filter = "Map Files(*.map)|*.map";
			fd.InitialDirectory = Globals.mapDir;
			DialogResult res = fd.ShowDialog(this);

			if (res == DialogResult.OK)
			{
				openMap(fd.FileName);
			}
		}

		/// <summary>
		/// Saves the current map.
		/// Triggered when the File->Save menu item is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Trigger saveAs if map has never been saved before.
			if (curMapFilename == "")
			{
				saveAsToolStripMenuItem.PerformClick();
				return;
			}

			saveMap(curMapFilename);
		}

		/// <summary>
		/// Saves the current map as a new file.
		/// Triggered when the File->SaveAs menu item is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog fd = new SaveFileDialog();
			fd.Filter = "Map Files(*.map)|*.map";
			fd.InitialDirectory = Globals.mapDir;
			DialogResult res = fd.ShowDialog(this);

			if (res == DialogResult.OK)
			{
				saveMap(fd.FileName);
			}
		}

		/// <summary>
		/// Exits the application.
		/// Triggered when the File->Exit menu item is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// Toggle layer 1 visibility.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void layer1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			layer1ToolStripMenuItem.Checked = !layer1ToolStripMenuItem.Checked;
		}

		private void layer1ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			layersVisible[0] = layer1ToolStripMenuItem.Checked;
			redrawMap();
		}

		/// <summary>
		/// Toggle layer 2 visibility.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void layer2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			layer2ToolStripMenuItem.Checked = !layer2ToolStripMenuItem.Checked;
		}

		private void layer2ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			layersVisible[1] = layer2ToolStripMenuItem.Checked;
			redrawMap();
		}

		/// <summary>
		/// Toggle layer 3 visibility.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void layer3ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			layer3ToolStripMenuItem.Checked = !layer3ToolStripMenuItem.Checked;
		}

		private void layer3ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			layersVisible[2] = layer3ToolStripMenuItem.Checked;
			redrawMap();
		}

		/// <summary>
		/// Toggle layer 4 visibility.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void layer4ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			layer4ToolStripMenuItem.Checked = !layer4ToolStripMenuItem.Checked;
		}

		private void layer4ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			layersVisible[3] = layer1ToolStripMenuItem.Checked;
			redrawMap();
		}

		/// <summary>
		/// Toggle walk layer visibility.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void walkLayerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			walkLayerToolStripMenuItem.Checked = !walkLayerToolStripMenuItem.Checked;
		}
		
		private void walkLayerToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			walkLayerVisible = walkLayerToolStripMenuItem.Checked;
			redrawMap();
		}

		/// <summary>
		/// Toggle grid visibility.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridToolStripMenuItem_Click(object sender, EventArgs e)
		{
			gridToolStripMenuItem.Checked = !gridToolStripMenuItem.Checked;
			drawGrid = gridToolStripMenuItem.Checked;

			redrawMap();
		}

		/// <summary>
		/// Displays a dialog to pick the grid color.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			cd.Color = gridColor;

			DialogResult res = cd.ShowDialog();
			if (res == DialogResult.OK)
			{
				gridColor = cd.Color;
				redrawMap();
			}
		}

		/// <summary>
		/// Displays the rename map dialog.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void renameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRenameMapForm dialog = new CRenameMapForm(curMap.name);
			DialogResult res = dialog.ShowDialog();

			if (res == DialogResult.OK)
			{
				curMap.name = dialog.name;
				curMapDirty = true;
			}
		}

		/// <summary>
		/// Displays the resize map dialog.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CResizeMapForm dialog = new CResizeMapForm(curMap);
			dialog.ShowDialog(this);
		}
		#endregion

		#region Tile Palette Functions
		/// <summary>
		/// Redraws the tile palette with the tiles from the current layer. 
		/// Triggered when the layer dropdown is changed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboLayers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (curMap == null)
				return;

			try
			{
				int i = 0;

				curLayer = comboLayers.SelectedIndex;

				// Enable visibility for the selected layer
				switch (curLayer)
				{
					case 0:
						layer1ToolStripMenuItem.Checked = true;
						break;
					case 1:
						layer2ToolStripMenuItem.Checked = true;
						break;
					case 2:
						layer3ToolStripMenuItem.Checked = true;
						break;
					case 3:
						layer4ToolStripMenuItem.Checked = true;
						break;
					case 4:
						walkLayerToolStripMenuItem.Checked = true;
						break;
				}

				// Remove all tiles from previous layer
				panelTiles.Controls.Clear();	

				// Add tiles from current layer
				if (curLayer < Globals.layerCount)
				{
					foreach (CTileSetGroup group in curMap.tileSet.layers[curLayer].groups)
					{
						foreach (CTile tile in group.tiles)
						{
							PictureBox pic = createPictureBoxFromTile(tile, i);
							panelTiles.Controls.Add(pic);
							i++;
						}
					}
				}
				else if (curLayer == Globals.layerCount)
				{
					foreach (CTile tile in walkTypeTiles)
					{
						PictureBox pic = createPictureBoxFromTile(tile, i);
						panelTiles.Controls.Add(pic);
						i++;
					}
				}

				// Select the first tile when changing layers
				tile_Click(panelTiles.Controls[0], EventArgs.Empty);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
			}
		}

		/// <summary>
		/// Creates a PictureBox for the tile palette.
		/// </summary>
		/// <param name="tile">The tile to create from.</param>
		/// <param name="index">The index used for positioning.</param>
		/// <returns></returns>
		private PictureBox createPictureBoxFromTile(CTile tile, int index)
		{
			try
			{
				PictureBox pic = new PictureBox();
				pic.Image = tile.image;
				pic.Width = Globals.tileSize;
				pic.Height = Globals.tileSize;
				pic.Location = new Point((index % 5) * Globals.tileSize, (index / 5) * Globals.tileSize);
				pic.Click += new System.EventHandler(this.tile_Click);
				pic.Tag = tile;

				return pic;
			}
			catch { throw; }
		}

		/// <summary>
		/// Sets the selected tile as the current brush.
		/// Triggered when a tile in the tile palette is clicked. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tile_Click(object sender, EventArgs e)
		{
			PictureBox curPic = (PictureBox)sender;
			curBrush = (CTile)curPic.Tag;

			foreach (PictureBox pic in panelTiles.Controls)
			{
				if (pic == curPic)
				{
					Bitmap img = (Bitmap)((CTile)pic.Tag).image.Clone();
					Graphics graphics = Graphics.FromImage(img);
					Pen pen = new Pen(Color.Red, 2);

					// Draw border around current tile
					graphics.DrawRectangle(pen, 0, 0, Globals.tileSize, Globals.tileSize);
					pic.Image = img;
				}
				else
				{
					// Redraw image to remove border
					pic.Image = ((CTile)pic.Tag).image;
				}
			}
		}

		/// <summary>
		/// Sets the brush size.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBrushSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboBrushSize.SelectedIndex)
			{
				case 0:
					curBrushSize = 1;
					break;
				case 1:
					curBrushSize = 3;
					break;
				case 2:
					curBrushSize = 5;
					break;
				case 3:
					curBrushSize = 7;
					break;
				case 4:
					curBrushSize = 9;
					break;
			}
		}
		#endregion

		#region Scroll Bar Functions
		/// <summary>
		/// Resets the scrollbars after a new map is created or a map is loaded.
		/// </summary>
		private void resetScrollBars()
		{
			scrollMapH.Value = 0;
			scrollMapH.Minimum = 0;
			scrollMapH.SmallChange = 1;

			scrollMapV.Value = 0;
			scrollMapV.Minimum = 0;
			scrollMapV.SmallChange = 1;

			// Set Maximum and LargeChange
			setScrollBarSizes();
		}

		/// <summary>
		/// Set the scrolbar sizes based on map size and window size.
		/// Called when a map is created or loaded or when the window is resized.
		/// The formula for Maximum comes from http://msdn.microsoft.com/en-us/library/system.windows.forms.scrollbar.maximum.aspx			
		/// It needs tweaking for maximum value.
		/// </summary>
		private void setScrollBarSizes()
		{
			// Bail if there is no current map
			if (curMap == null)
				return;

			// Calculate how many tiles are displayable in the panel
			int panelTileWidth = panelMap.Size.Width / Globals.tileSize;
			int panelTileHeight = panelMap.Size.Height / Globals.tileSize;

			// Enable the scrollbar
			scrollMapH.Enabled = true;
			// Move over one full screen, minus one tile
			scrollMapH.LargeChange = panelTileWidth - 1;
			// Needs adjusting, scrolls too far past the end
			scrollMapH.Maximum = Math.Max(0, curMap.width - panelTileWidth + scrollMapH.LargeChange);

			// Enable the scrollbar
			scrollMapV.Enabled = true;
			// Move over one full screen, minus one tile
			scrollMapV.LargeChange = panelTileHeight - 1;
			// Needs adjusting, scrolls too far past the end
			scrollMapV.Maximum = Math.Max(0, curMap.height - panelTileHeight + scrollMapV.LargeChange);
		}

		/// <summary>
		/// Event called when the horizontal scrollbar is moved.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void scrollMapH_Scroll(object sender, ScrollEventArgs e)
		{
			// Redraw map
			redrawMap();
			
			//logString(string.Format("h={0}", ((HScrollBar)sender).Value));
		}

		/// <summary>
		/// Event called when the vertical scrollbar is moved.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void scrollMapV_Scroll(object sender, ScrollEventArgs e)
		{
			// Redraw map
			redrawMap();
			
			//logString(string.Format("v={0}", ((VScrollBar)sender).Value));
		}
		#endregion

		#region Map Functions
		/// <summary>
		/// Creates and displays a new map.
		/// </summary>
		/// <param name="name">Map name.</param>
		/// <param name="width">Map width in tiles.</param>
		/// <param name="height">Map height in tiles.</param>
		/// <param name="tileSet">Map tileset.</param>
		private void newMap(string name, int width, int height, CTileSet tileSet)
		{
			curMap = new CMap(name, width, height, tileSet);
			curMapFilename = "";
			curMapDirty = true;
			
			saveToolStripMenuItem.Enabled = true;
			saveAsToolStripMenuItem.Enabled = true;
			
			displayCurrentMap();
		}

		/// <summary>
		/// Opens a map from a file.
		/// </summary>
		/// <param name="filename">Filename of map to open.</param>
		private void openMap(string filename)
		{
			try
			{
				curMap = new CMap(filename);
				curMapFilename = filename;
				curMapDirty = false;
				
				saveAsToolStripMenuItem.Enabled = true;
				
				displayCurrentMap();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// Saves the current map to a file.
		/// </summary>
		/// <param name="filename">Filename to save map to.</param>
		private void saveMap(string filename)
		{
			try
			{
				curMap.save(filename);
				curMapFilename = filename;
				curMapDirty = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// Checks if the current map is dirty and prompts to save it before continuing.
		/// Saves map if user selects Yes.
		/// </summary>
		/// <returns>False if map isn't dirty or user selected Yes or No. True if user selected Cancel.</returns>
		private bool cancelActionIfDirty()
		{
			if (curMapDirty == false)
				return false;

			DialogResult Res = MessageBox.Show("The map has unsaved changes. Do you want to save the map?", "", 
				MessageBoxButtons.YesNoCancel);

			if (Res == DialogResult.Yes)
			{
				saveToolStripMenuItem.PerformClick();

				// User cancelled out of saving a new map
				if (curMapFilename == "")
					return true;

				curMapDirty = false;

				return false;
			}
			else if (Res == DialogResult.No)
				return false;
			else //if (Res == DialogResult.Cancel)
				return true;
		}

		/// <summary>
		/// Starts displaying the current map.
		/// </summary>
		private void displayCurrentMap()
		{
			// Enable layer dropdown
			comboLayers.Enabled = true;

			// Enable brush size dropdown
			comboBrushSize.Enabled = true;

			// Enable Map menu item
			mapToolStripMenuItem.Enabled = true;

			// Reset layer palette. If current layer is 0, trigger change event manually because setting the index 
			// to itself doesn't trigger a change event.
			if (curLayer == 0)
				comboLayers_SelectedIndexChanged(comboLayers, EventArgs.Empty);
			else
				comboLayers.SelectedIndex = 0;

			// Redraw the map
			redrawMap();

			// Reset scrollbar values
			resetScrollBars();
		}

		private void redrawMap(bool redrawMiniMap = true)
		{
			panelMap.Refresh();

			if (redrawMiniMap == true)
			{
				// Queue a minimap update with a copy of the current map
				updateMiniMapQueue.Enqueue((CMap)curMap.Clone());
			}
		}

		/// <summary>
		/// Paints the map on the panel.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelMap_Paint(object sender, PaintEventArgs e)
		{
			// Local var to save some typing
			int tileSize = Globals.tileSize;

			// Create an image to paint on. Painting is double buffered.
			Bitmap buffer = new Bitmap(panelMap.Size.Width, panelMap.Size.Height);
			Graphics bufferGraphics = Graphics.FromImage(buffer);
			bufferGraphics.Clear(System.Drawing.SystemColors.Control);

			if (curMap != null)
			{
				// Number of tiles displayable inside the panel
				int panelTilesX = (panelMap.Size.Width / tileSize) + 1;
				int panelTilesY = (panelMap.Size.Height / tileSize) + 1;

				// Starting offset, in tiles, in the map to start painting from
				int offsetX = scrollMapH.Value;
				int offsetY = scrollMapV.Value;
				
				// The last tile to paint on screen
				int endX = Math.Min(curMap.width - offsetX, panelTilesX);
				int endY = Math.Min(curMap.height - offsetY, panelTilesY);

				// Pen for drawing grid
				Pen gridPen = new Pen(gridColor);

				for (int x = 0; x < endX; x++)
				{
					for (int y = 0; y < endY; y++)
					{
						for (int z = 0; z < Globals.layerCount; z++)
						{
							// Skip this layer if its visibility is turned off
							if (!layersVisible[z])
								continue;

							// Get the tile id to paint
							ushort tileId = curMap.cells[x + offsetX, y + offsetY].tiles[z];
							
							// Skip drawing if the tile is fully transparent
							if (tileId == 0)
								continue;

							// Get the tile to paint
							CTile curTile = curMap.tileSet.layers[z].getTileFromId(tileId);

							// Paint tile onto buffer
							bufferGraphics.DrawImage(curTile.image, x * tileSize, y * tileSize, tileSize, tileSize);
						}

						// Draw the walk layer if it is visible
						if (walkLayerVisible)
						{
							// Get the tile id to paint
							ushort walkTileId = (ushort)curMap.cells[x + offsetX, y + offsetY].walkType;

							// Skip drawing if the tile is fully transparent
							if ((EWalkType)walkTileId == EWalkType.NormalWalk)
								continue;

							// Get the tile to paint
							CTile walkTile = walkTypeTiles[walkTileId];

							// Paint tile onto buffer
							bufferGraphics.DrawImage(walkTile.image, x * tileSize, y * tileSize, tileSize, tileSize);
						}

						if (drawGrid)
							bufferGraphics.DrawLine(gridPen, 0, y * tileSize, endX * tileSize, y * tileSize);
					}

					if (drawGrid)
						bufferGraphics.DrawLine(gridPen, x * tileSize, 0, x * tileSize, endY * tileSize); 
				}

				gridPen.Dispose();
			}

			bufferGraphics.Dispose();
			
			// Copy image from buffer to panel
			e.Graphics.DrawImage(buffer, 0, 0, panelMap.Size.Width, panelMap.Size.Height);
		}

		/// <summary>
		/// Event called when window size changes.
		/// Reset scrollbar sizes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelMap_SizeChanged(object sender, EventArgs e)
		{
			setScrollBarSizes();
		}

		/// <summary>
		/// Event called when the mouse moves over the map.
		/// Updates the coordinates in the status bar.
		/// If left mouse button is down, trigger a mouse click event on the cell.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelMap_MouseMove(object sender, MouseEventArgs e)
		{
			// The tile position of the mouse, relative to the start of the map
			int tileX = (e.X / Globals.tileSize) + scrollMapH.Value;
			int tileY = (e.Y / Globals.tileSize) + scrollMapV.Value;

			// The tile position of the start of the brush, relative to the start of the panel
			int brushStartX = (e.X / Globals.tileSize) - (curBrushSize / 2);
			int brushStartY = (e.Y / Globals.tileSize) - (curBrushSize / 2);

			Graphics panelGraphics = panelMap.CreateGraphics();
			Pen pen = new Pen(Color.Red, 2);

			// Redraw map to remove old brush outline, but don't update minimap
			redrawMap(false);

			if (curMap != null && tileX < curMap.width && tileY < curMap.height)
			{
				// Draw a rectangle around the current brush
				panelGraphics.DrawRectangle(pen, brushStartX * Globals.tileSize, brushStartY * Globals.tileSize,
					curBrushSize * Globals.tileSize, curBrushSize * Globals.tileSize);

				// Update status bar with current map coordinates
				textStatus.Text = string.Format("{0}, {1}", tileX, tileY);

				// If left mouse button down, trigger click on current cell
				if (e.Button == MouseButtons.Left)
					panelMap_MouseClick(panelMap, e);
			}
			else
				textStatus.Text = "";
		}

		/// <summary>
		/// Event called when clicking on a cell.
		/// Changes the tile in the current layer of the cell with the current brush tile.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelMap_MouseClick(object sender, MouseEventArgs e)
		{
			// The tile position of the mouse, relative to the start of the map
			int tileX = (e.X / Globals.tileSize) + scrollMapH.Value;
			int tileY = (e.Y / Globals.tileSize) + scrollMapV.Value;

			// The layer to operate on
			int curLayer = comboLayers.SelectedIndex;

			// Calculate the tiles contained within the current brush size
			int brushStartX = tileX - (curBrushSize / 2);
			int brushEndX = tileX + (curBrushSize / 2);
			int brushStartY = tileY - (curBrushSize / 2);
			int brushEndY = tileY + (curBrushSize / 2);

			// Bail if there is no map, or the mouse is located off the map
			if (curMap == null || tileX >= curMap.width || tileY >= curMap.height)
				return;

			// Update all tiles with the current brush
			for (int x = brushStartX; x <= brushEndX; x++)
			{
				for (int y = brushStartY; y <= brushEndY; y++)
				{
					// Only draw if the coordinates are within the map
					if (x >= 0 && y >= 0 && x < curMap.width && y < curMap.height)
					{
						CMapCell cell = curMap.cells[x, y];

						if (curLayer < Globals.layerCount)
							cell.tiles[curLayer] = curBrush.id;
						else if (curLayer == Globals.layerCount)
							cell.walkType = (EWalkType)curBrush.id;
					}
				}
			}

			curMapDirty = true;

			redrawMap();
		}
		#endregion

		#region MiniMap Functions
		/// <summary>
		/// Background thread function to update the minimap.
		/// Only runs if there is a copy of the map in the updateMiniMapQueue.
		/// This implementation is probably not the best way to do it, but I'm just
		/// interested in getting things up and running quickly for now.
		/// </summary>
		private void updateMiniMapThreadFunc()
		{
			int i = 0;

			while (true)
			{
				if (updateMiniMapQueue.Count() > 0)
				{
					Console.WriteLine("{0} {1}", i++, DateTime.Now);

					CMap curMapCopy = updateMiniMapQueue.Dequeue();
					updateMiniMap(curMapCopy);
				}

				Thread.Sleep(10);
			}
		}

		/// <summary>
		/// Updates the minimap image.
		/// This is horribly inefficient right now.
		/// </summary>
		private void updateMiniMap(CMap curMapCopy)
		{
			try
			{
				// Draw blank image if map is null
				if (curMapCopy == null)
				{
					Console.WriteLine("Updating minimap without a map");
					Bitmap bmp = new Bitmap(picMiniMap.Size.Width, picMiniMap.Size.Height);
					Graphics bmpGraphics = Graphics.FromImage(bmp);
					bmpGraphics.Clear(System.Drawing.SystemColors.Control);

					this.Invoke((MethodInvoker)delegate
					{
						picMiniMap.Image = bmp;
					});

					return;
				}

				// Local var to save some typing
				int tileSize = Globals.tileSize;

				// Get pixel dimensions of full map
				int mapWidth = curMapCopy.width * tileSize;
				int mapHeight = curMapCopy.height * tileSize;

				// Create a full sized image to paint on
				Bitmap buffer = new Bitmap(mapWidth, mapHeight);
				Graphics bufferGraphics = Graphics.FromImage(buffer);
				bufferGraphics.Clear(System.Drawing.SystemColors.Control);

				for (int x = 0; x < curMapCopy.width; x++)
				{
					for (int y = 0; y < curMapCopy.height; y++)
					{
						for (int z = 0; z < Globals.layerCount; z++)
						{
							// Skip this layer if its visibility is turned off
							if (!layersVisible[z])
								continue;

							// Get the tile to paint
							ushort tileId = curMapCopy.cells[x, y].tiles[z];
							CTile curTile = curMapCopy.tileSet.layers[z].getTileFromId(tileId);
							Bitmap curTileImage = curTile.image;

							// Paint tile onto buffer
							bufferGraphics.DrawImage(curTileImage, x * tileSize, y * tileSize, tileSize, tileSize);
						}
					}
				}

				int newWidth = 0;
				int newHeight = 0;

				// Calculate the scaled down size of the map within the minimap image
				if (mapWidth > mapHeight)
				{
					newWidth = picMiniMap.Size.Width;
					newHeight = (int)Math.Floor(((double)mapHeight / mapWidth) * picMiniMap.Size.Width);
				}
				else
				{
					newHeight = picMiniMap.Size.Height;
					newWidth = (int)Math.Floor(((double)mapWidth / mapHeight) * picMiniMap.Size.Height);
				}

				// Create blank image that is the same size as the minimap
				Bitmap newBmp = new Bitmap(picMiniMap.Size.Width, picMiniMap.Size.Height);
				Graphics newBmpGraphics = Graphics.FromImage(newBmp);
				newBmpGraphics.Clear(System.Drawing.SystemColors.Control);

				// Draw map centered on newBmp
				newBmpGraphics.DrawImage(buffer, (picMiniMap.Size.Width / 2) - (newWidth / 2), 
					(picMiniMap.Size.Height / 2) - (newHeight / 2), newWidth, newHeight);

				// Update minimp
				this.Invoke((MethodInvoker)delegate
				{
					picMiniMap.Image = newBmp;
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
			}
		}
		#endregion

		public void logString(string message)
		{
			if (!message.EndsWith("\n"))
				message += "\n";

			txtLog.AppendText(message);
		}
    }
}
