using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Webkit;

namespace News_Reader.Activities
{
    [Activity(Label = "WebActivity")]
    public class WebActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set activity to apply color to status bar
            this.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Web);

            // Get toolbar from the layout resource
            var toolbar = FindViewById<Toolbar>(Resource.Id.web_toolbar);

            // And set is to act as an action bar
            SetSupportActionBar(toolbar);

            // Get listview from the layout resource
            var webview = FindViewById<WebView>(Resource.Id.web_webview);

            // Get url from MainActivity
            string url = Intent.GetStringExtra("url");
            string title = Intent.GetStringExtra("title");

            // Load url to webview
            webview.SetWebViewClient(new WebViewClient());
            webview.LoadUrl(url);

            // Set title of web to toolbar
            SupportActionBar.Title = title;
        }
    }
}