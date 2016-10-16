using SQLite;

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
        public string PEmail { get; set; }
        public string PLocation { get; set; }
    //    public List<string> PCal { get; set; }
        public bool PLocCheck { get; set; }
        public bool PCalCheck { get; set; }


        

        public Person() {}

        public Person(string firstname, string lastname, string phot, string email, string location, bool loccheck, bool calcheck)
        {
            pFirstname = firstname;
            pLastname = lastname;
            photo = phot;
            PEmail = email;
            PLocation = location;
          //  PCal = calander;
            PLocCheck = loccheck;
            PCalCheck = calcheck;

        }

        //public override string ToString()
        //{
        //    return string.Format("[Person: ID={0}, FirstName={1}, LastName={2}]", ID, pFirstname, pLastname);
        //}


    }

}