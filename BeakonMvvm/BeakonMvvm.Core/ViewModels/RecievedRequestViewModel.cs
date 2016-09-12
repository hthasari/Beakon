using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;


namespace BeakonMvvm.Core.ViewModels
{
    class RecievedRequestViewModel : MvxViewModel
    {
          
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
    }
    
}

