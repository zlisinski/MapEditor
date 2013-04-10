using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace MapEditor
{
	/// <summary>
	/// Represents a tile image.
	/// </summary>
	public class CTile : ICloneable
	{
		/// <summary>
		/// The id of the tile.
		/// </summary>
		[XmlAttribute("id")]
		public ushort id { get; set; }

		/// <summary>
		/// The name of the tile.
		/// </summary>
		[XmlAttribute("name")]
		public string name { get; set; }

		/// <summary>
		/// The image filename of the tile.
		/// </summary>
		[XmlAttribute("filename")]
		public string filename { get; set; }

		/// <summary>
		/// X offset of the image within a sprite file.
		/// </summary>
		[XmlAttribute("xOffset")]
		public int xOffset { get; set; }

		/// <summary>
		/// Y offset of the image within a sprite file.
		/// </summary>
		[XmlAttribute("yOffset")]
		public int yOffset { get; set; }

		/// <summary>
		/// The transparency color of the tile. Defaults to Magenta(#FF00FF) if not present.
		/// </summary>
		[XmlAttribute("trans")]
		public string transColor { get; set; }

		/// <summary>
		/// Bitmap image.
		/// </summary>
		private Bitmap _image = null;
		public Bitmap image
		{
			get
			{
				if (_image != null)
					return _image;

				try
				{
					// Local var to save some typing
					int tileSize = Globals.tileSize;

					// If filename is a relative path, append tile dir
					if (!Path.IsPathRooted(filename))
						filename = Globals.tileDir + filename;

					// Bail if file doesn't exist
					if (!File.Exists(filename))
						throw new FileNotFoundException(filename + " not found", filename);

					// Load source image
					Bitmap srcImage = new Bitmap(filename);

					// Create tile and Graphics object to draw on it
					_image = new Bitmap(tileSize, tileSize);
					Graphics graphics = Graphics.FromImage(_image);

					// Set source and destination dimensions
					Rectangle srcRect = new Rectangle(xOffset * tileSize, yOffset * tileSize, tileSize, tileSize);
					Rectangle destRect = new Rectangle(0, 0, tileSize, tileSize);

					// Copy from source image onto dest image
					graphics.DrawImage(srcImage, destRect, srcRect, GraphicsUnit.Pixel);

					// Set transparency color
					Color transparent = Color.Magenta;
					try
					{
						if (transColor != null && transColor != "")
							transparent = Color.FromArgb(Convert.ToInt32(transColor, 16));
					}
					catch { }
					_image.MakeTransparent(transparent);

					return _image;
				}
				catch { throw; }
			}
		}

		public CTile() { }

		public CTile(ushort id, string name, string filename, int xOffset, int yOffset)
		{
			this.id = id;
			this.name = name;
			this.filename = filename;
			this.xOffset = xOffset;
			this.yOffset = yOffset;
		}

		public override string ToString()
		{
			return name;
		}

		#region ICloneable Members

		public object Clone()
		{
			CTile newTile = new CTile(id, name, filename, xOffset, yOffset);
			newTile._image = (Bitmap)image.Clone();

			return newTile;
		}

		#endregion
	}
}
