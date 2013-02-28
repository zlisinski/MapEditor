using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MapEditor
{
	/// <summary>
	/// Represents a starting location on the map.
	/// A CMapExit on another map points to this entrance.
	/// </summary>
	public class CMapEntrance : ICloneable
	{
		/// <summary>
		/// The id of the entrance.
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// The X location of the entrance.
		/// </summary>
		public int tileX { get; set; }

		/// <summary>
		/// The Y location of the entrance.
		/// </summary>
		public int tileY { get; set; }

		/// <summary>
		/// Creates an entrance with the provided values.
		/// </summary>
		/// <param name="id">The id on the entrance</param>
		/// <param name="x">The X location of the entrance</param>
		/// <param name="y">The Y location of the entrance</param>
		public CMapEntrance(int id, int x, int y)
		{
			this.id = id;
			this.tileX = x;
			this.tileY = y;
		}

		/// <summary>
		/// Creates an entrance by loading from the provided reader
		/// </summary>
		/// <param name="reader">The reader to load from</param>
		public CMapEntrance(BinaryReader reader)
		{
			try
			{
				load(reader);
			}
			catch { throw; }
		}

		/// <summary>
		/// Loads the entrance from the provided reader
		/// </summary>
		/// <param name="reader">The reader to load from</param>
		public void load(BinaryReader reader)
		{
			try
			{
				id = reader.ReadInt32();
				tileX = reader.ReadInt32();
				tileY = reader.ReadInt32();
			}
			catch { throw; }
		}

		/// <summary>
		/// Saves the entrance to the provided writer
		/// </summary>
		/// <param name="writer">The writer to save to</param>
		public void save(BinaryWriter writer)
		{
			writer.Write(id);
			writer.Write(tileX);
			writer.Write(tileY);
		}

		#region ICloneable Members

		public object Clone()
		{
			CMapEntrance newEnt = new CMapEntrance(id, tileX, tileY);

			return newEnt;
		}

		#endregion
	}
}