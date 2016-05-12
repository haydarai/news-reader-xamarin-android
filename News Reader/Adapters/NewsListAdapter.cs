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
using Java.Lang;
using News_Reader.Models;
using RestSharp;

namespace News_Reader.Adapters
{
    public class NewsListAdapter : BaseAdapter<RSS.Item>
    {
        List<RSS.Item> items;
        Activity activity;

        public NewsListAdapter(Activity activity, List<RSS.Item> items)
        {
            this.activity = activity;
            this.items = items;
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override RSS.Item this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return items[position];
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.NewsListItem, parent, false);
            var title = view.FindViewById<TextView>(Resource.Id.news_list_item_title);
            var content = view.FindViewById<TextView>(Resource.Id.news_list_item_content);

            title.Text = items[position].title;
            content.Text = items[position].content;
            return view;
        }
    }
}