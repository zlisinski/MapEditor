using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MapEditor
{
	/// <summary>
	/// Determines whether the player can walk on a cell, and how fast they can travel.
	/// </summary>
	public enum EWalkType
	{
		NonWolk, NormalWalk, SlowWalk, FastWalk
	}

	/// <summary>
	/// Represents one cell(stack of tiles and walk type) on the map.
	/// </summary>
	public class CMapCell
	{
		/// <summary>
		/// Array of tiles layers.
		/// </summary>
		public ushort[] tiles = new ushort[Globals.layerCount];

		/// <summary>
		/// Walk type of cell.
		/// </summary>
		public EWalkType walkType;

		/// <summary>
		/// Creates new cell instance with default values.
		/// </summary>
		public CMapCell()
		{
			tiles[0] = 1;
			//tiles[1] = (Globals.rand.Next() % 3 == 0) ? (ushort)1 : (ushort)0;
			for (int i = 1; i < Globals.layerCount; i++)
				tiles[i] = 0;
			
			walkType = EWalkType.NormalWalk;
		}

		/// <summary>
		/// Creates a new cell instance with the provided values.
		/// </summary>
		/// <param name="tiles">Array of tiles.</param>
		/// <param name="walkType"></param>
		public CMapCell(ushort[] tiles, EWalkType cellType)
		{
			this.tiles = tiles;
			this.walkType = cellType;
		}

		/// <summary>
		/// Creates a new cell instance and loads from a file
		/// </summary>
		/// <param name="reader">Reader linked to the file stream to load from.</param>
		public CMapCell(BinaryReader reader)
		{
			load(reader);
		}

		/// <summary>
		/// Loads the cell from the provided file.
		/// </summary>
		/// <param name="reader">Reader linked to the file stream to load from.</param>
		public void load(BinaryReader reader)
		{
			try
			{
				for (int i = 0; i < tiles.Length; i++)
					tiles[i] = reader.ReadUInt16();

				walkType = (EWalkType)reader.ReadUInt16();
			}
			catch { throw; }
		}

		/// <summary>
		/// Saves the cell to the provided file.
		/// </summary>
		/// <param name="writer">Writer linked to the file stream to save to.</param>
		public void save(BinaryWriter writer)
		{
			try
			{
				for (int i = 0; i < tiles.Length; i++)
					writer.Write(tiles[i]);

				writer.Write((ushort)walkType);
			}
			catch { throw; }
		}
	}
}
