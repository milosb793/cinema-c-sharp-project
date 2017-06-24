using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using System.Linq;
using Bioskop;

namespace bioskop
{
	public partial class Projekcijski : Panel
	{
		// meni
		private Command prijaviSeCmd;
		private Command pocetnaCmd;
		private MenuBar meni;

		private Label izdvajamoLabela, najnovijeLabela, kategorijeLabela, separator;

		// pretraga 
		private DynamicLayout pretragaLayout;
		private ImageView     lupaImg;
		private TextBox 	  pretragaBox;

		// paneli 
		private TableLayout panel;
		private DynamicLayout desniPanel;
		private DynamicLayout kategorijePanel;
		private DynamicLayout  leviPanel;
		private DynamicLayout izdvajamoPanel;
		private DynamicLayout najnovijePanel;

		// panel za prikaz projekcija iz zanra
		private DynamicLayout glavniPanelZanr;
		private Label zanrLabela;
		private DynamicLayout sadrzajZanrPanel;

		private Korisnik prijavljeniKorisnik;

		private static Projekcijski instanca;

		public Projekcijski ( )
		{
			//this.prijavljeniKorisnik = Prijavljivanje.instanca.VratiPrijavljenogKorisnika();
			prijaviSeCmd = new Command{ 
				MenuText = "Одјави се",
				ToolTip = "Одјави се"
			};

			pocetnaCmd = new Command{ 
				MenuText = "Почетна",
				ToolTip = "Почетна"
			};

			pocetnaCmd.Executed += (object sender, EventArgs e) => {

			};

			prijaviSeCmd.Executed += (object sender , EventArgs e ) =>
			{
				Prijavljivanje.instanca.InitializeComponents();
				//this.Dispose();
			};
			InitializeComponents();

			//this.ClientSize = new Size ( 700 , 500 );
		}

		public void InitializeComponents()
		{
			


			meni = new MenuBar{ 
				Items = {
					new ButtonMenuItem{ Text="Почетна", Items ={ this.pocetnaCmd } } ,
					new SeparatorMenuItem(),
					new ButtonMenuItem{ Text="Одјави се", Items ={ this.prijaviSeCmd } }
				}
			};

			// labele
			izdvajamoLabela =  new Label{ Text="\tИздвајамо: ", Font = new Font(SystemFont.Bold, 14)};
			najnovijeLabela =  new Label{ Text="\tНајновије: ", Font = new Font(SystemFont.Bold, 14)};
			kategorijeLabela = new Label{ Text="\tКатегорије: ", Font = new Font(SystemFont.Bold, 12)};
			separator = 	   new Label{Text="\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", 
								Font = new Font(SystemFont.Default,10, FontDecoration.Strikethrough)
			};

			// pretraga
			lupaImg = new ImageView{ Image = Icon.FromResource("search-icon") }; 
			lupaImg.Width = 30;
			lupaImg.Height = 30;
			lupaImg.MouseEnter += (sender, e) => {
				lupaImg.Width += 10;
				lupaImg.Height += 10;
			};
			lupaImg.MouseLeave += (sender, e) => {
				lupaImg.Width = 30;
				lupaImg.Height = 30;
			};
			pretragaBox = new TextBox ( ){ PlaceholderText="Унесите назив филма..."};
			pretragaBox.ToolTip = "Притисните ентер за претрагу.";
			pretragaBox.KeyUp += (sender, e) => {
				Console.WriteLine ("Pretraga");
			};
			pretragaLayout = new DynamicLayout ( ){ Spacing = new Size(10,10) };
			pretragaLayout.BeginVertical();
			pretragaLayout.EndBeginHorizontal();
			pretragaLayout.Add( null , true , false );
			pretragaLayout.Add( lupaImg );
			pretragaLayout.Add( pretragaBox );
			pretragaLayout.Add( null , true , false );
			pretragaLayout.EndHorizontal();
			pretragaLayout.EndVertical();

			// kategorije 
			List<string> listaKategorija = ZanrC.VratiSveZanrove();
			List<Label> listaLabela = new List<Label> ( );
			listaKategorija.ForEach( x => listaLabela.Add(new Label{ Text=x.ToString() }) );

			listaLabela.ForEach( x => {
				x.MouseEnter += (sender, e) => {
					x.Font = new Font(SystemFont.Default, 10 , FontDecoration.Underline);
				};

				x.MouseLeave += (sender, e) => {
					x.Font = new Font(SystemFont.Default, 10, FontDecoration.None);
				};
				x.MouseDown += (sender, e) => {
					Console.WriteLine ("Kliknuto: " + x.Text);
				};
			});
			kategorijePanel = new DynamicLayout ( ){ 
				Spacing = new Size(10,10), 
				Padding = new Padding(10,10)
			};
			kategorijePanel.BeginVertical();
			listaLabela.ForEach( x => { 
				kategorijePanel.BeginHorizontal();
				kategorijePanel.Add( null , true , false );
				kategorijePanel.Add( x );
				//kategorijePanel.Add( null , true , false );
				kategorijePanel.EndHorizontal();
			} );
			kategorijePanel.EndVertical();

			// pretraga i desni panel
			desniPanel = new DynamicLayout ( ){ 
				Spacing = new Size(10,10), 
				BackgroundColor = Color.FromArgb(255,238,91,70 ),
				Size=new Size(300,500)
			};
			desniPanel.BeginVertical();
			desniPanel.Add( pretragaLayout );
			desniPanel.Add( kategorijeLabela );
			separator.Text = "\t\t\t\t\t\t\t";
			desniPanel.Add( separator );
			desniPanel.Add( kategorijePanel );
			desniPanel.EndVertical();

			izdvajamoPanel = new DynamicLayout ( ) {
				Padding = new Padding ( 10 , 10 ),
				BackgroundColor = Color.FromArgb( 40 , 40 , 40 , 50 ),
				Spacing = new Size ( 5 ,5),

			};
			izdvajamoPanel.BeginVertical();

			// inicijalizacija izdvajamo panela 
			List<Projekcija> listaProjekcijaPodaci = Projekcija.Sve();

			for(int i = 0; i < listaProjekcijaPodaci.Count-1; i ++)
			{
				// nasumicno odabiranje projekcije 
				if ( i == Metode.VratiNasumicniInt( 0 , listaProjekcijaPodaci.Count ) )
					continue;
				
				Label nazivFilma = new Label{ Text="Назив филма: "+listaProjekcijaPodaci[i].Film.Naziv};
				Label nazivSale =  new Label{ Text ="Назив сале:  "+ listaProjekcijaPodaci[i].Sala.Naziv };
				Label vreme = 	   new Label{ Text = "Време:\t  "+listaProjekcijaPodaci[i].Vreme };
				Button kupi = 	   new Button{ Text = "Kупите карту" };
				Button vise =	   new Button{ Text = "Више информација" };
				var podPanel =	   new DynamicLayout ( ){ Spacing=new Size(10,10)};
				var dugmici = 	   new DynamicLayout{ Spacing=new Size(10,10) };

				kupi.Click += (sender, e) => KupiKartu(listaProjekcijaPodaci[i]) ;
				vise.Click += (sender, e) => PrikaziVise(listaProjekcijaPodaci[i]);

				podPanel.BeginVertical();
				podPanel.Add( nazivFilma );
				podPanel.Add( nazivSale );
				podPanel.Add( vreme );

				dugmici.BeginVertical(); 
				dugmici.BeginHorizontal();
				dugmici.Add( null , true , false );
				dugmici.Add( kupi );
				dugmici.Add( null , true , false );
				dugmici.EndHorizontal();

				dugmici.BeginHorizontal();
				dugmici.Add( null , true , false );
				dugmici.Add( vise );
				dugmici.Add( null , true , false );
				dugmici.EndHorizontal();
				dugmici.EndVertical();

				podPanel.Add( dugmici );
				podPanel.EndVertical();

				izdvajamoPanel.Add( podPanel );

			}
			izdvajamoPanel.EndVertical();

			najnovijePanel = new DynamicLayout(){
				Padding = new Padding ( 10 , 10 ),
				BackgroundColor = Color.FromArgb( 40 , 40 , 40 , 50 ),
				Spacing = new Size ( 10,10),
			};

			najnovijePanel.BeginVertical();
			for(int i = 0; i < listaProjekcijaPodaci.Count -1; i ++)
			{
				if ( i == Metode.VratiNasumicniInt( 0 , listaProjekcijaPodaci.Count ) )
					continue;

				Label nazivFilma = new Label{ Text="Назив филма: "+listaProjekcijaPodaci[i].Film.Naziv};
				Label nazivSale =  new Label{ Text ="Назив сале:  "+ listaProjekcijaPodaci[i].Sala.Naziv };
				Label vreme = 	   new Label{ Text = "Време:\t  "+listaProjekcijaPodaci[i].Vreme };
				Button kupi = 	   new Button{ Text = "Kупите карту" };
				Button vise =	   new Button{ Text = "Више информација" };
				var podPanel =	   new DynamicLayout ( ){ Spacing=new Size(10,10)};
				var dugmici = 	   new DynamicLayout{ Spacing=new Size(5,5) };

				kupi.Click += (sender, e) => KupiKartu(listaProjekcijaPodaci[i]) ;
				vise.Click += (sender, e) => PrikaziVise(listaProjekcijaPodaci[i]);

				podPanel.BeginVertical();
				podPanel.Add( nazivFilma );
				podPanel.Add( nazivSale );
				podPanel.Add( vreme );

				dugmici.BeginVertical(); 
				dugmici.BeginHorizontal();
				dugmici.Add( null , true , false );
				dugmici.Add( kupi );
				dugmici.Add( null , true , false );
				dugmici.EndHorizontal();

				dugmici.BeginHorizontal();
				dugmici.Add( null , true , false );
				dugmici.Add( vise );
				dugmici.Add( null , true , false );
				dugmici.EndHorizontal();
				dugmici.EndVertical();


				podPanel.Add( dugmici );
				podPanel.EndVertical();

				najnovijePanel.Add( podPanel );

			}
			najnovijePanel.EndBeginVertical();


			leviPanel = new DynamicLayout (){ 
				Spacing = new Size(10,10), 
				Padding = new Padding(10,10)
			};
			leviPanel.BeginVertical();
			leviPanel.Add( izdvajamoLabela );
			leviPanel.Add( separator );
			leviPanel.Add( izdvajamoPanel );
			leviPanel.Add( najnovijeLabela );
			leviPanel.Add( separator);
			leviPanel.Add( najnovijePanel );
			leviPanel.EndVertical();

			Scrollable scrollLeviPanel = new Scrollable{ Content = leviPanel, Size=new Size(400,500) };

			// try with table layout
			var mainPanel = new TableLayout(){
				Padding = new Padding(10), // padding around cells
				Spacing = new Size(5, 5), // spacing between each cell
				Rows = {
					new TableRow ( 
					              new TableCell(scrollLeviPanel),
					              new TableCell(desniPanel)
					             ) 
				}
			};

			panel = mainPanel;


		}

		public static Projekcijski VratiInstancu()
		{
			if ( instanca == null )
				instanca = new Projekcijski ();
	
			return instanca;
		}

		public TableLayout VratiPanel()
		{
			return instanca.panel;
		}

		public MenuBar VratiMeni()
		{
			return instanca.meni;
		}

		public Korisnik VratiKorisnika()
		{
			return prijavljeniKorisnik;
		}

		public void PostaviKorisnika(Korisnik k)
		{
			this.prijavljeniKorisnik = k;
		}


		private void PrikaziVise(Projekcija p )
		{
			Console.WriteLine(p);
			DynamicLayout layout = new DynamicLayout ( ){ Spacing = new Size(20,20), Padding=new Padding(10) };

			layout.BeginVertical (); // fields section
			layout.AddRow (new Label{ Text = "Назив филма: " + p.Film.Naziv } );
			layout.AddRow (new Label{ Text = "Жанр: \t  " + p.Film.GetZanr().ToString() });
			layout.AddRow (new Label{ Text = "Оцена: \t " + p.Film.Ocena });
			layout.AddRow (new Label{ Text = "Назив сале:  " + p.Sala.Naziv } );
			layout.AddRow (new Label{ Text = "Време:\t  " + p.Vreme });
			layout.AddRow (new Label{ Text = "Опис: \t " + p.Film.Opis });
			Button kupiKartu = new Button{ Text = "Kупите карту" };

			kupiKartu.Click += (sender, e) => KupiKartu(p);;
			layout.AddRow (null, kupiKartu , null);

			layout.EndVertical ();

			Dialog d = new Dialog ( ) {
				Content = layout
						
				
			};
			d.ShowModal();
		}

		private void KupiKartu(Projekcija p)
		{
			

			List<int> izabranaMesta = new List<int> ( );
			new Sedista ( p ).ShowModal( this );
		}
	}
}

