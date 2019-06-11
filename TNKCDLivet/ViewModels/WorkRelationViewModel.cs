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
    public class WorkRelationViewModel : ViewModel
    {
       

        #region Work
        private List<Work> _Work;

        public List<Work> Work
        {
            get
            { return _Work; }
            set
            {
                if (_Work == value)
                {
                    return;
                }

                _Work = value;
                RaisePropertyChanged();
            }
        }
        #endregion

   
        public async void Initialize()
        {
            Work work = new Work();
            this.Work = await work.GetWorkAsync();

       
          
        }

        
    }
}
