using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Author Gurpreet Dhaliwal

namespace BeakonMvvm.Core
{
    [Table("Req")]
    public class Req
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ReqFrom { get; set; }
        public string ReqTo { get; set; }
        public bool ReqCal { get; set; }
        public bool ReqLoc { get; set; }
        public string ReqExtra { get; set; }

        public Req() {}

        public Req(string reqfrom, string reqto, bool reqcal, bool reqloc, string reqextra)
        {
            ReqFrom = reqfrom;
            ReqTo = reqto;
            ReqCal = reqcal;
            ReqLoc = reqloc;
            ReqExtra = reqextra;


        }

        //public override string ToString()
        //{
        //    return string.Format("[Person: ID={0}, FirstName={1}, LastName={2}]", ID, pFirstname, pLastname);
        //}


    }

}