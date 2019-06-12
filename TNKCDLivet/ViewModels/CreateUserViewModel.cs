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

using TNKCDLivet.Views;
using System.Windows;
using TNKCDLivet.Models;

namespace TNKCDLivet.ViewModels
{
    public class CreateUserViewModel : ViewModel
    {
        #region Employee
        private Employee _Employee;

        public Employee Employee
        {
            get
            { return _Employee; }
            set
            {
                if (_Employee == value)
                    return;
                _Employee = value;
                RaisePropertyChanged(nameof(Employee));
            }
        }
        #endregion

        #region Ka
        private List<Ka>  _Ka;

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

        #region CKa
        private Ka _CKa;

        public Ka CKa
        {
            get
            { return _CKa; }
            set
            {
                if (_CKa == value)
                    return;
                _CKa = value;
                RaisePropertyChanged(nameof(CKa));
            }
        }
        #endregion

        #region SubmitCommand
        private ViewModelCommand _SubmitCommand;

        public ViewModelCommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new ViewModelCommand(Submit);
                }
                return _SubmitCommand;
            }
        }

        public async void Submit()
        {
            Employee createdEmployee = await Employee.PostEmployeeAsync(this.Employee);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "SubmitCommand"));
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Created"));
        }

        #endregion

        public async void Initialize()
        {
            Ka ka = new Ka();
            this.Ka = await ka.GetKaAsync();

            this.CKa = new Ka();
            this.Employee = new Employee();
        }
    }
}
