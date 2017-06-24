using System;
using bioskop;
using System.Collections.Generic;
using Eto.Forms;

namespace Bioskop
{
	[Serializable]
	public class Projekcija
	{
		private int    _projekcijaId;
		private string _vreme;
		private int    _film_id;
		private int    _sala_id;

		[NonSerialized]
		private Film   _film;
		[NonSerialized]
		private Sala   _sala;
		private static List<int> lista_id = InicijalizujListuId();

		public Projekcija ()
		{
			this._projekcijaId = Metode.dobaviId(ref lista_id);
			this._sala = null;
			this._film = null;
			this._vreme = DateTime.Now.ToString("f");
			this._film_id = 0;
			this._sala_id = 0;
		}

		public Projekcija( Film film, Sala sala, string vreme )
		{
			this._projekcijaId = Metode.dobaviId(ref lista_id);
			this._film = film;
			this._sala = sala;
			this._vreme = vreme;
			this._film_id = film.FilmId;
			this._sala_id = sala.SalaId;
		}

		public Projekcija( int film_id, int sala_id, string vreme )
		{
			this._film_id = film_id;
			this._sala_id = sala_id;
			this._projekcijaId = Metode.dobaviId(ref lista_id);
			this._film = Film.VratiPoID(film_id);
			this._sala = Sala.VratiPoID(sala_id);
			this._vreme = vreme;
		}






        /**
         * Geteri i seteri
         * */
        public int ProjekcijaId
        {
            get { return this._projekcijaId; }
        }

        public Film Film
        {
            get
			{ 
				if ( this._film == null && this._film_id != 0 )
				{
					this._film = Film.VratiPoID( _film_id );
				}
				return this._film;
			}
            set
			{ 
				_film = value; 
				_film_id = value.FilmId;

			}
        }

        public Sala Sala
        {
            get
			{  
				if ( this._sala == null && this._sala_id != 0 )
				{
					this._sala = Sala.VratiPoID( _sala_id );
				}
				return this._sala; 
			}
            set
			{ 
				_sala = value; 
				_sala_id = value.SalaId;

			}
        }

        public string Vreme
        {
            get { return this._vreme; }
            set { _vreme = value; }
        }


         /**
         * Metode
         * */

        /* Vracanje svih filmova */
        public static List<Projekcija> Sve()
        {
			List<Projekcija> lista = (List<Projekcija>) Serijalizacija.ReadAllObjectFromFile<Projekcija>(Serijalizacija.PrDat);

//			List<Film> sviFilmovi = Film.Svi();
//			List<Sala> sveSale = Sala.Sve();
//
//
//			for ( int i = 0 ; i < lista.Count -1 ; i++ )
//			{
//				lista [ i ]._film = sviFilmovi.Find( (x ) => lista [ i ]._film_id == x.FilmId );
//				lista [ i ]._sala = sveSale.Find( (x ) => lista [ i ]._sala_id == x.SalaId );
//
//			}

            return lista;
        }

        /* Vrati film po ID-u */
        public static Projekcija VratiPoID(int id)
        {
                List<Projekcija> sveProjekcije = Sve();

                foreach (Projekcija p in sveProjekcije)
                {
                    if (p.ProjekcijaId == id)
                    {
                        return p;
                    }
                }

            return null;
        }


//         /* Upisi Projekciju */
//        public static void upisiProjekciju( Film film, Sala sala, DateTime vreme )
//        {
//            List<Projekcija> sveProjekcije = vratiListuSvih();
//
//            foreach (Projekcija p in sveProjekcije)
//            {
//                if (p.Vreme == vreme && p.Sala == sala)
//                {
//                    MessageBox.Show("Vec postoji Projekcija koja se u to vreme odrzava u toj sali.", MessageBoxType.Warning);
//                    Console.WriteLine("Vec postoji Projekcija koja se u to vreme odrzava u toj sali.");
//                }
//            }
//            Projekcija projekcija = new Projekcija(film, sala, vreme);
//
//            Serijalizacija.WriteToBinaryFile<Projekcija>(Serijalizacija.ProDat, projekcija, true);
//            //MessageBox.Show ("Film uspesno upisan!",MessageBoxType.Information );
//            Console.WriteLine("Projekcija uspesno upisana!");
//        }


		public void Sacuvaj()
		{
			List<Projekcija> sveProjekcije = Sve();

			if ( sveProjekcije != null )
			{
				foreach ( var item in sveProjekcije )
				{
					if ( item.ProjekcijaId == this._projekcijaId )
					{
						sveProjekcije.Remove( item );
						sveProjekcije.Add( this );

						//sveProjekcije [ i ] = this;
						Serijalizacija.WriteListToBinaryFile<Projekcija>( Serijalizacija.PrDat , sveProjekcije , false );
						//MessageBox.Show("Uspesno ste sacuvali projekciju!", MessageBoxType.Warning);
						Console.WriteLine( "Uspesno ste sacuvali projekciju!" );
						return;
					}
				}
			}
			else
			{
				Serijalizacija.WriteToBinaryFile<Projekcija>(Serijalizacija.PrDat, this, true);
			}
			//MessageBox.Show ("Projekcija uspesno upisana!",MessageBoxType.Information );
			Console.WriteLine("Projekcija uspesno upisana!");
		}

         /* Upisi Projekciju */
        public static void upisiProjekciju( Projekcija projekcija )
        {
            List<Projekcija> sveProjekcije = Sve();

            foreach (Projekcija p in sveProjekcije)
            {
                if (p == projekcija)
                {
                    //MessageBox.Show("Vec postoji Projekcija koja se u to vreme odrzava u toj sali.", MessageBoxType.Warning);
                    Console.WriteLine("Vec postoji Projekcija koja se u to vreme odrzava u toj sali.");
                    return;
                }
            }

			Serijalizacija.WriteToBinaryFile<Projekcija>(Serijalizacija.PrDat, projekcija, true);
            //MessageBox.Show ("Film uspesno upisan!",MessageBoxType.Information );
            Console.WriteLine("Projekcija uspesno upisana!");
        }


        public override string ToString()
        {
			return String.Format("[ id:{0}, Film:{1}, Sala:{2}, Vreme:{3} ]", 
			                     _projekcijaId, this.Film, this.Sala, _vreme );
        }

        public bool Equals(Projekcija p2)
        {
        	if( this._vreme == p2.Vreme && 
			    this.Sala == p2.Sala && 
			    this.Film == p2.Film 
			  )
        		return true;
        	return false;
        }

		private static List<int> InicijalizujListuId()
		{
			List<Projekcija> lista = Sve();
			List<int> list_id = new List<int> ( );

			if ( lista != null )
			{
				foreach ( Projekcija p in lista )
				{
					list_id.Add( p.ProjekcijaId );
				}
			}

			return list_id;
		}

	}
}

