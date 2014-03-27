using System;
using System.Collections.Generic;

namespace Pengeplan.Core
{
	public static class DataManager
	{
		public static IEnumerable<Transaction> GetTransactions ()
		{
			return Database.GetItems<Transaction> ();
		}

		public static Transaction GetTransaction (long id)
		{
			return Database.GetItem<Transaction> (id);
		}

		public static long SaveTransaction (Transaction item)
		{
			return Database.SaveItem<Transaction> (item);
		}

		public static void SaveTransactions (IEnumerable<Transaction> items)
		{
			Database.SaveItems<Transaction> (items);
		}

		public static int DeleteTransaction (long id)
		{
			return Database.DeleteItem<Transaction> (id);
		}

		public static void DeleteTransactions ()
		{
			Database.ClearTable<Transaction> ();
		}

		public static int CountTransaction ()
		{
			return Database.CountTable<Transaction> ();
		}
	}
}

