using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BeakonMvvm.Core.Classes;

namespace BeakonMvvm.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        static private User UserObj = new User("Fred", "Flintstone", "email.address@site.com", false, false);
        static private ObservableCollection<User> UserFriends;

        private bool settingsMainViewVisible = true;
        string abc = "a";

        public string Abc
        {
            get { return abc; }
        }

        public bool SettingsMainViewVisible
        {
            get { return settingsMainViewVisible; }
        }


        public string FirstName
        {
            get { return UserObj.UserFirstName; }
            set { UserObj.UserFirstName = value; }
        }

        public string LastName
        {
            get { return UserObj.UserLastName; }
            set { UserObj.UserLastName = value; }
        }

        public string Email
        {
            get { return UserObj.UserEmail; }
            set { UserObj.UserEmail = value; }
        }

        public bool AutoCalendar
        {
            get { return UserObj.UserAutoCalendar; }
            set { UserObj.UserAutoCalendar = value; }
        }

        public bool AutoLocation
        {
            get { return UserObj.UserAutoLocation; }
            set { UserObj.UserAutoLocation = value; }
        }

        public MvxCommand NavNotCmd
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<NotificationViewModel>());
            }
        }

        public MvxCommand NavReqCmd
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<RequestsViewModel>());
            }
        }
    }

    public class FavouratesViewModel : MvxViewModel
    {

    }
}
