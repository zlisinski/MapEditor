using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace MapEditor
{
	public class Globals
	{
		public static readonly string baseDir;
		public static readonly string imageDir;
		public static readonly string battleBackgroundDir;
		public static readonly string tileDir;
		public static readonly string dataDir;
		public static readonly string tileSetDir;
		public static readonly string mapDir;

		public const string version = "1.0.0";

		public const uint layerCount = 4;

		public const int tileSize = 32;

		public static readonly Random rand = new Random();

		static Globals()
		{
			try
			{
				string configFilename = "config.xml";
				string configPath = Directory.GetCurrentDirectory();

				// Search up the directory tree for the config file
				while (!File.Exists(configPath + "\\" + configFilename))
				{
					DirectoryInfo dir = Directory.GetParent(configPath);
					if (dir == null)
						throw new FileNotFoundException(string.Format("Cannot find {0} file", configFilename));
					configPath = dir.FullName;
				}

				// Read the config file
				XmlTextReader reader = new XmlTextReader(configPath + "\\" + configFilename);
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element && reader.Name == "config")
					{
						baseDir = reader.GetAttribute("baseDir");
						imageDir = reader.GetAttribute("imageDir");
						battleBackgroundDir = reader.GetAttribute("battleBackgroundDir");
						tileDir = reader.GetAttribute("tileDir");
						dataDir = reader.GetAttribute("dataDir");
						tileSetDir = reader.GetAttribute("tileSetDir");
						mapDir = reader.GetAttribute("mapDir");
					}
				}

				// Make sure we got all the values
				if (baseDir == null)
					throw new Exception("Error reading baseDir from config file");
				if (imageDir == null)
					throw new Exception("Error reading imageDir from config file");
				if (battleBackgroundDir == null)
					throw new Exception("Error reading battleBackgroundDir from config file");
				if (tileDir == null)
					throw new Exception("Error reading tileDir from config file");
				if (dataDir == null)
					throw new Exception("Error reading dataDir from config file");
				if (tileSetDir == null)
					throw new Exception("Error reading tileSetDir from config file");
				if (mapDir == null)
					throw new Exception("Error reading mapDir from config file");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Application.Exit();
			}
		}
	}
}
