using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;
using System.Windows.Forms;

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
		public uint xOffset { get; set; }

		/// <summary>
		/// Y offset of the image within a sprite file. NYI.
		/// </summary>
		[XmlAttribute("yOffset")]
		public uint yOffset { get; set; }

		/// <summary>
		/// Bitmap image.
		/// </summary>
		private Bitmap _image;
		public Bitmap image
		{
			get
			{
				if (_image == null)
				{
					_image = new Bitmap(Globals.tileDir + filename);
					_image.MakeTransparent(Color.Magenta);
				}
				return _image;
			}
		}

		public CTile() { }

		public override string ToString()
		{
			return name;
		}
	}
}
