using SQLite.Net;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Author Gurpreet Dhaliwal

namespace BeakonMvvm.Core
{
    [Table("Person")]
    public class Person
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int ID
        {

            get { return _id; }

            set { this._id = value; }
        }

        public string pFirstname { get; set; }
        public string pLastname { get; set; }

        public Person(string firstname, string lastname)
        {
            pFirstname = firstname;
            pLastname = lastname;
        }
 
        public override string ToString()
        {
            return string.Format("[Person: ID={0}, FirstName={1}, LastName={2}]", ID, pFirstname, pLastname);
        }


    }
}