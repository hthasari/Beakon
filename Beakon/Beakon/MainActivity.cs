﻿using System;
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
            

            // Get our button from the layout resource,

        }

        private void MListView_ItemClick1(object sender, AdapterView.ItemClickEventArgs e)
        {
            Android.Widget.Toast.MakeText(this, "List View Clicked", ToastLength.Short).Show();
        }

    }
}