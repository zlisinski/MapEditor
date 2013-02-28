using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace MapEditor
{
	/// <summary>
	/// Represents a monster region.
	/// </summary>
	[XmlRoot("monsterRegion")]
	public class CMonsterRegion : ICloneable
	{
		/// <summary>
		/// Monster region file format version.
		/// </summary>
		[XmlAttribute("version")]
		public int version { get; set; }

		/// <summary>
		/// Id number of the region.
		/// </summary>
		[XmlAttribute("id")]
		public int id { get; set; }

		/// <summary>
		/// Internal name of region.
		/// </summary>
		[XmlAttribute("name")]
		public string name { get; set; }

		public CMonsterRegion() { }

		public override string ToString()
		{
			return name;
		}

		#region ICloneable Members

		public object Clone()
		{
			CMonsterRegion newRegion = new CMonsterRegion();
			newRegion.version = version;
			newRegion.id = id;
			newRegion.name = name;

			return newRegion;
		}

		#endregion
	}

	/// <summary>
	/// Singleton class encapsulating all monster regions.
	/// </summary>
	public class MonsterRegions : IEnumerable<CMonsterRegion>
	{
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static MonsterRegions singleton;

		/// <summary>
		/// Dictionary that maps ids to monster regions.
		/// </summary>
		private Dictionary<int, CMonsterRegion> regions = new Dictionary<int, CMonsterRegion>();

		/// <summary>
		/// Private constructor that loads all monster regions.
		/// </summary>
		private MonsterRegions()
		{
			try
			{
				XmlTextReader reader = new XmlTextReader(Globals.monsterRegionDir + "monsterregions.xml");
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element && reader.Name == "monsterRegion")
					{
						int id = Convert.ToInt32(reader.GetAttribute("id"));
						string name = reader.GetAttribute("name");

						XmlSerializer serializer = new XmlSerializer(typeof(CMonsterRegion));
						StreamReader regionReader = new StreamReader(Globals.monsterRegionDir + name + ".xml");

						CMonsterRegion newRegion = (CMonsterRegion)serializer.Deserialize(regionReader);

						if (newRegion.id != id)
							throw new Exception(string.Format("The region ids don't match. {0} != {1}", newRegion.id, id));
						if (newRegion.name != name)
							throw new Exception(string.Format("The region names don't match. {0} != {1}", newRegion.name, name));

						regions.Add(id, newRegion);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		/// <summary>
		/// Singleton instance accessor
		/// </summary>
		public static MonsterRegions instance
		{
			get
			{
				if (singleton == null)
					singleton = new MonsterRegions();
				return singleton;
			}
		}

		/// <summary>
		/// Indexer to get a monster region by id.
		/// </summary>
		/// <param name="id">Id of monster region to get.</param>
		/// <returns>Monster region or null.</returns>
		public CMonsterRegion this[int id]
		{
			get
			{
				if (regions.ContainsKey(id))
					return regions[id];
				else
					return null;
			}
		}

		#region IEnumerable<CMonsterRegion> Members

		IEnumerator<CMonsterRegion> IEnumerable<CMonsterRegion>.GetEnumerator()
		{
			return regions.Values.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return regions.Values.GetEnumerator();
		}

		#endregion
	}
}
