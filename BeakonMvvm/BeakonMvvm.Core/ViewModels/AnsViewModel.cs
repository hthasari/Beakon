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
        public ICommand SelectMessage { get; private set; }
        private readonly IDialogService dialog;
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


        public AnsViewModel(IDialogService dialog, IToast toast, IAnsDB ansDB)
        {
            answerDB = ansDB;
            if(MyGlobals.answer != null)
            {
                insertAns(MyGlobals.answer);
                MyGlobals.answer = null;
            }

            Message = new ObservableCollection<Answ>();
            toast.Show("Responses Loading...");
            getCount();
            this.dialog = dialog;

            SelectMessage = new MvxCommand<Answ>(async selectedItem =>
            {
                string mes = "from " + selectedItem.AnsFrom + "\n" + "Calendar: " + selectedItem.AnsCal + "\n" + "Location: "+ selectedItem.AnsLoc + "\nOther Info:" + selectedItem.AnsExtra;
                bool Answer = await dialog.Show(mes, "Status Response", "Ok", "Delete");

                if  (Answer == false)
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

        public async void getCount()
        {
            foreach (Answ a in await answerDB.GetAns())
            {
                Message.Add(a);
            }
        }
        public async void DeleteAns(object id)
        {
            await answerDB.DeleteAns(id);
        }

        public async void insertAns(Answ a)
        {
            await answerDB.InsertAns(a);
        }
    }
}

