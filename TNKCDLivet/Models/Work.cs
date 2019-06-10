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
    public class Work : NotificationObject
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

        #region WorkRelation

        private int _WorkRelation;
        [JsonProperty("WorkRelation")]
        public int WorkRelation
        {
            get
            { return _WorkRelation; }
            set
            { 
                if (_WorkRelation == value)
                    return;
                _WorkRelation = value;
                RaisePropertyChanged();
            }
        }



        #endregion


        public async Task<List<Work>> GetWorkAsync()
        {
            IRestService rest = new RestService();
            List<Work> work = await rest.GetWorkAsync();
            return work;
        }



        public async Task<Work> PostWorkAsync(Work work)
        {
            IRestService rest = new RestService();
            Work createdWork = await rest.PostWorkAsync(work);
            return createdWork;
        }
        public async Task<Work> DeleteWorkAsync(int Id)
        {
            IRestService rest = new RestService();
            Work deletedWork = await rest.DeleteWorkAsync(Id);
            return deletedWork;
        }
    }
}
