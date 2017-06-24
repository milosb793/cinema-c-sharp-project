using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Bioskop;

namespace bioskop
{
	public class IzmenaSale : Dialog
	{
		private Label sveSaleLabela;
		private ComboBox sveSaleComboBox;

		private Label naziv;
		private TextBox nazivPolje;

		private Button dodaj;
		private Button ponisti;

		private DynamicLayout layout;

		private Sala sala;

		public IzmenaSale ( )
		{
			Title = String.Format("Izmena sale - {0}","");

			InitializeComponents();
		}

		private void InitializeComponents ()
		{
			List<Sala> sveSalePodaci = Sala.Sve();

			ClientSize = new Size ( 300 , 250 );
			// kontrole
			naziv = new Label{ Text="Naziv sale:" };
			nazivPolje = new TextBox{ };

			sveSaleLabela = new Label{ Text="Izaberite salu: " };
			sveSaleComboBox = new ComboBox(); 
				
			dodaj = new Button{ Text = "Izmeni", Width=100 };
			ponisti = new Button{ Text = "Ponisti", Width=100};


			foreach(Sala s in sveSalePodaci)
				sveSaleComboBox.Items.Add(s.Naziv, s.SalaId.ToString() );

			naziv.Visible = false;
			nazivPolje.Visible = false;

			dodaj.Visible = false;
			ponisti.Visible = false;



			sveSaleComboBox.SelectedKeyChanged += (sender, e) => {
				foreach(Sala s in sveSalePodaci)
				{
					if ( s.SalaId ==  int.Parse(sveSaleComboBox.SelectedKey) )
					{
						sala = s;
						this.nazivPolje.Text = sala.Naziv;

						Title = String.Format("Izmena filma - {0}",sala.Naziv);

						naziv.Visible = true;
						nazivPolje.Visible = true;
						dodaj.Visible = true;
						ponisti.Visible = true;
					}
				}
			};



			dodaj.Click += (sender, e) => izmeniSalu();

			ponisti.Click += (sender, e) => ponistiFormu();

			layout = new DynamicLayout ( ){ Spacing = new Size(20,20)};
			layout.BeginVertical();

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

		private void izmeniSalu ()
		{
			string naziv = this.nazivPolje.Text.Trim();

			if ( sala != null && Metode.ProveriDuzinu( naziv , 5 , 30 ) )
			{
				sala.Naziv = naziv;
				sala.Sacuvaj();
				new Obavestenje ( "Uspesno ste izmenili salu!" ).ShowModal(this);

			}
			else
				new Obavestenje ( "Izgleda da niste popunili sva polja,\n ili je duzina neodgovarajuca." ).ShowModal(this);

		}

		private void ponistiFormu ()
		{
			nazivPolje.Text = sala.Naziv;
		}
	}
}

