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
        private List<Busyo> _Busyo;

        public List<Busyo> Busyo
        {
            get
            { return _Busyo; }
            set
            {
                if (_Busyo == value)
                {
                    return;
                }

                _Busyo = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CloseCommand
        private ViewModelCommand _CloseCommand;

        public ViewModelCommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                {
                    _CloseCommand = new ViewModelCommand(Close);
                }
                return _CloseCommand;
            }
        }

        public void Close()
        {
            
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
        }
        #endregion

        public async void Initialize()
        {
            Busyo busyo = new Busyo();
            this.Busyo = await busyo.GetBusyoAsync();
        }
    }
}
