using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Widget;
using RestSharp;
using News_Reader.Models;
using News_Reader.Adapters;
using System.Collections.Generic;

namespace News_Reader
{
    [Activity(Label = "News_Reader", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        ListView listview;
        NewsListAdapter adapter;
        RSS.Item feeds;

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

            // Get listview from the layout resource
            listview = FindViewById<ListView>(Resource.Id.main_listview);

            // Request to RSS
            var client = new RestClient("http://rss2json.com/");
            var request = new RestRequest("api.json?rss_url=http://feeds.bbc.co.uk/indonesian/index.xml", Method.GET);

            // Response from RSS
            IRestResponse<RSS.RootObject> response = client.Execute<RSS.RootObject>(request);

            // Creating list adapter and set it to listview
            NewsListAdapter adapter = new NewsListAdapter(this, response.Data.items);
            listview.Adapter = adapter;

            // Enable click event when list item clicked
            listview.ItemClick += ListViewContent_ItemClick;
        }

        private void ListViewContent_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = (RSS.Item)listview.GetItemAtPosition(e.Position);
            var uri = Android.Net.Uri.Parse(item.link);
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }
    }
}

