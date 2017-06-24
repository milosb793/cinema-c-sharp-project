using System;
using System.Collections.Generic;
using Bioskop;
using System.IO;


namespace bioskop
{
	
	public abstract class InicijalnoSejanje
	{


		public static void posejSve()
		{
			PosejKorisnike();
			PosejFilmove();
			PosejSale();
			PosejProjekcije();
			PosejKarte();
		}

		public static void PosejFilmove()
		{
			Console.WriteLine("Provera da li datoteka vec postoji:");
			if ( Serijalizacija.DaLiJePrazanFajl( Serijalizacija.FiDat ) )
			{
				Console.WriteLine( "Fajl ne postoji. Kreira se..." );
			}
			else
			{
				Console.WriteLine("Fajl postoji, prebrisace se...");
			}
			Console.WriteLine( "Upisivanje u datoteku: \n" );

			try{
					
				List<Film> lista = new List<Film> ( )
				{ 
					new Film("Film 1",Zanr.animirani,"Sed vel ligula volutpat, molestie metus sit amet, ultrices lorem. Proin vel risus eleifend, cursus sem id, aliquam nibh. Curabitur placerat mi felis, et porta risus gravida vitae. In eu ullamcorper quam. Nam nec ligula ac purus auctor laoreet. Vivamus at sodales arcu. Aliquam accumsan imperdiet ligula. ",8.4F),
					new Film("Film 2",Zanr.crtac," Aliquam quis felis a sem posuere finibus dignissim ac urna. Cras eget egestas libero. Aenean sed orci et sapien ullamcorper gravida. ",8.5F),
					new Film("Film 3",Zanr.drama,"Sed nunc libero, interdum sed efficitur vitae, vehicula ac arcu. Curabitur efficitur lorem quis viverra cursus. Donec eget rutrum lacus, nec lacinia tortor. ",5.5F),
					new Film("Film 4",Zanr.triler,"Nullam consequat dignissim iaculis. Fusce ultrices vitae velit vel luctus. Vivamus id elementum orci, nec feugiat velit.",7.5F),
					new Film("Film 5",Zanr.akcija,"Proin eget elit et orci placerat fermentum facilisis lacinia libero. Nunc vel ultricies urna. Sed sagittis quam sit amet est vestibulum varius. ",6F)
//
				};

				Serijalizacija.WriteListToBinaryFile<Film>( Serijalizacija.FiDat , lista , false );

			}
			catch(Exception e){
				Console.WriteLine(e.ToString());
			}

		}


		public static void PosejSale()
		{
		
			try{
				List<Sala> lista = new List<Sala> ( )
				{ 
					new Sala("Sala 1", 5,10),
					new Sala("Sala 2", 5,9),
					new Sala("Sala 3", 5,7),
					new Sala("Sala 4", 5,11),
					new Sala("Sala 5", 5,9)
				};

				Console.WriteLine("Provera da li datoteka vec postoji:");
				if ( Serijalizacija.DaLiJePrazanFajl( Serijalizacija.SaDat ) )
				{
					Console.WriteLine( "Fajl ne postoji. Kreira se..." );
				}
				else
				{
					Console.WriteLine("Fajl postoji, prebrisace se...");
				}
				Console.WriteLine( "Upisivanje u datoteku: \n" );
				Serijalizacija.WriteListToBinaryFile<Sala>( Serijalizacija.SaDat , lista , false );

			}catch(Exception e){
				Console.WriteLine(	e.ToString());
			}
		}


		public static void PosejProjekcije()
		{
			try
			{
				List<Film> listaFilmova = Film.Svi();
				List<Sala> listaSala = Sala.Sve(); 


				List<Projekcija> lista = new List<Projekcija> ( )
				{ 
					new Projekcija(listaFilmova[Metode.VratiNasumicniInt(0,listaFilmova.Count-1)], listaSala[Metode.VratiNasumicniInt(0,listaSala.Count-1)], DateTime.Now.ToString("f")),
					new Projekcija(listaFilmova[Metode.VratiNasumicniInt(0,listaFilmova.Count-1)], listaSala[Metode.VratiNasumicniInt(0,listaSala.Count-1)], DateTime.Now.ToString("f")),
					new Projekcija(listaFilmova[Metode.VratiNasumicniInt(0,listaFilmova.Count-1)], listaSala[Metode.VratiNasumicniInt(0,listaSala.Count-1)], DateTime.Now.ToString("f")),
					new Projekcija(listaFilmova[Metode.VratiNasumicniInt(0,listaFilmova.Count-1)], listaSala[Metode.VratiNasumicniInt(0,listaSala.Count-1)], DateTime.Now.ToString("f")),
					new Projekcija(listaFilmova[Metode.VratiNasumicniInt(0,listaFilmova.Count-1)], listaSala[Metode.VratiNasumicniInt(0,listaSala.Count-1)], DateTime.Now.ToString("f"))

				};

				Console.WriteLine("Provera da li datoteka vec postoji:");
				if ( Serijalizacija.DaLiJePrazanFajl( Serijalizacija.PrDat ) )
				{
					Console.WriteLine( "Fajl ne postoji. Kreira se..." );
				}
				else
				{
					Console.WriteLine("Fajl postoji, prebrisace se...");
				}
				Console.WriteLine( "Upisivanje u datoteku: \n" );
				Serijalizacija.WriteListToBinaryFile<Projekcija>( Serijalizacija.PrDat , lista , false );

			}
			catch ( Exception ex )
			{
				Console.WriteLine(ex.ToString());
			}

		}


		public static void PosejKarte()
		{

			try
			{
				List<Projekcija> listaProjekcija = Projekcija.Sve();
				List<Korisnik> listaKorisnika = Korisnik.Svi();



				List<Karta> lista = new List<Karta> ( )
				{ 
					
//					new Karta(listaProjekcija[Metode.VratiNasumicniInt(0,listaProjekcija.Count-1)].ProjekcijaId, listaKorisnika[Metode.VratiNasumicniInt(0,listaKorisnika.Count-1)].KorisnikId, Metode.VratiNasumicniInt(300,700), Metode.VratiNasumicniInt(0,5), Metode.VratiNasumicniInt(0,10)),
//					new Karta(listaProjekcija[Metode.VratiNasumicniInt(0,listaProjekcija.Count-1)].ProjekcijaId, listaKorisnika[Metode.VratiNasumicniInt(0,listaKorisnika.Count-1)].KorisnikId, Metode.VratiNasumicniInt(300,700), Metode.VratiNasumicniInt(0,5), Metode.VratiNasumicniInt(0,10)),
//					new Karta(listaProjekcija[Metode.VratiNasumicniInt(0,listaProjekcija.Count-1)].ProjekcijaId, listaKorisnika[Metode.VratiNasumicniInt(0,listaKorisnika.Count-1)].KorisnikId, Metode.VratiNasumicniInt(300,700), Metode.VratiNasumicniInt(0,5), Metode.VratiNasumicniInt(0,10)),
//					new Karta(listaProjekcija[Metode.VratiNasumicniInt(0,listaProjekcija.Count-1)].ProjekcijaId, listaKorisnika[Metode.VratiNasumicniInt(0,listaKorisnika.Count-1)].KorisnikId, Metode.VratiNasumicniInt(300,700), Metode.VratiNasumicniInt(0,5), Metode.VratiNasumicniInt(0,10)),
//					new Karta(listaProjekcija[Metode.VratiNasumicniInt(0,listaProjekcija.Count-1)].ProjekcijaId, listaKorisnika[Metode.VratiNasumicniInt(0,listaKorisnika.Count-1)].KorisnikId, Metode.VratiNasumicniInt(300,700), Metode.VratiNasumicniInt(0,5), Metode.VratiNasumicniInt(0,10))
//
//
					new Karta(listaProjekcija[Metode.VratiNasumicniInt(0,listaProjekcija.Count-1)].ProjekcijaId, listaKorisnika[0].KorisnikId, Metode.VratiNasumicniInt(300,700), Metode.VratiNasumicniInt(0,5), Metode.VratiNasumicniInt(0,10)),
					new Karta(listaProjekcija[Metode.VratiNasumicniInt(0,listaProjekcija.Count-1)].ProjekcijaId, listaKorisnika[0].KorisnikId, Metode.VratiNasumicniInt(300,700), Metode.VratiNasumicniInt(0,5), Metode.VratiNasumicniInt(0,10)),
					new Karta(listaProjekcija[Metode.VratiNasumicniInt(0,listaProjekcija.Count-1)].ProjekcijaId, listaKorisnika[0].KorisnikId, Metode.VratiNasumicniInt(300,700), Metode.VratiNasumicniInt(0,5), Metode.VratiNasumicniInt(0,10)),
					new Karta(listaProjekcija[Metode.VratiNasumicniInt(0,listaProjekcija.Count-1)].ProjekcijaId, listaKorisnika[0].KorisnikId, Metode.VratiNasumicniInt(300,700), Metode.VratiNasumicniInt(0,5), Metode.VratiNasumicniInt(0,10)),
					new Karta(listaProjekcija[Metode.VratiNasumicniInt(0,listaProjekcija.Count-1)].ProjekcijaId, listaKorisnika[0].KorisnikId, Metode.VratiNasumicniInt(300,700), Metode.VratiNasumicniInt(0,5), Metode.VratiNasumicniInt(0,10))

				};

				Console.WriteLine("Provera da li datoteka vec postoji:");

				if ( Serijalizacija.DaLiJePrazanFajl( Serijalizacija.KaDat ) ){
					Console.WriteLine( "Fajl ne postoji. Kreira se..." );
				}
				else{
					Console.WriteLine("Fajl postoji, prebrisace se...");
				}

				Console.WriteLine( "Upisivanje u datoteku: \n" );
				Serijalizacija.WriteListToBinaryFile<Karta>( Serijalizacija.KaDat , lista , false );

			}
			catch ( Exception ex ){
				Console.WriteLine(ex.ToString());
			}
		}

		public static void PosejKorisnike()
		{
			try
			{
				List<Korisnik> lista = new List<Korisnik> ( )
				{ 
					new Korisnik ("admin", "pass", 1, "Administrator"),
					new Korisnik ("korisnik1", "pass", 2, "Ime1 Prezime1"),
					new Korisnik("korisnik2","pass",2,"Ime2 Prezime2")
				};

				Console.WriteLine("Provera da li datoteka vec postoji:");
				if ( Serijalizacija.DaLiJePrazanFajl( Serijalizacija.KoDat ) ){
					Console.WriteLine( "Fajl ne postoji. Kreira se..." );
				}
				else{
					Console.WriteLine("Fajl postoji, prebrisace se...");
				}

				Console.WriteLine( "Upisivanje u datoteku: \n" );
				Serijalizacija.WriteListToBinaryFile<Korisnik>( Serijalizacija.KoDat , lista , false );
			}
			catch ( Exception ex ){
				Console.WriteLine(ex.ToString());
			}
		}
	}
}

