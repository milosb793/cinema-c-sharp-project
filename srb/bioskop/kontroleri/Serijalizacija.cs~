using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; 
using System.Collections.Generic;
using System.Collections;
//using GLib;

namespace Bioskop
{
	public static class Serijalizacija
	{
		public const string KoDat = "korisnici.dat";
		public const string FiDat = "filmovi.dat";
		public const string SaDat = "sale.dat";
		public const string KaDat = "karte.dat";
		public const string PrDat = "projekcije.dat";


		/**
		 * Konvertovanje objekta u niz bajtova
		 * */
		public static byte[] ObjectToByteArray(object obj)
		{
			if(obj == null)
				return null;
			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			bf.Serialize(ms, obj);
			return ms.ToArray();
		}

		/**
		 * Konvertovanje niza bajtova u objekat
		 * */
		public static object ByteArrayToObject(byte[] arrBytes)
		{
			MemoryStream memStream = new MemoryStream();
			BinaryFormatter binForm = new BinaryFormatter();
			memStream.Write(arrBytes, 0, arrBytes.Length);
			memStream.Seek(0, SeekOrigin.Begin);
			object obj = (object) binForm.Deserialize(memStream);
			return obj;
		}


		/**
		* Upisivanje objekta u fajl. Moze se upisati i vise objekata, pomocu liste.
		* */
		public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
		{
			using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
			{
				var binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(stream, objectToWrite);
			}
		}


		/* Upisivanje liste u binarnu datoteku, objekat po objekat */
		public static void WriteListToBinaryFile<T>(string filePath, List<T> listToWrite, bool append = false)
		{

			for ( int i = 0 ; i < listToWrite.Count ; i++ )
			{
				if ( append == false)
				{
					if ( i == 0 )
						WriteToBinaryFile<T>( filePath , listToWrite [ i ] , false );
					else 
						WriteToBinaryFile<T>( filePath , listToWrite[i] , true );
				}
				else
					WriteToBinaryFile<T>( filePath , listToWrite[i] , append );
			}

		}


		/* Upisivanje niza objekata u binarnu datoteku, objekat po objekat */
		public static void WriteArrayToBinaryFile<T>(string filePath, T[] arrayToWrite, bool append = false)
		{
			foreach ( T obj in arrayToWrite ){
				WriteToBinaryFile<T>( filePath , obj , append );
			}
		}


		/**
		 * Deserijalizacija svih objekata, vraca listu
		 * */
		public static List<T> ReadAllObjectFromFile<T>(string path)
		{
			if ( !DaLiJePrazanFajl( path ) )
			{
				long position = 0;
				List<T> list = new List<T> ( );
				BinaryFormatter formatter = new BinaryFormatter ( );
				using ( FileStream stream = new FileStream ( path , FileMode.OpenOrCreate, FileAccess.Read ) )
				{
					while ( position != stream.Length )
					{
						stream.Seek( position , SeekOrigin.Begin );
						list.Add( ( T )formatter.Deserialize( stream ) );
						position = stream.Position;
					}
				}

				return list;
			}

			return null;

		}

		public static bool DaLiJePrazanFajl(string putanja)
		{
			FileInfo fi = new FileInfo(putanja);
			if ( fi.Exists )
			{
				if ( fi.Length != 0 )
					return false;
			}
			return true;

		}
			

	}


}

