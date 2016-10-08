﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;

namespace BeakonMvvm.Core.ViewModels
{
   public class MemberViewModel : MvxViewModel
    {

        private ObservableCollection<Person> messages;

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
        public MemberViewModel()
        {
            Messages = new ObservableCollection<Person>() {
                new Person("John", "Dhaliwal"),
                new Person("kala", "Gill"),
                new Person("Gora", "Dhillon"),
                new Person("Nicki", "Sidhu"),
                new Person("Paul", "Mannan") };
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
