using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using Android.Graphics;
using Android.Hardware.Camera2;
using Java.IO;
using Android.Util;
using Java.Lang;

namespace EmotionsX.Droid
{
	[Activity (Label = "EmotionsX.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        
        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
            this.Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            try
            {
                FragmentManager.BeginTransaction().Replace(Resource.Id.fragmentcontainer, EmotionsFragment.NewInstance()).Commit();

            }
            catch (System.Exception e)
            {
                Toast.MakeText(this, "shit happens", ToastLength.Long).Show();
                throw e;
            }
            //FragmentManager.BeginTransaction().Replace(Resource.Id.fragmentcontainer, CameraFragment.NewInstance()).Commit();
            
            //FragmentManager.BeginTransaction().Replace(Resource.Id.fragmentcontainer2, EmotionsFragment.NewInstance()).Commit();
        }
	}
}


