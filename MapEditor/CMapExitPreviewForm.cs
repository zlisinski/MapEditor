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
	public partial class CMapExitPreviewForm : Form
	{
		private CMapExit curExit;

		public CMapExitPreviewForm(CMapExit exit)
		{
			InitializeComponent();

			curExit = exit;

			comboMap.DataSource = MapList.mapNames;
			comboMap.SelectedValue = curExit.mapUuid;

			textEntranceId.Text = curExit.mapEntranceId.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		private void updateMapImage()
		{
			CMap map = MapList.getMapFromUuid((Guid)comboMap.SelectedValue);
			CMapEntrance curEntrance = map.entrances[curExit.mapEntranceId];
			CMapRenderer renderer = new CMapRenderer(map, curEntrance, null);
			CLayerVisibility layers = new CLayerVisibility();

			int mapWidth = map.width * Globals.tileSize;
			int mapHeight = map.height * Globals.tileSize;
			int newWidth = 0;
			int newHeight = 0;

			// Calculate the scaled down size of the map to fit within the image
			if (mapWidth > mapHeight)
			{
				newWidth = picMapPreview.Size.Width;
				newHeight = (int)Math.Floor(((double)mapHeight / mapWidth) * picMapPreview.Size.Width);
			}
			else
			{
				newHeight = picMapPreview.Size.Height;
				newWidth = (int)Math.Floor(((double)mapWidth / mapHeight) * picMapPreview.Size.Height);
			}

			// Don't scale map up if it can fit
			if (newWidth > mapWidth || newHeight > mapHeight)
			{
				newWidth = mapWidth;
				newHeight = mapHeight;
			}

			picMapPreview.Image = renderer.render(0, 0, mapWidth, mapHeight, newWidth, newHeight, layers);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboMap_SelectedIndexChanged(object sender, EventArgs e)
		{
			updateMapImage();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void picMapPreview_Click(object sender, EventArgs e)
		{

		}
	}
}
