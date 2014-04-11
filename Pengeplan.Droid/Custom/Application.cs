using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Pengeplan.Core;
using Xamarin.Auth;

namespace Pengeplan.Droid
{
	[Application]			
	public class Application : Android.App.Application
	{
		//This constructor is required
		public Application (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
		{
		}

		public override void OnCreate ()
		{
			base.OnCreate ();
			ServiceContainer.Register<AccountStore> (() => AccountStore.Create (this));
			ServiceContainer.Register<LoginService> (() => new LoginService ());
			ServiceContainer.Register<DataManager> (() => new DataManager ());
			ServiceContainer.Register<PengeplanApi> (() => new PengeplanApi ());
			ServiceContainer.Register<LoginViewModel> (() => new LoginViewModel ());
			ServiceContainer.Register<SecuritiesViewModel> (() => new SecuritiesViewModel ());
			ServiceContainer.Register<DepositoriesViewModel> (() => new DepositoriesViewModel ());
			ServiceContainer.Register<HistoryViewModel> (() => new HistoryViewModel ());
			ServiceContainer.Register<TransactionsViewModel> (() => new TransactionsViewModel ());
			ServiceContainer.Register<UpdateTransactonsViewModel> (() => new UpdateTransactonsViewModel ());
		}
	}
}

