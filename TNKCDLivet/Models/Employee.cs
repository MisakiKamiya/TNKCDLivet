using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using Newtonsoft.Json;
using TNKCDLivet.Services;

namespace TNKCDLivet.Models
{
    public class Employee : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです@。
         */

        #region Id

        private int _Id;

        public int Id
        {
            get
            { return _Id; }
            set
            { 
                if (_Id == value)
                    return;
                _Id = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region CD


        private int _CD;

        public int CD
        {
            get
            { return _CD; }
            set
            { 
                if (_CD == value)
                    return;
                _CD = value;
                RaisePropertyChanged();
            }
        }



        #endregion

        #region Name

        private string _Name;
        [JsonProperty("Name")]
        public string Name
        {
            get
            { return _Name; }
            set
            { 
                if (_Name == value)
                    return;
                _Name = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #region NameKana

        private string _NameKana;
        [JsonProperty("KanaName")]

        public string NameKana
        {
            get
            { return _NameKana; }
            set
            { 
                if (_NameKana == value)
                    return;
                _NameKana = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region PassWord

        private string _Password;
        [JsonProperty("Password")]
        public string Password
        {
            get
            { return _Password; }
            set
            {
                if (_Password == value)
                    return;
                _Password = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Mail
        private string _Mail;
        [JsonProperty("Mail")]
        public string Mail
        {
            get
            { return _Mail; }
            set
            { 
                if (_Mail == value)
                    return;
                _Mail = value;
                RaisePropertyChanged();
            }
        }

        #endregion


        public async Task<Employee> LogonAsync()
        {
            IRestService rest = new RestService();
            Employee authorizedUser = await rest.LogonAsync(this);
            return authorizedUser;
        }

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            IRestService rest = new RestService();
            List<Employee> employee = await rest.GetEmployeeAsync();
            return employee;
        }
    }
}
