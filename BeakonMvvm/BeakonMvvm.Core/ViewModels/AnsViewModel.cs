using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using BeakonMvvm.Core.Interfaces;
using System.Windows.Input;
using BeakonMvvm.Core.Database;
using System.Threading.Tasks;

namespace BeakonMvvm.Core.ViewModels
{
    public class AnsViewModel : MvxViewModel
    {
        public ICommand SelectMessage { get; private set; }
        private readonly IDialogServiceP dialog;
        private ObservableCollection<Answ> messages;
        IAnsDB answerDB;
        public ObservableCollection<Answ> Message
        {
            get { return messages; }
            set
            {
                SetProperty(ref messages, value);
            }
        }


        public AnsViewModel(IDialogServiceP dialog, IToast toast, IAnsDB ansDB)
        {
            answerDB = ansDB;
            if (MyGlobals.answer != null)
                {
                Answ sel = MyGlobals.answer;
                insertAns(sel.AnsFrom, sel.AnsTo, sel.AnsCal, sel.AnsLoc, sel.AnsExtra);
                MyGlobals.answer = null;
               }

            Message = new ObservableCollection<Answ>();
            toast.Show("Responses Loading...");
            getCount(toast);
            this.dialog = dialog;

            SelectMessage = new MvxCommand<Answ>(async selectedItem =>
            {
                string mes = "from " + selectedItem.AnsFrom + "\n" + "Calendar: " + selectedItem.AnsCal + "\n" + "Location: "+ selectedItem.AnsLoc + "\nOther Info:" + selectedItem.AnsExtra;
                List<string> Answer = await dialog.Show(mes, "Status Response", "Ok", "Delete");

                if  (Answer[0] == "false")
                {
                    Message.Remove(selectedItem);
                    DeleteAns(selectedItem.Id);
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

        public async void getCount(IToast t)
        {
            foreach (Answ a in await answerDB.GetAns(MyGlobals.SelPer.pFirstname))
            {
                Message.Add(a);
            }
        }
        public void DeleteAns(object id)
        {
            Task<int> aa = answerDB.DeleteAns(id);
        }

        public async void insertAns(string from, string to, string cal, string loc, string extra)
        {
            await answerDB.InsertAns(from,to, cal,loc,extra);
        }




    }
}

