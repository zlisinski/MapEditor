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
		public bool monsterRegionLayerVisible;
		public bool entranceExitLayerVisible;

		public CLayerVisibility()
		{
			layersVisible = new bool[Globals.layerCount];
			for (int i = 0; i < layersVisible.Length; i++)
				layersVisible[i] = true;
			walkLayerVisible = true;
			monsterRegionLayerVisible = true;
			entranceExitLayerVisible = true;
		}

		public CLayerVisibility(bool[] layersVisible, bool walkLayerVisible, bool monsterRegionLayerVisible, bool entranceExitLayerVisible)
		{
			this.layersVisible = layersVisible.Select(x => x).ToArray();
			this.walkLayerVisible = walkLayerVisible;
			this.monsterRegionLayerVisible = monsterRegionLayerVisible;
			this.entranceExitLayerVisible = entranceExitLayerVisible;
		}

		public CLayerVisibility(CLayerVisibility copy)
		{
			layersVisible = copy.layersVisible.Select(x => x).ToArray();
			walkLayerVisible = copy.walkLayerVisible;
			monsterRegionLayerVisible = copy.monsterRegionLayerVisible;
			entranceExitLayerVisible = copy.entranceExitLayerVisible;
		}
	}
}
