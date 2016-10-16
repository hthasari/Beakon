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
        public static Person perr { get; set; }
        public static Person SelPer { get; set; }
    }

    public class RequestsViewModel : MvxViewModel
    { 
       private ObservableCollection<Person> messages;
       private IPersonDB dbs;
       List<Person> jj = new List<Person>();
       public ICommand SelectPer { get; private set; }
       private readonly IDialogService dialog;
        private Person Per;


        public ObservableCollection<Person> Messages
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

        public RequestsViewModel(IDialogService dialog, IPersonDB dbs)
        {
            this.dbs = new PersonDB();
            jj = dbs.GetPersons();

          Messages = new ObservableCollection<Person>();
                 
            foreach (Person p in jj)
            {
               Messages.Add(p);
            }
            this.dialog = dialog;

            SelectPer = new MvxCommand<Person>( selectedPer =>
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

    }



}

