using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace bioskop
{
	public class DodavanjeKarte : Form
	{
		public DodavanjeKarte ( )
		{
			Title = "My DodavanjeKarte form";

			Content = new StackLayout {
				Items = {
					new Label { Text = "Some Content" }
				}
			};
		}
	}
}

