using System;

namespace Pengeplan.Core
{
	public class TransactionsViewModel : BaseViewModel, ITableViewViewModel
	{
		public string paperName { get; set; }

		public TransactionsViewModel ()
		{
			this.paperName = paperName;
		}

		public int NumberOfItems ()
		{
			return manager.CountTransactions (paperName);
		}

		public string RightCellContent (int cell)
		{
			return string.Format ("{0} {1} for {2} {3}", manager.TransactionType (paperName, cell), manager.TransactionNumberOfUnits (paperName, cell), manager.TransactionAmount (paperName, cell), manager.TransactionCurrency (paperName, cell));
		}

		public string LeftCellContent (int cell)
		{
			return manager.TransactionDate (paperName, cell);
		}
	}
}

