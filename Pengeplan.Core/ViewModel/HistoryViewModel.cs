using System;

namespace Pengeplan.Core
{
	public class HistoryViewModel : BaseViewModel, ITableViewViewModel
	{
		public HistoryViewModel ()
		{
		}

		public int NumberOfItems ()
		{
			int count;

			try {
				IsBusy = true;
				count = manager.CountPapersOwned ();
			} finally {
				IsBusy = false;
			}
			return count;
		}

		public string RightCellContent (int cell)
		{
			string rigth;

			try {
				IsBusy = true;
				rigth = manager.TransactionForSecurity (cell); 
			} finally {
				IsBusy = false;
			}
			return rigth;
		}

		public string LeftCellContent (int cell)
		{
			string rigth;

			try {
				IsBusy = true;
				//TODO Get local currency from server
				rigth = manager.SecuritiesPaperName (cell); 
			} finally {
				IsBusy = false;
			}
			return rigth;
		}
	}
}

