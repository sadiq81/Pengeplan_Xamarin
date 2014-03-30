using System;
using System.Threading.Tasks;

namespace Pengeplan.Core
{
	public class LoginViewModel : BaseViewModel
	{
		public string Username { get; set; }

		public string Password { get; set; }

		public string Pin { get; set; }

		public bool Remember { get; set; }

		public async Task<bool> Login ()
		{
			AuthResponse response = new AuthResponse ();
			if (string.IsNullOrEmpty (Username))
				throw new Exception ("Username is blank.");
			if (string.IsNullOrEmpty (Password))
				throw new Exception ("Password is blank.");
			if (Remember && (string.IsNullOrEmpty (Pin) || Pin.Length < LoginService.PIN_MIN_LENGTH))
				throw new Exception ("Pin is blank or to small.");

			IsBusy = true;
			try {
				response = await pengeplanApi.authenticate (Username, Password, Pin);
				if (response.authorized)
					loginService.StoreCredentials (response);
			} finally {
				IsBusy = false;
				return response.authorized;
			}
		}

		public void DeleteCredentials ()
		{
			loginService.DeleteCredentials ();
		}

		public void ClearFields ()
		{
			Username = Password = Pin = "";
			Remember = false;
		}
	}
}

