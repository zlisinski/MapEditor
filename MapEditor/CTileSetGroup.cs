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
	public class CTileSetGroup
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
	}
}
