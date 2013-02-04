using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace MapEditor
{
	/// <summary>
	/// Represents a map tileset.
	/// </summary>
	[XmlRoot("tileSet")]
	public class CTileSet : ICloneable
	{
		/// <summary>
		/// Tile set file format version.
		/// </summary>
		[XmlAttribute("version")]
		public int version { get; set; }

		/// <summary>
		/// Id number of the tileset.
		/// </summary>
		[XmlAttribute("id")]
		public int id { get; set; }
		
		/// <summary>
		/// Internal name of tileset.
		/// </summary>
		[XmlAttribute("name")]
		public string name { get; set; }
		
		/// <summary>
		/// Array of battle background images.
		/// </summary>
		[XmlElement("battleBackground")]
		public CBattleBackground[] battleBackgrounds {get; set;}
		
		/// <summary>
		/// Array of tileset layers.
		/// </summary>
		[XmlElement("layer")]
		public CTileSetLayer[] layers { get; set; }

		public CTileSet() {}

		public override string ToString()
		{
			return name;
		}

		#region ICloneable Members

		public object Clone()
		{
			CTileSet newTileSet = new CTileSet();
			newTileSet.version = version;
			newTileSet.id = id;
			newTileSet.name = name;
			newTileSet.battleBackgrounds = battleBackgrounds.Select(x => (CBattleBackground)x.Clone()).ToArray();
			newTileSet.layers = layers.Select(x => (CTileSetLayer)x.Clone()).ToArray();

			return newTileSet;
		}

		#endregion
	}


	/// <summary>
	/// Singleton class encapsulating all tilesets.
	/// </summary>
	public class TileSets : IEnumerable<CTileSet>
	{
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static TileSets singleton;

		/// <summary>
		/// Dictionary that maps ids to tilesets.
		/// </summary>
		private Dictionary<int, CTileSet> tileSets = new Dictionary<int, CTileSet>();

		/// <summary>
		/// Private constructor that loads all tilesets.
		/// </summary>
		private TileSets()
		{
			try
			{
				XmlTextReader reader = new XmlTextReader(Globals.tileSetDir + "tilesets.xml");
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element && reader.Name == "tileSet")
					{
						int id = Convert.ToInt32(reader.GetAttribute("id"));
						string name = reader.GetAttribute("name");

						XmlSerializer serializer = new XmlSerializer(typeof(CTileSet));
						StreamReader tileSetReader = new StreamReader(Globals.tileSetDir + name + ".xml");

						CTileSet newTileSet = (CTileSet)serializer.Deserialize(tileSetReader);

						if (newTileSet.id != id)
							throw new Exception(string.Format("The tileset ids don't match. {0} != {1}", newTileSet.id, id));
						if (newTileSet.name != name)
							throw new Exception(string.Format("The tileset names don't match. {0} != {1}", newTileSet.name, name));

						tileSets.Add(id, newTileSet);
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// Singleton instance accessor
		/// </summary>
		public static TileSets instance
		{
			get
			{
				if (singleton == null)
					singleton = new TileSets();
				return singleton;
			}
		}

		/// <summary>
		/// Indexer to get a tileset by id.
		/// </summary>
		/// <param name="id">Id of tileset to get.</param>
		/// <returns>Tileset or null.</returns>
		public CTileSet this[int id]
		{
			get
			{
				if (tileSets.ContainsKey(id))
					return tileSets[id];
				else
					return null;
			}
		}

		#region IEnumerable<CTileSet> Members

		IEnumerator<CTileSet> IEnumerable<CTileSet>.GetEnumerator()
		{
			return tileSets.Values.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return tileSets.Values.GetEnumerator();
		}

		#endregion
	}
}
