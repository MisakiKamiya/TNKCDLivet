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
    public class Ka : NotificationObject
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

        #region KaName

        private string _KaName;

        public string KaName
        {
            get
            { return _KaName; }
            set
            { 
                if (_KaName == value)
                    return;
                _KaName = value;
                RaisePropertyChanged();
            }
        }



        #endregion

        #region BusyoId

        private int _BusyoId;

        public int BusyoId
        {
            get
            { return _BusyoId; }
            set
            { 
                if (_BusyoId == value)
                    return;
                _BusyoId = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Busyo

        private Busyo _Busyo;

        public Busyo Busyo
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

        public async Task<List<Ka>> GetKaAsync()
        {
            IRestService rest = new RestService();
            List<Ka> ka = await rest.GetKaAsync();
            return ka;
        }
        public async Task<Ka> PostKaAsync(Ka ka)
        {
            IRestService rest = new RestService();
            Ka createdka = await rest.PostKaAsync(ka);
            return createdka;
        }
        public async Task<Ka> DeleteKaAsync(int Id)
        {
            IRestService rest = new RestService();
            Ka deletedKa = await rest.DeleteKaAsync(Id);
            return deletedKa;
        }

       
    }
}