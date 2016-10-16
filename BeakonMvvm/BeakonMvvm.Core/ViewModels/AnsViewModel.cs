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
        List<Answ> dbAnswers = new List<Answ>();
        public ICommand SelectMessage { get; private set; }
        private readonly IDialogService dialog;

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
        public AnsViewModel(IDialogService dialog, IToast toast)
        {
            Message = new ObservableCollection<Answ>();

            adbs = new AnsDB();

            dbAnswers = adbs.GetAns();

            foreach (Answ person in dbAnswers)
            {
                Message.Add(person);
            }

            this.dialog = dialog;

            SelectMessage = new MvxCommand<Answ>(async selectedItem =>
            {
                string mes = "from " + selectedItem.AnsFrom + "\n" + "Calendar: Meeting in F111\n" + "Location: "+ selectedItem.AnsLoc + "\nOther Info:" + selectedItem.AnsExtra;
                bool Answer = await dialog.Show(mes, "Status Response", "Ok", "Delete");

                if  (Answer == false)
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

