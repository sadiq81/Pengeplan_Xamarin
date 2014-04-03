using System;

namespace Pengeplan.Core
{
	public interface ITableViewViewModel
	{
		int NumberOfItems ();

		string RightCellContent (int cell);

		string LeftCellContent (int cell);
	}
}

