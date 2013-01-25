using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MapEditor
{
	public class CBattleBackground
	{
		[XmlAttributeAttribute("id")]
		public uint id { get; set; }

		[XmlAttribute("name")]
		public string name { get; set; }
		
		[XmlAttributeAttribute("filename")]
		public string filename { get; set; }

		public CBattleBackground() { }

		public override string ToString()
		{
			return name;
		}
	}
}
