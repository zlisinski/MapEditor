using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MapEditor
{
	public class CMonsterRegion
	{
		/// <summary>
		/// The id of this monster region.
		/// </summary>
		[XmlAttribute("id")]
		public uint id { get; set; }

		/// <summary>
		/// The name of this monster region.
		/// </summary>
		[XmlAttribute("name")]
		public string name { get; set; }

		public CMonsterRegion() { }

		public override string ToString()
		{
			return name;
		}
	}
}
