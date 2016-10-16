﻿using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BeakonMvvm.Core.Interfaces;
using BeakonMvvm.Core.Database;

namespace BeakonMvvm.Core.ViewModels
{
    public class AnswerViewModel : MvxViewModel

    {
        private IReqDB dbss;

        static string nameofperson = "Request Status of " + MyGlobals.perr.pFirstname + "";

        private string _PerInfo = nameofperson;
        public string PerInfo
        {
            get { return _PerInfo; }
        }

        private string _PersonPhto = MyGlobals.perr.photo;
        public string PersonPhto
        {
            get { return _PersonPhto; }
        }

        private string _ExtraInfo;
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
        public ICommand CancelButton { get; private set; }

        public AnswerViewModel(IToast toast)
        {

            SendButton = new MvxCommand(() =>
                {
                    dbss = new ReqDB();

                    string from = "form " + MyGlobals.SelPer.pFirstname + " " + MyGlobals.SelPer.pLastname;

                    dbss.InsertReq(new Req(from, MyGlobals.perr.pFirstname, IsCheckedCal, IsCheckedLoc, ExtraInfo));

                    toast.Show("Status Request Sent");

                    ShowViewModel<NotificationViewModel>();

                });

            CancelButton = new MvxCommand(() =>
            {
                ShowViewModel<RequestsViewModel>();

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
