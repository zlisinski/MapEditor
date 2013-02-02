using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MapEditor
{
	/// <summary>
	/// Represents a group of tiles within one layer
	/// </summary>
	public class CTileSetGroup : ICloneable
	{
		/// <summary>
		/// The name of the tile group.
		/// </summary>
		[XmlAttribute("name")]
		public string name { get; set; }
		
		/// <summary>
		/// The background used in battle mode by all tiles in this group.
		/// </summary>
		[XmlAttribute("battleBackground")]
		public uint battleBackgroundId { get; set; }
		
		/// <summary>
		/// Array of tiles in this group.
		/// </summary>
		[XmlElement("tile")]
		public CTile[] tiles { get; set; }

		public CTileSetGroup() { }

		#region ICloneable Members

		public object Clone()
		{
			CTileSetGroup newGroup = new CTileSetGroup();
			newGroup.name = name;
			newGroup.battleBackgroundId = battleBackgroundId;
			newGroup.tiles = tiles.Select(x => (CTile)x.Clone()).ToArray();

			return newGroup;
		}

		#endregion
	}
}
