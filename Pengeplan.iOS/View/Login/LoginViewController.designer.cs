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
	[Register ("LoginViewController")]
	partial class LoginViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField passwordTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel pinLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField pinTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch rememberSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField usernameTextField { get; set; }

		[Action ("login:")]
		partial void login (MonoTouch.Foundation.NSObject sender);

		[Action ("remember:")]
		partial void remember (MonoTouch.Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (usernameTextField != null) {
				usernameTextField.Dispose ();
				usernameTextField = null;
			}

			if (passwordTextField != null) {
				passwordTextField.Dispose ();
				passwordTextField = null;
			}

			if (rememberSwitch != null) {
				rememberSwitch.Dispose ();
				rememberSwitch = null;
			}

			if (pinLabel != null) {
				pinLabel.Dispose ();
				pinLabel = null;
			}

			if (pinTextField != null) {
				pinTextField.Dispose ();
				pinTextField = null;
			}
		}
	}
}
