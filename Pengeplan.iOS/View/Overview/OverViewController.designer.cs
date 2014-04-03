// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Pengeplan.iOS
{
	[Register ("OverViewController")]
	partial class OverViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITableView SecuritiesTableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl SegmentedController { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (SecuritiesTableView != null) {
				SecuritiesTableView.Dispose ();
				SecuritiesTableView = null;
			}

			if (SegmentedController != null) {
				SegmentedController.Dispose ();
				SegmentedController = null;
			}
		}
	}
}
