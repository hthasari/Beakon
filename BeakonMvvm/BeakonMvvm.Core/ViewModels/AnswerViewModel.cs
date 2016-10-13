using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BeakonMvvm.Core.Interfaces;
using BeakonMvvm.Core.Database;

namespace BeakonMvvm.Core.ViewModels
{
   public class AnswerViewModel : MvxViewModel

    {
        private ObservableCollection<Person> messages;
        private IReqDB dbss;
        List<Person> jj = new List<Person>();

        private string _PerInfo = MyGlobals.perr.pFirstname;
        public string PerInfo
        {
            get { return _PerInfo; }
            set
            {
                if (value != null && value != _PerInfo)
                {
                    _ExtraInfo = value;
                    RaisePropertyChanged(() => PerInfo);
                }
            }
        }


        private string _ExtraInfo = "Extra Info";
    public string ExtraInfo
    {
        get { return _ExtraInfo; }
        set
        {
                if (value != null && value != _ExtraInfo)
                {
                    _ExtraInfo = value;
                    RaisePropertyChanged(() => ExtraInfo);
                }
            }
    }

    private bool _isCheckedCal = true;
    public bool IsCheckedCal
    {
        get { return _isCheckedCal; }
        set
        {

                    _isCheckedCal = value;
                    RaisePropertyChanged(() => IsCheckedCal);
                
            }
    }

        private bool _isCheckedLoc = true;
        public bool IsCheckedLoc
        {
            get { return _isCheckedLoc; }
            set
            {

                _isCheckedLoc = value;
                RaisePropertyChanged(() => IsCheckedLoc);

            }
        }

        public ICommand SendButton { get; private set; }

    public AnswerViewModel()
    {
            
           // jj = dbs.GetPersons();
           

            SendButton = new MvxCommand(() =>
        {
            this.dbss = new ReqDB();
            dbss.InsertReq(new Req("Gurpreet", "Dh", IsCheckedCal, IsCheckedLoc, ExtraInfo));
            List<Req> a = dbss.GetReq();
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
