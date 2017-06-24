using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Bioskop;

namespace bioskop
{
	public class ObrisiSalu : Dialog
	{

		private Label sveSaleLabela;
		private ComboBox sveSaleComboBox;

		private Button obrisi;

		private DynamicLayout layout;

		private int sala_id;

		public ObrisiSalu ( )
		{
			Title = "Brisanje sale - ";

			InicializeComponents();

		}

		private void InicializeComponents()
		{
			ClientSize = new Size ( 350 , 150 );

			List<Sala> sveSalePodaci = Sala.Sve();

			this.sveSaleLabela = new Label{ Text="Izaberite salu: "};
			this.sveSaleComboBox = new ComboBox ( );

			this.obrisi = new Button{ 
				Text = "Obrisi" ,
				ToolTip = "Obrisi salu"

			};
			this.obrisi.Visible = false;

			foreach ( Sala s in sveSalePodaci )
				sveSaleComboBox.Items.Add(s.Naziv, s.SalaId.ToString() );
			


			this.obrisi.Click += (sender, e) => obrisiSalu();

			this.sveSaleComboBox.SelectedIndexChanged += (sender, e) => {
				this.sala_id = int.Parse(this.sveSaleComboBox.SelectedKey );
				this.obrisi.Visible = true;
			};

			layout = new DynamicLayout (){ Spacing = new Size(0,3) };

			layout.BeginVertical();
			layout.Add( null , true , true );
			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.sveSaleLabela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.sveSaleComboBox, true,false );
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

		private void obrisiSalu ()
		{
			if ( sala_id != 0 )
			{
				List<Sala> sveSalePodaci = Sala.Sve();

				try{
					sveSaleComboBox.Items.RemoveAt(sveSaleComboBox.SelectedIndex -1);

					int id = sveSalePodaci.FindIndex( x => x.SalaId == this.sala_id );
					sveSalePodaci.RemoveAt( id );
					Serijalizacija.WriteListToBinaryFile<Sala>( Serijalizacija.SaDat , sveSalePodaci , false );
					new Obavestenje ( "Uspesno ste obrisali salu!" ).ShowModal(this);
					InicializeComponents();
				}
				catch(Exception e){Console.WriteLine(e.ToString());}

				//MessageBox.Show( this , "Uspesno ste obrisali film!", MessageBoxType.Information );
			}
			else
				MessageBox.Show( this , "Niste izabrali salu!", MessageBoxType.Information );

		}

	}
}

