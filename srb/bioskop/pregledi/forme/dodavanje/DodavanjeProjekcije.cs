using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Bioskop;

namespace bioskop
{
	public class DodavanjeProjekcije : Dialog
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

		public DodavanjeProjekcije ( )
		{
			Title = "Dodavanje projekcije";

			InitializeComponents();
		}

		private void InitializeComponents ()
		{
			List<Film> sviFilmoviPodaci = Film.Svi();
			List<Sala> sveSalePodaci = Sala.Sve();

			ClientSize = new Size ( 200 , 300 );

			// inicijalizacije
			filmLabela = new Label{ Text="Izaberite film: "};
			filmComboBox = new ComboBox ();

			salaLabela = new Label{ Text="Izaberite salu: "};
			salaComboBox = new ComboBox ();

			vremeLabela = new Label{ Text="Izaberite vreme: "};
			vremePolje = new DateTimePicker{ Mode = DateTimePickerMode.DateTime };
			

			dodaj = new Button{ Text="Dodaj", Width=50};
			ponisti = new Button{ Text="Ponisti", Width=50};

			// popunjavanje i dogadjaji 
			foreach ( var item in sviFilmoviPodaci )
			{
				filmComboBox.Items.Add( item.Naziv , item.FilmId.ToString() );
			}

			foreach ( var item in sveSalePodaci )
			{
				salaComboBox.Items.Add( item.Naziv , item.SalaId.ToString() );
			}

			vremePolje.ToolTip = "Kliknite na polje i izaberite datum.";

			dodaj.Click += (sender , e ) => dodajProjekciju();
			ponisti.Click += (sender, e) => ponistiFormu();

			layout = new DynamicLayout ( ){ Spacing = new Size ( 100 , 100 ), Padding=20 };

			// layout dodavanje
			layout.BeginVertical();

			layout.Add( null , true , true );
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

			//layout.Add( null, true, true );

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

			//layout.Add( null );
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

		private void ponistiFormu ()
		{
			this.filmComboBox.SelectedIndex = -1;
			this.salaComboBox.SelectedIndex = -1;
			this.vremePolje.Value = null;
		}

		private void dodajProjekciju ()
		{
			int film_id = int.Parse( this.filmComboBox.SelectedKey );
			int sala_id = int.Parse( this.salaComboBox.SelectedKey );
			string datum = this.vremePolje.Value.ToString();

			Console.WriteLine(datum);

			Film f = Film.VratiPoID( film_id );
			Sala s = Sala.VratiPoID( sala_id );

			Projekcija p = new Projekcija ( f , s , datum );
			p.Sacuvaj();

			new Obavestenje ("Uspesno ste kreirali projekciju!" ).ShowModal( this );
			Console.WriteLine(p.ToString());

		}
	}
}

