using System;
using Android.Widget;
using Pengeplan.Core;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;

namespace Pengeplan.Droid
{
	public class ListViewAdapter <TViewModel> : ArrayAdapter<String> where TViewModel : BaseViewModel, ITableViewViewModel
	{
		public ITableViewViewModel model { get; set; }

		public ListViewAdapter (Context context) : base (context, Resource.Layout.transaction_list_cell)
		{
			model = ServiceContainer.Resolve<TViewModel> ();
		}

		public override View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			LayoutInflater inflater = (LayoutInflater)Context.GetSystemService (Context.LayoutInflaterService);

			View rowView = inflater.Inflate (Resource.Layout.transaction_list_cell, parent, false);


			TextView name = (TextView)rowView.FindViewById (Resource.Id.transaction_list_cell_name);

			name.SetWidth (Context.Resources.DisplayMetrics.WidthPixels / 2);
			TextView value = (TextView)rowView.FindViewById (Resource.Id.transaction_list_cell_value);
			value.SetWidth (Context.Resources.DisplayMetrics.WidthPixels / 2);

			name.SetText (model.LeftCellContent (position), TextView.BufferType.Normal);
			value.SetText (model.RightCellContent (position), TextView.BufferType.Normal);

			return rowView;
		}

		public override int Count {
			get {
				return model.NumberOfItems ();
			}
		}
	}
}

