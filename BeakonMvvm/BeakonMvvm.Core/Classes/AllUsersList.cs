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
                new User("0001", "Aaron", "Andersen", "AAndersen1@hotmail.com"),
                new User("0002", "Bill", "Benson", "BBensen1@hotmail.com"),
                new User("0003", "Chevy", "Carter", "CCarter1@hotmail.com"),
                new User("0004","Derek", "Davis", "DDavis1@hotmail.com"),
                new User("0005", "Erin", "Ericson", "EEricson1@hotmail.com"),
                new User("0006", "Fred", "Farrell", "FFarrell1@hotmail.com"),
                new User("0007", "George", "Grinch", "GGrinch1@hotmail.com"),
                new User("0008", "Harri", "Houdini", "HHoudini1@hotmail.com"),
                new User("0009", "Zed", "Zakowski", "ZZakowski@hotmail.com")
            };

        public ObservableCollection<User> AllUsers
        {
            get { return allUsers; }
        }
}
}
