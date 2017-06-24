using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Bioskop;

namespace bioskop
{
	public class ObrisiFilm : Dialog
	{

		private Label izaberiFilm;
		private ComboBox listaFilmova;
		private Button obrisi;

		private DynamicLayout layout;

		private int filmId;

		public ObrisiFilm ( )
		{
			Title = "Brisanje filma - ";

			InicializeComponents();
		}

		private void InicializeComponents()
		{
			ClientSize = new Size ( 350 , 150 );

			List<Film> sviFilmoviPodaci = Film.Svi();

			this.izaberiFilm = new Label{ Text="Izaberite film: "};
			this.listaFilmova = new ComboBox ( );
			this.obrisi = new Button{ 
				Text = "Obrisi" ,
				ToolTip = "Obrisi film"

			};
			this.obrisi.Visible = false;

			this.obrisi.Visible = false;

			foreach ( Film f in sviFilmoviPodaci )
			{
				listaFilmova.Items.Add(f.Naziv, f.FilmId.ToString() );
			}


			this.obrisi.Click += (sender, e) => obrisiFilm();

			this.listaFilmova.SelectedIndexChanged += (sender, e) => {
				Console.WriteLine ("Vrednost selektovanog elementa: " + listaFilmova.SelectedValue);
				this.filmId = int.Parse(this.listaFilmova.SelectedKey );
				Console.WriteLine ("Id filma za brisanje: " + this.filmId);
				this.obrisi.Visible = true;
			};

			layout = new DynamicLayout (){ Spacing = new Size(0,3) };

			layout.BeginVertical();
			layout.Add( null , true , true );
			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.izaberiFilm, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.listaFilmova, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.Add( null, true, true );

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.obrisi, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.Add( null, true,true );

			Content = layout;

		}

		private void obrisiFilm ()
		{
			if ( filmId != 0 )
			{
				List<Film> sviFilmovi = Film.Svi();

				// TODO: sredi ozbacivanje iz liste

				try{Console.WriteLine(this.listaFilmova.SelectedIndex);}catch(Exception e){Console.WriteLine(e.ToString());}

				try{
					listaFilmova.Items.RemoveAt(listaFilmova.SelectedIndex -1);

					int id = sviFilmovi.FindIndex( x => x.FilmId == this.filmId );
					sviFilmovi.RemoveAt( id );
					Serijalizacija.WriteListToBinaryFile<Film>( Serijalizacija.FiDat , sviFilmovi , false );
					new Obavestenje ( "Uspesno ste obrisali film!" ).ShowModal(this);
					InicializeComponents();
				}
				catch(Exception e){Console.WriteLine(e.ToString());}

				//MessageBox.Show( this , "Uspesno ste obrisali film!", MessageBoxType.Information );
			}
			else
				MessageBox.Show( this , "Niste izabrali film!", MessageBoxType.Information );

		}
	}
}

