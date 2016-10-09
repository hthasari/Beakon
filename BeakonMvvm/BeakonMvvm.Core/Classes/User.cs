using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace BeakonMvvm.Core.Classes
{
    public class User
    {
        public string _nearestWifi;
        public string _nearestBlutooth;
        public string _latestUpdateTime;

        public User(string firstName, string lastName, string email)
        {
            UserFirstName = firstName;
            UserLastName = lastName;
            UserEmail = email;
            UserDetails = lastName + ", " + firstName + " - " + email;
        }

        public User(string firstName, string lastName, string email, bool autoCalendar, bool autoLocation)
        {
            UserFirstName = firstName;
            UserLastName = lastName;
            UserEmail = email;
            UserAutoCalendar = autoCalendar;
            UserAutoLocation = autoLocation;
        }

        public User(string firstName, string lastName, string email, bool autoCalendar, bool autoLocation, string nearestWifi, string nearestBlutooth)
        {
            UserFirstName = firstName;
            UserLastName = lastName;
            UserEmail = email;
            UserAutoCalendar = autoCalendar;
            UserAutoLocation = autoLocation;
            _nearestWifi = null;
            _nearestBlutooth = null;
            _latestUpdateTime = null;
        }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserDetails { get; set; }
        public bool UserAutoCalendar { get; set; }
        public bool UserAutoLocation { get; set; }

        static private ObservableCollection<User> userContactsList = new ObservableCollection<User>() {
                new User("Aaron", "Andersen", "AAndersen1@hotmail.com"),
                new User("Bill", "Benson", "BBensen1@hotmail.com"),
                new User("Fred", "Farrell", "FFarrell1@hotmail.com"),
                new User("Harri", "Houdini", "HHoudini1@hotmail.com") };

        public ObservableCollection<User> UserContactsList
        {
            get { return userContactsList; }
        }

}




}
