using System.Collections.Generic;
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
        public AnsViewModel(IDialogService dialog, ICalendar calendar, INetwork ssid, IToast toast)
        {
            Message = new ObservableCollection<Answ>();
            this.adbs = new AnsDB();

            jj = adbs.GetAns();
            foreach (Answ p in jj)
            {
                Message.Add(p);
            }

            this.ssid = ssid;
            this.dialog = dialog;
            this.calendar = calendar;
            SelectMessage = new MvxCommand<Answ>(async selectedItem =>
            {
                string mes = "from " + selectedItem.AnsFrom + "\n" + "Calendar: Meeting in F111\n" + "Location: "+ selectedItem.AnsLoc + "\nOther Info:" + selectedItem.AnsExtra;
                bool Answer = await dialog.Show(mes, "Status Response", "Ok", "Delete");
                if (Answer == true)
                {

                }
                else if  (Answer == false)
                {
                    Message.Remove(selectedItem);
                    adbs.DeleteAnsw(selectedItem.Id);
                    toast.Show("Status Response Deleted");
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

