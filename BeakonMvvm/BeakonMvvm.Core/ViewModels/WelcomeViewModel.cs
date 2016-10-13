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

    public class WelcomeViewModel : MvxViewModel
    {
        IPersonDB db;
        Person Gur;
        Person Hari;


        public ICommand GurButton { get; private set; }
        public ICommand HarriButton { get; private set; }
        public WelcomeViewModel()
        {
            db = new PersonDB();
            List<string> a = new List<string>();
            a.Add("1.Cal");

            if (db.GetPersons().Count()==0)
            {
                this.Gur = new Person("Gurpreet", "Dhaliwal", "@drawable/gur", "hathur.gg@gmail.com","Someting",true,true);
                this.Hari = new Person("Harri", "Tuononen", "@drawable/harri", "hathur.gg@gmail.com", "Someting", true, true);
                Person Ian = new Person("Ian", "Maskell", "@drawable/iam", "hathur.gg@gmail.com", "Someting", true, true);

                db.InsertPerson(Gur);
                db.InsertPerson(Hari);
                db.InsertPerson(Ian);
            } 
            else
            {
                this.Gur = new Person("Gurpreet", "Dhaliwal", "@drawable/gur", "hathur.gg@gmail.com", "Someting", true, true);
                this.Hari = new Person("Harri", "Tuononen", "@drawable/harri", "hathur.gg@gmail.com", "Someting", true, true);
            }

            GurButton = new MvxCommand(() =>
            {
                MyGlobals.SelPer = Gur;
                ShowViewModel<SettingsViewModel>();

            });
            HarriButton = new MvxCommand(() =>
            {
                MyGlobals.SelPer = Hari;
                ShowViewModel<SettingsViewModel>();

            });

        }

    }
}

