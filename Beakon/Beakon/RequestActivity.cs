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


 [Activity(Label = "Requests", MainLauncher = false, Icon = "@drawable/Beakon_Icon")]
    public class RequestActivity : Activity
    {
        private List<Person> mItems;
        private ListView mListView;

       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ImageButton settingsButton = FindViewById<ImageButton>(Resource.Id.btnSettingsMain);
            settingsButton.Click += delegate { StartActivity(typeof(SettingsActivity)); };

            ImageButton notificationButton = FindViewById<ImageButton>(Resource.Id.btnNotificationMain);
            notificationButton.Click += delegate { StartActivity(typeof(NotificationActivity)); };




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
            

            

        }

        private void MListView_ItemClick1(object sender, AdapterView.ItemClickEventArgs e)
        {

            StartActivity(typeof(members));
        }

      
    }
}