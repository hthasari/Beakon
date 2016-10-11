using Android.App;
using Android.OS;
using BeakonMvvm.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace BeakonMvvm.Droid.Views
{
    [MvxViewFor(typeof(MemberViewModel))]
    [Activity(Label = "Member")]
    public class answers : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.members);
        }
    }
}

