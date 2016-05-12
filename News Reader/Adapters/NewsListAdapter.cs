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

namespace News_Reader.Adapters
{
    public class NewsListAdapter : BaseAdapter
    {
        Activity activity;
        List<RSS.Item> listItem;

        public NewsListAdapter(Activity activity, List<RSS.Item> listItem)
        {
            this.activity = activity;
            this.listItem = listItem;
        }

        public override int Count
        {
            get
            {
                return listItem.Count();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return listItem[position];
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = activity.LayoutInflater.Inflate(Resource.Layout.NewsListItem, null);
            }
            view.FindViewById<TextView>(Resource.Id.news_list_item_title).Text = listItem[position].title;
            view.FindViewById<TextView>(Resource.Id.news_list_item_content).Text = listItem[position].content;
            return view;
        }
    }
}