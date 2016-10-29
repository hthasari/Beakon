using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using BeakonMvvm.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace BeakonMvvm.Droid.Views
{
    [MvxViewFor(typeof(NotificationViewModel))]
    [Activity(Label = "Notification")]
    public class Notification : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Notification);

            SwipeRefreshLayout refresher = FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);
            refresher.Refresh += delegate {
                // refresher.Refreshing = false;
              
            };

        }

    }

}

