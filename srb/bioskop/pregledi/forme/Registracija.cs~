using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Bioskop;

namespace bioskop
{
	public class Registracija : Dialog
	{

		private Label imeLabela;
		private TextBox imeTextBox;

		private Label prezimeLabela;
		private TextBox prezimeTextBox;

		private Label korImeLabela;
		private TextBox korImeTextBox;

		private Label lozinka1Labela;
		private PasswordBox lozinka1TextBox;

		private Label lozinka2Labela;
		private PasswordBox lozinka2TextBox;

		private Button registrujSe;
		private Button ponisti;

		private DynamicLayout layout;


		public Registracija ( )
		{
			Title = "Региструјте се";

			
			InitializeComponents();

		}

		private void InitializeComponents()
		{
			// inicijalizacija 
			imeLabela = new Label{ Text="Име: " };
			imeTextBox = new TextBox ( );

			prezimeLabela = new Label{ Text="Презиме: " };
			prezimeTextBox = new TextBox ( );

			korImeLabela = new Label{ Text="Корисничко име: " };
			korImeTextBox = new TextBox ( );

			lozinka1Labela = new Label{ Text="Лозинка: " };
			lozinka1TextBox = new PasswordBox ( );

			lozinka2Labela = new Label{ Text="Поново унесите лозинку: " };
			lozinka2TextBox = new PasswordBox ( );

			registrujSe = new Button{ Text="Региструј се"};
			ponisti = new Button{ Text="Поништи форму"};

			layout = new DynamicLayout ( ){ Spacing = new Size ( 10 , 10 ) };


			registrujSe.Click += (sender, e) => Registrovanje();
			ponisti.Click += (sender, e) => PonistiFormu();


			// layout //

			layout.BeginVertical();
			layout.Add( null , true , true );
			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.imeLabela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.imeTextBox, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.Add( null, true, true );

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.prezimeLabela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.prezimeTextBox, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.korImeLabela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.korImeTextBox, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.lozinka1Labela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.lozinka1TextBox, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.lozinka2Labela, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.lozinka2TextBox, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.lozinka2TextBox, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.registrujSe,true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.BeginHorizontal();
			layout.Add( null );
			layout.Add( this.ponisti, true,false );
			layout.Add( null );
			layout.EndHorizontal();

			layout.Add( null, true,true );

			Content = layout;



		}

		private void Registrovanje ()
		{
			string ime = this.korImeTextBox.Text.Trim();
			string prezime = this.prezimeTextBox.Text.Trim();
			string korIme = this.korImeTextBox.Text.Trim();
			string lozinka1 = this.lozinka1TextBox.Text.Trim();
			string lozinka2 = this.lozinka2TextBox.Text.Trim();

			List<Korisnik> sviKorisnici = Korisnik.Svi();

			if ( Metode.ProveriDuzinu( ime , 3 , 15 ) && Metode.ProveriDuzinu( prezime , 3 , 15 ) &&
			     Metode.ProveriDuzinu( korIme , 3 , 15 ) && Metode.ProveriDuzinu( lozinka1 , 5 , 15 ) &&
			     Metode.ProveriDuzinu( lozinka2 , 5 , 15 ) )
			{
				if ( lozinka1 != lozinka2 )
				{
					new Obavestenje ( "Лозинке се морају поклапати!" ).ShowModal( this );
					return;
				}
				else
				{
					Korisnik k = sviKorisnici.Find( x => x.ImePrezime == ime + " " + prezime &&
					             x.KorIme == korIme 
					             );
					if ( k == null )
					{
						Korisnik noviKorisnik = new Korisnik ( korIme , lozinka1 , Korisnik.KOR , ime + " " + prezime );
						noviKorisnik.Sacuvaj();
						new Obavestenje ( "Успешно сте се регистровали. Можете да се пријавите." ).ShowModal( this );
						this.Close();

							
					}
					else
					{
						new Obavestenje ( "Корисник са истим именом и/или корисничким именом већ постоји. " ).ShowModal( this );
						return;
					}
				}
			}
			else
			{
				new Obavestenje ( "Упс! Пропустили сте неко поље, или је неко поље неодговарајуће дужине. " ).ShowModal( this );

			}

		}

		private void PonistiFormu ()
		{
			this.imeTextBox.Text = "";
			this.prezimeTextBox.Text = "";
			this.korImeTextBox.Text = "";
			this.lozinka1TextBox.Text = "";
			this.lozinka2TextBox.Text = "";
		}
	}
}


