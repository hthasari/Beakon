using System;

using Android.App;
using BeakonMvvm.Core.Interfaces;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using System.Threading.Tasks;
using Android.Views;
using Android.Widget;

namespace BeakonMvvm.Droid.Services
{
    public class DialogServiceText : IDialogService
    {
        Dialog dialog = null;
       public int word;

        public async Task<bool> Show(string message, string title)
        {
            return await Show(message, title, "OK", "Cancel");
        }

        public async Task<bool> Show(string message, string title, string confirmButton, string cancelButton)
        {
            bool buttonPressed = false;
            bool chosenOption = false;
            Application.SynchronizationContext.Post(_ =>
            {



                var mvxTopActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();

                Android.App.AlertDialog.Builder alertDialog = new AlertDialog.Builder(mvxTopActivity.Activity);
                alertDialog.SetTitle(title);
                alertDialog.SetMessage(message);
                //alertDialog.SetView(Resource.Layout.CustomDialog);
                alertDialog.SetNegativeButton(cancelButton, (s, args) =>
                {
                    chosenOption = false;
                });
                alertDialog.SetPositiveButton(confirmButton, (s, args) =>
                {

                    chosenOption = true;

                    //var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();

                  
                    //string word = top.Activity.FindViewById<EditText>(Resource.Id.editTextDialogUserInput).Text;

                    //int i = 5;


                });

                dialog = alertDialog.Create();
                dialog.DismissEvent += (object sender, EventArgs e) =>
                {
                    buttonPressed = true;
                    dialog.Dismiss();
                };
                dialog.Show();
            }, null);
            while (!buttonPressed)
            {
                await Task.Delay(100);
            }
            return chosenOption;
        }
    }
}