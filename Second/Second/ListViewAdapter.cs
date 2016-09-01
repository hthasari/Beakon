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

// Author Harri Tuononen
namespace Second
{
    public class ListViewAdapter : BaseAdapter
    {
       private List<RequestMessage> mItems;
       private Context mContext;

       public ListViewAdapter(Context Context, List<RequestMessage> items)
        {
            mItems = items;
            mContext = Context;
        }

      public  ListViewAdapter(Context Context, RequestMessage[] items)
        {
            mItems = new List<RequestMessage>();
            foreach (RequestMessage x in items)
            {
                mItems.Add(x);
            }
            
            mContext = Context;
        }
        public override int Count
        {
            get{ return mItems.Count;}
        }

        public override long GetItemId(int position)
        {
            return position;

        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null) {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.CustomListView, null, false);
            }

            TextView rowTextHeader = row.FindViewById<TextView>(Resource.Id.messageHeader);
            rowTextHeader.Text = mItems[position].messageHeader;

            TextView rowTextBasic = row.FindViewById<TextView>(Resource.Id.basicText);
            rowTextBasic.Text = mItems[position].basicText;

            return row;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

    } 
}