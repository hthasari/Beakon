using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using BeakonMvvm.Core.Interfaces;
using BeakonMvvm.Core.Database;
using System.Windows.Input;

namespace BeakonMvvm.Core.ViewModels
{
    public static class MyGlobals
    {
        public static Perso perr { get; set; }
        public static Perso SelPer { get; set; }
    }

    public class RequestsViewModel : MvxViewModel
    { 
       private ObservableCollection<Perso> messages;
       private IAPerson dbs;

       List<Perso> dbPersons = new List<Perso>();
       public ICommand SelectPer { get; private set; }

        public ObservableCollection<Perso> Messages
        {

            get { return messages; }
            set
            {
                SetProperty(ref messages, value);
            }
        }


        private string messageHeader;
        public string pFirstName
        {

            get { return messageHeader; }
            set
            {
                if (value != null)

                    SetProperty(ref messageHeader, value);
            }
        }
        private string basicText;
        public string pLastName
        {
            get { return basicText; }
            set
            {
                if (value != null)
                {

                    SetProperty(ref basicText, value);
                }
            }
        }

        public RequestsViewModel(IAPerson dbs, IToast toast)
        {
            Messages = new ObservableCollection<Perso>();
            this.dbs = dbs;
            toast.Show("Members Loading...");
            getCount();

            SelectPer = new MvxCommand<Perso>( selectedPer =>
            {
                MyGlobals.perr = selectedPer;
                ShowViewModel<AnswerViewModel>();

            });


        }

        public MvxCommand NavNotCmd
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<NotificationViewModel>());
            }
        }

        public MvxCommand NavSetCmd
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<SettingsViewModel>());
            }
        }

        public async void getCount()
        {

            foreach (Perso a in await dbs.GetPersons())
            { 
                Messages.Add(a);
            }


        }


    }



}

