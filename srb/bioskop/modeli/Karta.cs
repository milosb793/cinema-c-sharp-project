using System;
using System.Collections.Generic;
using Eto.Forms;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Bioskop
{

	[Serializable]
	public class Karta : ISerializable
	{
		private int   _kartaId;
		private float _cena;
		private int   _red;
		private int   _sediste;
		private int   _projekcija_id;
		private int   _kupac_id;

		[NonSerialized]
		private Projekcija _projekcija;
		[NonSerialized]
		private Korisnik   _kupac;
		private static List<int> lista_id = InicijalizujListuId();


		public Karta ()
		{
			this._kartaId = Metode.dobaviId(ref lista_id);
			this._projekcija = null;
			this._kupac = null;
			this._cena = 0.0F;
			this._red = this._sediste = 0;
			this._kupac_id = 0;
			this._projekcija_id = 0;

		}

		public Karta ( Projekcija projekcija,Korisnik kupac, float cena, int red, int sediste )
		{
			this._kartaId = Metode.dobaviId(ref lista_id);
			this._projekcija = projekcija;
			this._kupac = kupac;
			this._cena = cena;
			this._red = red;
			this._sediste = sediste;
			this._kupac_id = kupac.KorisnikId;
			this._projekcija_id = projekcija.ProjekcijaId;
		}

		public Karta ( int projekcija_id, int kupac_id, float cena, int red, int sediste )
		{
			this._kartaId = Metode.dobaviId(ref lista_id);
			this._projekcija = Projekcija.VratiPoID(projekcija_id);
			this._kupac = Korisnik.VratiPoID(kupac_id);
			this._cena = cena;
			this._red = red;
			this._sediste = sediste;
			this._kupac_id = kupac_id;
			this._projekcija_id = projekcija_id;
		}

		protected Karta(SerializationInfo info, StreamingContext context)
		{
			this._kartaId = (int)info.GetInt32( "kartaId" );
			this._projekcija = (Projekcija)info.GetValue( "projekcija",Projekcija.GetType() );
			this._kupac = (Korisnik)info.GetValue( "kupac", Kupac.GetType() );
			this._cena = info.GetSingle( "cena" );
			this._red = info.GetInt32( "red" );
			this._sediste = info.GetInt32( "sediste" );
			this._kupac_id = info.GetInt32( "kupacId" );
			this._projekcija_id = info.GetInt32( "projekcijaId" );
		}

		public virtual void GetObjectData (SerializationInfo info, StreamingContext context)
		{
			info.AddValue("kartaId", _kartaId,typeof(int));
			info.AddValue("kupacId",_kupac_id);
			info.AddValue("projekcijaId",_projekcija_id);
			info.AddValue("kupac",_kupac,(_kupac).GetType());
			info.AddValue("projekcija",_projekcija, (_projekcija).GetType());
			info.AddValue("red",_red);
			info.AddValue("sediste",_sediste);
			info.AddValue("cena",_cena);

		}

		 /**
         * Geteri i seteri
         * */
        public int KartaId
        {
            get { return this._kartaId; }
        }

		public Projekcija Projekcija
        {
			get
			{ 
				if ( this._projekcija == null && this._projekcija_id != 0 )
				{
					this._projekcija = Projekcija.VratiPoID( _projekcija_id );
				}
				return this._projekcija; 
			}
			set
			{ 
				_projekcija = value;
				_projekcija_id = value.ProjekcijaId;
			}
        }

        public int Red
        {
            get { return this._red; }
        }

        public int Sediste
        {
            get { return this._sediste; }
        }


        public float Cena
        {
            get { return this._cena; }
            set { _cena = value; }
        }

		public Korisnik Kupac
		{
			get 
			{ 
				if ( this._kupac == null && this._kupac_id != 0 )
				{
					this._kupac = Korisnik.VratiPoID( _kupac_id );
				}
				return this._kupac; 
			}
			set
			{ 
				_kupac = value;
				_kupac_id = value.KorisnikId;
			}
		}


         /* Vracanje svih karata */
        public static List<Karta> Sve()
        {
            List<Karta> lista = (List<Karta>) Serijalizacija.ReadAllObjectFromFile<Karta>(Serijalizacija.KaDat);
//			List<Projekcija> listaProj = Projekcija.Sve();
//			List<Korisnik> listaKor = Korisnik.Svi();
//
//			for ( int i = 0 ; i < lista.Count -1 ; i++ )
//			{
//				//Console.WriteLine(	"Kupac id: " + lista[i]._kupac_id);
//
//				Korisnik k = listaKor.Find( x => x.KorisnikId == lista[i]._kupac_id );
//
//				lista [ i ]._kupac = k;
//				lista[i]._projekcija = listaProj.Find( x => x.ProjekcijaId == lista[i]._projekcija_id );
//
//				//Console.WriteLine("\nKupac: " + lista[i].Kupac);
//				//Console.WriteLine("\nProjekcija: " + lista[i]._projekcija);
//
//			}

            return lista;
        }

        /* Vrati kartu po ID-u */
        public static Karta VratiPoID(int id)
        {																																													
            List<Karta> sveKarte = Sve();

            foreach (Karta k in sveKarte)
			{
				if (k.KartaId == id)
				{
					return k;
                }
            }

            return null;
        }

         /* Upisi kartu u datoteku */
        public void Sacuvaj()
        {
            List<Karta> sveKarte = Sve();

			if ( sveKarte != null )
			{
				for ( int i = 0; i < sveKarte.Count-1; i++ )
				{
					if ( sveKarte[i].KartaId == this._kartaId )
					{
						sveKarte [ i ] = this;
						Serijalizacija.WriteListToBinaryFile<Karta>( Serijalizacija.KaDat , sveKarte , false );
						//MessageBox.Show("Uspesno ste sacuvali kartu!", MessageBoxType.Warning);
						Console.WriteLine( "Uspesno ste sacuvali kartu!" );
						return;
					}
				}
			}
			else
			{
				Serijalizacija.WriteToBinaryFile<Karta>(Serijalizacija.KaDat, this, true);
			}

            Console.WriteLine("Karta uspesno upisanaa!");
        }

         /* Upisi Kartu */
		public static void UpisiKartu( Projekcija projekcija, Korisnik kupac, float cena, int red, int sediste )
        {
			List<Karta> sveKarte = Karta.Sve(); 

//			foreach (Karta k in sveKarte)
//            {
//				if (k.Kupac == kupac && k.Projekcija == projekcija)
//                { 
//                    Console.WriteLine("Vec postoji Projekcija koja se u to vreme odrzava u toj sali.");
//					return;
//                }
//            }
			Karta karta = new Karta(projekcija, kupac,cena,red,sediste);
			Debug.WriteLine("\nUpravo kreirana karta, pred upis: {0}",karta);

			sveKarte.Add( karta );
			Serijalizacija.WriteListToBinaryFile<Karta>( Serijalizacija.KaDat , sveKarte , false );
            Console.WriteLine("Karta uspesno upisana!");
        }



        public override string ToString()
        {
			return String.Format("[ id:{0}, Projekcija{1}, Kupac: {2}, Red:{3}, Sediste:{4}, Cena:{5} ]",
			                     _kartaId, this.Projekcija, this.Kupac, _red, _sediste, _cena );
        }

        public bool Equals(Karta k2)
        {
			if( this._projekcija == k2.Projekcija && 
        		this._red == k2._red && 
			    this._sediste == k2._sediste &&
        		this._cena == k2._cena && 
			    this._kupac == k2.Kupac
			  )
        		return true;
        	return false;
        }

		private static List<int> InicijalizujListuId()
		{
			List<Karta> lista = Sve();
			List<int> list_id = new List<int> ( );

			if ( lista != null )
			{
				foreach ( Karta k in lista )
				{
					list_id.Add( k.KartaId );
				}
			}
			return list_id;
		}

	}
}

