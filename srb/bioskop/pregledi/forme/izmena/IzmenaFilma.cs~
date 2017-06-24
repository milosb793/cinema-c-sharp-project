using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Bioskop;

namespace bioskop
{
	public class IzmenaFilma : Dialog
	{
		private Label naziv;
		private TextBox nazivPolje;

		private Label zanr;
		private ComboBox zanrList;

		private Label sviFilmovi;
		private ComboBox sviFilmoviLista;

		private Label opis;
		private TextArea opisPolje;

		private Button dodaj;
		private Button ponisti;
		private Film film;

		public IzmenaFilma ()
		{

			Title = String.Format("Izmena filma - {0}","");
			InitializeComponents();
		}

		private void InitializeComponents()
		{
			List<Film> sviFilmoviPodaci = Film.Svi();


			// kontrole
			naziv = new Label{ Text="Naziv filma:" };
			nazivPolje = new TextBox{ Width = 190};

			zanr = new Label{ Text="Zanr" };
			zanrList = new ComboBox(); 
			zanrList.Items.Add( "Horor" );
			zanrList.Items.Add( "Akcija" );
			zanrList.Items.Add( "Drama" );
			zanrList.Items.Add( "Triler" );
			zanrList.Items.Add( "Animirani" );
			zanrList.Items.Add( "Crtac" ); 

			sviFilmovi = new Label{ Text = "Izaberite film sa liste: " };
			sviFilmoviLista = new ComboBox ( );
			opis = new Label{ Text="Opis filma: " };
			opisPolje = new TextArea{ Width = 190 };
			dodaj = new Button{ Text = "Izmeni", Width=100 };
			ponisti = new Button{ Text = "Ponisti", Width=100};


			naziv.Visible = false;
			nazivPolje.Visible = false;
			opis.Visible = false;
			opisPolje.Visible = false;
			zanr.Visible = false;
			zanrList.Visible = false;
			dodaj.Visible = false;
			ponisti.Visible = false;


			foreach(Film f in sviFilmoviPodaci)
				sviFilmoviLista.Items.Add(f.Naziv, f.FilmId.ToString() );

			sviFilmoviLista.SelectedKeyChanged += (sender, e) => {
				foreach(Film f in sviFilmoviPodaci)
				{
					if ( f.FilmId ==  int.Parse(sviFilmoviLista.SelectedKey) )
					{
						film = f;
						this.nazivPolje.Text = film.Naziv;
						this.opisPolje.Text = film.Opis;
						this.zanrList.SelectedIndex = (int)film.GetZanr();
						Title = String.Format("Izmena filma - {0}",film.Naziv);

						naziv.Visible = true;
						nazivPolje.Visible = true;
						opis.Visible = true;
						opisPolje.Visible = true;
						zanr.Visible = true;
						zanrList.Visible = true;
						dodaj.Visible = true;
						ponisti.Visible = true;
					}
				}
			};



			dodaj.Click += (sender, e) => izmeniFilm();

			ponisti.Click += (sender, e) => ponistiFormu();



			// podaci


			// layout
			var layout = new TableLayout{
				Spacing = new Size(5,5),
				Padding = 10,
				Rows = {
					new TableRow(sviFilmovi),
					new TableRow(sviFilmoviLista),
					new TableRow(naziv),
					new TableRow(nazivPolje),
					new TableRow(zanr),
					new TableRow(zanrList),
					new TableRow(opis),
					new TableRow(opisPolje),
					new TableRow(dodaj,ponisti)

				}
			};

			Content = layout;
		}

		private void izmeniFilm()
		{


			string nazivF = this.nazivPolje.Text.Trim();
			string opisF = this.opisPolje.Text.Trim();
			Zanr zanr = (Zanr)this.zanrList.SelectedIndex;

			if ( Metode.ProveriDuzinu( nazivF , 5 , 30 ) &&
			    Metode.ProveriDuzinu( opisF , 4 , 255 ) )
			{
				film.Naziv = nazivF;
				film.Opis = opisF;
				film.setZanr( zanr );
				film.Sacuvaj();
				new Obavestenje ( "Uspesno ste izmenili film!" ).ShowModal();
				//MessageBox.Show( this , "Uspesno ste izmenili film!" , MessageBoxType.Information );
				InitializeComponents();
			}
			else
				new Obavestenje ( "Izgleda da imate praznih polja, ili je duzina neodgovarajuca." ).ShowModal();
				//MessageBox.Show( this , "Izgleda da imate praznih polja, ili je duzina neodgovarajuca." , MessageBoxType.Warning );
		}

		private void osveziListuFilmova()
		{
			List<Film> sviFilmoviPodaci = Film.Svi();

			//TODO: sredi osvezavanje liste

			foreach ( var i in sviFilmoviPodaci )
			{
				if ( film != null && i.FilmId == film.FilmId )
				{
					this.sviFilmoviLista.Items.Add( film.Naziv , film.FilmId.ToString() );
				}
				else
					this.sviFilmoviLista.Items.Add(i.Naziv , i.FilmId.ToString());
			}
		}

		private void ponistiFormu ()
		{
			if ( film != null )
			{
				this.nazivPolje.Text = film.Naziv;
				this.opisPolje.Text = film.Opis;
				this.zanrList.SelectedIndex = (int)film.GetZanr();	
			}

		}
	}
}

