//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;

//namespace Beakon
//{
//    class members : Activity
//    {
//        protected override void OnCreate(Bundle bundle)
//        {
//            base.OnCreate(bundle);
//            SetContentView(Resource.Layout.members);
//            Button sendBut = FindViewById<Button>(Resource.Id.sendButton);
//            Button cancelBut = FindViewById<Button>(Resource.Id.cancelButton);
//            sendBut.Click += delegate
//            {
//                Android.Widget.Toast.MakeText(this, "Status Request Sent.", ToastLength.Short).Show();
//                Intent intent = new Intent(this, typeof(first));
//                StartActivityForResult(intent, 0);
//            };

//            cancelBut.Click += delegate
//            {
//                AlertDialog.Builder alert = new AlertDialog.Builder(this);
//                alert.SetTitle("Confirm Cancel");
//                alert.SetMessage("Are You Sure want to cancel Status request ?");
//                alert.SetPositiveButton("Yes", (senderAlert, args) =>
//                {
//                    Toast.MakeText(this, "Request Canceled", ToastLength.Short).Show();
//                    Intent intent = new Intent(this, typeof(first));
//                    StartActivityForResult(intent, 0);
//                });

//                alert.SetNegativeButton("No", (senderAlert, args) =>
//                {
//                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
//                });

//                Dialog dialog = alert.Create();
//                dialog.Show();
//            };


//        }
//    }
//}