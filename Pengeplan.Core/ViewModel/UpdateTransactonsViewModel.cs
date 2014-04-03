using System;
using Xamarin.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pengeplan.Core
{
	public class UpdateTransactonsViewModel : BaseViewModel
	{
		public UpdateTransactonsViewModel ()
		{
		}

		public async Task<int> UpdateTransactions ()
		{
			int result;
			IsBusy = true;
			try {
				AuthResponse response = loginService.UserInfo ();
				List<Transaction> transactions = await pengeplanApi.getItems (response.username, response.password);
				result = await manager.AsyncSaveTransactions (transactions);
			} finally {
				IsBusy = false;
			}
			return result;
		}
	}
}

