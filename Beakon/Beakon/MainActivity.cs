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

    public class Planer
    {
        public string Name { get; set; }
        public string Size { get; set; }

        public Planer(string Name = "", string size = "")
        {
            this.Name = Name;
            Size = size;
        }
    }
    [Activity(Label = "Beakon", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            String[] planets = new String[] { "Mercury", "Venus", "Earth", "Mars",
                                      "Jupiter", "Saturn", "Uranus", "Neptune"};
            var planetList = new List<Planer>();

            foreach (var planet in planets)
            {
                planetList.Add(new Planer(planet,"Huge"));
            }

            var venus = planetList.Where(x => x.Name == "Venus" && x.Size == "Huge").FirstOrDefault();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}

