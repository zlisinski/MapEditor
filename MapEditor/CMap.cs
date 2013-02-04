﻿using System;
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
		/// Map file format version.
		/// </summary>
		public int version { get; protected set; }

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
		/// Two dimensional array of cells in the map.
		/// </summary>
		public CMapCell[,] cells { get; set; }

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
			this.version = 2;
			this.name = name;
			this.width = width;
			this.height = height;
			this.tileSet = tileSet;
			this.monsterRegion = monsterRegion;
			
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
				}

				version = 2;

				reader.Close();
				fileStream.Close();
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
				FileStream fileStream = new FileStream(filename, FileMode.Create);
				BinaryWriter writer = new BinaryWriter(fileStream, Encoding.UTF8);

				writer.Write(version);
				writer.Write(name);
				writer.Write(width);
				writer.Write(height);
				writer.Write(tileSet.id);
				writer.Write(monsterRegion.id);

				for (int x = 0; x < width; x++)
					for (int y = 0; y < height; y++)
						cells[x, y].save(writer);

				writer.Close();
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
				name = reader.ReadString();
				width = reader.ReadInt32();
				height = reader.ReadInt32();

				// Load tileset
				int tileSetId = reader.ReadInt32();
				tileSet = TileSets.instance[tileSetId];
				if (tileSet == null)
					throw new Exception(string.Format("Couldn't find tileset with id {0}", tileSetId));

				// Version 1 doesn't have a monster region
				monsterRegion = new CMonsterRegion();

				cells = new CMapCell[width, height];
				for (int x = 0; x < width; x++)
					for (int y = 0; y < height; y++)
						cells[x, y] = new CMapCell(reader, version);
			}
			catch { throw; }
		}

		protected void loadVersion2(BinaryReader reader)
		{
			try
			{
				name = reader.ReadString();
				width = reader.ReadInt32();
				height = reader.ReadInt32();

				// Load tileset
				int tileSetId = reader.ReadInt32();
				tileSet = TileSets.instance[tileSetId];
				if (tileSet == null)
					throw new Exception(string.Format("Couldn't find tileset with id {0}", tileSetId));

				// Load monster region
				int monsterRegionId = reader.ReadInt32();
				monsterRegion = new CMonsterRegion();

				cells = new CMapCell[width, height];
				for (int x = 0; x < width; x++)
					for (int y = 0; y < height; y++)
						cells[x, y] = new CMapCell(reader, version);
			}
			catch { throw; }
		}

		#region ICloneable Members

		public object Clone()
		{
			CMap newMap = new CMap();
			newMap.version = version;
			newMap.name = name;
			newMap.width = width;
			newMap.height = height;
			newMap.tileSet = (CTileSet)tileSet.Clone();
			newMap.cells = new CMapCell[width, height];
			for (int x = 0; x < width; x++)
				for (int y = 0; y < height; y++)
					newMap.cells[x, y] = (CMapCell)cells[x, y].Clone();

			return newMap;
		}

		#endregion
	}
}
