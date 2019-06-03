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

namespace TNKCDLivet.ViewModels
{
    public class UserPropertiesViewModel : ViewModel
    {
        #region EmployeeProperty
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

        #region KaProperty
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

        public async void Initialize()
        {
            Employee employee = new Employee();
            this.Employee = await employee.GetEmployeeAsync();
            Ka ka = new Ka();
            this.Ka = await ka.GetKaAsync();
        }
    }
}
