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
    internal class Ka : NotificationObject
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
        #endregion CD

        #region KaName

        private string _KaName;
        [JsonProperty("KaName")]
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

        internal Task<List<Ka>> GetKaAsync()
        {
            throw new NotImplementedException();
        }



        #endregion

        #region Busyo

        private string _Busyo;
        [JsonProperty("Busyo")]
        public string Busyo
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
    }
}