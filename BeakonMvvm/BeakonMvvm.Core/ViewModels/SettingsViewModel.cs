using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BeakonMvvm.Core.Classes;

namespace BeakonMvvm.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        static private User UserObj = new User("Joe", "Bloggs", "joebloggs@site.com", false, false);
        static private AllUsersList List = new AllUsersList();


        static private ObservableCollection<User> allContactsList = List.AllUsers;

        static private ObservableCollection<User> userContactsList = UserObj.UserContactsList;

        public ObservableCollection<User> UserContactsList
        {
            get { return userContactsList; }
            set
            {
                SetProperty(ref userContactsList, value);
            }
        }



        public ObservableCollection<User> AllContactsList
        {
            get { return allContactsList; }
            set
            {
                SetProperty(ref allContactsList, value);
            }
        }

        private bool settingsMainViewVisible = true;
        public bool SettingsMainViewVisible
        {
            get { return settingsMainViewVisible; }
            set
            {
                SetProperty(ref settingsMainViewVisible, value);
            }
        }

        private bool settingsFavContViewVisible = false;
        public bool SettingsFavContViewVisible
        {
            get { return settingsFavContViewVisible; }
            set
            {
                SetProperty(ref settingsFavContViewVisible, value);
            }
        }



        public ICommand ButtonFavouriteContacts { get; private set; }
        public ICommand ButtonMainView { get; private set; }
        public SettingsViewModel()
        {
            ButtonFavouriteContacts = new MvxCommand(() =>
            {
                SettingsMainViewVisible = false;
                SettingsFavContViewVisible = true;
                RaisePropertyChanged(() => SettingsMainViewVisible);
            });

            ButtonMainView = new MvxCommand(() =>
            {
                SettingsMainViewVisible = true;
                SettingsFavContViewVisible = false;
                RaisePropertyChanged(() => SettingsMainViewVisible);
            });

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
