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

namespace Beakon
{

    [Activity(Label = "NotificationActivity")]
    public class NotificationActivity : Activity
    {
        //notification screen
        ListView view;
        private List<RequestMessage> LItems;
        notificationListViewAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            notificationPage();

            // Menu Buttons
            ImageButton settingsButton = FindViewById<ImageButton>(Resource.Id.btnSettingsNotification);
            settingsButton.Click += delegate { StartActivity(typeof(SettingsActivity)); };
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

        private void notificationPage()
        {
            LItems = new List<RequestMessage>();
            LItems.Add(new RequestMessage("John", "New request"));
            LItems.Add(new RequestMessage("Malcom", "New request"));
            LItems.Add(new RequestMessage("Kate", "New request"));
            LItems.Add(new RequestMessage("Tom", "New request"));

            SetContentView(Resource.Layout.Notification);

            view = FindViewById<ListView>(Resource.Id.MyListView);


            adapter = new notificationListViewAdapter(this, LItems);

            view.Adapter = adapter;

            view.ItemClick += View_ItemClick;

        }
    }
}