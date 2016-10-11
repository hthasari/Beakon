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
using SQLite.Net;

namespace BeakonMvvm.Core.ViewModels
{
   public class RequestsViewModel : MvxViewModel
    { 
        private ObservableCollection<Person> messages;
        PersonDB dbs;
        List<Person> jj = new List<Person>();



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
        public RequestsViewModel()
        {
          //  this.Messages = new ObservableCollection<Person>(dbs.)
            dbs = new PersonDB();
            int j = dbs.InsertPerson(new Person("John", "Dhaliwal"));
            //dbs.InsertPerson(new Person("John", "Dhaliwal"));
            //dbs.InsertPerson(new Person("John", "Dhaliwal"));
            //dbs.InsertPerson(new Person("John", "Dhaliwal"));
            //dbs.InsertPerson(new Person("John", "Dhaliwal"));
            //dbs.DeletePerson(6);
            //   string t = dbs.Count();
            int jjj = j;

            Messages = new ObservableCollection<Person>();
            //jj = dbs.GetPersons();
     
            //foreach (Person p in jj)
            //{
            //    Messages.Add(p);
            //}



            //   db.InsertPerson(new Person("John", "Dhaliwal"));


            //Messages = new ObservableCollection<Person>() {
            //    new Person("John", "Dhaliwal"),
            //    new Person("kala", "Gill"),
            //    new Person("Gora", "Dhillon"),
            //    new Person("Nicki", "Sidhu"),
            //    new Person("Paul", "Mannan")
            //  };

            // db.InsertLocation(new Person("John", "Dhaliwal"));

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


        public MvxCommand memberSelected
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<MemberViewModel>());
            }
        }

    }
    
}

