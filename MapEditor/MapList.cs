using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Collections;

namespace MapEditor
{
	/// <summary>
	/// Holds basic info about all maps that may be needed by other maps.
	/// </summary>
	public class MapList
	{
		/// <summary>
		/// The data from each map. I can see this growing to be everything in a map except for the cell data, but I'll 
		/// refactor when it gets to that point.
		/// </summary>
		private class MapData
		{
			public Guid uuid;
			public string filename;
			public string name;
			public Dictionary<int, CMapEntrance> entrances;
			public List<CMapExit> exits;

			public MapData(Guid uuid, string filename, string name, Dictionary<int, CMapEntrance> entrances, List<CMapExit> exits)
			{
				this.uuid = uuid;
				this.filename = Path.GetFileName(filename);
				this.name = name;

				// Clone entances
				this.entrances = new Dictionary<int, CMapEntrance>(entrances.Count);
				foreach (KeyValuePair<int, CMapEntrance> entry in entrances)
					this.entrances.Add(entry.Key, (CMapEntrance)entry.Value.Clone());

				// Clone exits
				this.exits = new List<CMapExit>(exits.Count);
				foreach (CMapExit exit in exits)
					this.exits.Add((CMapExit)exit.Clone());
			}
		}

		/// <summary>
		/// Dictionary of uuid to mapdata.
		/// </summary>
		private static Dictionary<Guid, MapData> mapData = null;

		/// <summary>
		/// Returns an array of tuples of uuid and map name.
		/// </summary>
		public static Tuple<Guid, string>[] mapNames
		{
			get
			{
				if (mapData == null)
					refreshData();

				List<Tuple<Guid, string>> tuples = new List<Tuple<Guid, string>>();

				foreach (Guid uuid in mapData.Keys)
					tuples.Add(Tuple.Create(uuid, mapData[uuid].name));

				return tuples.ToArray();
			}
		}

		/// <summary>
		/// Reads data from all maps in $MapDir, then calls writeXmp() to write data to $MapDir/maps.xml.
		/// This should be called after every map save.
		/// Eventually a map save will update only itself, instead of reading all maps each time one is saved.
		/// Currently reads the entire map when I only care about all data except the cell data.
		/// A later version of the map code will have some way to load map data without having to read cell data.
		/// </summary>
		public static void refreshData()
		{
			Dictionary<Guid, MapData> newMapData = new Dictionary<Guid, MapData>();

			// Get a list of all map filenames
			string[] filenames = Directory.GetFiles(Globals.mapDir, "*.map");

			// Read each map file found
			foreach (string filename in filenames)
			{
				try
				{
					CMap map = new CMap(filename);

					MapData data = new MapData(map.uuid, map.filename, map.name, map.entrances, map.exits);

					newMapData[map.uuid] = data;
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			}

			mapData = newMapData;

			// Write xml file
			writeXml();
		}

		/// <summary>
		/// Writes the map data to "$MapDir/maps.xml"
		/// I'm using XmlTextWriter because I'm experimenting with other ways to write xml. 
		/// I think I'll use serialization if this gets any bigger, as this is a mess.
		/// </summary>
		public static void writeXml()
		{
			XmlTextWriter writer = new XmlTextWriter(Globals.mapDir + "maps.xml", Encoding.UTF8);

			writer.WriteStartDocument();
			writer.WriteWhitespace("\n");
			writer.WriteStartElement("maps");
			writer.WriteWhitespace("\n");

			foreach (Guid uuid in mapData.Keys)
			{
				MapData data = mapData[uuid];

				writer.WriteWhitespace("\t");
				writer.WriteStartElement("map");
				writer.WriteAttributeString("uuid", uuid.ToString());
				writer.WriteAttributeString("name", data.name);
				writer.WriteAttributeString("filename", data.filename);
				writer.WriteWhitespace("\n\t\t");
				writer.WriteStartElement("entrances");
				writer.WriteWhitespace("\n");

				List<int> keys = data.entrances.Keys.ToList();
				keys.Sort();
				foreach (int id in keys)
				{
					writer.WriteWhitespace("\t\t\t");
					writer.WriteStartElement("entrance");
					writer.WriteAttributeString("id", id.ToString());
					writer.WriteAttributeString("x", data.entrances[id].tileX.ToString());
					writer.WriteAttributeString("y", data.entrances[id].tileY.ToString());
					writer.WriteEndElement();
					writer.WriteWhitespace("\n");
				}

				writer.WriteWhitespace("\t\t");
				writer.WriteEndElement();
				writer.WriteWhitespace("\n\t\t");
				writer.WriteStartElement("exits");
				writer.WriteWhitespace("\n");

				foreach (CMapExit exit in data.exits)
				{
					writer.WriteWhitespace("\t\t\t");
					writer.WriteStartElement("exit");
					writer.WriteAttributeString("map", exit.mapUuid.ToString());
					writer.WriteAttributeString("entance", exit.mapEntranceId.ToString());
					writer.WriteAttributeString("x", exit.tileX.ToString());
					writer.WriteAttributeString("y", exit.tileY.ToString());
					writer.WriteEndElement();
					writer.WriteWhitespace("\n");
				}

				writer.WriteWhitespace("\t\t");
				writer.WriteEndElement();
				writer.WriteWhitespace("\n\t");
				writer.WriteEndElement();
				writer.WriteWhitespace("\n");
			}

			writer.WriteEndElement();
			writer.WriteEndDocument();

			writer.Close();
		}
	}
}
