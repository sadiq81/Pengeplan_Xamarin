// This file has been autogenerated from a class added in the UI designer.

using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Pengeplan.Core;
using System.Threading.Tasks;

namespace Pengeplan.iOS
{
	public partial class LoginController : KeyboardSupportedUIViewController
	{
		readonly LoginViewModel loginViewModel = ServiceContainer.Resolve<LoginViewModel> ();
		string pin = null;

		public LoginController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			LoginButton.TouchUpInside += async(sender, e) => {
				loginViewModel.Username = UsernameTextField.Text;
				loginViewModel.Password = PasswordTextField.Text;
				loginViewModel.Pin = PinTextField.Text;
				loginViewModel.Remember = RememberSwitch.On;
				try {
					bool pinTest = ((this.pin != null && this.pin.Equals (this.PinTextField.Text)) || pin == null);

					bool authenticated = pinTest && await loginViewModel.Login ();

					if (authenticated) {
						this.PerformSegue ("OnLogin", this);
					} else {
						new UIAlertView ("Failure!", "", null, "Ok").Show ();
					}

				} catch (Exception exc) {
					new UIAlertView ("Oops!", exc.Message, null, "Ok").Show ();
				} finally {
				}
			};

			RememberSwitch.ValueChanged += (sender, e) => {
				if (RememberSwitch.On) {
					PinLabel.Hidden = PinTextField.Hidden = false;
				} else {
					UsernameTextField.Text = PasswordTextField.Text = PinTextField.Text = "";
					loginViewModel.ClearFields ();
					pin = null;
					PinLabel.Hidden = PinTextField.Hidden = true;
				}
			};

			if (this.loginViewModel.Remember) {
				this.UsernameTextField.Text = this.loginViewModel.Username;
				this.PasswordTextField.Text = this.loginViewModel.Password;
				this.RememberSwitch.On = true;
				this.PinLabel.Hidden = false;
				this.PinTextField.Hidden = false;
				this.pin = loginViewModel.Pin;
			}

		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			loginViewModel.IsBusyChanged += OnIsBusyChanged;
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			loginViewModel.IsBusyChanged -= OnIsBusyChanged;
		}

		void OnIsBusyChanged (object sender, EventArgs e)
		{
			UsernameTextField.Enabled = PasswordTextField.Enabled = LoginButton.Enabled = !loginViewModel.IsBusy;
		}
	}
}