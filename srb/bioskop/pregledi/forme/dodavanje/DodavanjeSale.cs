using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Bioskop;

namespace bioskop
{
	public class DodavanjeSale : Dialog
	{

		private Label naziv;
		private TextBox nazivPolje;

		private Label redovaLabela;
		private NumericUpDown redovaPolje;

		private Label sedistaLabela;
		private NumericUpDown sedistaPolje;

		private Button dodaj;
		private Button ponisti;

		private DynamicLayout layout;



		public DodavanjeSale ( )
		{
			Title = "Dodavanje sale";

			InitializeComponents();
		}

		public void InitializeComponents()
		{
			ClientSize = new Size ( 300 , 250 );


			naziv = new Label{ Text="Naziv sale:" };
			nazivPolje = new TextBox{ };

			redovaLabela = new Label{ Text="Broj redova sedista: " };
			redovaPolje = new NumericUpDown{ 
				MinValue=5, 
				MaxValue = 10
			};

			sedistaLabela = new Label{ Text="Broj sedista u redu: " };
			sedistaPolje = new NumericUpDown{ 
				MinValue=5, 
				MaxValue = 10
			};
					

			dodaj = new Button{ Text = "Dodaj" };
			dodaj.Click += (sender, e) => dodajSalu();

			ponisti = new Button{ Text = "Ponisti"};
			ponisti.Click += (sender, e) => ponistiFormu();


			layout = new DynamicLayout ( ){ Spacing = new Size(20,20)};
			layout.BeginVertical();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.naziv, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.nazivPolje, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.redovaLabela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.redovaPolje, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.sedistaLabela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.sedistaPolje, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.dodaj,true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.ponisti, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.Add( null, true,true );
			layout.EndVertical();

			Content = layout;
		}
			

		private void dodajSalu ()
		{
			List<Sala> sveSalePodaci = Sala.Sve();
			string naziv = this.nazivPolje.Text.Trim();
			int brojRedova = ( int )this.redovaPolje.Value;
			int brojSedista = ( int )this.sedistaPolje.Value;


			if ( Metode.ProveriDuzinu( naziv , 5 , 30 ) )
			{
				if(sveSalePodaci.Find(x => x.Naziv == naziv) != null)
				{
					new Obavestenje ( "Sala sa tim nazivom vec postoji!" ).ShowModal(this);
					return;
					// TODO: uradi ovu proveru u svim dodavanjima!
				}

				Sala s = new Sala ( naziv,brojRedova, brojSedista );
				s.Sacuvaj();
				new Obavestenje ( "Uspesno ste dodali salu!" ).ShowModal(this);

				//MessageBox.Show( this , "Uspesno ste dodali film!" , MessageBoxType.Warning );

			}
			else
				new Obavestenje ( "Izgleda da niste popunili sva polja, ili je duzina neodgovarajuca." ).ShowModal();
			//MessageBox.Show( this , "Izgleda da niste popunili sva polja, ili je duzina neodgovarajuca." , MessageBoxType.Warning );

		}


		private void ponistiFormu ()
		{
			this.nazivPolje.Text = "";
			this.redovaPolje.Value = 5;
			this.sedistaPolje.Value = 5;

		}

	}
}

