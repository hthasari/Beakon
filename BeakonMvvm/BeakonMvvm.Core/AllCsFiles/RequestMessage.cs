using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Author Harri Tuononen

namespace BeakonMvvm.Core
{
    public class RequestMessage
    {
        public string MessageHeader { get; set; }
        public string BasicText { get; set; }

        public RequestMessage(string messageHeader1, string basicText1)
        {
            MessageHeader = messageHeader1;
            BasicText = basicText1;
        }
    }
}