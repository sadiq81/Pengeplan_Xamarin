using System;
using System.Collections.Generic;
using System.Collections;
using SQLite;

namespace Pengeplan.Core
{
	public class DataManager
	{
		SQLiteConnection conn;

		public DataManager ()
		{

			string folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			conn = new SQLiteConnection (System.IO.Path.Combine (folder, "pengeplan.db"));
			conn.CreateTable<Transaction> ();
		}

		public  IEnumerable<Transaction> GetTransactions ()
		{
			return conn.Table<Transaction> ();
		}

		public  Transaction GetTransaction (long id)
		{
			return conn.Table<Transaction> ().Where (t => t.id.Equals (id)).First ();
		}

		public  long SaveTransaction (Transaction item)
		{
			return conn.Insert (item);
		}

		public  void SaveTransactions (IEnumerable<Transaction> items)
		{
			conn.InsertAll (items);
		}

		public  int DeleteTransaction (long id)
		{
			return conn.Delete (id);
		}

		public  void DeleteTransactions ()
		{
			conn.DeleteAll<Transaction> ();
		}
	}
}

