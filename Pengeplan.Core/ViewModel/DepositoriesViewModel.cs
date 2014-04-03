using System;

namespace Pengeplan.Core
{
	public class DepositoriesViewModel: BaseViewModel, ITableViewViewModel
	{
		public DepositoriesViewModel ()
		{
		}

		public int NumberOfItems ()
		{
			int count;

			try {
				IsBusy = true;
				count = manager.CountDepositoriesUsed ();
			} finally {
				IsBusy = false;
			}
			return count;
		}

		public String RightCellContent (int cell)
		{
			string rigth;

			try {
				IsBusy = true;
				//TODO Get local currency from server
				rigth = manager.DepositoriesAmount (cell) + " DKK"; 
			} finally {
				IsBusy = false;
			}
			return rigth;
		}

		public  String LeftCellContent (int cell)
		{
			string left;

			try {
				IsBusy = true;
				left = manager.DepositoriesName (cell);
			} finally {
				IsBusy = false;
			}
			return left;
		}
	}
}

