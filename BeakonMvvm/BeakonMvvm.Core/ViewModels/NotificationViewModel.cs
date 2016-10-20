using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using BeakonMvvm.Core.Interfaces;
using System.Windows.Input;
using BeakonMvvm.Core.Database;
using Android.App;
using System;

namespace BeakonMvvm.Core.ViewModels
{
    public class NotificationViewModel : MvxViewModel
    {

        private IReqDB dbs;
        private IAnsDB adbs;
        public ICommand SelectMessage { get; private set; }
        private readonly IDialogService dialog;
        private ICalendar calendar;


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
        public NotificationViewModel(IDialogService dialog, ICalendar calendar, IToast toast, IReqDB db)
        {
            Message = new ObservableCollection<Req>();
            dbs = db;
            adbs = new AnsDB();
            toast.Show("Responses Loading...");
            try
            {
                getCount();
            }
            catch (Exception e)
            {
                toast.Show("Error:" + e);
            }
  
            this.dialog = dialog;
            this.calendar = calendar;
            SelectMessage = new MvxCommand<Req>(async selectedItem =>
            {
                
                string mes = selectedItem.ReqFrom + "\n" + "Calendar: Needed\n" + "Location: Needed\n" + "Other Info:" + selectedItem.ReqExtra; 

                bool Answer = await dialog.Show(mes, "Status Request",  "Send", "Dismiss");
                if (Answer == true)
                {
      
                    //string calend = calendar.returnEvents();

                    Perso sell = MyGlobals.SelPer;

                    Answ Hari = new Answ
                    {
                        AnsFrom = selectedItem.ReqTo,
                        AnsTo = sell.pFirstname,
                        AnsLoc = sell.PLocation,
                        AnsCal = "Something",
                        AnsExtra = selectedItem.ReqExtra
                    };
                   await adbs.InsertAns(Hari);

                    Message.Remove(selectedItem);
                 DeleteReq(selectedItem.Id); 
                 toast.Show("Status Response Sent");
                }
                else
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

        public async void getCount()
        {
            
            foreach (Req a in await dbs.GetReq())
            {
                Message.Add(a);
                //  await adb.CheckIfExists(p);
            }
        }

        public async void DeleteReq(object id)
        {
            await dbs.DeleteReq(id);

        }


    }
}

