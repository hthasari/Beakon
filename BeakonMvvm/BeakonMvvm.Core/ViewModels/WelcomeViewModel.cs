using System.Collections.Generic;
using System.Linq;
using MvvmCross.Core.ViewModels;
using BeakonMvvm.Core.Interfaces;
using BeakonMvvm.Core.Database;
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
        public WelcomeViewModel(IToast toast)
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
                toast.Show("Logged in as " + MyGlobals.SelPer.pFirstname + "");
                ShowViewModel<SettingsViewModel>();

            });
            HarriButton = new MvxCommand(() =>
            {
                MyGlobals.SelPer = Hari;
                toast.Show("Logged in as " + MyGlobals.SelPer.pFirstname + "");
                ShowViewModel<SettingsViewModel>();

            });

        }

    }
}

