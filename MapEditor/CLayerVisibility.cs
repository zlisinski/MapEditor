using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
	class CLayerVisibility
	{
		public bool[] layersVisible;
		public bool walkLayerVisible;
		public bool entranceExitLayerVisible;

		public CLayerVisibility()
		{
			layersVisible = new bool[Globals.layerCount];
			for (int i = 0; i < layersVisible.Length; i++)
				layersVisible[i] = true;
			walkLayerVisible = true;
			entranceExitLayerVisible = true;
		}

		public CLayerVisibility(bool[] layersVisible, bool walkLayerVisible, bool entranceExitLayerVisible)
		{
			this.layersVisible = layersVisible.Select(x => x).ToArray();
			this.walkLayerVisible = walkLayerVisible;
			this.entranceExitLayerVisible = entranceExitLayerVisible;
		}

		public CLayerVisibility(CLayerVisibility copy)
		{
			layersVisible = copy.layersVisible.Select(x => x).ToArray();
			walkLayerVisible = copy.walkLayerVisible;
			entranceExitLayerVisible = copy.entranceExitLayerVisible;
		}
	}
}
