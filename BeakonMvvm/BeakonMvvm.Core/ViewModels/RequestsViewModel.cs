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
        public static Answ answer { get; set; }
    }

    public class RequestsViewModel : MvxViewModel
    { 
       private ObservableCollection<Perso> message;
       private IAPerson dbs;

       List<Perso> dbPersons = new List<Perso>();
       public ICommand SelectPer { get; private set; }

        public ObservableCollection<Perso> Messages
        {

            get { return message; }
            set
            {
                SetProperty(ref message, value);
                RaisePropertyChanged("Messages");
            }
        }

        public RequestsViewModel(IAPerson dbs, IToast toast)
        {
            Messages = new ObservableCollection<Perso>();
            this.dbs = dbs;
            toast.Show("Loading from databse");
            LoadPeople();

            SelectPer = new MvxCommand<Perso>( selectedPer =>
            {
                MyGlobals.perr = null;
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

        public async void LoadPeople()
        {
            foreach (Perso a in await dbs.GetPersons())
            {
                Messages.Add(a);
            }

        }

    }
}

