﻿using System;
using Eto;
using Eto.Forms;

namespace bioskop.Gtk2
{
	public class Program
	{
		[STAThread]
		public static void Main ( string[] args )
		{
			new Application ( Platforms.Gtk2 ).Run( new MainForm ( ) );
		}
	}
}
