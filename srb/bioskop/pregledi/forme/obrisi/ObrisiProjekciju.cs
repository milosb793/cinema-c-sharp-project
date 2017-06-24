using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Bioskop;

namespace bioskop
{
	public class ObrisiProjekciju : Dialog
	{
		private Label sveProjekcijeLabela;
		private ComboBox sveProjekcijeComboBox;

		private Button obrisi;

		private DynamicLayout layout;

		private int projekcija_id;

		public ObrisiProjekciju ( )
		{
			Title = "Brisanje projekcije - ";

			InicializeComponents();

		}

		private void InicializeComponents()
		{
			ClientSize = new Size ( 350 , 150 );

			List<Projekcija> sveProjekcijePodaci = Projekcija.Sve();

			this.sveProjekcijeLabela = new Label{ Text="Izaberite projekciju: "};
			this.sveProjekcijeComboBox = new ComboBox ( );

			this.obrisi = new Button{ 
				Text = "Obrisi" ,
				ToolTip = "Obrisi projekciju"

			};
			this.obrisi.Visible = false;

			foreach ( Projekcija p in sveProjekcijePodaci )
				sveProjekcijeComboBox.Items.Add(p.Film.Naziv+", "+p.Sala.Naziv, p.ProjekcijaId.ToString() );


			this.obrisi.Click += (sender, e) => obrisiProjekciju();

			this.sveProjekcijeComboBox.SelectedIndexChanged += (sender, e) => {
				this.projekcija_id = int.Parse(this.sveProjekcijeComboBox.SelectedKey );
				this.obrisi.Visible = true;
			};

			layout = new DynamicLayout (){ Spacing = new Size(0,3) };

			layout.BeginVertical();
			layout.Add( null , true , true );
			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.sveProjekcijeLabela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.sveProjekcijeComboBox, true,false );
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

		private void obrisiProjekciju ()
		{
			if ( projekcija_id != 0 )
			{
				List<Projekcija> sveProjekcijePodaci = Projekcija.Sve();

				try{
					sveProjekcijeComboBox.Items.RemoveAt(sveProjekcijeComboBox.SelectedIndex -1);

					int id = sveProjekcijePodaci.FindIndex( x => x.ProjekcijaId == this.projekcija_id );
					sveProjekcijePodaci.RemoveAt( id );
					Serijalizacija.WriteListToBinaryFile<Projekcija>( Serijalizacija.PrDat , sveProjekcijePodaci , false );
					new Obavestenje ( "Uspesno ste obrisali projekciju!" ).ShowModal(this);
					InicializeComponents();
				}
				catch(Exception e){Console.WriteLine(e.ToString());}
			}
			else
				MessageBox.Show( this , "Niste izabrali projekciju!", MessageBoxType.Information );

		}
	}
}

