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
	/// Represents a monster region group.
	/// </summary>
	[XmlRoot("monsterRegionGroup")]
	public class CMonsterRegionGroup : ICloneable
	{
		/// <summary>
		/// Monster region group file format version.
		/// </summary>
		[XmlAttribute("version")]
		public int version { get; set; }

		/// <summary>
		/// Id number of the region group.
		/// </summary>
		[XmlAttribute("id")]
		public int id { get; set; }

		/// <summary>
		/// Internal name of region group.
		/// </summary>
		[XmlAttribute("name")]
		public string name { get; set; }

		/// <summary>
		/// Array of monster regions.
		/// </summary>
		[XmlElement("monsterRegion")]
		public CMonsterRegion[] monsterRegions { get; set; }

		public CMonsterRegionGroup() { }

		public override string ToString()
		{
			return name;
		}

		#region ICloneable Members

		public object Clone()
		{
			CMonsterRegionGroup newRegionGroup = new CMonsterRegionGroup();
			newRegionGroup.version = version;
			newRegionGroup.id = id;
			newRegionGroup.name = name;

			return newRegionGroup;
		}

		#endregion
	}

	/// <summary>
	/// Singleton class encapsulating all monster region groups.
	/// </summary>
	public class MonsterRegionGroups : IEnumerable<CMonsterRegionGroup>
	{
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static MonsterRegionGroups singleton;

		/// <summary>
		/// Dictionary that maps ids to monster region groups.
		/// </summary>
		private Dictionary<int, CMonsterRegionGroup> regionGroups = new Dictionary<int, CMonsterRegionGroup>();

		/// <summary>
		/// Private constructor that loads all monster region groups.
		/// </summary>
		private MonsterRegionGroups()
		{
			try
			{
				XmlTextReader reader = new XmlTextReader(Globals.monsterRegionDir + "monsterregiongroups.xml");
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element && reader.Name == "monsterRegionGroup")
					{
						int id = Convert.ToInt32(reader.GetAttribute("id"));
						string name = reader.GetAttribute("name");

						XmlSerializer serializer = new XmlSerializer(typeof(CMonsterRegionGroup));
						StreamReader regionReader = new StreamReader(Globals.monsterRegionDir + name + ".xml");

						CMonsterRegionGroup newRegionGroup = (CMonsterRegionGroup)serializer.Deserialize(regionReader);

						if (newRegionGroup.id != id)
							throw new Exception(string.Format("The region group ids don't match. {0} != {1}", newRegionGroup.id, id));
						if (newRegionGroup.name != name)
							throw new Exception(string.Format("The region group names don't match. {0} != {1}", newRegionGroup.name, name));

						regionGroups.Add(id, newRegionGroup);
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
		public static MonsterRegionGroups instance
		{
			get
			{
				if (singleton == null)
					singleton = new MonsterRegionGroups();
				return singleton;
			}
		}

		/// <summary>
		/// Indexer to get a monster region group by id.
		/// </summary>
		/// <param name="id">Id of monster region group to get.</param>
		/// <returns>Monster region group or null.</returns>
		public CMonsterRegionGroup this[int id]
		{
			get
			{
				if (regionGroups.ContainsKey(id))
					return regionGroups[id];
				else
					return null;
			}
		}

		#region IEnumerable<CMonsterRegionGroup> Members

		IEnumerator<CMonsterRegionGroup> IEnumerable<CMonsterRegionGroup>.GetEnumerator()
		{
			return regionGroups.Values.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return regionGroups.Values.GetEnumerator();
		}

		#endregion
	}
}
