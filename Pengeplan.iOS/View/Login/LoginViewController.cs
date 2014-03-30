using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading.Tasks;
using Pengeplan.Core;

namespace Pengeplan.iOS
{
	public partial class LoginViewController : CustomUIViewController
	{
		public LoginViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		
			// Perform any additional setup after loading the view, typically from a nib.

		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion

		async partial void login (NSObject sender)
		{

			if (true) {
				this.PerformSegue ("loginSeque", this);
			}

		}

		partial void remember (NSObject sender)
		{
			if (this.rememberSwitch.On) {
				this.pinLabel.Hidden = this.pinTextField.Hidden = false;
			} else {
				this.pinLabel.Hidden = this.pinTextField.Hidden = true;
				this.usernameTextField.Text = "";
				this.passwordTextField.Text = "";
				this.usernameTextField.Enabled = true;
				this.passwordTextField.Enabled = true;
				this.pinTextField.Text = "";
				this.usernameTextField.TextColor = UIColor.Black;
				this.passwordTextField.TextColor = UIColor.Black;
				pin = null;
				//[[LoginService sharedLoginService] deleteAccounts];

			}
		}
	}
}

