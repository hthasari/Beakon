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

namespace BeakonMvvm.Droid.Services
{
    class Event
    {
        public string EventHeader { get; set; }
        public string EventText { get; set; }

        public Event(string messageHeader1, string basicText1)
        {
            EventHeader = messageHeader1;
            EventText = basicText1;
        }
    }
}