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
using Android.Views.Animations;

namespace Pengeplan.Droid
{
	[Activity (Label = "Splash", MainLauncher = true)]			
	public class Splash : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			this.RequestWindowFeature (WindowFeatures.NoTitle);
			SetContentView (Resource.Layout.splash);

			// Create your application here
			ImageView splash = (ImageView)FindViewById (Resource.Id.splash_imageView);
			Animation fade_in = AnimationUtils.LoadAnimation (this, Resource.Animation.fade_in);
			splash.StartAnimation (fade_in);
			fade_in.SetAnimationListener (new SplashEndAnimationListener (this));


		}

		private class SplashEndAnimationListener : Java.Lang.Object, Animation.IAnimationListener
		{
			Splash context;

			public SplashEndAnimationListener (Splash context)
			{
				this.context = context;
			}

			public void OnAnimationEnd (Animation animation)
			{
				var intent = new Intent (context, typeof(LoginActivity));
				context.StartActivity (intent);
				context.Finish ();
			}

			public void OnAnimationRepeat (Animation animation)
			{
			}

			public void OnAnimationStart (Animation animation)
			{
			}
		}
	}
}

