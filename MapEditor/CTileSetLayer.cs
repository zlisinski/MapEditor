using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MapEditor
{
	/// <summary>
	/// Represents tiles of a single layer in a tile set.
	/// </summary>
	public class CTileSetLayer
	{
		/// <summary>
		/// The id of this layer.
		/// </summary>
		[XmlAttribute("id")]
		public uint id { get; set; }

		/// <summary>
		/// Array of tile groups in this layer.
		/// </summary>
		[XmlElement("group")]
		public CTileSetGroup[] groups { get; set; }

		/// <summary>
		/// Gets the tile with the provided tile id.
		/// </summary>
		/// <param name="id">Id of the tile to search for.</param>
		/// <returns>A tile or null if no tile with the id exists.</returns>
		public CTile getTileFromId(UInt16 id)
		{
			foreach (CTileSetGroup group in groups)
				foreach (CTile tile in group.tiles)
					if (tile.id == id)
						return tile;

			return null;
		}

		public CTileSetLayer() { }

		public override string  ToString()
		{
			return string.Format("Layer {0}", id);
		}
	}
}
