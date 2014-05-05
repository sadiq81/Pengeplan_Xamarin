using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using SQLite;

namespace Pengeplan.Core
{
	public class DataManager
	{
		SQLiteConnection sync;

		public DataManager ()
		{

			string folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);

			sync = new SQLiteConnection (System.IO.Path.Combine (folder, "pengeplan.db"));

			sync.CreateTable<Transaction> ();
			sync.DeleteAll<Transaction> ();

		}

		public  IEnumerable<Transaction> GetTransactions ()
		{
			return sync.Table<Transaction> ();
		}

		public int CountPapersOwned ()
		{
			var list = sync.Query<Transaction> ("SELECT  *" +
			           " FROM 'Transaction'" +
			           " GROUP BY paperName");
			return list.Count;
		}

		public string SecuritiesAmount (int cell)
		{
			decimal amount = sync.ExecuteScalar<decimal> ("SELECT SUM(amount) as AMOUNT" +
			                 " FROM 'Transaction'" +
			                 " GROUP BY paperName" +
			                 " ORDER BY paperName ASC" +
			                 " LIMIT 1 OFFSET " + cell);
			return amount.ToString ();
		}

		public decimal SecuritiesAmountLocal (int cell)
		{
			decimal amount = sync.ExecuteScalar<decimal> ("SELECT SUM(localAmount) as AMOUNT" +
			                 " FROM 'Transaction'" +
			                 " GROUP BY paperName" +
			                 " ORDER BY paperName ASC" +
			                 " LIMIT 1 OFFSET " + cell);
			return amount;
		}

		public string SecuritiesCurrency (int cell)
		{
			string currency = sync.ExecuteScalar<string> ("SELECT currency" +
			                  " FROM 'Transaction'" +
			                  " GROUP BY paperName" +
			                  " ORDER BY paperName ASC" +
			                  " LIMIT 1 OFFSET " + cell);
			                         
			return currency;
		}

		public string SecuritiesPaperName (int cell)
		{
			string paperName = sync.ExecuteScalar<string> ("SELECT paperName" +
			                   " FROM 'Transaction'" +
			                   " GROUP BY paperName" +
			                   " ORDER BY paperName ASC" +
			                   " LIMIT 1 OFFSET " + cell);

			return paperName;
		}

		public int CountDepositoriesUsed ()
		{
			var list = sync.Query<Transaction> ("SELECT  *" +
			           " FROM 'Transaction'" +
			           " GROUP BY ownedAccount");
			return list.Count;
		}

		public string DepositoriesName (int cell)
		{
			string depositoryName = sync.ExecuteScalar<string> ("SELECT ownedAccount" +
			                        " FROM 'Transaction'" +
			                        " GROUP BY ownedAccount" +
			                        " ORDER BY ownedAccount ASC" +
			                        " LIMIT 1 OFFSET " + cell);
			depositoryName = depositoryName.Substring (0, depositoryName.LastIndexOf ("-"));
			return depositoryName;
		}

		public string DepositoriesAmount (int cell)
		{
			decimal amount = sync.ExecuteScalar<decimal> ("SELECT sum(localAmount)" +
			                 " FROM 'Transaction'" +
			                 " GROUP BY ownedAccount" +
			                 " ORDER BY ownedAccount ASC" +
			                 " LIMIT 1 OFFSET " + cell);

			return amount.ToString ();
		}
		//   ---------------- TransactionsViewModel ---------------- //
		public string TransactionForSecurity (int cell)
		{
			decimal amount = sync.ExecuteScalar<decimal> ("SELECT count(paperName)" +
			                 " FROM 'Transaction'" +
			                 " GROUP BY paperName" +
			                 " ORDER BY paperName ASC" +
			                 " LIMIT 1 OFFSET " + cell);

			return amount.ToString ();
		}

		public int  CountTransactions (string paperName)
		{
			int count = sync.ExecuteScalar<int> ("SELECT count(paperName)" +
			            " FROM 'Transaction'" +
			            " WHERE paperName = ?", paperName);

			return count;
		}

		public string TransactionDate (string paperName, int cell)
		{
			List<Transaction> list = sync.Query<Transaction> ("SELECT *" +
			                         " FROM 'Transaction'" +
			                         " WHERE paperName = ?" +
			                         " ORDER BY date ASC" +
			                         " LIMIT 1 OFFSET ?", paperName, cell);
			return list [0].date.ToString ("dd-MM-yy");
		}

		public string TransactionCurrency (string paperName, int cell)
		{
			List<Transaction> list = sync.Query<Transaction> ("SELECT *" +
			                         " FROM 'Transaction'" +
			                         " WHERE paperName = ?" +
			                         " ORDER BY date ASC" +
			                         " LIMIT 1 OFFSET ?", paperName, cell);
			return list [0].currency;
		}

		public string TransactionAmount (string paperName, int cell)
		{
			List<Transaction> list = sync.Query<Transaction> ("SELECT *" +
			                         " FROM 'Transaction'" +
			                         " WHERE paperName = ?" +
			                         " ORDER BY date ASC" +
			                         " LIMIT 1 OFFSET ?", paperName, cell);
			return list [0].amount.ToString ();
		}

		public string TransactionNumberOfUnits (string paperName, int cell)
		{
			List<Transaction> list = sync.Query<Transaction> ("SELECT *" +
			                         " FROM 'Transaction'" +
			                         " WHERE paperName = ?" +
			                         " ORDER BY date ASC" +
			                         " LIMIT 1 OFFSET ?", paperName, cell);
			return list [0].numberOfItems.ToString ();
		}

		public string TransactionType (string paperName, int cell)
		{
			List<Transaction> list = sync.Query<Transaction> ("SELECT *" +
			                         " FROM 'Transaction'" +
			                         " WHERE paperName = ?" +
			                         " ORDER BY date ASC" +
			                         " LIMIT 1 OFFSET ?", paperName, cell);
			return list [0].transactionType.ToString ();
		}
		//   ---------------- Generic methods ---------------- //
		public  Transaction GetTransaction (long id)
		{
			return sync.Table<Transaction> ().Where (t => t.id.Equals (id)).First ();
		}

		public  long SaveTransaction (Transaction item)
		{
			return sync.InsertOrReplace (item);
		}

		public async Task<int> SaveTransactions (IEnumerable<Transaction> items)
		{
			int count = 0;
			foreach (Transaction transaction in items) {
				count += sync.InsertOrReplace (transaction);
			}
			return count;
		}

		public  int DeleteTransaction (long id)
		{
			return sync.Delete (id);
		}

		public  void DeleteTransactions ()
		{
			sync.DeleteAll<Transaction> ();
		}
	}
}

