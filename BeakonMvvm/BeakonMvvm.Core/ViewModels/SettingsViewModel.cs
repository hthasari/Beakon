﻿using MvvmCross.Core.ViewModels;
using BeakonMvvm.Core.Interfaces;

namespace BeakonMvvm.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        static Perso selected = MyGlobals.SelPer;

        // First Name
        private string _name = selected.pFirstname;
        public string fName
        {
            get { return _name; }
            set
            {
                if (value != null && value != _name)
                {
                    _name = value;
                    selected.pFirstname = value;
                    RaisePropertyChanged(() => fName);
                }
            }
        }

        //Last Name
        private string _lname = selected.pLastname;
        public string lName
        {
            get { return _lname; }
            set
            {
                if (value != null && value != _lname)
                {
                    _lname = value;
                    selected.pLastname = value;
                    RaisePropertyChanged(() => lName);
                }
            }
        }

        //Last Name
        private string _email = selected.PEmail;
        public string Eemail
        {
            get { return _email; }
            set
            {
                if (value != null && value != _email)
                {
                    _email = value;
                    selected.PEmail = value;
                    RaisePropertyChanged(() => Eemail);
                }
            }
        }

        //Last Name
        private string _photo = selected.photo;
        public string Photo
        {
            get { return _photo; }
        }
        private INetwork ssid;
        private string ssidName;




        public string Wifi
        {
            get { return ssidName; }
            set
            {
                if (value != ssidName)
                {
                    ssidName = value;
                    selected.PLocation = value;
                    RaisePropertyChanged(() => Wifi);
                }
            }
        }




        //Last Name
        private bool _loc = selected.PLocCheck;
        public bool Location
        {
            get { return _loc; }
            set
            {
                if (value != _loc)
                {
                    _loc = value;
                    selected.PLocCheck = value;
                    RaisePropertyChanged(() => Location);
                }
            }
        }

        //Last Name
        private bool _cal = selected.PCalCheck;
        public bool Calandr
        {
            get { return _cal; }
            set
            {
                if (value != _cal)
                {
                    _cal = value;
                    selected.PCalCheck = value;
                    RaisePropertyChanged(() => Calandr);
                }
            }
        }

        public SettingsViewModel(INetwork ssid)
        {

            this.ssid = ssid;
            ssidName = ssid.SSID();
            selected.PLocation = ssidName;
            _lname = MyGlobals.SelPer.pLastname;
            _name = MyGlobals.SelPer.pFirstname;
            _email = MyGlobals.SelPer.PEmail;
            _cal = MyGlobals.SelPer.PCalCheck;
            _loc = MyGlobals.SelPer.PLocCheck;
            _photo = MyGlobals.SelPer.photo;
        }


      public MvxCommand NavNotCmd
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<NotificationViewModel>());
            }
        }

        public MvxCommand NavReqCmd
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<RequestsViewModel>());
            }
        }
    }

}
