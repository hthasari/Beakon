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
// Author Harri Tuononen

namespace Beakon
{
  public  class RequestMessage
    {
        public string messageHeader { get; set;}
        public string basicText { get; set; }

        public RequestMessage(string messageHeader1, string basicText1)
        {
            messageHeader = messageHeader1;
            basicText = basicText1;
        }
    }
}