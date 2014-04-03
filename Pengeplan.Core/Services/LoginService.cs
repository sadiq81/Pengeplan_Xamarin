using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Auth;

namespace Pengeplan.Core
{
	public class LoginService
	{
		protected readonly AccountStore accountStore = ServiceContainer.Resolve<AccountStore> ();
		public static readonly string CREDENTIALS_SERVICE = "pengeplanCredentials";
		public static readonly string PASSWORD = "password";
		public static readonly string PIN = "pin";
		public static readonly int PIN_MIN_LENGTH = 4;

		public void StoreCredentials (AuthResponse authResponse)
		{
			DeleteCredentials ();
			Dictionary<string, string> dic = new Dictionary<string, string> ();
			dic.Add (PASSWORD, authResponse.password);
			if (authResponse.pin.Length >= PIN_MIN_LENGTH) {
				dic.Add (PIN, authResponse.pin);
			}
			Account account = new Account (authResponse.username, dic, null);
			accountStore.Save (account, CREDENTIALS_SERVICE);
		}

		public void DeleteCredentials ()
		{
			IEnumerable<Account> accounts = accountStore.FindAccountsForService (CREDENTIALS_SERVICE);
			foreach (Account account in accounts) {
				accountStore.Delete (account, CREDENTIALS_SERVICE);
			}
		}

		public AuthResponse UserInfo ()
		{
			IEnumerable<Account> accounts = accountStore.FindAccountsForService (CREDENTIALS_SERVICE);
			Account account = accounts.FirstOrDefault ();
			string username = account.Username;
			string password = account.Properties [LoginService.PASSWORD];
			AuthResponse response = new AuthResponse ();
			response.username = username;
			response.password = password;
			return response;
		}

		public Account userExists ()
		{
			IEnumerable<Account> accounts = accountStore.FindAccountsForService (CREDENTIALS_SERVICE);
			Account account = accounts.FirstOrDefault ();
			if (account != null && account.Properties.ContainsKey (PIN)) {
				return account;
			} else {
				return null;
			}
		}
	}
}

