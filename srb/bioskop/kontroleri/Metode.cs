using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using GLib;
using System.Collections.Generic;
using System.Collections;
//using GLib;

namespace Bioskop
{

	public static class Metode
	{
		public const int Jedan = 0;
		public const int Lista = 1;
		private static Random generator = new Random();



		public static bool proveriUnos(String s, int min, int max)
		{
			if (s.Length == 0)
				return false;
			else if (s.Length < min || s.Length > max)
				return false;
			else
				return true;
		}




		public static int dobaviId(ref List<int> lista)
		{
			Random r = new Random ( 101 );
			int broj = r.Next( 0 , 1000 );
				
			while ( lista.Contains( broj ) )
			{
				broj = r.Next( 0 , 1000 );
			}
			lista.Add( broj );

			return broj;
		}

		/* Ispisivanje liste */
		public static void ispisi<T>(List<T> lista)
		{
			foreach ( T obj in lista )
			{
				Console.WriteLine(obj.ToString());
			}
		
		}

		public static int VratiNasumicniInt(int min=0, int max=10)
		{
			return generator.Next( min , max );
		}

		public static bool Prazno(string obj)
		{
			if ( obj == "" || obj.Length == 0 )
				return true;
			return false;
		}

		public static bool ProveriDuzinu(string obj,int min, int max)
		{
			if ( !Prazno( obj ) )
			{
				if ( obj.Length > min && obj.Length <= max )
					return true;
			}
			return false;
		}

	}
}

