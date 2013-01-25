using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapEditor
{
	public partial class CNewMapForm : Form
	{
		public string name;
		public int width;
		public int height;
		public CTileSet tileSet;

		public CNewMapForm()
		{
			InitializeComponent();

			foreach (CTileSet tileSet in TileSets.instance)
			{
				comboTileSet.Items.Add(tileSet);
			}

			comboTileSet.SelectedIndex = 0;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			name = textName.Text.Trim();
			if (name == "")
			{
				MessageBox.Show("Enter a map name");
				DialogResult = DialogResult.None;
				return;
			}

			width = Convert.ToInt32(numWidth.Value);
			height = Convert.ToInt32(numHeight.Value);
			tileSet = (CTileSet)comboTileSet.SelectedItem;
		}
	}
}
