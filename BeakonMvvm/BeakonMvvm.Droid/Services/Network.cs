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
using Android.Net.Wifi;
using BeakonMvvm.Core.Interfaces;

namespace BeakonMvvm.Droid.Database
{
    public class Network : INetwork
    {
        public string SSID()
        {
            var wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);

            string ssId = wifiManager.ConnectionInfo.SSID;

            return ssId;
        }
    }
}