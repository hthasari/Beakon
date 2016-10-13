using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using BeakonMvvm.Core.Interfaces;
using System.Windows.Input;
using BeakonMvvm.Core.Database;

namespace BeakonMvvm.Core.ViewModels
{
    public class NotificationViewModel : MvxViewModel
    {

        private IReqDB dbs;
        List<Req> jj = new List<Req>();
        public ICommand SelectMessage { get; private set; }
        private readonly IDialogService dialog;
        private ICalendar calendar;
        private INetwork ssid;

        private ObservableCollection<Req> messages;
        public ObservableCollection<Req> Message
        {
            get { return messages; }
            set
            {
                SetProperty(ref messages, value);
            }
        }


        private string Reqfrom;
        public string ReqFrom
        {
            get { return Reqfrom; }
            set
            {
                if (value != null)

                    SetProperty(ref Reqfrom, value);
            }
        }
        private string reqextra;

        public string ReqExtra
        {
            get { return reqextra; }
            set
            {
                if (value != null)
                {

                    SetProperty(ref reqextra, value);
                }
            }
        }
        public NotificationViewModel(IDialogService dialog, ICalendar calendar, INetwork ssid)
        {
            Message = new ObservableCollection<Req>();
            this.dbs = new ReqDB();
            // dbs.InsertReq(new Req("Gur", "Dhaliwal", true, false, "yes"));
            jj = dbs.GetReq();
            foreach (Req p in jj)
            {
                Message.Add(p);
            }

            this.ssid = ssid;
            this.dialog = dialog;
            this.calendar = calendar;
            SelectMessage = new MvxCommand<Req>(async selectedItem =>
            {

                bool Answer = await dialog.Show(selectedItem.ReqFrom, selectedItem.ReqExtra, "Send", "Dismiss");
                if (Answer == true)
                {
                    // list of event on this day. Format is id:title:startingTime
                    List<string> EventList = calendar.returnEvents();

                    //Name of the wifi
                    string ssidName = ssid.SSID();
                    Message.Remove(selectedItem);
                    
                    //Send Needed Information to databas
                }
                else
                {
                    Message.Remove(selectedItem);
                    dbs.DeleteReq(selectedItem.Id);

                }
            });

            ButtonFavouriteContacts = new MvxCommand(() =>
            {
                SettingsMainViewVisible = false;
                SettingsFavContViewVisible = true;
                RaisePropertyChanged(() => SettingsMainViewVisible);
            });

            ButtonMainView = new MvxCommand(() =>
            {
                SettingsMainViewVisible = true;
                SettingsFavContViewVisible = false;
                RaisePropertyChanged(() => SettingsMainViewVisible);
            });
        }

        public MvxCommand NavReqCmd
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<RequestsViewModel>());
            }
        }

        public MvxCommand NavSetCmd
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<SettingsViewModel>());
            }
        }

  

        private bool settingsMainViewVisible = true;
        public bool SettingsMainViewVisible
        {
            get { return settingsMainViewVisible; }
            set
            {
                SetProperty(ref settingsMainViewVisible, value);
            }
        }

        private bool settingsFavContViewVisible = false;
        public bool SettingsFavContViewVisible
        {
            get { return settingsFavContViewVisible; }
            set
            {
                SetProperty(ref settingsFavContViewVisible, value);
            }
        }



        public ICommand ButtonFavouriteContacts { get; private set; }
        public ICommand ButtonMainView { get; private set; }




    }


    }

