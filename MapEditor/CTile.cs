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
	public class CTile
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
		/// X offset of the image within a sprite file. NYI.
		/// </summary>
		[XmlAttribute("xOffset")]
		public int xOffset { get; set; }

		/// <summary>
		/// Y offset of the image within a sprite file. NYI.
		/// </summary>
		[XmlAttribute("yOffset")]
		public int yOffset { get; set; }

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
					_image.MakeTransparent(Color.Magenta);

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
	}
}
