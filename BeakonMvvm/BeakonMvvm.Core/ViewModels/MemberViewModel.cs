using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using BeakonMvvm.Core.ViewModels;

namespace BeakonMvvm.Core.ViewModels
{
   public class MemberViewModel : MvxViewModel
    {

        private ObservableCollection<Person> messages;
        public string Reqperson;
        Person p;

        public ObservableCollection<Person> Messages
        {
            get { return messages; }
            set
            {
                SetProperty(ref messages, value);
            }
        }


        private string messageHeader;
        public string pFirstName
        {

            get { return messageHeader; }
            set
            {
                if (value != null)

                    SetProperty(ref messageHeader, value);
            }
        }

        public string ReqPerson
        {

            get { return Reqperson; }
            set
            {
                if (value != null)

                    SetProperty(ref Reqperson, value);
            }
        }
        private string basicText;
        public string pLastName
        {
            get { return basicText; }
            set
            {
                if (value != null)
                {

                    SetProperty(ref basicText, value);
                }
            }
        }
        public MemberViewModel() {
            Reqperson = "a";
        }
        public MvxCommand NavNotCmd {

            get
            {
                return new MvxCommand(() => ShowViewModel<NotificationViewModel>());
            }
        }

        public MvxCommand NavSetCmd
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<SettingsViewModel>());
            }
        }

    }
    
}

