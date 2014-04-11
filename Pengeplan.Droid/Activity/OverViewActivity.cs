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
using Android.Support.V4.Widget;
using Android;
using Android.Graphics;
using Java.Lang;

namespace Pengeplan.Droid
{
	[Activity (Label = "OverViewActivity")]			
	public class OverViewActivity : BaseActivity <SecuritiesViewModel>
	{
		private readonly HistoryViewModel historyViewModel = ServiceContainer.Resolve<HistoryViewModel> ();
		private UpdateTransactonsViewModel updateModel = ServiceContainer.Resolve<UpdateTransactonsViewModel> ();
		LinearLayout pieContainer;
		private PieView pie;
		SwipeRefreshLayout refresher;

		public OverViewActivity ()
		{

		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.overview);
//
			TabHost host = (TabHost)FindViewById (Resource.Id.tabHost);
			host.Setup ();
//
			TabHost.TabSpec securities = host.NewTabSpec ("secTab");
			securities.SetIndicator (this.Resources.GetString (Resource.String.securities));
			securities.SetContent (Resource.Id.securities);
			host.AddTab (securities);
//
			TabHost.TabSpec depositories = host.NewTabSpec ("depTab");
			depositories.SetIndicator (this.Resources.GetString (Resource.String.depositories));
			depositories.SetContent (Resource.Id.depositories);
			host.AddTab (depositories);
//
			TabHost.TabSpec history = host.NewTabSpec ("hisTab");
			history.SetIndicator (this.Resources.GetString (Resource.String.history));
			history.SetContent (Resource.Id.history);
			host.AddTab (history);
//
//			mPullToRefreshLayouts.add((PullToRefreshLayout) findViewById(R.id.ptr_layout_securities));
//			ActionBarPullToRefresh.from(this).allChildrenArePullable().listener(this).setup(mPullToRefreshLayouts.get(0));
//
//			mPullToRefreshLayouts.add((PullToRefreshLayout) findViewById(R.id.ptr_layout_depositories));
//			ActionBarPullToRefresh.from(this).allChildrenArePullable().listener(this).setup(mPullToRefreshLayouts.get(1));
//
//			mPullToRefreshLayouts.add((PullToRefreshLayout) findViewById(R.id.ptr_layout_history));
//			ActionBarPullToRefresh.from(this).allChildrenArePullable().listener(this).setup(mPullToRefreshLayouts.get(2));
//
//
//			pie = (PieChart) findViewById(R.id.securities_pie_chart);
//			pie.getBorderPaint().setColor(Color.TRANSPARENT);
//			pie.getBackgroundPaint().setColor(Color.TRANSPARENT);


			ListView listViewSecurities = (ListView)FindViewById (Resource.Id.listView_securities);
			listViewSecurities.Adapter = new ListViewAdapter<SecuritiesViewModel> (this);

			ListView listViewDepositories = (ListView)FindViewById (Resource.Id.listView_depositories);
			listViewDepositories.Adapter = new ListViewAdapter<DepositoriesViewModel> (this);
//
			ListView listViewHistory = (ListView)FindViewById (Resource.Id.listView_history);
			listViewHistory.Adapter = new ListViewAdapter<HistoryViewModel> (this);

			listViewHistory.ItemClick += delegate (object sender, Android.Widget.AdapterView.ItemClickEventArgs args) {
				string paperName = historyViewModel.LeftCellContent (args.Position);

				var activity2 = new Intent (this, typeof(TransactionsActivity));
				activity2.PutExtra ("stock", paperName);
				StartActivity (activity2);  
			};

			pieContainer = (LinearLayout)FindViewById (Resource.Id.pie_container_id);
			pie = new PieView (this, pieContainer);
			pieContainer.AddView (pie);

			refresher = FindViewById<SwipeRefreshLayout> (Resource.Id.refresher);
			refresher.SetColorScheme (Resource.Color.ptrsharp_sb_gradient_start, Resource.Color.ptrsharp_sb_gradient_end, Resource.Color.ptrsharp_sb_header_text, Resource.Color.ptrsharp_sb_header_text_shadow);
			refresher.Refresh += async delegate {
				await updateModel.UpdateTransactions ();
				((ArrayAdapter<string>)listViewSecurities.Adapter).NotifyDataSetChanged ();
				((ArrayAdapter<string>)listViewSecurities.Adapter).NotifyDataSetChanged ();
				((ArrayAdapter<string>)listViewHistory.Adapter).NotifyDataSetChanged ();
				refresher.Refreshing = false;
			};

		}
	}
}

