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
using TNKCDLivet.Services;
using System.Windows;

namespace TNKCDLivet.ViewModels
{
    public class UserPropertiesViewModel : ViewModel
    {
        #region Employee
        private List<Employee> _Employee;

        public List<Employee> Employee
        {
            get
            { return _Employee; }
            set
            {
                if (_Employee == value)
                    return;
                _Employee = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ShowCreateUserCommand
        private ViewModelCommand _ShowCreateUserCommand;

        public ViewModelCommand ShowCreateUserpCommand
        {
            get
            {
                if (_ShowCreateUserCommand == null)
                {
                    _ShowCreateUserCommand = new ViewModelCommand(ShowCreateUser);
                }
                return _ShowCreateUserCommand;
            }
        }

        public void ShowCreateUser()
        {
            System.Diagnostics.Debug.WriteLine("ShowCreateUser");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                CreateUserViewModel ViewModel = new CreateUserViewModel();
                var message = new TransitionMessage(typeof(Views.CreateUser), ViewModel, TransitionMode.Modal, "ShowCreateUser");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion





        public async void Initialize()
        {
            Employee employee = new Employee();
            this.Employee = await employee.GetEmployeeAsync();


        }
    }
}
