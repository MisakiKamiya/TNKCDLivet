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
    public class BusyoRelationViewModel : ViewModel
    {
        #region Busyo

        private string _Busyo;

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
        #region Work

        private string _Work;

        public string Work
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
        public async void Initialize()
        {
            Busyo busyo = new Busyo();
            this.Busyo = await busyo.GetTAsync();
        }

    }
}
