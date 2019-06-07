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
using TNKCDLivet.Services;
using System.Windows;

namespace TNKCDLivet.ViewModels
{
    public class WorkRelationViewModel : ViewModel
    {
        private Work _Work;

        public Work CWork
        {
            get
            { return _Work; }
            set
            {
                if (_Work == value)
                    return;
                _Work = value;
                RaisePropertyChanged(nameof(CWork));
            }
        }
        #region Work
        private List<Work> _work;
        public List<Work> Work
        {
            get
            {
                return _work;
                
            }
            set
            {
                if (_work == value)
                    return;
                _work = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        public async void Initialize()
        {

            Work work = new Work();
            this.Work = await work.GetWorkAsync();

            this.CWork = new Work();
        }


        #region SubmitCommand
        private ViewModelCommand _SubmitCommand;

        public ViewModelCommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new ViewModelCommand(Submit);
                }
                return _SubmitCommand;
            }
        }

        public async void Submit()
        {
            Work createdWork = await CWork.PostWorkAsync(this.CWork);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "ShowSubmitCommand"));
        }
        #endregion

        #region DelCommand
        private ListenerCommand<Work> _WorkDelCommand;

        public ListenerCommand<Work> WorkDelCommand
        {
            get
            {
                if (_WorkDelCommand == null)
                {
                    _WorkDelCommand = new ListenerCommand<Work>(WorkDel);
                }
                return _WorkDelCommand;
            }
        }

        public async void WorkDel(Work Work)
        {
            System.Diagnostics.Debug.WriteLine("WorkDeleteCommand" + Work.Id);
            Work deletedUser = await Work.DeleteWorkAsync(Work.Id);
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "ShowUserMst"));
        }
        #endregion
        


    }
}
