using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BeakonMvvm.Core.Classes;
using System.Linq;
using BeakonMvvm.Core.Interfaces;
using BeakonMvvm.Core.Database;
using MvvmCross.Platform;

namespace BeakonMvvm.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        static private User UserObj = new User("Joe", "Bloggs", "joebloggs@site.com", false, false, null);

        static private AllUsersList List = new AllUsersList();
        static private ObservableCollection<User> allContactsList = List.AllUsers;

        static private ObservableCollection<User> userContactsList = UserObj.UserContactsList;
        static private ObservableCollection<User> updatedContactsList = UserObj.UserContactsList;


        public ObservableCollection<User> UserContactsList
        {
            get { return userContactsList; }
            set
            {
                SetProperty(ref userContactsList, value);
            }
        }

        static Person selected = MyGlobals.SelPer;

        // First Name
        private string _name = selected.pFirstname;
        public string fName
        {
            get { return _name; }
            set
            {
                if (value != null && value != _name)
                {
                    _name = value;
                    selected.pFirstname = value;
                    RaisePropertyChanged(() => fName);
                }
            }
        }

        //Last Name
        private string _lname = selected.pLastname;
        public string lName
        {
            get { return _lname; }
            set
            {
                if (value != null && value != _lname)
                {
                    _lname = value;
                    selected.pLastname = value;
                    RaisePropertyChanged(() => lName);
                }
            }
        }

        //Last Name
        private string _email = selected.PEmail;
        public string Eemail
        {
            get { return _email; }
            set
            {
                if (value != null && value != _email)
                {
                    _email = value;
                    selected.PEmail = value;
                    RaisePropertyChanged(() => Eemail);
                }
            }
        }

        //Last Name
        private string _photo = selected.photo;
        public string Photo
        {
            get { return _photo; }
        }
        private INetwork ssdi;
        private string ssdiName;




        public string Wifi
        {
            get { return ssdiName; }
            set
            {
                if (value != ssdiName)
                {
                    ssdiName = value;
                    selected.PLocation = value;
                    RaisePropertyChanged(() => Wifi);
                }
            }
        }




        //Last Name
        private bool _loc = selected.PLocCheck;
        public bool Location
        {
            get { return _loc; }
            set
            {
                if (value != _loc)
                {
                    _loc = value;
                    selected.PLocCheck = value;
                    RaisePropertyChanged(() => Location);
                }
            }
        }

        //Last Name
        private bool _cal = selected.PCalCheck;
        public bool Calander
        {
            get { return _cal; }
            set
            {
                if (value != _cal)
                {
                    _cal = value;
                    selected.PCalCheck = value;
                    RaisePropertyChanged(() => Calander);
                }
            }
        }



        public ObservableCollection<User> UpdatedContactsList
        {
            get { return updatedContactsList; }
            set
            {
                SetProperty(ref updatedContactsList, value);
                RaisePropertyChanged(() => UpdatedContactsList);
            }
        }


        public string UserContactsSearchTerm
        {
            set
            {
                UpdatedContactsList = new ObservableCollection<User>( UserObj.UserContactsList.Where(x => x.UserDetails.Contains(value)));
            }
        }

        public void SearchUserContactsList(string UserContactsSearchTerm)
        {
            UpdatedContactsList.Clear();
            updatedContactsList = UserContactsList;
            RaisePropertyChanged(()=> UpdatedContactsList);          
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

        public SettingsViewModel(INetwork ssdi)
        {

            this.ssdi = ssdi;
            ssdiName = ssdi.SSID();
            //string strSSID = ssID.SSID();
            //UserObj.UserSSID = strSSID;

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

        public string UserSSID
        {
            get { return UserObj.UserSSID; }
            set { UserObj.UserSSID = value; }
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
