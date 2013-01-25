using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MapEditor
{
	/// <summary>
	/// Represents a map tileset.
	/// </summary>
	[XmlRoot("tileSet")]
	public class CTileSet
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
				string[] filenames = Directory.GetFiles(Globals.tileSetDir, "*.xml");

				foreach (string filename in filenames)
				{
					CTileSet newTileSet = null;
					XmlSerializer serializer = new XmlSerializer(typeof(CTileSet));
					StreamReader reader = new StreamReader(filename);
					
					try
					{
						newTileSet = (CTileSet)serializer.Deserialize(reader);
						tileSets.Add(newTileSet.id, newTileSet);
						//logString("Loaded " + filename + "\n\n");
					}
					catch (InvalidOperationException)
					{
						//logString("Error loading " + filename);
					}

					reader.Close();
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
