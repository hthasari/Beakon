using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using BeakonMvvm.Core.Interfaces;
using System.Windows.Input;
using BeakonMvvm.Core.Database;

namespace BeakonMvvm.Core.ViewModels
{
    public class AnsViewModel : MvxViewModel
    {

        private IAnsDB adbs;
        List<Answ> jj = new List<Answ>();
        public ICommand SelectMessage { get; private set; }
        private readonly IDialogService dialog;
        private ICalendar calendar;
        private INetwork ssid;

        private ObservableCollection<Answ> messages;
        public ObservableCollection<Answ> Message
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
        public AnsViewModel(IDialogService dialog, ICalendar calendar, INetwork ssid)
        {
            Message = new ObservableCollection<Answ>();
            this.adbs = new AnsDB();
            // dbs.InsertReq(new Req("Gur", "Dhaliwal", true, false, "yes"));
            jj = adbs.GetAns();
            foreach (Answ p in jj)
            {
                Message.Add(p);
            }

            this.ssid = ssid;
            this.dialog = dialog;
            this.calendar = calendar;
            SelectMessage = new MvxCommand<Req>(async selectedItem =>
            {

                bool Answer = await dialog.Show(selectedItem.ReqFrom, selectedItem.ReqExtra, "Send", "Dismiss");
                if (Answer == true)
                {
                    // list of event on this day. Format is id:title:startingTime
                    //
                    //     List<string> EventList = calendar.returnEvents();
                    this.adbs = new AnsDB();
                    Person sell = MyGlobals.SelPer;
                    adbs.InsertAns(new Answ(selectedItem.ReqTo, sell.pFirstname,sell.PLocation, selectedItem.ReqExtra));

                    //Name of the wifi
                  //  string ssidName = ssid.SSID();
                  //  Message.Remove(selectedItem);
                //    dbs.DeleteReq(selectedItem.Id);

                    //Send Needed Information to databas
                }
                else
                {
                  //  Message.Remove(selectedItem);
                  //  dbs.DeleteReq(selectedItem.Id);

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

        public MvxCommand NavNoti
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<NotificationViewModel>());
            }
        }



    }


    }

