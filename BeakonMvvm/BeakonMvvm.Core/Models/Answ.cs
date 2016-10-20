
// Author Gurpreet Dhaliwal

namespace BeakonMvvm.Core
{
    public class Answ
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }
        public string AnsFrom { get; set; }
        public string AnsTo { get; set; }
        public string AnsLoc { get; set; }
        public string  AnsCal { get; set; }
        public string AnsExtra { get; set; }

    }

}