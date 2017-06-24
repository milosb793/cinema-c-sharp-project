using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using System.Linq;
using Bioskop;

namespace bioskop
{
	public class DodavanjeFilma : Dialog
	{
		private Label naziv;
		private TextBox nazivPolje;

		private Label zanr;
		private ComboBox zanrList;

		private Label opis;
		private TextArea opisPolje;

		private Button dodaj;
		private Button ponisti;




		public DodavanjeFilma ( )
		{
			Title = "Dodavanje Filma";

			InitializeComponents();
		}

		public void InitializeComponents()
		{
			List<string> listaZanrova = ZanrC.VratiSveZanrove();


			naziv = new Label{ Text="Naziv filma:" };
			nazivPolje = new TextBox{ Width = 190};

			zanr = new Label{ Text="Zanr" };
			zanrList = new ComboBox(); 


			listaZanrova.ForEach( (x) => zanrList.Items.Add( x ) );


			opis = new Label{ Text="Opis filma: " };
			opisPolje = new TextArea{ Width = 190 };

			dodaj = new Button{ Text = "Dodaj" };
			dodaj.Click += (sender, e) => dodajFilm();

			ponisti = new Button{ Text = "Ponisti"};
			ponisti.Click += (sender, e) => ponistiFormu();

			var dugmici = new StackLayout {
				Orientation = Orientation.Horizontal,
				Padding = 10,
				Spacing = 20,
				Items = {
					dodaj, ponisti
				}
			};

			Content = new StackLayout {
				Spacing = 10,
				Padding = 5,
				Orientation = Orientation.Vertical,
				Items = {
					naziv,
					nazivPolje,
					zanr,
					zanrList,
					opis,
					opisPolje,
					dugmici
				}
			};
		}


		private void dodajFilm ()
		{
			string naziv = this.nazivPolje.Text.Trim();
			string opis = this.opisPolje.Text.Trim();
			Zanr zanr = (Zanr)this.zanrList.SelectedIndex;

			if ( Metode.ProveriDuzinu( naziv , 5 , 30 ) &&
			    Metode.ProveriDuzinu( opis , 5 , 255 ) )
			{
				Film f = new Film ( naziv , zanr , opis , 0.0F );
				f.Sacuvaj();
				new Obavestenje ( "Uspesno ste dodali film!" ).ShowModal();

				//MessageBox.Show( this , "Uspesno ste dodali film!" , MessageBoxType.Warning );

			}
			else
				new Obavestenje ( "Izgleda da niste popunili sva polja, ili je duzina neodgovarajuca." ).ShowModal();
				//MessageBox.Show( this , "Izgleda da niste popunili sva polja, ili je duzina neodgovarajuca." , MessageBoxType.Warning );
		
		}


		private void ponistiFormu ()
		{
			this.nazivPolje.Text = "";
			this.opisPolje.Text = "";
			this.zanrList.SelectedIndex = 0;
		}
	}
}

