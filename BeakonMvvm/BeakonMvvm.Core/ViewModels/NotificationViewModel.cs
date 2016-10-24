﻿using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using BeakonMvvm.Core.Interfaces;
using System.Windows.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public NotificationViewModel(IReqDB dbss, IDialogService dialog, ICalendar calendar, IToast toast, INetwork net, IAnsDB ans)
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

                if (selectedItem.ReqLoc == true) { ifloc = "Needed"; }

                if (selectedItem.ReqCal == true) { ifcal = "Needed"; }

                string mes = selectedItem.ReqFrom + "\n" + "Calendar: " + ifcal + "\n" + "Location: " + ifloc + "\n" + "Other Info:" + selectedItem.ReqExtra; 

                List<string> Answer = await dialog.Show(mes, "Status Request",  "Send", "Dismiss");
                if (Answer[0] == "true")
                {

                    Message.Remove(selectedItem);
                   await DeleteReq(selectedItem.Id);
                    toast.Show("Status Response Sent");
     
                    string calend = calendar.returnEvents(); // Calander Events for Today
                    string wifi = net.SSID(); // Wifi Access point of person

                    Answ a = new Answ
                    {
                        AnsFrom = selectedItem.ReqTo,
                        AnsTo = selectedItem.ReqFrom,
                        AnsLoc = wifi,
                        AnsCal = calend,
                        AnsExtra = Answer[1]
                    };

                   await insertAns(ans, a);
                }

                else if(Answer[0]=="false")
                {
                    Message.Remove(selectedItem);
                    await DeleteReq(selectedItem.Id);
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

        public async Task DeleteReq(object id)
        {
            await dbs.DeleteReq(id);
        }

        public async Task insertAns(IAnsDB answerDB, Answ a)
        {
                Answ sel = a;
                await answerDB.InsertAns(sel.AnsFrom, sel.AnsTo, sel.AnsCal, sel.AnsLoc, sel.AnsExtra);
              //  ShowViewModel<AnsViewModel>();
        }

    }
}