﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using Newtonsoft.Json;
using TNKCDLivet.Services;

namespace TNKCDLivet.Models
{
    public class TNKCD : NotificationObject
    {
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

        #region DateSend  

        private DateTime _DateSend;
        [JsonProperty("DateSend")]
        public DateTime DateSend
        {
            get
            { return _DateSend; }
            set
            { 
                if (_DateSend == value)
                    return;
                _DateSend = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region DateHelp

        private DateTime _DateHelp;
        [JsonProperty("DateHelp")]
        public DateTime DateHelp
        {
            get
            { return _DateHelp; }
            set
            { 
                if (_DateHelp == value)
                    return;
                _DateHelp = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region EmployeeToId

        private int? _EmployeeToId;

        public int? EmployeeToId
        {
            get
            { return _EmployeeToId; }
            set
            { 
                if (_EmployeeToId == value)
                    return;
                _EmployeeToId = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region EmployeeTo

        private Employee _EmployeeTo;

        public Employee EmployeeTo
        {
            get
            { return _EmployeeTo; }
            set
            { 
                if (_EmployeeTo == value)
                    return;
                _EmployeeTo = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region EmployeeFromId

        private int? _EmployeeFromId;

        public int? EmployeeFromId
        {
            get
            { return _EmployeeFromId; }
            set
            { 
                if (_EmployeeFromId == value)
                    return;
                _EmployeeFromId = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region EmployeeFrom

        private Employee _EmployeeFrom;

        public Employee EmployeeFrom
        {
            get
            { return _EmployeeFrom; }
            set
            { 
                if (_EmployeeFrom == value)
                    return;
                _EmployeeFrom = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Title

        private string _Title;
        [JsonProperty("Title")]
        public string Title
        {
            get
            { return _Title; }
            set
            { 
                if (_Title == value)
                    return;
                _Title = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Body

        private string _Body;
        [JsonProperty("Body")]
        public string Body
        {
            get
            { return _Body; }
            set
            { 
                if (_Body == value)
                    return;
                _Body = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region WorkId

        private int _WorkId;


        public int WorkId
        {
            get
            { return _WorkId; }
            set
            { 
                if (_WorkId == value)
                    return;
                _WorkId = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Work

        private Work _Work;

        public Work Work
        {
            get
            { return _Work; }
            set
            { 
                if (_Work == value)
                    return;
                _Work = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Look

        private bool _Look;

        public bool Look
        {
            get
            { return _Look; }
            set
            { 
                if (_Look == value)
                    return;
                _Look = value;
                RaisePropertyChanged();
            }
        }

        #endregion


        public async Task<List<TNKCD>> GetTNKCDAsync()
        {
            IRestService rest = new RestService();
            List<TNKCD> TNKCD = await rest.GetTNKCDAsync();
            return TNKCD;
        }
        public async Task<TNKCD> PostTNKCDAsync(TNKCD tNKCD)
        {
            IRestService rest = new RestService();
            TNKCD createdTNKCD = await rest.PostTNKCDAsync(tNKCD);
            return createdTNKCD;
        }
        public async Task<TNKCD> DeleteTNKCDAsync(int Id)
        {
            IRestService rest = new RestService();
            TNKCD deletedTNKCD = await rest.DeleteTNKCDAsync(Id);
            return deletedTNKCD;
        }
        public TNKCD()
        {
            this.DateHelp = DateTime.Now;
            this.DateSend = DateTime.Now;
        }
    }
}
