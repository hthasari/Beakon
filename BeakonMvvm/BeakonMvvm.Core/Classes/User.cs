using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeakonMvvm.Core.Classes
{
    class User
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private bool _autoCalendar;
        private bool _autoLocation;
        private string _nearestWifi;
        private string _nearestBlutooth;
        private string _latestUpdateTime;

        public User(string firstName, string lastName, string email, bool autoCalendar, bool autoLocation)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _autoCalendar = autoCalendar;
            _autoLocation = autoLocation;
        }

        public User(string firstName, string lastName, string email, bool autoCalendar, bool autoLocation, string nearestWifi, string nearestBlutooth)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _autoCalendar = autoCalendar;
            _autoLocation = autoLocation;
            _nearestWifi = null;
            _nearestBlutooth = null;
            _latestUpdateTime = null;

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

    }
}
