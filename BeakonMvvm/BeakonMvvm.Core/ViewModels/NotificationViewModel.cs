using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using BeakonMvvm.Core.Interfaces;
using System.Windows.Input;
using BeakonMvvm.Core.Database;
using Android.App;
using System;
using System.Windows;
using System.Diagnostics;
using System.Threading.Tasks;
using Android.OS;
using Java.Util.Logging;

namespace BeakonMvvm.Core.ViewModels
{
    public class NotificationViewModel : MvxViewModel
    {
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
                RaisePropertyChanged("Message");


            }
        }

        public NotificationViewModel(IReqDB dbss, IDialogService dialog, ICalendar calendar, IToast toast)
        {

            Message = new ObservableCollection<Req>();
            dbs = dbss;       

            this.dialog = dialog;
            this.calendar = calendar;
            toast.Show("Loading from Database");
            LoadRequestes();
           


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
                        AnsLoc = "Wifi",
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