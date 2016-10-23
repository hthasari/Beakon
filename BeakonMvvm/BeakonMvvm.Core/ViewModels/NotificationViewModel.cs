using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using BeakonMvvm.Core.Interfaces;
using System.Windows.Input;
using System.Collections.Generic;

namespace BeakonMvvm.Core.ViewModels
{
    public class NotificationViewModel : MvxViewModel
    {
        private IReqDB dbs;
        public ICommand SelectMessage { get; private set; }
        private readonly IDialogService dialog;
        private ICalendar calendar;
        private Perso sell = MyGlobals.SelPer;
      

        private ObservableCollection<Req> messages;
        public ObservableCollection<Req> Message
        {
            get { return messages; }
            set
            {
                    SetProperty(ref messages, value);
                RaisePropertyChanged("Message");

            }
        }

        public NotificationViewModel(IReqDB dbss, IDialogService dialog, ICalendar calendar, IToast toast, INetwork net)
        {

            Message = new ObservableCollection<Req>();
            dbs = dbss;       
            this.dialog = dialog;
            this.calendar = calendar;
            LoadRequestes();
           
            SelectMessage = new MvxCommand<Req>(async selectedItem =>
            {
                string ifloc = "Not Needed";
                string ifcal = "Not Needed";
                if (selectedItem.ReqLoc == true)
                {
                    ifloc = "Needed";
                }

                if (selectedItem.ReqCal == true)
                {
                    ifcal = "Needed";
                }
                string mes = selectedItem.ReqFrom + "\n" + "Calendar: " + ifcal + "\n" + "Location: " + ifloc + "\n" + "Other Info:" + selectedItem.ReqExtra; 

                List<string> Answer = await dialog.Show(mes, "Status Request",  "Send", "Dismiss");
                if (Answer[0] == "true")
                {

                    Message.Remove(selectedItem);
                    DeleteReq(selectedItem.Id);
                    toast.Show("Status Response Sent");
     
                        string calend = calendar.returnEvents();
      
                    string wifi = net.SSID();
                    MyGlobals.answer = new Answ
                    {
                        AnsFrom = selectedItem.ReqTo,
                        AnsTo = selectedItem.ReqFrom,
                        AnsLoc = wifi,
                        AnsCal = calend,
                        AnsExtra = Answer[1]
                    };

        }
                else if(Answer[0]=="false")
                {
                    Message.Remove(selectedItem);
                    DeleteReq(selectedItem.Id);
                    toast.Show("Status Request Deleted");
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


        public MvxCommand NavAns
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<AnsViewModel>());
            }
        }
        public async void LoadRequestes()
        {

            foreach (Req request in await dbs.GetReq(MyGlobals.SelPer.pFirstname))
            {
                Message.Add(request);
                
            }
        }

        public async void DeleteReq(object id)
        {
            await dbs.DeleteReq(id);
        }

    }
}