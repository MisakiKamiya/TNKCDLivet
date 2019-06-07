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

        #region CloseCommand
        private ViewModelCommand _CloseCommand;

        public ViewModelCommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                {
                    _CloseCommand = new ViewModelCommand(Close);
                }
                return _CloseCommand;
            }
        }

        public void Close()
        {
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
        }
        #endregion

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


            var message= new TransitionMessage(typeof(Views.CreateUser), new UserPropertiesViewModel(), TransitionMode.Modal, "UserCreate");
            Messenger.Raise(message);


        }
        #endregion

        #region UserDeleteCommand
        private ListenerCommand<Employee> _UserDeleteCommand;

        public ListenerCommand<Employee> UserDeleteCommand
        {
            get
            {
                if (_UserDeleteCommand == null)
                {
                    _UserDeleteCommand = new ListenerCommand<Employee>(UserDelete);
                }
                return _UserDeleteCommand;
            }
        }

        public async void UserDelete(Employee Employee)
        {
            System.Diagnostics.Debug.WriteLine("DeleteCommand" + Employee.Id);
            Employee deletedUser = await Employee.DeleteEmployeeAsync(Employee.Id);
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "ShowUserMst"));
            this.Initialize();
        }
        #endregion

        public async void Initialize()
        {
            Employee employee = new Employee();
            this.Employee = await employee.GetEmployeeAsync();
        }
    }
}
