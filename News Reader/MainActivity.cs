using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Widget;


namespace News_Reader
{
    [Activity(Label = "News_Reader", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set activity to apply color to status bar
            this.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get toolbar from the layout resource
            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);

            // And set is to act as an action bar
            SetSupportActionBar(toolbar);

            //// Get our button from the layout resource,
            //// and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}

