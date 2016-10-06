using MvvmCross.Core.ViewModels;

namespace BeakonMvvm.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        static User UserObj = new User("Fred", "Flintstone", "email.address@site.com", false, false, "");

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

    public class User
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private bool _autoCalendar;
        private bool _autoLocation;
        private string _wifiPoint;

        public User(string firstName, string lastName, string email, bool autoCalendar, bool autoLocation, string wifiPoint)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _autoCalendar = autoCalendar;
            _autoLocation = autoLocation;
            _wifiPoint = wifiPoint;
        }  
        
        public string UserFirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string UserLastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string UserEmail
        {
            get { return _email; }
            set { _email = value; }
        }

        public bool UserAutoCalendar
        {
            get { return _autoCalendar; }
            set { _autoCalendar = value; }
        }
        public bool UserAutoLocation
        {
            get { return _autoLocation; }
            set { _autoLocation = value; }
        }

        public string WifiPoint
        {
            get { return _wifiPoint; }
            set { _wifiPoint = value; }
        }

    }
}