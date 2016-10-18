using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using BeakonMvvm.Core.Interfaces;
using BeakonMvvm.Droid.Services;
using BeakonMvvm.Droid.Database;
using BeakonMvvm.Core.Database;

namespace BeakonMvvm.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new BeakonMvvm.Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
        protected override void InitializeFirstChance()
        {
            Mvx.LazyConstructAndRegisterSingleton<IDialogService, DialogService>();
            Mvx.LazyConstructAndRegisterSingleton<ISqlite, SqliteDroid>();
            Mvx.LazyConstructAndRegisterSingleton<ICalendar, Calendar>();
            Mvx.LazyConstructAndRegisterSingleton<IPersonDB, PersonDB>();
            Mvx.LazyConstructAndRegisterSingleton<IToast, ToastService>();
            Mvx.LazyConstructAndRegisterSingleton<INetwork, Network>();
            Mvx.LazyConstructAndRegisterSingleton<IDialogServiceText, DialogServiceText>();
            base.InitializeFirstChance();
        }
    }
}