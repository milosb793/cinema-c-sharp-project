using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Bioskop;

namespace bioskop
{
	public class IzmenaProjekcije : Dialog
	{

		private Label filmLabela;
		private ComboBox filmComboBox;

		private Label salaLabela;
		private ComboBox salaComboBox;

		private Label vremeLabela;
		private DateTimePicker vremePolje;

		private Button dodaj;
		private Button ponisti;

		private DynamicLayout layout;

		private Projekcija projekcija;
		private Label projekcijeLabela;
		private ComboBox projekcijeComboBox;


		public IzmenaProjekcije ( )
		{
			Title = "Izmena projekcije";

			InitializeComponents();
		}

		private void InitializeComponents ()
		{
			List<Projekcija> sveProjekcijePodaci = Projekcija.Sve();
			List<Film> sviFilmoviPodaci = Film.Svi();
			List<Sala> sveSalePodaci = Sala.Sve();

			ClientSize = new Size ( 350 ,200 );

			projekcijeLabela = new Label{ Text="Izaberite projekciju: " };
			projekcijeComboBox = new ComboBox ( );
			filmLabela = new Label{Text="Izaberite film: " };
			filmComboBox = new ComboBox ( );
			salaLabela = new Label{Text="Izaberite salu: " };
			salaComboBox = new ComboBox ( ); 
			vremeLabela = new Label{Text="Izaberite vreme: " };
			vremePolje = new DateTimePicker{ Mode=DateTimePickerMode.DateTime};
			dodaj = new Button{Text="Izmeni" };
			ponisti = new Button{Text="Ponisti" };

			dodaj.Click += (sender, e) => dodajProjekciju();
			ponisti.Click += (sender, e) => ponistiFormu();

			if ( sveProjekcijePodaci != null )
			{
				foreach ( Projekcija item in sveProjekcijePodaci )
				{
					projekcijeComboBox.Items.Add( item.Film.Naziv + ", " + item.Sala.Naziv , 
					                              item.ProjekcijaId.ToString() );
				}

				foreach ( var item in sviFilmoviPodaci )
				{
					filmComboBox.Items.Add( item.Naziv , item.FilmId.ToString() );
				}

				foreach ( var item in sveSalePodaci )
				{
					salaComboBox.Items.Add( item.Naziv , item.SalaId.ToString() );
				}
			}
			else{
				new Obavestenje ( "Trenutno nema projekcija." ).ShowModal( this );
				this.Close();
			}
			

			filmLabela.Visible = false;
			filmComboBox.Visible = false;
			salaLabela.Visible = false;
			salaComboBox.Visible = false;
			vremeLabela.Visible = false;
			vremePolje.Visible = false;
			dodaj.Visible = false;
			ponisti.Visible = false;


			projekcijeComboBox.SelectedIndexChanged += (sender, e) => {
				filmLabela.Visible = true;
				filmComboBox.Visible = true;
				salaLabela.Visible = true;
				salaComboBox.Visible = true;
				vremeLabela.Visible = true;
				vremePolje.Visible = true;
				dodaj.Visible = true;
				ponisti.Visible = true;

				int projekcija_id = int.Parse(projekcijeComboBox.SelectedKey);
				this.projekcija = sveProjekcijePodaci.Find( (x) => x.ProjekcijaId == projekcija_id);
				projekcijeComboBox.SelectedKey = this.projekcija.ProjekcijaId.ToString();
				filmComboBox.SelectedKey = this.projekcija.Film.FilmId.ToString();
				salaComboBox.SelectedKey = this.projekcija.Sala.SalaId.ToString();
				vremePolje.Value = DateTime.Parse(this.projekcija.Vreme);

			};


			// layout

			layout = new DynamicLayout ( ){ Spacing = new Size ( 100 , 100 ), Padding=20 };

			layout.BeginVertical();

			//layout.Add( null , true , true );

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.projekcijeLabela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.projekcijeComboBox, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.filmLabela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.filmComboBox, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.salaLabela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.salaComboBox, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.vremeLabela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.vremePolje, true,false );
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

			//layout.Add( null , true , true );
			layout.EndVertical();

			Content = layout;
		}

		private void dodajProjekciju ()
		{
			if(this.projekcija != null)
			{
				try{
					Film f = Film.VratiPoID(int.Parse(filmComboBox.SelectedKey));
					Sala s = Sala.VratiPoID( int.Parse( salaComboBox.SelectedKey ) );
					string vreme = vremePolje.Value.ToString();

					this.projekcija.Film = f;
					this.projekcija.Sala = s;
					this.projekcija.Vreme = vreme;

					this.projekcija.Sacuvaj();

					new Obavestenje ( "Uspesno ste izmenili projekciju! " ).ShowModal( this );

				}catch(Exception ex){
					Console.WriteLine(ex.ToString());
				}
			}
			else
				new Obavestenje ( "Niste izabrali projekciju! " ).ShowModal( this );
			
		}

		private void ponistiFormu ()
		{
			//projekcijeComboBox.SelectedKey = this.projekcija.ProjekcijaId.ToString();
			filmComboBox.SelectedKey = this.projekcija.Film.FilmId.ToString();
			salaComboBox.SelectedKey = this.projekcija.Sala.SalaId.ToString();
			vremePolje.Value = DateTime.Parse(this.projekcija.Vreme);

		}
	}
}

