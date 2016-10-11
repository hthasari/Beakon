using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Author Gurpreet Dhaliwal

namespace BeakonMvvm.Core
{
    public class Answer
    {
        public Answer() { }

        public int ID { get; set; }
        public string AnsFrom { get; set; }
        public string AnstTo { get; set; }
        public string AnsMessage { get; set; }

        public Answer(Answer ans)
        {

            AnsFrom = ans.AnsFrom;
            AnstTo = ans.AnstTo;
            AnsMessage = ans.AnstTo;
        }

        public Answer(String from, String to, String message)
        {
            AnsFrom = from;
            AnstTo = to;
            AnsMessage = message;
        }

    }
}