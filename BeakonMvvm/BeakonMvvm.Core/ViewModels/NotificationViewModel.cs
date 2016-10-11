using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using BeakonMvvm.Core.Interfaces;
using System.Windows.Input;

namespace BeakonMvvm.Core.ViewModels
{
   public class NotificationViewModel : MvxViewModel
    {
        public ICommand SelectMessage { get; private set; }
        private readonly IDialogService dialog;
        private ICalendar calendar;

        private ObservableCollection<RequestMessage> messages;
        public ObservableCollection<RequestMessage> Messages
        {
            get { return messages; }
            set
            {
                SetProperty(ref messages, value);
            }
        }


        private string messageHeader;
        public string MessageHeader
        {
            get { return messageHeader; }
            set
            {
                if (value != null)

                    SetProperty(ref messageHeader, value);
            }
        }
        private string basicText;
        public string BasicText
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
        public NotificationViewModel(IDialogService dialog, ICalendar calendar)
        {
            
            Messages = new ObservableCollection<RequestMessage>() {
                new RequestMessage("John Mack", "Recieved request"),
                new RequestMessage("Tom Mack", "Recieved request"),
                new RequestMessage("Nick Mack", "Recieved request"),
                new RequestMessage("Nick Mack", "Recieved request"),
                new RequestMessage("Paul Mack", "Recieved request") };
            
            this.dialog = dialog;
            this.calendar = calendar;
            SelectMessage = new MvxCommand<RequestMessage>(async selectedItem =>
            {
              
                bool Answer = await dialog.Show(selectedItem.BasicText, selectedItem.MessageHeader, "Send", "Dismiss");
                if(Answer == true)
                {
                    // list of event on this day. Format is id:title:startingTime
                   List<string> EventList =  calendar.returnEvents();
                    Messages.Remove(selectedItem);

                    //Send Needed Information to databas
                }
                else
                {
                    Messages.Remove(selectedItem);
                
                }
            });
        }

        public MvxCommand NavReqCmd
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<RequestsViewModel>());
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

