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
		/// The map's filename.
		/// </summary>
		public string filename { get; protected set; }

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
		/// <param name="monsterRegion">MonsterRegion of map.</param>
		public CMap(string name, int width, int height, CTileSet tileSet, CMonsterRegion monsterRegion)
		{
			this.filename = "";
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
		protected void load(string filename)
		{
			try
			{
				this.filename = filename;

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

		/// <summary>
		/// Loads a version 1 map.
		/// </summary>
		/// <param name="reader">The BinaryReader to read from.</param>
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

		/// <summary>
		/// Loads a version 2 map.
		/// Version 2 added a MonsterRegion to the map, and a monsterRegionId to each cell.
		/// </summary>
		/// <param name="reader">The BinaryReader to read from.</param>
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
				exits = new List<CMapExit>(); // Version 2 doesn't have map exits
				cells = readCells(reader);
			}
			catch { throw; }
		}

		/// <summary>
		/// Loads a version 3 map.
		/// Version 3 added a uuid, entrances, and exits to the map.
		/// </summary>
		/// <param name="reader">The BinaryReader to read from.</param>
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
		/// <param name="newFilename">The filename to save to map to.</param>
		public void save(string newFilename, DYesNoPrompt dYesNoPrompt = null)
		{
			// Save original uuid in case we change it and the save fails
			Guid originalUuid = this.uuid;

			// Create a temp file to save the map to. If the save succeeds, the temp file will be moved to the path in newFilename
			string tmpFilename = Path.GetTempFileName();

			try
			{
				// Every map must have an entrance with an id of 0
				if (!entrances.ContainsKey(0))
					throw new Exception("Map does not contain an entrance with an id of 0");

				// Prompt to generate a new uuid if this is a Save As
				if (newFilename != this.filename && this.filename != "" && dYesNoPrompt != null)
				{
					string caption = "Change UUID";
					string message = "You are saving a copy of this map with another filename.\n\n" +
						"Do you want to generate a new UUID?";
					if (dYesNoPrompt(message, caption) == true)
						this.uuid = Guid.NewGuid();
				}

				FileStream fileStream = new FileStream(tmpFilename, FileMode.Create);
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

				// Move temp file to newFilename
				File.Copy(tmpFilename, newFilename, true);
				File.Delete(tmpFilename);

				// Map saved successfully, update filename
				this.filename = newFilename;
			}
			catch
			{
				// Restore the uuid in case we changed it and the save failed
				this.uuid = originalUuid;

				// Delete temp file
				File.Delete(tmpFilename);

				throw;
			}
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
			newMap.filename = filename;
			newMap.version = version;
			newMap.uuid = uuid;
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
