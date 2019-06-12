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
        private Employee _CEmployee;

        public Employee CEmployee
        {
            get
            { return _CEmployee; }
            set
            {
                if (_CEmployee == value)
                    return;
                _CEmployee = value;
                RaisePropertyChanged(nameof(CEmployee));
            }
        }
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


            CreateUserViewModel ViewModel = new CreateUserViewModel();
            var message = new TransitionMessage(typeof(Views.CreateUser), ViewModel, TransitionMode.Modal, "UserCreate");
            Messenger.Raise(message);

       
        }
        #endregion

          #region UserEditCommand
        private ViewModelCommand _UserEditCommand;

        public ViewModelCommand UserEditCommand

        {
            get
            {
                if (_UserEditCommand == null)
                {
                    _UserEditCommand = new ViewModelCommand(UserEdit);
                }
                return _UserEditCommand;
            }
        }

        public void UserEdit()
        {

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
            window.Hide();


            var message = new TransitionMessage(typeof(Views.UserEdit), new UserPropertiesViewModel(), TransitionMode.Modal, "UserEdit");
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
            Employee deletedemployee = await Employee.DeleteEmployeeAsync(Employee.Id);
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "ShowDeleteCommand"));
        }
        #endregion

        #region BusyoCombo(絞り込み)
        private IEnumerable<Employee> _BusyoCombo;

        public IEnumerable<Employee> BusyoCombo
        {
            get
            { return _BusyoCombo; }
            set
            {
                if (_BusyoCombo == value)
                    return;
                _BusyoCombo = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region SelectBusyoCommand(絞り込み)
        private ListenerCommand<Ka> _SelectBusyoCommand;

        public ListenerCommand<Ka> SelectBusyoCommand
        {
            get

            {
                if (_SelectBusyoCommand == null)
                {
                    _SelectBusyoCommand = new ListenerCommand<Ka>(SelectBusyo);
                }
                return _SelectBusyoCommand;
            }
        }

        public void SelectBusyo(Ka parameter)
        {
            this.BusyoCombo = Employee.Where(t => parameter == t.Ka);
        }
        #endregion

        #region Ka

        private List<Ka> _Ka;

        public List<Ka> Ka
        {
            get
            { return _Ka; }
            set
            { 
                if (_Ka == value)
                    return;
                _Ka = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Busyo

        private List<Busyo> _Busyo;

        public List<Busyo> Busyo
        {
            get
            { return _Busyo; }
            set
            { 
                if (_Busyo == value)
                    return;
                _Busyo = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public async void Initialize()
        {
            Employee employee = new Employee();
            this.Employee = await employee.GetEmployeeAsync();
            this.CEmployee = new Employee();

            Ka ka = new Ka();
            this.Ka = await ka.GetKaAsync();

            Busyo busyo = new Busyo();
            this.Busyo = await busyo.GetBusyoAsync();
                 
           

        }
        #region UserEditCommand
        private ListenerCommand<Employee> _EmployeeEditCommand;

        public ListenerCommand<Employee> EmployeeEditCommand
        {
            get
            {
                if (_EmployeeEditCommand == null)
                {
                    _EmployeeEditCommand = new ListenerCommand<Employee>(UserEdit);
                }
                return _EmployeeEditCommand;
            }
        }

        public void UserEdit(Employee Employee)
        {
            System.Diagnostics.Debug.WriteLine("EmployeeEditCommand" + Employee.Id);
            UserEditViewModel ViewModel = new UserEditViewModel();
            ViewModel.Employee = Employee;
            var message = new TransitionMessage(typeof(Views.UserEdit), ViewModel, TransitionMode.Modal, "UserEdit");
            Messenger.Raise(message);
        }
        #endregion
    }
}
