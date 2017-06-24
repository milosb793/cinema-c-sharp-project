using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using System.Diagnostics;
using bioskop;
using Bioskop;
using Eto;
using System.Threading;

namespace bioskop
{
	// TODO: refaktirizuj klasu; preimenuj, nazovi GLavniProzor; prijavljivanje napravi u odvojeni panel.
	
	public class Prijavljivanje : Form
	{
		private  Label korImeLabela;
		private  Label passLabela;
		private  TextBox korImePolje;
		private  PasswordBox passPolje;

		private  Command prijaviSe;
		private  Command ponisti;

		private  StackLayout glavniPanel;

		public static Prijavljivanje instanca = new Prijavljivanje();

		// za admina /// <summary>
		/// Initializes a new instance of the <see cref="bioskop.Prijavljivanje"/> class.
		/// </summary>
		// dodaj //
		private  Command dodajFilm;
		private  Command dodajSalu;
		private  Command dodajProjekciju; 
		// izmeni 

		private  Command izmeniProjekciju;
		private  Command izmeniSalu;
		private  Command izmeniFilm;

		// obrisi 
		private  Command obrisiProjekciju;
		private  Command obrisiSalu;
		private  Command obrisiFilm;

		// odjavljivanje 
		private  Command odjaviSe;
		private Command registrujSe;

		// prikazi
		private  Command prikaziFilm;
		private  Command prikaziProjekciju;
		private  Command prikaziKartu;
		private  Command prikaziSalu;
		private  Command prikaziKorisnika;

		// statistika
		private Command statistika;
		private MenuBar menu;

		private Korisnik prijavljeniKorisnik;

		private Label separator;

		public Prijavljivanje ( )
		{

			InitializeComponents();


			
		}
			

		public  void InitializeComponents()
		{
			Title = "Prijavljivanje";
			//this.Closed += (sender , e ) => MessageBox.Show("");
			//Menu = Administratorski.VratiInstancu().VratiMeni();

			// kontrole
			korImeLabela = new Label{ 
				Text="Kорисничко име:"
			};
			passLabela = new Label{ 
				Text="Лозинка:"
			};
			korImePolje = new TextBox { 
				Text = "korisnik1",
				ToolTip = "Proba",
				PlaceholderText = "", 
				TextColor=Eto.Drawing.Color.Parse("gray")
			} ;
			passPolje = new PasswordBox { 
				Text = "pass",
				PasswordChar = '*', 
				TextColor=Eto.Drawing.Color.Parse("gray")
			};

			separator = new Label{Text="\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", 
				Font = new Font(SystemFont.Default,10, FontDecoration.Strikethrough)
			};

			// dugmici
			//delegati i dogadjaji
			prijaviSe = new Command { 
				MenuText = "Пријави се",
				ToolBarText = "Пријави се"
			};
			ponisti = new Command { 
				MenuText = "Поништи",
				ToolBarText = "Поништи"
			};

			ponisti.Executed += (sender , e ) =>  Close();
			prijaviSe.Executed += (sender , e ) => procesuirajPrijavu();
			prijaviSe.Shortcut = Keys.Enter;
			ponisti.Shortcut = Keys.Control | Keys.C;
			Button prijaviSeBtn = new Button { Text = "Пријави се", Command = prijaviSe };
			Button ponistiBtn = new Button { Text = "Поништи", Command = ponisti };


			var buttons = new DynamicLayout {
				Padding = new Padding(5,5),
				Spacing = new Size(10,10)
			};
			buttons.BeginHorizontal();
			buttons.BeginHorizontal();
			buttons.Add( prijaviSeBtn );
			buttons.Add( ponistiBtn );
			buttons.EndHorizontal();
			buttons.EndVertical();


			glavniPanel = new StackLayout {
				Spacing = 10,
				Padding = 5,
				Orientation = Orientation.Vertical,
				Items = {
					new StackLayoutItem(korImeLabela,VerticalAlignment.Center),
					new StackLayoutItem(korImePolje,VerticalAlignment.Center),
					new StackLayoutItem(passLabela,VerticalAlignment.Center),
					new StackLayoutItem(passPolje,VerticalAlignment.Center),
					new StackLayoutItem ( buttons , HorizontalAlignment.Center )
				}
			};

			Content = glavniPanel;


			// stavke menija 
			dodajProjekciju = new Command{
				MenuText = "3. Додај пројекцију",
				ToolBarText = "3. Додај пројекцију",
				// komanda za izvrsenje
			};

			dodajSalu = new Command{
				MenuText = "2. Додај салу",
				ToolBarText = "2. Додај салу",
				// komanda za izvrsenje

			};

			dodajFilm = new Command{
				MenuText = "1. Додај филм",
				ToolBarText = "1. Додај филм",
				// komanda za izvrsenje

			};
			// izmena 

			izmeniProjekciju = new Command{
				MenuText = "3. Измени пројекцију",
				ToolBarText = "3. Измени пројекцију",
				// komanda za izvrsenje
			};

			izmeniSalu = new Command{
				MenuText = "2. Измени салу",
				ToolBarText = "2. Измени салу",
				// komanda za izvrsenje

			};

			izmeniFilm = new Command{
				MenuText = "1. Измени филм",
				ToolBarText = "1. Измени филм",
				// komanda za izvrsenje

			};

			// obrisi 
			obrisiProjekciju = new Command{
				MenuText = "3. Обриши пројекцију",
				ToolBarText = "3. Обриши пројекцију",
				// komanda za izvrsenje
			};

			obrisiSalu = new Command{
				MenuText = "2. Обриши салу",
				ToolBarText = "2. Обриши салу",
				// komanda za izvrsenje

			};

			obrisiFilm = new Command{
				MenuText = "1. Обриши филм",
				ToolBarText = "1. Обриши филм",
				// komanda za izvrsenje

			};

			odjaviSe = new Command{
				MenuText = "Одјави се",
				ToolBarText = "Одјави се",
				// komanda za izvrsenje

			};

			registrujSe = new Command{
				MenuText = "Региструј се",
				ToolBarText = "Региструј се",
				ToolTip = "Ако нисте корисник, морате се прво регистровати."
				// komanda za izvrsenje
			};

			statistika = new Command{
				MenuText = "Статистика",
				ToolTip = "Статистика",
				// komanda za izvrsenje

			};

			// prikazivanje
			prikaziFilm = new Command{
				MenuText = "Прикажи филмове",
				ToolTip = "Прикажи филмове",
				// komanda za izvrsenje

			};

			prikaziProjekciju = new Command{
				MenuText = "Прикажи пројекције",
				ToolTip = "Прикажи пројекције",
				// komanda za izvrsenje

			};
			prikaziKartu  = new Command{
				MenuText = "Прикажи карте",
				ToolTip = "Прикажи карте",
				// komanda za izvrsenje

			};
			prikaziSalu  = new Command{
				MenuText = "Прикажи сале",
				ToolTip = "Прикажи сале",
				// komanda za izvrsenje

			};
			prikaziKorisnika  = new Command{
				MenuText = "Прикажи кориснике",
				ToolTip = "Прикажи кориснике",
				// komanda za izvrsenje

			};


			// komande
			odjaviSe.Executed += (sender, e) => { 
				Prijavljivanje.instanca = new Prijavljivanje();
				Content = Prijavljivanje.instanca.glavniPanel;
				Menu = new MenuBar();
				ToolBar = inicijalizujTulBar();
				// TODO: sredi meni kad se odjavi admin
			};

			dodajFilm.Executed += (sender, e) => {
				new DodavanjeFilma().ShowModal(this);
			};

			dodajSalu.Executed += (sender, e) => {
				new DodavanjeSale().ShowModal(this);
			};

			dodajProjekciju.Executed += (sender, e) => {
				new DodavanjeProjekcije().ShowModal(this);
			};

			izmeniFilm.Executed += (sender, e) => {
				new IzmenaFilma().ShowModal(this);
			};

			izmeniSalu.Executed += (sender, e) => {
				new IzmenaSale().ShowModal(this);
			};

			izmeniProjekciju.Executed += (sender, e) => {
				new IzmenaProjekcije().ShowModal(this);
			};

			obrisiFilm.Executed += (sender, e) => {
				new ObrisiFilm().ShowModal(this);
			};

			obrisiSalu.Executed += (sender, e) => {
				new ObrisiSalu().ShowModal(this);
			};

			obrisiProjekciju.Executed += (sender, e) => {
				new ObrisiProjekciju().ShowModal(this);
			};

			registrujSe.Executed += (sender, e) => {
				new Registracija().ShowModal(this);
			};
				
			prikaziFilm.Executed += (sender, e) => PrikaziSveFilmove();
			prikaziProjekciju.Executed += (sender, e) => PrikaziSveProjekcije();
			prikaziKartu.Executed += (sender, e) => PrikaziSveKarte();
			prikaziSalu.Executed += (sender, e) => PrikaziSveSale();
			prikaziKorisnika.Executed += (sender, e) => PrikaziSveKorisnike();

			ToolBar = inicijalizujTulBar();

			//meni 
			menu = inicijalizujAdminMeni();
			Content.Width = 400;
			Content.Height = 150;

		}

		private MenuBar inicijalizujAdminMeni ()
		{
			MenuBar mb = new MenuBar {
				Items = {
					// File submenu
					new ButtonMenuItem { Text = "&Додај", Items = { this.dodajFilm, this.dodajSalu,this.dodajProjekciju } },
					new ButtonMenuItem { Text = "&Измени", Items = { this.izmeniFilm, this.izmeniSalu, this.izmeniProjekciju } },
					new ButtonMenuItem { Text = "&Обриши", Items = { this.obrisiFilm, this.obrisiSalu, this.obrisiProjekciju } },
					new ButtonMenuItem { Text = "&Прикажи", Items = { this.prikaziFilm, this.prikaziProjekciju, this.prikaziKartu, this.prikaziSalu, new SeparatorMenuItem(), this.prikaziKorisnika } },
					this.statistika,
					this.odjaviSe
				},

			};
			return mb;
		}

		private ToolBar inicijalizujTulBar ()
		{
			var toolbar = new ToolBar{
				TextAlign = ToolBarTextAlign.Right,
				Items = {
					new ButtonToolItem(registrujSe)
				}
			};
			return toolbar;
		}

		private  void procesuirajPrijavu()
		{
			string korIme = korImePolje.Text;
			string lozinka = passPolje.Text;

			// provera 
			if ( Metode.ProveriDuzinu( korIme , 3 , 10 ) && Metode.ProveriDuzinu( lozinka , 3 , 10 ) )
			{
				prijavljeniKorisnik = Korisnik.ulogujSe( korIme , lozinka );

				if ( prijavljeniKorisnik != null && prijavljeniKorisnik.Tip == Korisnik.ADMIN )
				{
					ToolBar = new ToolBar ( );

					// TODO: popravi uklanjanje 
					Menu = inicijalizujAdminMeni();
					Menu.Dispose();

					glavniPanel.Content = Administratorski.VratiInstancu().VratiPanel();
					Administratorski.VratiInstancu().PostaviKorIme( prijavljeniKorisnik.KorIme );
					this.ClientSize = new Size ( 700 , 500 );
					glavniPanel.BackgroundColor = Color.FromArgb( 240 , 240 , 240 , 50 );
				}
				else if(prijavljeniKorisnik != null && prijavljeniKorisnik.Tip == Korisnik.KOR)
				{
					ToolBar = new ToolBar ( );

					// TODO: popravi uklanjanje 
					menu.Items.Clear();
					Menu = Projekcijski.VratiInstancu().VratiMeni();
					//Menu.Dispose();

					Projekcijski.VratiInstancu().PostaviKorisnika(prijavljeniKorisnik);
					glavniPanel.Content = Projekcijski.VratiInstancu().VratiPanel();
					this.ClientSize = new Size ( 700 , 500 );
					glavniPanel.BackgroundColor = Color.FromArgb( 240 , 240 , 240 , 50 );
				}
			}
			else
			{
				promeniBojePolja();
			}

	

		}

		/**
		 * Menjanje boje polja
		 * */
		private  void promeniBojePolja()
		{
			if ( korImePolje.TextColor == Eto.Drawing.Color.Parse("gray") )
			{
				korImePolje.TextColor = Eto.Drawing.Color.FromArgb( 200 , 0 , 0 , 255 );
				passPolje.TextColor = Eto.Drawing.Color.FromArgb( 200 , 0 , 0 , 255 );
			}
			else
			{
				korImePolje.TextColor = Eto.Drawing.Color.FromArgb( 0 , 0 , 0 , 255 );
				passPolje.TextColor = Eto.Drawing.Color.FromArgb( 0, 0 , 0 , 255 );	
			}
		}

		/**
		 * Vracanje glavnog panela 
		 * */
		public StackLayout VratiPanel()
		{
			if ( instanca.glavniPanel == null )
				instanca = new Prijavljivanje ( );
			return instanca.glavniPanel;
		}

		/**
		 * Vracanje instance prijavljenog korisnika
		 * */
		public Korisnik VratiPrijavljenogKorisnika()
		{
			return prijavljeniKorisnik;
		}
			
		/**
		 * Prikaz svih filmova
		 * */
		private void PrikaziSveFilmove()
		{
			List<Film> sviFilmoviPodaci = Film.Svi();

			var layout = new DynamicLayout ( ){ Spacing = new Size(15,15), Padding = new Padding(15,15)};
			DynamicLayout podLayout;
			Label naslov,nazivLabela, opisLabela, zanrLabela, ocenaLabela;

			naslov = new Label{ Text = "Сви филмови", Font = new Font ( SystemFont.Bold , 14 ) };

			layout.BeginVertical(new Padding(10),new Size(10,10),false, true);
			layout.Add( naslov );
			layout.Add( separator );

			foreach ( var item in sviFilmoviPodaci )
			{
				nazivLabela = new Label{ Text=String.Format("{0,-15} {1,-15}","Назив: ",item.Naziv) };
				opisLabela =  new Label{ Text=String.Format("{0,-15} {1,-15}","Опис: ",item.Naziv) };
				zanrLabela =  new Label{ Text=String.Format("{0,-15} {1,-15}","Жанр: ",item.GetZanr().ToString()) };
				ocenaLabela = new Label{ Text=String.Format("{0,-15} {1,-15}","Оцена: ",item.Ocena.ToString()) };

				podLayout = new DynamicLayout(){ Spacing = new Size(5,5), Padding = new Padding(5,5)};
				podLayout.BeginVertical(new Padding(5),new Size(5,5),false, true);
					podLayout.Add( nazivLabela );
					podLayout.Add( opisLabela );
					podLayout.Add( zanrLabela );
					podLayout.Add( ocenaLabela );
				podLayout.EndVertical();
				podLayout.BackgroundColor = Color.FromArgb( 10 , 10 , 10 , 10 );
				layout.Add( podLayout );
				layout.Add( null );
			}
			layout.EndVertical();

			Scrollable scrPanel = new Scrollable ( ){ Border = BorderType.Line };

			scrPanel.Content = layout;
			glavniPanel.Content = scrPanel;

			this.ClientSize = new Size(900,600);

		}

		private void PrikaziSveProjekcije()
		{
			List<Projekcija> sveProjekcijePodaci = Projekcija.Sve();

			var layout = new DynamicLayout ( ){ Spacing = new Size(15,15), Padding = new Padding(15,15)};
			DynamicLayout podLayout;
			Label naslov,nazivFilmaLabela, nazivSaleLabela, vremeLabela;

			naslov = new Label{ Text = "Све пројекције:", Font = new Font ( SystemFont.Bold , 14 ) };

			layout.BeginVertical(new Padding(10),new Size(10,10),false, true);
			layout.Add( naslov );
			layout.Add( separator );

			foreach ( var item in sveProjekcijePodaci )
			{ 
				nazivFilmaLabela =  new Label{ Text=String.Format("{0,-15} {1,-15}","Назив филма: ",item.Film.Naziv) };
				nazivSaleLabela =   new Label{ Text=String.Format("{0,-15} {1,-15}","Назив сале: ",item.Sala.Naziv) };
				vremeLabela = 		new Label{ Text=String.Format("{0,-15} {1,-15}","Време пројекције: ",item.Vreme) };

				podLayout = new DynamicLayout(){ Spacing = new Size(5,5), Padding = new Padding(5,5)};
				podLayout.BeginVertical(new Padding(5),new Size(5,5),false, true);
					podLayout.Add( nazivFilmaLabela );
					podLayout.Add( nazivSaleLabela );
					podLayout.Add( vremeLabela );
				podLayout.EndVertical();
				podLayout.BackgroundColor = Color.FromArgb( 10 , 10 , 10 , 10 );
				layout.Add( podLayout );
				layout.Add( null );
			}
			layout.EndVertical();

			Scrollable scrPanel = new Scrollable ( );

			scrPanel.Content = layout;
			glavniPanel.Content = scrPanel;

			this.ClientSize = new Size(900,600);
		}

		private void PrikaziSveKarte()
		{
			List<Karta> sveKartePodaci = Karta.Sve();

			var layout = new DynamicLayout ( ){ Spacing = new Size(15,15), Padding = new Padding(15,15)};
			DynamicLayout podLayout;
			Label naslov, nazivFilmaLabela,
				  nazivSaleLabela, korisnikImePrezLabela, 
				  vremeLabela, redISedisteLabela, cenaLabela;

			naslov = new Label{ Text = "Све карте:", Font = new Font ( SystemFont.Bold , 14 ) };

			layout.BeginVertical(new Padding(10),new Size(10,10),false, true);
			layout.Add( naslov );
			layout.Add( separator );

			foreach ( var item in sveKartePodaci )
			{
				nazivFilmaLabela =	    new Label{ Text=String.Format("{0,-15} {1,-15}","Назив филма: ",     item.Projekcija.Film.Naziv) };
				nazivSaleLabela = 		new Label{ Text=String.Format("{0,-15} {1,-15}","Назив сале: ",		 item.Projekcija.Sala.Naziv) };
				vremeLabela = 			new Label{ Text=String.Format("{0,-15} {1,-15}","Време пројекције: ",item.Projekcija.Vreme) };
				korisnikImePrezLabela = new Label{ Text=String.Format("{0,-15} {1,-15}","Kупац:",			 item.Kupac.ImePrezime) };
				redISedisteLabela = 	new Label{ Text=String.Format("{0,-15} {1,-15}","Место: (ред: ",     item.Red + ", сед.: " + item.Sediste + ") ") };
				cenaLabela = 		    new Label{ Text=String.Format("{0,-15} {1,-15}","Цена: ",			 item.Cena.ToString()) };

				podLayout = new DynamicLayout(){ Spacing = new Size(5,5), Padding = new Padding(5,5)};
				podLayout.BeginVertical(new Padding(5),new Size(5,5),false, true);
					podLayout.Add( nazivFilmaLabela );
					podLayout.Add( nazivSaleLabela );
					podLayout.Add( korisnikImePrezLabela );
					podLayout.Add( redISedisteLabela );
					podLayout.Add( cenaLabela );
				podLayout.EndVertical();
				podLayout.BackgroundColor = Color.FromArgb( 10 , 10 , 10 , 10 );
				layout.Add( podLayout );
				layout.Add( null );
			}
			layout.EndVertical();

			Scrollable scrPanel = new Scrollable ( );

			scrPanel.Content = layout;
			glavniPanel.Content = scrPanel;

			this.ClientSize = new Size(900,600);
		}

		private void PrikaziSveSale()
		{
			List<Sala> sveSalePodaci = Sala.Sve();

			var layout = new DynamicLayout ( ){ Spacing = new Size(15,15), Padding = new Padding(15,15)};
			DynamicLayout podLayout;
			Label naslov,nazivSaleLabela, ukupnoMestaLabela, ukupnoRedova, ukupnoSedista;

			naslov = 	new Label{ Text = "Све сале:", Font = new Font ( SystemFont.Bold , 14 ) };

			layout.BeginVertical(new Padding(10),new Size(10,10),false, true);

			layout.Add( naslov );
			layout.Add( separator );

			foreach ( var item in sveSalePodaci )
			{
				nazivSaleLabela = 	new Label{ Text=String.Format("{0,-15} {1,-15}","Назив сале: ",item.Naziv) };
				ukupnoMestaLabela = new Label{ Text=String.Format("{0,-15} {1,-15}","Укупно места: ",item.UkupnoMesta) };
				ukupnoRedova =  	new Label{ Text=String.Format("{0,-15} {1,-15}","Укупно редова: ",item.Redova) };
				ukupnoSedista = 	new Label{ Text=String.Format("{0,-15} {1,-15}","Седишта по реду: ",item.SedistaPoRedu) };

				podLayout = new DynamicLayout(){ Spacing = new Size(5,5), Padding = new Padding(5,5)};
				podLayout.BeginVertical(new Padding(5),new Size(5,5),false, true);
					podLayout.Add( nazivSaleLabela );
					podLayout.Add( ukupnoMestaLabela );
					podLayout.Add( ukupnoRedova );
					podLayout.Add( ukupnoSedista );
				podLayout.EndVertical();
				podLayout.BackgroundColor = Color.FromArgb( 10 , 10 , 10 , 10 );
				layout.Add( podLayout );
				layout.Add( null );
			}
			layout.EndVertical();

			Scrollable scrPanel = new Scrollable ( );

			scrPanel.Content = layout;
			glavniPanel.Content = scrPanel;

			this.ClientSize = new Size(900,600);
		}

		private void PrikaziSveKorisnike()
		{

			List<Korisnik> sviKorisniciPodaci = Korisnik.Svi();

			var layout = new DynamicLayout ( ){ Spacing = new Size(15,15), Padding = new Padding(15,15)};
			DynamicLayout podLayout;
			Label naslov,imePrezimeLabela, korImeLabela, tipKorisnikaLabela;

			naslov = 	new Label{ Text = "Сви корисници: ", Font = new Font ( SystemFont.Bold , 14 ) };

			layout.BeginVertical(new Padding(10),new Size(10,10),false, true);

			layout.Add( naslov );
			layout.Add( separator );

			foreach ( var item in sviKorisniciPodaci )
			{
				imePrezimeLabela = 	 new Label{ Text=String.Format("{0,-15} {1,-15}","Име и презиме: ",item.ImePrezime) };
				korImeLabela = 		 new Label{ Text=String.Format("{0,-15} {1,-15}","Кор. име: "	  ,item.KorIme) };
				tipKorisnikaLabela = new Label{ Text=String.Format("{0,-15} {1,-15}","Тип корисника: ",item.Tip == 1 ? "Админ":"Купац") };


				podLayout = new DynamicLayout(){ Spacing = new Size(5,5), Padding = new Padding(5,5)};
				podLayout.BeginVertical(new Padding(5),new Size(5,5),false, true);
					podLayout.Add( imePrezimeLabela );
					podLayout.Add( korImeLabela );
					podLayout.Add( tipKorisnikaLabela );
				podLayout.EndVertical();
				podLayout.BackgroundColor = Color.FromArgb( 10 , 10 , 10 , 10 );
				layout.Add( podLayout );
				layout.Add( null );
			}
			layout.EndVertical();

			Scrollable scrPanel = new Scrollable ( );

			scrPanel.Content = layout;
			glavniPanel.Content = scrPanel;

			this.ClientSize = new Size(900,600);
		}

	}

}


