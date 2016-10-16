using Android.App;
using Android.OS;
using BeakonMvvm.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using Android.Net.Wifi;

namespace BeakonMvvm.Droid.Views
{
    [MvxViewFor(typeof(SettingsViewModel))]
    [Activity(Label = "Settings")]
    public class Settings : MvxActivity
    {
        protected override void OnCreate(Bundle Bundle)
        {
            base.OnCreate(Bundle);
            SetContentView(Resource.Layout.settings);
        }
    }
}
