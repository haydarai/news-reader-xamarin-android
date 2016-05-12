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

namespace News_Reader.Models
{
    public class RSS
    {
        public class Feed
        {
            public string title { get; set; }
            public string link { get; set; }
            public string author { get; set; }
            public string description { get; set; }
            public string image { get; set; }
        }

        public class Item : Java.Lang.Object
        {
            public string title { get; set; }
            public string link { get; set; }
            public string guid { get; set; }
            public string pubDate { get; set; }
            public List<object> categories { get; set; }
            public string author { get; set; }
            public string thumbnail { get; set; }
            public string description { get; set; }
            public string content { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public Feed feed { get; set; }
            public List<Item> items { get; set; }
        }
    }
}