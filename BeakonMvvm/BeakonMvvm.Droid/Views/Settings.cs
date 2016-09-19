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
        static public Network NetSSID = new Network(WifiManager.ExtraBssid);

        protected override void OnCreate(Bundle Bundle)
        {
            base.OnCreate(Bundle);
            SetContentView(Resource.Layout.settings);
        }
    }

    public class Network
    {
        private string _SSID;

        public Network(string SSID)
        {
            _SSID = SSID;
        }

        public string SSID { 
            get { return _SSID; }
            set { _SSID = WifiManager.ExtraBssid; }
        }
  
    }
}
