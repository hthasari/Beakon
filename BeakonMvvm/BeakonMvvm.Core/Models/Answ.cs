using SQLite;

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
        public string  AnsCal { get; set; }
        public string AnsExtra { get; set; }

        public Answ() {}

        public Answ(string anfrom, string anto, string anloc, string anscall, string anextra)
        {
            AnsFrom = anfrom;
            AnsTo = anto;
            AnsCal = anscall;
            AnsLoc = anloc;
            AnsExtra = anextra;

        }

    }

}