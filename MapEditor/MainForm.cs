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

namespace MapEditor
{
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
		/// Whether or not to draw the grid.
		/// </summary>
		protected bool drawGrid = false;

		/// <summary>
		/// The color of the grid.
		/// </summary>
		protected Color gridColor = Color.White;

		#region Startup Functions
		public MainForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				tileSets = TileSets.instance;
				foreach (CTileSet ts in tileSets)
				{
					logString("Loaded tileset " + ts);
				}

				comboLayers.SelectedIndex = 0;
				comboBrushSize.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion

		#region Menu Events
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CNewMapForm dialog = new CNewMapForm();
			DialogResult res = dialog.ShowDialog();

			if (res == DialogResult.OK)
			{
				newMap(dialog.name, dialog.width, dialog.height, dialog.tileSet);
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog fd = new OpenFileDialog();
			fd.Filter = "Map Files(*.map)|*.map";
			fd.InitialDirectory = Globals.mapDir;
			DialogResult res = fd.ShowDialog(this);

			if (res == DialogResult.OK)
			{
				openMap(fd.FileName);
			}
		}

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

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void layer1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			layer1ToolStripMenuItem.Checked = !layer1ToolStripMenuItem.Checked;
			layersVisible[0] = layer1ToolStripMenuItem.Checked;

			redrawMap();
		}

		private void layer2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			layer2ToolStripMenuItem.Checked = !layer2ToolStripMenuItem.Checked;
			layersVisible[1] = layer2ToolStripMenuItem.Checked;

			redrawMap();
		}

		private void layer3ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			layer3ToolStripMenuItem.Checked = !layer3ToolStripMenuItem.Checked;
			layersVisible[2] = layer3ToolStripMenuItem.Checked;

			redrawMap();
		}

		private void layer4ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			layer4ToolStripMenuItem.Checked = !layer4ToolStripMenuItem.Checked;
			layersVisible[3] = layer1ToolStripMenuItem.Checked;

			redrawMap();
		}

		private void gridToolStripMenuItem_Click(object sender, EventArgs e)
		{
			gridToolStripMenuItem.Checked = !gridToolStripMenuItem.Checked;
			drawGrid = gridToolStripMenuItem.Checked;

			redrawMap();
		}

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
			int i = 0;
			
			curLayer = comboLayers.SelectedIndex;

			panelTiles.Controls.Clear();

			if (curMap == null)
				return;

			foreach (CTileSetGroup group in curMap.tileSet.layers[curLayer].groups)
			{
				foreach (CTile tile in group.tiles)
				{
					PictureBox pic = new PictureBox();
					pic.Image = tile.image;
					pic.Width = 32;
					pic.Height = 32;
					pic.Location = new Point((i % 4) * 32, (i / 4) * 32);
					pic.Click += new System.EventHandler(this.tile_Click);
					pic.Tag = tile;
					panelTiles.Controls.Add(pic);
					i++;
				}
			}
			
			// Select the first tile when changing layers
			tile_Click(panelTiles.Controls[0], EventArgs.Empty);
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
			CTile tile = (CTile)curPic.Tag;
			curBrush = tile;
			
			foreach (PictureBox pic in panelTiles.Controls)
				pic.BorderStyle = BorderStyle.None;
			curPic.BorderStyle = BorderStyle.Fixed3D;
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
			int panelTileWidth = panelMap.Size.Width / 32;
			int panelTileHeight = panelMap.Size.Height / 32;

			// Move over one full screen, minus one tile
			scrollMapH.LargeChange = panelTileWidth - 1;
			// Needs adjusting, scrolls too far past the end
			scrollMapH.Maximum = Math.Max(0, curMap.width - panelTileWidth + scrollMapH.LargeChange);

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
				
				saveToolStripMenuItem.Enabled = true;
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
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
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

		private void redrawMap()
		{
			panelMap.Refresh();
		}

		/// <summary>
		/// Paints the map on the panel.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelMap_Paint(object sender, PaintEventArgs e)
		{
			// Create an image to paint on. Painting is double buffered.
			Bitmap buffer = new Bitmap(panelMap.Size.Width, panelMap.Size.Height);
			Graphics bufferGraphics = Graphics.FromImage(buffer);
			bufferGraphics.Clear(System.Drawing.SystemColors.Control);

			// Get the Graphics object for the panel
			Graphics panelGraphics = panelMap.CreateGraphics();

			if (curMap != null)
			{
				// Number of tiles displayable inside the panel
				int panelTilesX = (panelMap.Size.Width / 32) + 1;
				int panelTilesY = (panelMap.Size.Height / 32) + 1;

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
							if (!layersVisible[z])
								continue;

							// Get the tile to paint
							ushort tileId = curMap.cells[x + offsetX, y + offsetY].tiles[z];
							CTile curTile = curMap.tileSet.layers[z].getTileFromId(tileId);

							// Paint tile onto buffer
							bufferGraphics.DrawImage(curTile.image, x * 32, y * 32, 32, 32);
						}

						if (drawGrid)
							bufferGraphics.DrawLine(gridPen, 0, y * 32, endX * 32, y * 32);
					}

					if (drawGrid)
						bufferGraphics.DrawLine(gridPen, x * 32, 0, x * 32, endY * 32); 
				}
			}

			// Copy image from buffer to panel
			panelGraphics.DrawImage(buffer, 0, 0, panelMap.Size.Width, panelMap.Size.Height);
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
		/// Updated the coordinates in the status bar.
		/// If left mouse button is down, trigger a mouse click event on the cell.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelMap_MouseMove(object sender, MouseEventArgs e)
		{
			int tileX = (e.X / 32) + scrollMapH.Value;
			int tileY = (e.Y / 32) + scrollMapV.Value;

			/*int brushStartX = tileX - (curBrushSize / 2);
			int brushStartY = tileY - (curBrushSize / 2);*/
			int brushStartX = (e.X / 32) - (curBrushSize / 2);
			int brushStartY = (e.Y / 32) - (curBrushSize / 2);

			Graphics panelGraphics = panelMap.CreateGraphics();
			Pen pen = new Pen(Color.Red, 2);

			redrawMap();
			if (curMap != null && tileX < curMap.width && tileY < curMap.height)
			{
				// Draw a rectangle around the current brush
				panelGraphics.DrawRectangle(pen, brushStartX * 32, brushStartY * 32, 
					curBrushSize * 32, curBrushSize * 32);

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
			int tileX = (e.X / 32) + scrollMapH.Value;
			int tileY = (e.Y / 32) + scrollMapV.Value;
			int curLayer = comboLayers.SelectedIndex;

			int brushStartX = tileX - (curBrushSize / 2);
			int brushEndX = tileX + (curBrushSize / 2);
			int brushStartY = tileY - (curBrushSize / 2);
			int brushEndY = tileY + (curBrushSize / 2);

			if (curMap == null || tileX >= curMap.width || tileY >= curMap.height)
				return;

			for (int x = brushStartX; x <= brushEndX; x++)
			{
				for (int y = brushStartY; y <= brushEndY; y++)
				{
					if (x >= 0 && y >= 0 && x < curMap.width && y < curMap.height)
					{
						CMapCell cell = curMap.cells[x, y];
						cell.tiles[curLayer] = curBrush.id;
					}
				}
			}

			redrawMap();
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
