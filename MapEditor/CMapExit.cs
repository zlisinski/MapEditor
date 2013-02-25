using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MapEditor
{
	/// <summary>
	/// Represents an exit location on the map.
	/// This points to a CMapEntrance on another map.
	/// </summary>
	public class CMapExit : ICloneable
	{
		/// <summary>
		/// The UUID of the map to jump to.
		/// </summary>
		public Guid mapUuid;

		/// <summary>
		/// The entrance id in the map to jump to.
		/// </summary>
		public int mapEntranceId;

		/// <summary>
		/// The X location of the exit. 
		/// </summary>
		public int tileX;

		/// <summary>
		/// The Y location of the exit. 
		/// </summary>
		public int tileY;

		/// <summary>
		/// Creates an exit with the provided values.
		/// </summary>
		/// <param name="uuid">The UUID of the map the entrance is located on</param>
		/// <param name="mapEntranceId">The id of the entrance in the map</param>
		/// <param name="x">The X location of the exit</param>
		/// <param name="y">The Y location of the exit</param>
		public CMapExit(Guid uuid, int mapEntranceId, int x, int y)
		{
			this.mapUuid = uuid;
			this.mapEntranceId = mapEntranceId;
			this.tileX = x;
			this.tileY = y;
		}

		/// <summary>
		/// Creates an exit by loading from the provided reader
		/// </summary>
		/// <param name="reader">The reader to load from</param>
		public CMapExit(BinaryReader reader)
		{
			try
			{
				load(reader);
			}
			catch { throw; }
		}

		/// <summary>
		/// Loads the exit from the provided reader
		/// </summary>
		/// <param name="reader">The reader to load from</param>
		public void load(BinaryReader reader)
		{
			try
			{
				mapUuid = new Guid(reader.ReadBytes(16));
				//mapUuid = new Guid("1A31EC2F34338E4DBC0F2BF5BFB70ECF"); //overworld1.map
				//mapUuid = new Guid("35D873DCB462C94E915DD39C310397DB"); //overworld2.map
				mapEntranceId = reader.ReadInt32();
				tileX = reader.ReadInt32();
				tileY = reader.ReadInt32();
			}
			catch { throw; }
		}

		/// <summary>
		/// Saves the exit to the provided writer
		/// </summary>
		/// <param name="writer">The writer to save to</param>
		public void save(BinaryWriter writer)
		{
			writer.Write(mapUuid.ToByteArray());
			writer.Write(mapEntranceId);
			writer.Write(tileX);
			writer.Write(tileY);
		}

		#region ICloneable Members

		public object Clone()
		{
			CMapExit newExit = new CMapExit(mapUuid, mapEntranceId, tileX, tileY);

			return newExit;
		}

		#endregion
	}
}
