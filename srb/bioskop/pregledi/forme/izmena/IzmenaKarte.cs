using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace bioskop
{
	public class IzmenaKarte : Form
	{
		public IzmenaKarte ( )
		{
			Title = "My IzmenaKarte form";

			Content = new StackLayout {
				Items = {
					new Label { Text = "Some Content" }
				}
			};
		}
	}
}

