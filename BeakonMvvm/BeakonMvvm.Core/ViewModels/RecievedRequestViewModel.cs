using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;

namespace BeakonMvvm.Core.ViewModels
{
   public class RecievedRequestViewModel : MvxViewModel
    {
        private ObservableCollection<RequestMessage> messages;
        public ObservableCollection<RequestMessage> Messages
        {
            get { return messages; }
            set { SetProperty(ref messages, value);
            }
        }


        private string messageHeader;
        public string MessageHeader {
            get { return messageHeader; }
            set { if (value != null)
                
                    SetProperty (ref messageHeader, value);
                }
            }
        private string basicText;
        public string BasicText
        {
            get { return basicText; }
            set
            {
                if (value != null)

                    SetProperty(ref basicText, value);
            }
        }
        public RecievedRequestViewModel()
        {
            Messages = new ObservableCollection<RequestMessage>() {
                new RequestMessage("John Mack", "Recieved request"),
                new RequestMessage("Tom Mack", "Recieved request"),
                new RequestMessage("Nick Mack", "Recieved request"),
                new RequestMessage("Paul Mack", "Recieved request") };
        }

    }
    
}

