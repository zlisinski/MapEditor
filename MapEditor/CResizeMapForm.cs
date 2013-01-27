using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapEditor
{
	public partial class CResizeMapForm : Form
	{
		CMap curMap;

		public CResizeMapForm(CMap curMap)
		{
			InitializeComponent();

			this.curMap = curMap;

			labelCurrentWidthValue.Text = curMap.width.ToString();
			labelCurrentHeightValue.Text = curMap.height.ToString();
			numNewWidth.Value = curMap.width;
			numNewHeight.Value = curMap.height;

			/*Bitmap bmp = new Bitmap(curMap.width * Globals.tileSize, curMap.height * Globals.tileSize);
			Graphics graphics = Graphics.FromImage(bmp);

			for (int x = 0; x < curMap.width; x++)
			{
				for (int y = 0; y < curMap.height; y++)
				{
					for (int z = 0; z < Globals.layerCount; z++)
					{
						// Get the tile to paint
						ushort tileId = curMap.cells[x, y].tiles[z];
						CTile curTile = curMap.tileSet.layers[z].getTileFromId(tileId);

						// Paint tile onto buffer
						graphics.DrawImage(curTile.image, x * Globals.tileSize, y * Globals.tileSize,
							Globals.tileSize, Globals.tileSize);
					}

					//if (drawGrid)
						//bufferGraphics.DrawLine(gridPen, 0, y * Globals.tileSize, endX * Globals.tileSize, y * Globals.tileSize);*/
				}

				//if (drawGrid)
					//bufferGraphics.DrawLine(gridPen, x * Globals.tileSize, 0, x * Globals.tileSize, endY * Globals.tileSize);
			}*/
		}

		private void checkCenterH_CheckedChanged(object sender, EventArgs e)
		{
			numTop.Enabled = !checkCenterH.Checked;
		}

		private void checkCentrV_CheckedChanged(object sender, EventArgs e)
		{
			numLeft.Enabled = !checkCentrV.Checked;
		}

		private void numNewWidth_ValueChanged(object sender, EventArgs e)
		{

		}

		private void numNewHeight_ValueChanged(object sender, EventArgs e)
		{

		}

		private void numTop_ValueChanged(object sender, EventArgs e)
		{

		}

		private void numLeft_ValueChanged(object sender, EventArgs e)
		{

		}
	}
}
