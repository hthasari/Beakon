using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace List
{
    [Activity(Label = "List", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        RequestMessage[] Items = { new RequestMessage("John", "New request"), new RequestMessage("Malcom", "New request"), new RequestMessage("Kate", "New request") };
        ListView view;
        private List<RequestMessage> LItems;
        ListViewAdapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            LItems = new List<RequestMessage>();
            LItems.Add(new RequestMessage("John", "New request"));
            LItems.Add(new RequestMessage("Malcom", "New request"));
            LItems.Add(new RequestMessage("Kate", "New request"));
            LItems.Add(new RequestMessage("Tom", "New request"));
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Notification);

            view = FindViewById<ListView>(Resource.Id.MyListView);


            adapter = new ListViewAdapter(this, LItems);

            view.Adapter = adapter;

            view.ItemClick += View_ItemClick;

        }

        private void View_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle(LItems[e.Position].messageHeader + " Message");
            alert.SetMessage(LItems[e.Position].basicText);
            alert.SetPositiveButton("Send", (senderAlert, args) =>
            {

                Toast.MakeText(this, "Message sent!", ToastLength.Short).Show();
                LItems.Remove(LItems[e.Position]);


            });
            alert.SetNegativeButton("Dissmis", (senderAlert, args) => {
                Toast.MakeText(this, "Request dismissd!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

    }
}

