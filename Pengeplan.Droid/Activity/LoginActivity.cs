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
using Java.Lang;

namespace Pengeplan.Droid
{
	[Activity (Label = "Login")]			
	public class LoginActivity : BaseActivity<LoginViewModel>
	{
		EditText username, password, pin;
		TextView pinLabel;
		Switch remember;
		Button login;
		string pinValue;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.login);
			username = FindViewById<EditText> (Resource.Id.username);
			password = FindViewById<EditText> (Resource.Id.password);
			remember = FindViewById<Switch> (Resource.Id.remember);
			pinLabel = FindViewById<TextView> (Resource.Id.pin_label);
			pin = FindViewById<EditText> (Resource.Id.pin);
			login = FindViewById<Button> (Resource.Id.login);
			login.Click += Login;
			remember.CheckedChange += Remember;

			if (this.viewModel.Remember) {
				username.Text = viewModel.Username;
				password.Text = viewModel.Password;
				remember.Checked = true;
				pinLabel.Visibility = ViewStates.Visible;
				pin.Visibility = ViewStates.Visible;
				pinValue = viewModel.Pin;
			}


		}

		protected override void OnResume ()
		{
			base.OnResume ();
			username.Text = password.Text = string.Empty;
		}

		public void Remember (object sender, EventArgs args)
		{

			if (remember.Checked) {
				pinLabel.Visibility = pin.Visibility = ViewStates.Visible;
			} else {
				username.Text = password.Text = pin.Text = "";
				viewModel.ClearFields ();
				pinValue = null;
				pinLabel.Visibility = pin.Visibility = ViewStates.Gone;
			}

		}

		async public void Login (object sender, EventArgs args)
		{
			viewModel.Username = username.Text;
			viewModel.Password = password.Text;
			viewModel.Pin = pin.Text;
			try {

				bool pinTest = ((pinValue != null && pinValue.Equals (pin.Text)) || pinValue == null);

				bool authenticated = pinTest && await viewModel.Login ();

				if (authenticated) {
					StartActivity (typeof(OverViewActivity));
					this.Finish ();
				} else {
					DisplayError (new NullPointerException ("Error in login"));
				}
				//TODO: navigate to a new activity
			} catch (Java.Lang.Exception exc) {
				DisplayError (exc);
			}
		}
	}
}

