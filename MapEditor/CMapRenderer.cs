using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditor
{
	class CMapRenderer
	{
		protected CMap map;
		protected CMapEntrance curEntrance;
		protected CMapExit curExit;
		protected static CTile[] walkTypeTiles = new CTile[Enum.GetNames(typeof(EWalkType)).Length];
		protected CTile[] monsterRegionTiles;

		public CMapRenderer(CMap map)
		{
			this.map = map;
		}

		public CMapRenderer(CMap map, CMapEntrance entrance, CMapExit exit)
		{
			this.map = map;
			this.curEntrance = entrance;
			this.curExit = exit;
		}

		static CMapRenderer()
		{
			string walkImagesFilename = Globals.tileDir + "walktypes.png";
			for (ushort i = 0; i < Enum.GetNames(typeof(EWalkType)).Length; i++)
			{
				string tileName = Enum.GetNames(typeof(EWalkType))[i];
				walkTypeTiles[i] = new CTile(i, tileName, walkImagesFilename, i, 0);
			}
		}

		/// <summary>
		/// Renders the entire map in the provided dimensions.
		/// </summary>
		/// <param name="destW">Width of the output image.</param>
		/// <param name="destH">Height of the output image.</param>
		/// <param name="layers">Which layers to render.</param>
		/// <returns>Bitmap</returns>
		public Bitmap render(int destW, int destH, CLayerVisibility layers)
		{
			try
			{
				if (map == null)
					throw new NullReferenceException("map is null");

				return render(0, 0, map.width * Globals.tileSize, map.height * Globals.tileSize, destW, destH, layers);
			}
			catch { throw; }
		}

		/// <summary>
		/// Renders the provided area of the map in the provided dimensions.
		/// </summary>
		/// <param name="sourceRect">Source rectangle of area to render.</param>
		/// <param name="destW">Width of the output image.</param>
		/// <param name="destH">Height of the output image.</param>
		/// <param name="layers">Which layers to render.</param>
		/// <returns>Bitmap</returns>
		public Bitmap render(Rectangle sourceRect, int destW, int destH, CLayerVisibility layers)
		{
			try
			{
				return render(sourceRect.X, sourceRect.Y, sourceRect.Width, sourceRect.Height, destW, destH, layers);
			}
			catch { throw; }
		}

		/// <summary>
		/// Renders the provided area of the map in the provided dimensions.
		/// </summary>
		/// <param name="sourceX">Source X of area to render.</param>
		/// <param name="sourceY">Source Y of area to render.</param>
		/// <param name="sourceW">Source width of area to render.</param>
		/// <param name="sourceH">Source height of area to render.</param>
		/// <param name="destW">Width of the output image.</param>
		/// <param name="destH">Height of the output image.</param>
		/// <param name="layers">Which layers to render.</param>
		/// <returns>Bitmap</returns>
		public Bitmap render(int sourceX, int sourceY, int sourceW, int sourceH, int destW, int destH, CLayerVisibility layers)
		{
			try
			{
				// Local var to save some typing
				int ts = Globals.tileSize;

				// Load monster region tiles
				const int maxMonsterRegions = 13;
				string monsterRegionImagesFilename = "monsterregions.png";
				int monsterRegionCount = map.monsterRegionGroup.monsterRegions.Length;
				CMonsterRegionGroup regionGroup = map.monsterRegionGroup;

				if (monsterRegionCount > maxMonsterRegions)
					throw new Exception(string.Format("There aren't enough colors set for monster group {0}. There are only {1} colors set.",
							regionGroup.name, maxMonsterRegions));

				monsterRegionTiles = new CTile[monsterRegionCount];
				for (ushort i = 0; i < monsterRegionCount; i++)
				{
					CMonsterRegion region = regionGroup.monsterRegions[i];
					string tileName = region.name;
					monsterRegionTiles[i] = new CTile(i, tileName, monsterRegionImagesFilename, i, 0);
				}

				// Calculate the start and end tiles that contain the source rectangle
				int tileStartX = (int)(sourceX / ts);
				int tileStartY = (int)(sourceY / ts);
				int tileEndX = (int)((sourceX + sourceW - 1) / ts);
				int tileEndY = (int)((sourceY + sourceH - 1) / ts);

				// Buffer size is source rectangle rounded up to tile boundaries
				int bufferX = ((tileEndX - tileStartX) + 1) * ts;
				int bufferY = ((tileEndY - tileStartY) + 1) * ts;

				Console.WriteLine("sourceX={0}, sourceW={1}, tileStartX={2}, tileEndX={3}, bufferX={4}", sourceX, sourceW,
					tileStartX, tileEndX, bufferX);

				if (map == null)
					return null;
				
				// Create buffer to render source to full size
				Bitmap buffer = new Bitmap(bufferX, bufferY);
				Graphics bufferGraphics = Graphics.FromImage(buffer);
				bufferGraphics.Clear(System.Drawing.SystemColors.Control);

				for (int x = tileStartX; x <= tileEndX; x++)
				{
					for (int y = tileStartY; y <= tileEndY; y++)
					{
						for (int z = 0; z < Globals.layerCount; z++)
						{
							// Skip this layer if its visibility is turned off
							if (!layers.layersVisible[z])
								continue;

							// Get the tile id to paint
							ushort tileId = map.cells[x, y].tiles[z];

							// Skip drawing if the tile is fully transparent
							if (tileId == 0)
								continue;

							// Get the tile to paint
							CTile tile = map.tileSet.layers[z].getTileFromId(tileId);
							Bitmap tileImage = tile.image;

							// Paint tile onto buffer
							bufferGraphics.DrawImage(tileImage, (x - tileStartX) * ts, (y - tileStartY) * ts, ts, ts);
						}

						// Draw the walk layer if it is visible
						if (layers.walkLayerVisible)
						{
							// Get the tile id to paint
							ushort walkTileId = (ushort)map.cells[x, y].walkType;

							// Skip drawing if the tile is fully transparent
							if ((EWalkType)walkTileId != EWalkType.NormalWalk)
							{
								// Get the tile to paint
								CTile walkTile = walkTypeTiles[walkTileId];

								// Paint tile onto buffer
								bufferGraphics.DrawImage(walkTile.image, x * ts, y * ts, ts, ts);
							}
						}

						// Draw the monster region layer if it is visible
						if (layers.monsterRegionLayerVisible)
						{
							// Get the tile id to paint
							ushort regionTileId = (ushort)map.cells[x, y].monsterRegionId;

							// Skip drawing if the tile is fully transparent
							if (regionTileId != 0)
							{
								// Get the tile to paint
								CTile regionTile = monsterRegionTiles[regionTileId];

								// Paint tile onto buffer
								bufferGraphics.DrawImage(regionTile.image, x * ts, y * ts, ts, ts);
							}
						}
					}
				}

				// Draw entrance and exit squares
				if (layers.entranceExitLayerVisible)
				{
					Pen pen = new Pen(Color.Aqua);
					foreach (int i in map.entrances.Keys)
					{
						CMapEntrance ent = map.entrances[i];

						// Skip if tile is off screen
						if (ent.tileX < tileStartX || ent.tileX > tileEndX || ent.tileY < tileStartX || ent.tileY > tileEndY)
							continue;

						if (ent == curEntrance)
							pen = new Pen(Color.Aqua, 3);
						else
							pen = new Pen(Color.Aqua, 1);

						Rectangle rect = new Rectangle((ent.tileX - tileStartX) * ts, (ent.tileY - tileStartY) * ts, ts, ts);

						// Draw entrance
						bufferGraphics.DrawRectangle(pen, rect);

						Font font = new Font("Arial", 10);
						SolidBrush brush = new SolidBrush(Color.Aqua);

						bufferGraphics.DrawString(i.ToString(), font, brush, rect);

						// Highlight the selected entrance
						if (ent == curEntrance)
							bufferGraphics.DrawEllipse(pen, rect.X + (rect.Width / 4), rect.Y + (rect.Height / 4),
								rect.Width / 2, rect.Height / 2);
					}

					//pen = new Pen(Color.Blue);
					foreach (CMapExit exit in map.exits)
					{
						// Skip if tile is off screen
						if (exit.tileX < tileStartX || exit.tileX > tileEndX || exit.tileY < tileStartY || exit.tileY >= tileEndY)
							continue;

						if (exit == curExit)
							pen = new Pen(Color.Blue, 3);
						else
							pen = new Pen(Color.Blue, 1);

						Rectangle rect = new Rectangle((exit.tileX - tileStartX) * ts, (exit.tileY - tileStartY) * ts, ts, ts);

						// Draw exit
						bufferGraphics.DrawRectangle(pen, rect);

						// Highlight the selected entrance
						if (exit == curExit)
							bufferGraphics.DrawEllipse(pen, rect.X + (rect.Width / 4), rect.Y + (rect.Height / 4),
								rect.Width / 2, rect.Height / 2);
					}
				}

				// Create output image sized to the destination dimensions
				Bitmap outputBmp = new Bitmap(destW, destH);
				Graphics outputBmpGraphics = Graphics.FromImage(outputBmp);
				//outputBmpGraphics.Clear(System.Drawing.SystemColors.Control);
				outputBmpGraphics.Clear(Color.Black);

				// Draw source image onto output image, possibly scaling image
				Rectangle destRect = new Rectangle(0, 0, destW, destH);
				Rectangle sourceRect = new Rectangle(sourceX % ts, sourceY % ts, sourceW, sourceH);
				outputBmpGraphics.DrawImage(buffer, destRect, sourceRect, GraphicsUnit.Pixel);

				return outputBmp;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}

			return null;
		}
	}
}
