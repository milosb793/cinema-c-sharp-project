using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Bioskop;
using System.Diagnostics;

namespace bioskop
{
	public class Sedista : Dialog
	{
		private DynamicLayout layout;
		private int[][] mesta;
		private int[][] oznacenaMesta;
		private Projekcija projekcija;
		private int brKarata = 4; // 5 ustvari

		public Sedista ( Projekcija p)
		{
			Title = "Седишта - " + p.Sala.Naziv;
			this.projekcija = p;
			this.mesta = projekcija.Sala.MatricaMesta;
			this.oznacenaMesta = new int[mesta.Length][];
			for ( int i = 0 ; i < mesta.Length ; i++ )
			{
				oznacenaMesta [ i ] = new int[mesta [ i ].Length];
			}


			InitializeComponents();

		}

		public void InitializeComponents()
		{
			// buttons
			DefaultButton = new Button { Text = "Купи" };

			AbortButton = new Button { Text = "Поништи" };

			var buttons = new StackLayout {
				Orientation = Orientation.Horizontal,
				Spacing = 5,
				Items = { DefaultButton, AbortButton }
			};

			DefaultButton.Click += (sender, e) => KupiKarte();
			AbortButton.Click += (sender , e ) =>
			{ 
				
				Close();
			};


			// sedista

			CheckBox[][] mestaCheckBox = new CheckBox[mesta.Length][];
			DynamicLayout[][] kontejnerZaMesto = new DynamicLayout[mesta.Length][];

			Console.WriteLine();

			for ( int i = 0 ; i < mesta.Length; i++ )
			{						
				//mesta [ i ] = new int[projekcija.Sala.MatricaMesta [ i ].Length];
				mestaCheckBox[i] = new CheckBox[mesta[i].Length];
				kontejnerZaMesto [ i ] = new DynamicLayout[mesta [ i ].Length];
				for (int j = 0; j < mesta[i].Length; j++) 
				{
					mestaCheckBox [ i ][ j ] = new CheckBox ( );
					mestaCheckBox [ i ][ j ].Text = string.Format( "{0}, {1}" , ( i + 1 ) , ( j + 1 ) );

					if ( mesta [ i ][ j ] == 1 )
					{
						mestaCheckBox [ i ][ j ].Enabled = false;
						mestaCheckBox [ i ][ j ].Checked = true;
					}
					else
					{
						mestaCheckBox [ i ][ j ].Enabled = true;
						mestaCheckBox [ i ][ j ].Checked = false;
					}

					Console.WriteLine(i + " " + j);

					mestaCheckBox [ i ][ j ].CheckedChanged += (sender, e) => OznacenoPolje( (CheckBox)sender );

					kontejnerZaMesto [ i ][ j ] = new DynamicLayout ( ){ };
					kontejnerZaMesto [ i ][ j ].BackgroundColor = Color.FromArgb( 10 , 10 , 10 , 10 );
					kontejnerZaMesto [ i ][ j ].Add( mestaCheckBox [ i ][ j ] );
				}
			}
				

			// layout
			layout = new DynamicLayout(){Spacing = new Size(20,20), Padding = new Padding(15)};

			layout.BeginVertical();
			for ( int i = 0 ; i < kontejnerZaMesto.Length ; i++ )
			{
				layout.BeginHorizontal();
				for ( int j = 0 ; j < kontejnerZaMesto[i].Length; j++ )
				{
					layout.Add( kontejnerZaMesto [ i ][ j ] );
				}
				layout.EndHorizontal();

			}
			layout.EndVertical();


			// dugmici
			layout.BeginVertical();
			layout.Add( null );
			layout.Add( buttons );
			layout.EndVertical();

			Content = layout;
		}

		private void OznacenoPolje(CheckBox cb)
		{
			string[] indeksi = cb.Text.Split( ',' );
			int red = int.Parse( indeksi [ 0 ] );
			int sed = int.Parse( indeksi [ 1 ].Trim() );

			if ( cb.Checked == true)
			{
				if ( brKarata == 0 )
				{
					new Obavestenje ( "Не можете купити више од 5 карти. " ).ShowModal( this );
					cb.Checked = false;
					return;
				}
				else
				{
					Console.WriteLine("Cekirano: "+brKarata);
					Console.WriteLine(string.Format("red:{0}, kolona:{1}",red, sed));
					Console.WriteLine(cb.Text);

					brKarata--;

					oznacenaMesta [ red ][ sed ] = 1;
				}

			}
			else
			{
				Console.WriteLine("false");
				if(brKarata < 4)
					brKarata++;
				
				oznacenaMesta [ red ][ sed ] = 0;
			}
			return;
		}

		private void KupiKarte ()
		{
			int brKupljenihKarti = 0;
			Korisnik k = Projekcijski.VratiInstancu().VratiKorisnika();


			for ( int i = 0 ; i < oznacenaMesta.Length; i++ )
			{
				for ( int j = 0 ; j < oznacenaMesta[i].Length; j++ )
				{
					Console.WriteLine("i: " + i + " j: " + j + " = "+oznacenaMesta[i][j]);

					if ( oznacenaMesta [ i ][ j ] == 1 )
					{
						

						Debug.WriteLine("\nPozdrav iz metode KupiKarte(), korisnik kreiran, njegov id: {0}",k.KorisnikId);

						float cena =  300 + 100 / (i+1) ;
						brKupljenihKarti++; 

						Karta.UpisiKartu( projekcija , k , cena , i , j );

					}
				}
			}
				
			new Obavestenje ( "Нисте купили " + brKupljenihKarti + " карти. Простите, пожалуста. Ево поправљамо грешку већ 24 сата." ).ShowModal( this );

		}


	}
}

