using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using TNKCDLivet.Models;
using System.Windows;

namespace TNKCDLivet.ViewModels
{
    public class UserPropertiesViewModel : ViewModel
    {
        public void Initialize()
        {
        }

        #region UserCreateCommand
        private ViewModelCommand _UserCreateCommand;

        public ViewModelCommand UserCreateCommand

        {
            get
            {
                if (_UserCreateCommand == null)
                {
                    _UserCreateCommand = new ViewModelCommand(UserCreate);
                }
                return _UserCreateCommand;
            }
        }

        public void UserCreate()
        {

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
            window.Hide();


            var message= new TransitionMessage(typeof(Views.CreateUser), new MainWindowViewModel(), TransitionMode.Modal, "UserCreate");
            Messenger.Raise(message);


        }
        #endregion
    }
}
