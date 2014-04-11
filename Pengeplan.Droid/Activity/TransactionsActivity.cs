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

namespace Pengeplan.Droid
{
	[Activity (Label = "TransactionsActivity")]			
	public class TransactionsActivity : BaseActivity<TransactionsViewModel>
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.transactions);
			String paperName = Intent.GetStringExtra ("stock");
			Window.SetTitle (paperName);

			ListView listViewSecurities = (ListView)FindViewById (Resource.Id.transactionsListView);
			listViewSecurities.Adapter = new ListViewAdapter<TransactionsViewModel> (this);
			((TransactionsViewModel)((ListViewAdapter<TransactionsViewModel>)listViewSecurities.Adapter).model).paperName = paperName;
		}
	}
}

