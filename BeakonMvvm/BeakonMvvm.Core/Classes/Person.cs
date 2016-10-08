using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Author Harri Tuononen

namespace BeakonMvvm.Core
{
    public class Person
    {
        public string pFirstname { get; set; }
        public string pLastname { get; set; }

        public Person(string firstname, string lastname)
        {
            pFirstname = firstname;
            pLastname = lastname;
        }

    }

}