using System;
using Xamarin.Auth;

namespace Pengeplan.Core
{
	public class BaseViewModel
	{
		protected readonly PengeplanApi pengeplanApi = ServiceContainer.Resolve < PengeplanApi> ();
		protected readonly LoginService loginService = ServiceContainer.Resolve < LoginService> ();

		public event EventHandler IsBusyChanged = delegate { };

		public BaseViewModel ()
		{
		}

		private bool isBusy = false;

		public bool IsBusy {
			get { return isBusy; }
			set {
				isBusy = value;
				IsBusyChanged (this, EventArgs.Empty);
			}
		}
	}
}

