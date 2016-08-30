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
    class first : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.first);
            ImageView sendBut = FindViewById<ImageView>(Resource.Id.image_req);
            sendBut.Click += delegate
            {
              //  Android.Widget.Toast.MakeText(this, "Status Request Sent.", ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivityForResult(intent, 0);
            };

        }
    }
}