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
	[Register ("LoginController")]
	partial class LoginController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton LoginButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField PasswordTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel PinLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField PinTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch RememberSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField UsernameTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LoginButton != null) {
				LoginButton.Dispose ();
				LoginButton = null;
			}

			if (PasswordTextField != null) {
				PasswordTextField.Dispose ();
				PasswordTextField = null;
			}

			if (PinLabel != null) {
				PinLabel.Dispose ();
				PinLabel = null;
			}

			if (PinTextField != null) {
				PinTextField.Dispose ();
				PinTextField = null;
			}

			if (RememberSwitch != null) {
				RememberSwitch.Dispose ();
				RememberSwitch = null;
			}

			if (UsernameTextField != null) {
				UsernameTextField.Dispose ();
				UsernameTextField = null;
			}
		}
	}
}
