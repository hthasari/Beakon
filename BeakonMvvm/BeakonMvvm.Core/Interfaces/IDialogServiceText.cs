﻿using System.Threading.Tasks;

namespace BeakonMvvm.Core.Interfaces
{
    public interface IDialogServiceText
    {
        /// <summary>
        /// Shows a dialog to the user, with a chosen message and title
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        Task<bool> Show(string message, string title);

        /// <summary>
        /// Shows a dialog to the user, with a chosen message, title, confirm button and cancel button
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="confirmButton"></param>
        /// <param name="cancelButton"></param>
        /// <returns></returns>
        Task<bool> Show(string message, string title, string confirmButton, string cancelButton);
    }
}