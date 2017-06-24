using System;
using Bioskop;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;


namespace Bioskop
{
	[Serializable]
	public class Korisnik
	{
		private int    _korisnikId;
		private string _korIme;
		private string _lozinka;
		private int    _tip;
		private string _imePrezime;
		private static List<int> lista_id = InicijalizujListuId();

		public const int ADMIN = 1;
		public const int KOR = 2;



		/**
		 * Konstruktori
		 * */
		public Korisnik ()
		{
			this._korisnikId = Metode.dobaviId(ref lista_id);
			this._imePrezime = "";
			this._korIme = "";
			this._lozinka = "";
		}

		public Korisnik (string korIme, string lozinka, int tip, string imePrezime)
		{
			this._korisnikId =  Metode.dobaviId(ref lista_id);
			this._korIme = korIme;
			this._lozinka = lozinka;
			this._tip = tip;
			this._imePrezime = imePrezime;
		}



		/**
		 * Geteri i seteri
		 * */

		public int KorisnikId {
			get {
				return this._korisnikId;
			}
		}

		public string KorIme {
			get {
				return this._korIme;
			}
			set {
				_korIme = value;
			}
		}

		public string Lozinka {
			get {
				return this._lozinka;
			}
			set {
				_lozinka = value;
			}
		}

		public int Tip {
			get {
				return this._tip;
			}
			set {
				_tip = value;
			}
		}

		public string ImePrezime {
			get {
				return this._imePrezime;
			}
			set {
				_imePrezime = value;
			}
		}

		/**
		 * Kloniranje objekta
		 * */
		public Korisnik Clone()
		{
			return new Korisnik ( this._korIme, this._lozinka, this._tip, this._imePrezime);
		}


		/**
		 * Metode
		 * */
		public static bool proveriDaLiPostoji(string korIme, string lozinka, out Korisnik k)
		{
			List<Korisnik> sviKorisnici = Svi();
			foreach(Korisnik korisnik in sviKorisnici)
			{
				if (String.Compare(korisnik.KorIme.Trim(),korIme,false) == 0 && String.Compare(korisnik.Lozinka.Trim(),lozinka,false) == 0 )  
				{
					k = korisnik.Clone ();
					return true;
				}
			}
			k = null;
			return false;
		}

		public static Korisnik ulogujSe(string korIme, string lozinka)
		{
			Korisnik k = null;

			if (!proveriDaLiPostoji (korIme, lozinka,out k)) 
			{
				//MessageBox.Show("Korisnik sa tim kredencijalima ne postoji!", MessageBoxType.Information);
				Console.WriteLine("Korisnik sa tim kredencijalima ne postoji!");
			}
			//MessageBox.Show("Uspesno ste se ulogovali!", MessageBoxType.Information);
			Console.WriteLine("Uspesno ste se ulogovali!");
			return k;
		}

		public override string ToString ()
		{
			return string.Format ("[Korisnik: _korisnikId={0}, _korIme={1}, _lozinka={2}, _tip={3}, _imePrezime={4}]",
			                      _korisnikId, _korIme, _lozinka, _tip, _imePrezime);
		}

		public bool Equals(Korisnik k2)
		{
			if( this._tip == k2.Tip && 
			    this._lozinka == k2.Lozinka && 
			    this._imePrezime == k2.ImePrezime && 
			    this._korIme == k2.KorIme 
			  )
				return true;
			return false;
		}

		/* Vracanje svih korisnika */

		public static List<Korisnik> Svi()
		{
			List<Korisnik> lista = (List<Korisnik>)Serijalizacija.ReadAllObjectFromFile<Korisnik>( Serijalizacija.KoDat );

			return lista;
		}


		/* Vrati korisnika po ID-u */
		public static Korisnik VratiPoID(int id)
		{
			List<Korisnik> sviKorsinici = Svi();

			foreach ( Korisnik k in sviKorsinici)
			{
				if ( k.KorisnikId == id )
				{
					return k;
				}
			}
			return null;

		}

//		/* Upisi korisnika u datoteku */
//		public static void UpisiKorisnika(string korIme, string lozinka, int tip, string imePrezime)
//		{
//			List<Korisnik> sviKorsinici = Svi();
//
//			foreach ( Korisnik k in sviKorsinici )
//			{
//				if ( k.KorIme.ToLower() == KorIme )
//				{
//					MessageBox.Show ("Korisnik sa tim korisnickim imenom vec postoji!",MessageBoxType.Warning );
//					Console.WriteLine("Korisnik sa tim korisnickim imenom vec postoji!");
//				}
//			}
//			Korisnik korisnik = new Korisnik (  korIme, lozinka, tip, imePrezime );
//			
//			Serijalizacija.WriteToBinaryFile<Korisnik>( Serijalizacija.KoDat , korisnik , true );
//			//MessageBox.Show ("Film uspesno upisan!",MessageBoxType.Information );
//			Console.WriteLine("Film uspesno upisan!");
//
//		}

		public void Sacuvaj()
		{
			List<Korisnik> sviKorisnici = Svi();

			if ( sviKorisnici != null )
			{
				foreach ( var item in sviKorisnici )
				{
					if (item.KorisnikId == this._korisnikId )
					{
						sviKorisnici.Remove( item );
						sviKorisnici.Add( this );
						Serijalizacija.WriteListToBinaryFile<Korisnik>( Serijalizacija.KoDat , sviKorisnici , false );
						//MessageBox.Show("Uspesno ste sacuvali korisnika!", MessageBoxType.Warning);
						Console.WriteLine( "Uspesno ste sacuvali korisnika!" );
						return;
					}
				}
			}
			else
			{
				Serijalizacija.WriteToBinaryFile<Korisnik>(Serijalizacija.KoDat, this, true);
			}


			//MessageBox.Show ("Korisnik uspesno upisan!",MessageBoxType.Information );
			Console.WriteLine("Korisnik uspesno upisan!");
		}

		public static void UpisiKorisnika( Korisnik korisnik )
		{
			List<Korisnik> sviKorsinici = Svi();

			foreach ( Korisnik k in sviKorsinici )
			{
				if ( k == korisnik )
				{
					//MessageBox.Show ("Takav korisnik vec postoji!",MessageBoxType.Warning );
					Console.WriteLine("Takav korisnik vec postoji!");
					return;
				}
			}
			
			Serijalizacija.WriteToBinaryFile<Korisnik>( Serijalizacija.KoDat , korisnik , true );
			//MessageBox.Show ("Korisnik uspesno upisan!",MessageBoxType.Information );
			Console.WriteLine("Korisnik uspesno upisan!");

		}

		private static List<int> InicijalizujListuId()
		{
			List<Korisnik> lista = Svi();
			List<int> list_id = new List<int> ( );

			if ( lista != null )
			{
				foreach ( Korisnik k in lista )
				{
					list_id.Add( k.KorisnikId );
				}
			}

			return list_id;
		}


	}
}

