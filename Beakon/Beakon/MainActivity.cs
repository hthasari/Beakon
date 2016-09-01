using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Linq;

namespace Beakon
{


    [Activity(Label = "Beakon", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<Person> mItems;
        private ListView mListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);



            ImageButton requestButton = FindViewById<ImageButton>(Resource.Id.abtnRequest);
            ImageButton notificationButton = FindViewById<ImageButton>(Resource.Id.abtnNotification);
            ImageButton settingsButton = FindViewById<ImageButton>(Resource.Id.abtnSettings);

            //settingsButton.Click += delegate { StartActivity(typeof(SettingsActivity)); };

            
             

            mListView = FindViewById<ListView>(Resource.Id.listView);

            

            mItems = new List<Person>(); // new List

            mItems.Add(new Person() { FirstName = "Gurpreet", LastName = "Active" });
            mItems.Add(new Person() { FirstName = "Harri", LastName = "Active" });
            mItems.Add(new Person() { FirstName = "Preet", LastName = "Active" });
            mItems.Add(new Person() { FirstName = "Gurpreet", LastName = "Active" });
            mItems.Add(new Person() { FirstName = "Harri", LastName = "Active" });
            mItems.Add(new Person() { FirstName = "Preet", LastName = "Active" });
            mItems.Add(new Person() { FirstName = "Gurpreet", LastName = "Active" });
            mItems.Add(new Person() { FirstName = "Harri", LastName = "Active" });
            mItems.Add(new Person() { FirstName = "Preet", LastName = "Active" });

            myListViewAdapter adapter = new myListViewAdapter(this, mItems);

            mListView.Adapter = adapter;
            mListView.ItemClick += MListView_ItemClick1;
            

          //  notificationPage();

        }

        private void MListView_ItemClick1(object sender, AdapterView.ItemClickEventArgs e)
        {
            Android.Widget.Toast.MakeText(this, "List View Clicked", ToastLength.Short).Show();
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
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Notification);

            view = FindViewById<ListView>(Resource.Id.MyListView);


            adapter = new ListViewAdapter(this, LItems);

            view.Adapter = adapter;

            view.ItemClick += View_ItemClick;

        }
    }
}