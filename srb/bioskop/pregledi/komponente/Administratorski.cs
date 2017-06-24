using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Bioskop;


namespace bioskop
{
	public partial class Administratorski : Form
	{

		// kontrole //
		private Label dobroDosliLabela;
		private Label sadrzajLabela;

		private Label separator;


		// layout //
		private DynamicLayout sadrzaj;

		// kontejner //
		private Panel panel;


		// create menu
		private  MenuBar menu;


		// singleton
		private static Korisnik prijavljeniKorisnik;
		private static Administratorski instanca = new Administratorski();

		
		private Administratorski ()
		{
			InitializeComponents();
		}

		public Panel VratiPanel ()
		{
			// TODO: Opcionalno: uradi opciju dodavanja admina 
			return panel;
		}

		public void InitializeComponents()
		{
			// kontrole
			separator = new Label{Text="\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", 
				Font = new Font(SystemFont.Default,10, FontDecoration.Strikethrough)
			};
		
			dobroDosliLabela = new Label {
				Text = "Добро дошли назад, "  };

			sadrzajLabela = new Label{
				Text="Изаберите неку од опција у менијима. "
			};


			dobroDosliLabela.Font = new Font ( SystemFont.Bold , 14.0F );

			// layout
			sadrzaj = new DynamicLayout(){ Spacing = new Size(10,10)};
			sadrzaj.BeginVertical(new Padding(10,10), new Size(5,5));
			sadrzaj.Add( dobroDosliLabela);
			sadrzaj.Add( separator);
			sadrzaj.Add( sadrzajLabela );

			sadrzaj.Add(null,true,true);
			

			// panel
			panel = new Panel();

			panel.Content = sadrzaj;

			//Content = panel;
		}


//		public MenuBar VratiMeni()
//		{ 
////			if ( instanca == null )
////			{
////				instanca.InitializeComponents();
////				Console.WriteLine("Instanca je null");
////			}
////			
////			return instanca.menu;
//
//			if ( menu == null )
//				InitializeComponents();
//			return menu;
//		}

		public static Administratorski VratiInstancu( )
		{
			if ( instanca == null )
				instanca = new Administratorski ( );
			return instanca;
		}


		public void PostaviKorIme(string korIme)
		{
			this.dobroDosliLabela.Text = "Добро дошли назад, " + korIme;
		}



	}
}

