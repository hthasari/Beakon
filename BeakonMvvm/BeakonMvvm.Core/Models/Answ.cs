using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Author Gurpreet Dhaliwal

namespace BeakonMvvm.Core
{
    [Table("Answ")]
    public class Answ
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string AnsFrom { get; set; }
        public string AnsTo { get; set; }
        public string AnsLoc { get; set; }
    //    public bool AnsCal { get; set; }
        public string AnsExtra { get; set; }

        public Answ() {}

        public Answ(string anfrom, string anto, string anloc, string anextra)
        {
            AnsFrom = anfrom;
            AnsTo = anto;
            //ReqCal = reqcal;
            AnsLoc = anloc;
            AnsExtra = anextra;

        }

    }

}