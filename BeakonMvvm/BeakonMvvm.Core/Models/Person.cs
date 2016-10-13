using SQLite;
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
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string pFirstname { get; set; }
        public string pLastname { get; set; }
        public string photo { get; set; }
        
        public Person() {}

        public Person(string firstname, string lastname, string phot)
        {
            pFirstname = firstname;
            pLastname = lastname;
            photo = phot;

        }

        //public override string ToString()
        //{
        //    return string.Format("[Person: ID={0}, FirstName={1}, LastName={2}]", ID, pFirstname, pLastname);
        //}


    }

}