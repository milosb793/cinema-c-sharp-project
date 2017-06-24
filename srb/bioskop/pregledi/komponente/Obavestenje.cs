using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace bioskop
{

	public class Obavestenje : Dialog
	{
		private Button ok;
		private Label tekstLabela;


		public Obavestenje ( string tekst)
		{
			ok = new Button{ Text = "Potvrdi" };
			ok.Click += (sender, e) => {
				this.Close();
			};

			tekstLabela = new Label{ Text=tekst, TextAlignment=TextAlignment.Center };

			ClientSize = new Size ( 150 , 100 );

			var layout = new DynamicLayout (){ Spacing = new Size(0,3) };

			layout.BeginVertical();
			layout.Add( null , true , true );
			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.tekstLabela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.Add( null , true , true );

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.ok, true,false );
			layout.Add( null );
			layout.EndHorizontal();
			layout.EndVertical();


			Content = layout; 

		}
	}
}

