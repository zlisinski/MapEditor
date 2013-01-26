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
	public partial class CRenameMapForm : Form
	{
		public string name;

		public CRenameMapForm(string mapName)
		{
			InitializeComponent();

			textName.Text = mapName;
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
		}
	}
}
