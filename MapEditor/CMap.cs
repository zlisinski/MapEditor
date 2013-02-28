using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MapEditor
{
	/// <summary>
	/// Represents a map
	/// </summary>
	public class CMap : ICloneable
	{
		/// <summary>
		/// The latest map format version.
		/// All maps will be converted to this version when saving.
		/// </summary>
		public static readonly int latestVersion = 3;

		/// <summary>
		/// Map file format version.
		/// </summary>
		public int version { get; protected set; }

		/// <summary>
		/// The UUID of the map.
		/// </summary>
		public Guid uuid { get; protected set; }

		/// <summary>
		/// Internal map name.
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Width of the map in tiles.
		/// </summary>
		public int width { get; protected set; }

		/// <summary>
		/// Height of the map in tiles.
		/// </summary>
		public int height { get; protected set; }

		/// <summary>
		/// Tileset used by map.
		/// </summary>
		public CTileSet tileSet { get; protected set; }

		/// <summary>
		/// MonsterRegion used by map.
		/// </summary>
		public CMonsterRegion monsterRegion { get; protected set; }

		/// <summary>
		/// Entrance tiles in the map.
		/// </summary>
		public Dictionary<int, CMapEntrance> entrances { get; set; }

		/// <summary>
		/// Exit tiles in the map.
		/// </summary>
		public List<CMapExit> exits { get; set; }

		/// <summary>
		/// Two dimensional array of cells in the map.
		/// </summary>
		public CMapCell[,] cells { get; set; }

		/// <summary>
		/// Gets the CMapEntrance located at x,y or null if no entrance exists at that position.
		/// </summary>
		/// <param name="x">The x position in tiles.</param>
		/// <param name="y">The y position in tiles.</param>
		/// <returns>The entrance at x,y or null.</returns>
		public CMapEntrance getEntranceAt(int x, int y)
		{
			foreach (CMapEntrance entrance in entrances.Values)
				if (entrance.tileX == x && entrance.tileY == y)
					return entrance;

			return null;
		}

		/// <summary>
		/// Gets the CMapExit located at x,y or null if no exit exists at that position.
		/// </summary>
		/// <param name="x">The x position in tiles.</param>
		/// <param name="y">The y position in tiles.</param>
		/// <returns>The exit at x,y or null.</returns>
		public CMapExit getExitAt(int x, int y)
		{
			foreach (CMapExit exit in exits)
				if (exit.tileX == x && exit.tileY == y)
					return exit;

			return null;
		}

		protected CMap() { }

		/// <summary>
		/// Creates a new map instance with the provided information.
		/// </summary>
		/// <param name="name">Name of map.</param>
		/// <param name="width">Width of map.</param>
		/// <param name="height">Height of map.</param>
		/// <param name="tileSet">Tileset of map.</param>
		public CMap(string name, int width, int height, CTileSet tileSet, CMonsterRegion monsterRegion)
		{
			this.version = CMap.latestVersion;
			this.uuid = Guid.NewGuid();
			this.name = name;
			this.width = width;
			this.height = height;
			this.tileSet = tileSet;
			this.monsterRegion = monsterRegion;
			this.entrances = new Dictionary<int, CMapEntrance>();
			this.exits = new List<CMapExit>();
			
			cells = new CMapCell[width, height];

			for (int x = 0; x < width; x++)
				for (int y = 0; y < height; y++)
					cells[x, y] = new CMapCell();
		}

		/// <summary>
		/// Creates a new map instance and loads from a file.
		/// </summary>
		/// <param name="filename">The fielename to load the map from.</param>
		public CMap(string filename)
		{
			try
			{
				load(filename);
			}
			catch { throw; }
		}

		/// <summary>
		/// Loads the map from a file.
		/// </summary>
		/// <param name="filename">The filename to load the map from.</param>
		public void load(string filename)
		{
			try
			{
				FileStream fileStream = new FileStream(filename, FileMode.Open);
				BinaryReader reader = new BinaryReader(fileStream, Encoding.UTF8);

				version = reader.ReadInt32();

				switch (version)
				{
					case 1:
						loadVersion1(reader);
						break;
					case 2:
						loadVersion2(reader);
						break;
					case 3:
						loadVersion3(reader);
						break;
					default:
						throw new Exception(string.Format("Map version '{0}' is invalid", version));
				}

				version = CMap.latestVersion;

				reader.Close();
				fileStream.Close();
			}
			catch { throw; }
		}

		public override string ToString()
		{
			return name;
		}

		protected void loadVersion1(BinaryReader reader)
		{
			try
			{
				uuid = Guid.NewGuid(); // Version 1 doesnt have uuid
				name = readName(reader);
				width = readWidth(reader);
				height = readHeight(reader);
				tileSet = readTileSet(reader);
				monsterRegion = new CMonsterRegion(); // Version 1 doesn't have a monster region
				entrances = new Dictionary<int, CMapEntrance>(); // Version 1 doesn't have map entrances
				exits = new List<CMapExit>(); // Version 1 doesn't have map exits
				cells = readCells(reader);
			}
			catch { throw; }
		}

		protected void loadVersion2(BinaryReader reader)
		{
			try
			{
				uuid = Guid.NewGuid(); // Version 2 doesnt have uuid
				name = readName(reader);
				width = readWidth(reader);
				height = readHeight(reader);
				tileSet = readTileSet(reader);
				monsterRegion = readMonsterRegion(reader);
				entrances = new Dictionary<int, CMapEntrance>(); // Version 2 doesn't have map entrances
				entrances.Add(1, new CMapEntrance(1, 12, 7));
				exits = new List<CMapExit>(); // Version 2 doesn't have map exits
				cells = readCells(reader);
			}
			catch { throw; }
		}

		protected void loadVersion3(BinaryReader reader)
		{
			try
			{
				uuid = readUuid(reader);
				name = readName(reader);
				width = readWidth(reader);
				height = readHeight(reader);
				tileSet = readTileSet(reader);
				monsterRegion = readMonsterRegion(reader);
				entrances = readEntrances(reader);
				exits = readExits(reader);
				cells = readCells(reader);
			}
			catch { throw; }
		}

		/// <summary>
		/// Saves the map to a file.
		/// </summary>
		/// <param name="filename">The filename to save to map to.</param>
		public void save(string filename)
		{
			try
			{
				if (!entrances.ContainsKey(0))
					throw new Exception("Map does not contain an entrance with an id of 0");

				FileStream fileStream = new FileStream(filename, FileMode.Create);
				BinaryWriter writer = new BinaryWriter(fileStream, Encoding.UTF8);

				writer.Write(version);
				writer.Write(uuid.ToByteArray());
				writer.Write(name);
				writer.Write(width);
				writer.Write(height);
				writer.Write(tileSet.id);
				writer.Write(monsterRegion.id);

				writer.Write(entrances.Count);
				foreach (int i in entrances.Keys)
					entrances[i].save(writer);

				writer.Write(exits.Count);
				foreach (CMapExit exit in exits)
					exit.save(writer);

				for (int x = 0; x < width; x++)
					for (int y = 0; y < height; y++)
						cells[x, y].save(writer);

				writer.Close();
				fileStream.Close();
			}
			catch { throw; }
		}

		#region File Reader Functions
		protected Guid readUuid(BinaryReader reader)
		{
			Guid newUuid = new Guid(reader.ReadBytes(16));

			return newUuid;
		}

		protected string readName(BinaryReader reader)
		{
			string newName = reader.ReadString();

			return newName;
		}

		protected int readWidth(BinaryReader reader)
		{
			int newWidth = reader.ReadInt32();

			return newWidth;
		}

		protected int readHeight(BinaryReader reader)
		{
			int newHeight = reader.ReadInt32();

			return newHeight;
		}

		protected CTileSet readTileSet(BinaryReader reader)
		{
			int tileSetId = reader.ReadInt32();

			CTileSet newTileSet = TileSets.instance[tileSetId];
			
			if (newTileSet == null)
				throw new Exception(string.Format("Couldn't find tileset with id {0}", tileSetId));
			
			return newTileSet;
		}

		protected CMonsterRegion readMonsterRegion(BinaryReader reader)
		{
			int monsterRegionId = reader.ReadInt32();

			CMonsterRegion newMonsterRegion = new CMonsterRegion();
			
			return newMonsterRegion;
		}

		protected Dictionary<int, CMapEntrance> readEntrances(BinaryReader reader)
		{
			int entranceCount = reader.ReadInt32();

			Dictionary<int, CMapEntrance> newEntrances = new Dictionary<int, CMapEntrance>(entranceCount);
			
			for (int i = 0; i < entranceCount; i++)
			{
				CMapEntrance newEnt = new CMapEntrance(reader);
				newEntrances[newEnt.id] = newEnt;
			}
			
			return newEntrances;
		}

		protected List<CMapExit> readExits(BinaryReader reader)
		{
			int exitCount = reader.ReadInt32();

			List<CMapExit> newExits = new List<CMapExit>(exitCount);

			for (int i = 0; i < exitCount; i++)
				newExits.Add(new CMapExit(reader));

			return newExits;
		}

		protected CMapCell[,] readCells(BinaryReader reader)
		{
			CMapCell[,] newCells = new CMapCell[width, height];

			for (int x = 0; x < width; x++)
				for (int y = 0; y < height; y++)
					newCells[x, y] = new CMapCell(reader, version);

			return newCells;
		}
		#endregion

		#region ICloneable Members

		public object Clone()
		{
			CMap newMap = new CMap();
			newMap.version = version;
			newMap.name = name;
			newMap.width = width;
			newMap.height = height;
			newMap.tileSet = (CTileSet)tileSet.Clone();
			newMap.monsterRegion = (CMonsterRegion)monsterRegion.Clone();
			
			newMap.entrances = new Dictionary<int, CMapEntrance>(entrances.Count);
			foreach (KeyValuePair<int, CMapEntrance> entry in entrances)
				newMap.entrances.Add(entry.Key, (CMapEntrance)entry.Value.Clone());

			newMap.exits = new List<CMapExit>(exits.Count);
			foreach (CMapExit exit in exits)
				newMap.exits.Add((CMapExit)exit.Clone());

			newMap.cells = new CMapCell[width, height];
			for (int x = 0; x < width; x++)
				for (int y = 0; y < height; y++)
					newMap.cells[x, y] = (CMapCell)cells[x, y].Clone();

			return newMap;
		}

		#endregion
	}
}
