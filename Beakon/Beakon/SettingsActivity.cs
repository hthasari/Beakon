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


    [Activity(Label = "Settings", MainLauncher = false, Icon = "@drawable/Beakon_Icon")]
    public class SettingsActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.settings);

            ImageButton settingsButton = FindViewById<ImageButton>(Resource.Id.btnSettingsSettings);
            settingsButton.Click += delegate { StartActivity(typeof(SettingsActivity)); };

            ImageButton notificationButton = FindViewById<ImageButton>(Resource.Id.btnNotificationSettings);
            notificationButton.Click += delegate { StartActivity(typeof(NotificationActivity)); };




        }

    }
}