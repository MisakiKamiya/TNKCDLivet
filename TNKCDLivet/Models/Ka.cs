using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Livet;
using TNKCDLivet.Services;

namespace TNKCDLivet.Models
{
    internal class Ka
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

        private int _KaName;

        public int KaName
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

        private void RaisePropertyChanged()
        {
            throw new NotImplementedException();
        }
        

    }
}