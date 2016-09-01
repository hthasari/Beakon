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
    [Activity(Label = "Notification")]
    public class Notification : Activity
    {
        public ArrayAdapter<string> ListAdapter { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            String[] recieved = new string[] { "Mark", "John", "Harry" };

            

            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, recieved);

           


        }
    }
}