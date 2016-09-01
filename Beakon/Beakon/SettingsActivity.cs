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


    [Activity(Label = "Beakon", MainLauncher = false, Icon = "@drawable/icon")]
    public class SettingsActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.settings);

            //ImageButton requestButton = FindViewById<ImageButton>(Resource.Id.btnRequest);
            //ImageButton notificationButton = FindViewById<ImageButton>(Resource.Id.btnNotification);
            //ImageButton settingsButton = FindViewById<ImageButton>(Resource.Id.btnSettings);

            
            

        }

    }
}