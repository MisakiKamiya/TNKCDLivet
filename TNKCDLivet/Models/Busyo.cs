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
    public class Busyo : NotificationObject
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

        #region BusyoName

        private string _BusyoName;

        public string BusyoName
        {
            get
            { return _BusyoName; }
            set
            { 
                if (_BusyoName == value)
                    return;
                _BusyoName = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Power

        private bool _Power;

        public bool Power
        {
            get
            { return _Power; }
            set
            { 
                if (_Power == value)
                    return;
                _Power = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public async Task<List<Busyo>> GetBusyoAsync()
        {
            IRestService rest = new RestService();
            List<Busyo> busyo = await rest.GetBusyoAsync();
            return busyo;
        }
        public async Task<Busyo> PostBusyoAsync(Busyo busyo)
        {
            IRestService rest = new RestService();
            Busyo createdbusyo = await rest.PostBusyoAsync(busyo);
            return createdbusyo;
        }
        public async Task<Busyo> DeleteBusyoAsync(int Id)
        {
            IRestService rest = new RestService();
            Busyo deletedbusyo = await rest.DeleteBusyoAsync(Id);
            return deletedbusyo;
        }

    }
}
