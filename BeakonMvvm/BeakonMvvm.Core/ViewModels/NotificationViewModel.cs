using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using BeakonMvvm.Core.Interfaces;
using System.Windows.Input;
using BeakonMvvm.Core.Database;

namespace BeakonMvvm.Core.ViewModels
{
    public class NotificationViewModel : MvxViewModel
    {

        private IReqDB dbs;
        private IAnsDB adbs;
        List<Req> dbRequests = new List<Req>();
        public ICommand SelectMessage { get; private set; }
        private readonly IDialogService dialog;
        private ICalendar calendar;
        private INetwork ssid;

        private ObservableCollection<Req> messages;
        public ObservableCollection<Req> Message
        {
            get { return messages; }
            set
            {
                SetProperty(ref messages, value);
            }
        }


        private string Reqfrom;
        public string ReqFrom
        {
            get { return Reqfrom; }
            set
            {
                if (value != null)

                    SetProperty(ref Reqfrom, value);
            }
        }
        private string reqextra;

        public string ReqExtra
        {
            get { return reqextra; }
            set
            {
                if (value != null)
                {

                    SetProperty(ref reqextra, value);
                }
            }
        }
        public NotificationViewModel(IDialogService dialog, ICalendar calendar, INetwork ssid, IToast toast)
        {
            Message = new ObservableCollection<Req>();
            dbs = new ReqDB();

            dbRequests = dbs.GetReq();
            foreach (Req request in dbRequests)
            {
                Message.Add(request);
            }

            this.ssid = ssid;
            this.dialog = dialog;
            this.calendar = calendar;
            SelectMessage = new MvxCommand<Req>(async selectedItem =>
            {
                string mes = selectedItem.ReqFrom + "\n" + "Calendar: Needed\n" + "Location: Needed\n" + "Other Info:" + selectedItem.ReqExtra; 

                bool Answer = await dialog.Show(mes, "Status Request",  "Send", "Dismiss");
                if (Answer == true)
                {

                      //  List<string> EventList = calendar.returnEvents();
                    adbs = new AnsDB();

                    Person sell = MyGlobals.SelPer;

                    adbs.InsertAns(new Answ(selectedItem.ReqTo, sell.pFirstname,sell.PLocation, selectedItem.ReqExtra));

                    Message.Remove(selectedItem);
                    dbs.DeleteReq(selectedItem.Id);

                    toast.Show("Status Response Sent");
                }
                else
                {
                    Message.Remove(selectedItem);
                    dbs.DeleteReq(selectedItem.Id);

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
    }
}

