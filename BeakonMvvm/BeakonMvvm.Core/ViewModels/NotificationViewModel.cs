using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using BeakonMvvm.Core.Interfaces;
using System.Windows.Input;
using BeakonMvvm.Core.Database;
using Android.App;
using System;

using System.Diagnostics;

namespace BeakonMvvm.Core.ViewModels
{
    public class NotificationViewModel : MvxViewModel
    {
       // IAnsDB adds = new AnsDB();
        private IReqDB dbs;
        public ICommand SelectMessage { get; private set; }
        private readonly IDialogService dialog;
        private ICalendar calendar;
        private Perso sell = MyGlobals.SelPer;
        private ObservableCollection<Req> two = new ObservableCollection<Req>();


        private ObservableCollection<Req> messages;
        public ObservableCollection<Req> Message
        {
            get { return messages; }
            set
            {
                    SetProperty(ref messages, value);
             

            }
        }

        public NotificationViewModel(IReqDB dbss, IDialogService dialog, ICalendar calendar, IToast toast)
        {
            Message = new ObservableCollection<Req>();
            dbs = dbss;       
            this.dialog = dialog;
            this.calendar = calendar;

            getCount();

            SelectMessage = new MvxCommand<Req>(async selectedItem =>
            {
                
                string mes = selectedItem.ReqFrom + "\n" + "Calendar: Needed\n" + "Location: Needed\n" + "Other Info:" + selectedItem.ReqExtra; 

                bool Answer = await dialog.Show(mes, "Status Request",  "Send", "Dismiss");
                if (Answer == true)
                {

                 Message.Remove(selectedItem);
                 DeleteReq(selectedItem.Id);
                    toast.Show("Status Response Sent");

                    MyGlobals.answer = new Answ
                    {
                        AnsFrom = selectedItem.ReqTo,
                        AnsTo = sell.pFirstname,
                        AnsLoc = sell.PLocation,
                        AnsCal = "Something",
                        AnsExtra = selectedItem.ReqExtra


                    };
                ShowViewModel<AnsViewModel>();
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
            }
        }

        public async void DeleteReq(object id)
        {
            await dbs.DeleteReq(id);
        }

    }
}

