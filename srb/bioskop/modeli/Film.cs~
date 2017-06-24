using System;
using bioskop;
using System.Collections.Generic;
using Eto.Forms;

namespace Bioskop
{
    [Serializable]
    public class Film
    {
        private int    _filmId;
        private string _naziv;
        private Zanr   _zanr;
        private string _opis;
        private float  _ocena;
		private static List<int> lista_id = InicijalizujListuId();

        /**
         * Konstruktori
         * */



        public Film()
        {
            this._filmId = Metode.dobaviId(ref lista_id);
            this._naziv = "";
            this._opis = "";
            this._ocena = 0.0F;
            this._zanr = Zanr.akcija;
        }

		public Film(string naziv, Zanr z, string opis, float ocena)
		{ 
			this._filmId = Metode.dobaviId(ref lista_id);
			this._naziv = naziv;
			this._zanr = z;
			this._opis = opis;
			this._ocena = ocena;
		}



        /**
         * Geteri i seteri
         * */
        public int FilmId
        {
            get { return this._filmId; }
        }

        public string Naziv
        {
            get { return this._naziv; }
            set { _naziv = value; }
        }

        public Zanr GetZanr()
        {
            return this._zanr;
        }

        public void setZanr( Zanr zanr)
        {
            this._zanr = zanr;
        }

        public string Opis
        {
            get { return this._opis; }
            set { _opis = value; }
        }

        public float Ocena
        {
            get { return this._ocena; }
            set { _ocena = value; }
        }

        /**
         * Metode
         * */

        /* Vracanje svih filmova */
        public static List<Film> Svi()
        {
            List<Film> lista = (List<Film>) Serijalizacija.ReadAllObjectFromFile<Film>(Serijalizacija.FiDat);

            return lista;
        }

        /* Vrati film po ID-u */
        public static Film VratiPoID(int id)
        {
            if (lista_id.Contains(id))
            {
                List<Film> sviFilmovi = Svi();

                foreach (Film f in sviFilmovi)
                {
                    if (f.FilmId == id)
                    {
                        return f;
                    }
                }
            }

            else
            {
                Console.WriteLine("Film sa id:{0} ne postoji!", id);
            }
            return null;
        }

        /* Vrati film po Nazivu */
        public static List<Film> VratiPoNazivu(string naziv)
        {
            List<Film> sviFilmovi = Svi();
            List<Film> kojiSadrzeNaslov = new List<Film>();

            foreach (Film f in sviFilmovi)
            {
                if (f.Naziv.ToLower() == naziv.ToLower())
                {
                    kojiSadrzeNaslov.Add(f); 
                }
                else if (f.Naziv.ToLower().Contains(naziv.ToLower()))
                {
                    kojiSadrzeNaslov.Add(f);
                }
            }

            return kojiSadrzeNaslov;
        }

        /* Vrati sve filmove iz Zanra */
        public static List<Film> vratiPoZanru(Zanr zanr)
        {
            List<Film> sviFilmovi = Svi();
            List<Film> sviFimoviIzZanra = new List<Film>();

            foreach (Film f in sviFilmovi)
            {
                if (f.GetZanr() == zanr)
                {
                    sviFimoviIzZanra.Add(f);
                }
            }

            return sviFimoviIzZanra;
        }

//        /* Upisi film */
//        public static void upisiFilm(string naziv, Zanr z, string opis, float ocena)
//        {
//            List<Film> sviFilmovi = Svi();
//
//            foreach (Film f in sviFilmovi)
//            {
//                if (f.Naziv.ToLower() == naziv)
//                {
//                    MessageBox.Show("Film sa tim nazivom vec postoji!", MessageBoxType.Warning);
//                    Console.WriteLine("Film sa tim nazivom vec postoji!");
//                }
//            }
//            Film film = new Film(naziv, z, opis, ocena);
//
//            Serijalizacija.WriteToBinaryFile<Film>(Serijalizacija.FiDat, film, true);
//            //MessageBox.Show ("Film uspesno upisan!",MessageBoxType.Information );
//            Console.WriteLine("Film uspesno upisan!");
//        }

		public void Sacuvaj()
		{
			List<Film> sviFilmovi = Svi();

			if ( sviFilmovi != null )
			{
				foreach ( var item in sviFilmovi )
				{
					if ( item.FilmId == this._filmId )
					{
						sviFilmovi.Remove( item );
						sviFilmovi.Add( this );
						Serijalizacija.WriteListToBinaryFile<Film>( Serijalizacija.FiDat , sviFilmovi , false );
						//MessageBox.Show("Uspesno ste sacuvali film!", MessageBoxType.Warning);
						Console.WriteLine( "Uspesno ste sacuvali film!" );
						return;
					}
				}
			}
			else
			{
				Serijalizacija.WriteToBinaryFile<Film>(Serijalizacija.FiDat, this, true);
			}
			//MessageBox.Show ("Film uspesno upisan!",MessageBoxType.Information );
			Console.WriteLine("Film uspesno upisan!");
		}


        public static void upisiFilm( Film film )
        {
            List<Film> sviFilmovi = Svi();

            foreach (Film f in sviFilmovi)
            {
                if (f == film)
                {
                    //MessageBox.Show("Takav film vec postoji!", MessageBoxType.Warning);
                    Console.WriteLine("Takav film vec postoji!");
                    return;
                }
            }

            Serijalizacija.WriteToBinaryFile<Film>(Serijalizacija.FiDat, film, true);
            //MessageBox.Show ("Film uspesno upisan!",MessageBoxType.Information );
            Console.WriteLine("Film uspesno upisan!");
        }


        public override string ToString()
        {
            return String.Format("[ id:{0}, naziv:{1}, zanr:{2}, opis:{3}, ocena:{4} ]", 
			                     _filmId, _naziv, _zanr.ToString(), _opis, _ocena);
        }

		public bool Equals(Film f2)
        {
			if( this._zanr == f2.GetZanr() && 
			   this._ocena == f2.Ocena && 
			   this._opis == f2.Opis && 
			   this._naziv == f2.Naziv
			  )
                 return true;
            return false;
        }

		private static List<int> InicijalizujListuId()
		{
			List<Film> lista = Svi();
			List<int> list_id = new List<int> ( );

			if ( lista != null )
			{
				foreach ( Film f in lista )
				{
					list_id.Add( f.FilmId );
				}
			}

			return list_id;
		}
    }
}