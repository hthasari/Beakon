using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BeakonMvvm.Core.Classes
{
    class AllUsersList
    {
        static private ObservableCollection<User> allUsers = new ObservableCollection<User>()
            {
                new User("Aaron", "Andersen", "AAndersen1@hotmail.com"),
                new User("Bill", "Benson", "BBensen1@hotmail.com"),
                new User("Chevy", "Carter", "CCarter1@hotmail.com"),
                new User("Derek", "Davis", "DDavis1@hotmail.com"),
                new User("Erin", "Ericson", "EEricson1@hotmail.com"),
                new User("Fred", "Farrell", "FFarrell1@hotmail.com"),
                new User("George", "Grinch", "GGrinch1@hotmail.com"),
                new User("Harri", "Houdini", "HHoudini1@hotmail.com"),
                new User("Zed", "Zakowski", "ZZakowski@hotmail.com")
            };

        public ObservableCollection<User> AllUsers
        {
            get { return allUsers; }
        }
}
}
