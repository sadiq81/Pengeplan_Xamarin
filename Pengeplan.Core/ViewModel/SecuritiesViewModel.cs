using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pengeplan.Core
{
	public class SecuritiesViewModel : BaseViewModel, ITableViewViewModel
	{
		public SecuritiesViewModel ()
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

		public String RightCellContent (int cell)
		{
			string rigth;

			try {
				IsBusy = true;
				rigth = manager.SecuritiesAmount (cell) + " " + manager.SecuritiesCurrency (cell); 
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
				left = manager.SecuritiesPaperName (cell);
			} finally {
				IsBusy = false;
			}
			return left;
		}

		public List<PieChartValue> DataForPieChart ()
		{
			List<PieChartValue> data = new List<PieChartValue> ();
			for (int i = 0; i < NumberOfItems (); i++) {
				data.Add (new PieChartValue (manager.SecuritiesPaperName (i), manager.SecuritiesAmountLocal (i)));
			}
			return data;
		}

		public class PieChartValue
		{
			public PieChartValue (string paperName, decimal amount)
			{
				this.paperName = paperName;
				this.amount = amount;
			}

			public string paperName { get; set; }

			public decimal amount { get; set; }
		}
	}
}

