using System;
using Eto.Forms;
using System.Collections.Generic;

namespace Bioskop
{


	[Serializable]
	public class Sala
	{
		private int _salaId;
		private string _naziv;
		private int[][] _mesta;
		private int _ukupnoMesta;
		private int _brZauzetih;
		private int _brSlobodnih;
		private int _redova;
		private int _sedistaPoRedu;
		private static List<int> lista_id = InicijalizujListuId();
		


		public Sala ()
		{
			this._salaId = Metode.dobaviId(ref lista_id);
			this._naziv = "";
			this._redova = 5;
			this._sedistaPoRedu = 10;
			this._mesta = new int[_redova][];
			for ( int i = 0 ; i < this._mesta.Length ; i++ )
			{
				this._mesta [ i ] = new int[_sedistaPoRedu];
			}
			
			_ukupnoMesta = _redova * _sedistaPoRedu;
			_brSlobodnih = _ukupnoMesta;
			_brZauzetih = 0;
		}

		public Sala ( string naziv, int redova, int sedistaPoRedu )
		{
			this._salaId = Metode.dobaviId(ref lista_id);
			this._naziv = naziv;
			this._redova = redova;
			this._sedistaPoRedu = sedistaPoRedu;
			this._mesta = new int[_redova][];
			for ( int i = 0 ; i < this._mesta.Length ; i++ )
			{
				this._mesta [ i ] = new int[_sedistaPoRedu];
			}
			this._ukupnoMesta = this._redova * this._sedistaPoRedu;
			this._brSlobodnih = this._ukupnoMesta;
			this._brZauzetih = 0;
		}


        /**
         * Geteri i seteri
         * */
        public int SalaId
        {
            get { return this._salaId; }
        }

        public string Naziv
        {
            get { return this._naziv; }
            set { _naziv = value; }
        }


        public int Redova
        {
            get { return this._redova; }
            set { _redova = value; }
        }


        public int SedistaPoRedu
        {
            get { return this._sedistaPoRedu; }
        }

        public int BrSlobodnih
        {
            get { return _brSlobodnih; }
        }

        public int BrZauzetih
        {
            get { return _brZauzetih; }
        }

        public int UkupnoMesta
        {
            get { return _ukupnoMesta; }
        }

		public int[][] MatricaMesta
		{
			get { return _mesta; }
		}


         /**
         * Metode
         * */

         public void RezervisiMesto( int red, int sediste)
         {
			try{
				if( this._mesta[red][sediste] == 0)
	         	{
					this._mesta[red][sediste] = 1; 
					//MessageBox.Show("Uspesno ste rezervisali mesto!", MessageBoxType.Information);
	         		Console.WriteLine("Uspesno ste rezervisali mesto!");
	         		_brZauzetih++;
	         		_brSlobodnih--;
	         	}
	         	else
	         	{
	         		//MessageBox.Show("To mesto je vec rezervisano.", MessageBoxType.Warning);
	         		Console.WriteLine("To mesto je vec rezervisano ili ne postoji.");
	         	}
			}catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
		
         }


         public void UkiniRezervaciju( int red, int sediste )
         {
         	if( this._mesta[red][sediste] == 0)
         	{
         		//MessageBox.Show("Ovo mesto nije rezervisano.", MessageBoxType.Information);
         		Console.WriteLine("Ovo mesto nije rezervisano.");
         	}
         	else
         	{
         		//MessageBox.Show("Uspesno ste ukinuli rezervaciju.", MessageBoxType.Information);
         		Console.WriteLine("Uspesno ste ukinuli rezervaciju.");
         		_brZauzetih--;
         		_brSlobodnih++;
         	}

         }


          /* Vracanje svih sala */
        public static List<Sala> Sve()
        {
            List<Sala> lista = (List<Sala>) Serijalizacija.ReadAllObjectFromFile<Sala>(Serijalizacija.SaDat);

            return lista;
        }

        /* Vrati salu po ID-u */
        public static Sala VratiPoID(int id)
        {
            if (lista_id.Contains(id))
            {
                List<Sala> sveSale = Sve();

                foreach (Sala s in sveSale)
                {
                    if (s.SalaId == id){
                        return s;
                    }
                }
            }

            else{
                Console.WriteLine("Sala sa id:{0} ne postoji!", id);
            }
            return null;
        }


//         /* Upisi Salu u datoteku */
//        public static void upisiSalu( string naziv, int redova, int sedistaPoRedu )
//        {
//            List<Sala> sveSale = Sve();
//
//            foreach (Sala s in sveSale)
//            {
//                if (s.Naziv == naziv && s.Redova == redova && s.SedistaPoRedu == sedistaPoRedu)
//                {
//                    MessageBox.Show("Ista sala vec postoji.", MessageBoxType.Warning);
//                    Console.WriteLine("Ista sala vec postoji.");
//                }
//            }
//            Sala sala = new Sala(naziv, redova, sedistaPoRedu);
//
//            Serijalizacija.WriteToBinaryFile<Sala>(Serijalizacija.SaDat, sala, true);
//            //MessageBox.Show ("Film uspesno upisan!",MessageBoxType.Information );
//            Console.WriteLine("Sala uspesno upisana!");
//        }


		public void Sacuvaj()
		{
			List<Sala> sveSale = Sve();

			if ( sveSale != null )
			{
				foreach ( var item in sveSale )
				{
					if ( item.SalaId == this._salaId )
					{
						sveSale.Remove( item );
						sveSale.Add( this );
						Serijalizacija.WriteListToBinaryFile<Sala>( Serijalizacija.SaDat , sveSale , false );
						//MessageBox.Show("Uspesno ste sacuvali salu!", MessageBoxType.Warning);
						Console.WriteLine( "Uspesno ste sacuvali salu!" );
						return;
					}
				}
			}
			else
			{
				Serijalizacija.WriteToBinaryFile<Sala>(Serijalizacija.SaDat, this, true);
			}


			//MessageBox.Show ("Sala uspesno upisana!",MessageBoxType.Information );
			Console.WriteLine("Sala uspesno upisana!");
		}


        public static void upisiSalu( Sala sala )
        {
            List<Sala> sveSale = Sve();

            foreach (Sala s in sveSale)
            {
                if (s == sala)
                {
                   // MessageBox.Show("Ista sala vec postoji.", MessageBoxType.Warning);
                    Console.WriteLine("Ista sala vec postoji.");
                    return;
                }
            }

            Serijalizacija.WriteToBinaryFile<Sala>(Serijalizacija.SaDat, sala, true);
            //MessageBox.Show ("Sala uspesno upisana!",MessageBoxType.Information );
            Console.WriteLine("Sala uspesno upisana!");
        }


        public override string ToString()
        {
            return String.Format("[ id:{0}, Naziv:{1}, Ukupno mesta:{2}, Slobodnih mesta:{3}, Zauzetih mesta:{4}, Redova:{5}, Sedista po redu:{6} ]",
			                     _salaId, _naziv,_ukupnoMesta, _brSlobodnih, _brZauzetih, _redova, _sedistaPoRedu );
        }

        public bool Equals(Sala s2)
        {
        	if( this._naziv == s2.Naziv && _ukupnoMesta == s2.UkupnoMesta && 
        		_brSlobodnih == s2.BrSlobodnih && _brZauzetih == s2.BrZauzetih &&
			    this._redova == s2.Redova && this._sedistaPoRedu == s2.SedistaPoRedu
			  )
        		return true;
        	return false;
        }

		private static List<int> InicijalizujListuId()
		{
			List<Sala> lista = Sve();
			List<int> list_id = new List<int> ( );

			if ( lista != null )
			{
				foreach ( Sala s in lista )
				{
					list_id.Add( s.SalaId );
				}
			}

			return list_id;
		}
	}
}

