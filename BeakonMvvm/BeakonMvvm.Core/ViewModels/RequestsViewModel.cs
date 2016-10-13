using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.IO;
using BeakonMvvm.Core.Interfaces;
using System.Collections;
using MvvmCross.Platform;
using BeakonMvvm.Core.Database;
using SQLite;
using System.Windows.Input;

namespace BeakonMvvm.Core.ViewModels
{
   public class RequestsViewModel : MvxViewModel
    { 
       private ObservableCollection<Person> messages;
       private IPersonDB dbs;
       List<Person> jj = new List<Person>();
       public ICommand SelectPer { get; private set; }
       private readonly IDialogService dialog;
       public Person Per { get; private set; }


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

            SelectPer = new MvxCommand<Person>(selectedPer =>
            {
                Per = selectedPer;
                ShowViewModel<MemberViewModel>(selectedPer);
            });

                //bool Answer = await dialog.Show(selectedPer.pFirstname, selectedPer.pLastname, "Send", "Dismiss");
                //if (Answer == true)
                //{
                //    Person p = new Person()
                //    { pFirstname = selectedPer.pFirstname,
                //    pLastname = selectedPer.pLastname
                //    };
                    
                //    Messages.Add(p);
                //    dbs.InsertPerson(p);

                //    //Send Needed Information to database
                //}
                //else
                //{
                //    int id = selectedPer.Id;
                //    Messages.Remove(selectedPer);
                //    dbs.DeletePerson(id);

                //}


           


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


        //public MvxCommand memberSelected
        //{
        //    get
        //    {
        //        return new MvxCommand(() => ShowViewModel<MemberViewModel>());
        //    }
        //}

    }
    
}

