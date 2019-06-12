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
        #region CWork(POST)
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
        #endregion


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

        #region WorkDeleteCommand
        private ListenerCommand<Work> _WorkDeleteCommand;

        public ListenerCommand<Work> WorkDeleteCommand
        {
            get
            {
                if (_WorkDeleteCommand == null)
                {
                    _WorkDeleteCommand = new ListenerCommand<Work>(WorkDelete);
                }
                return _WorkDeleteCommand;
            }
        }

        public async void WorkDelete(Work Work)
        {
            Work deletedWork = await Work.DeleteWorkAsync(Work.Id);
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "ShowDeleteCommand"));
        }
        #endregion

        #region WorkPutCommand
        private ListenerCommand<Work> _WorkPutCommand;

        public ListenerCommand<Work> WorkPutCommand
        {
            get
            {
                if (_WorkPutCommand == null)
                {
                    _WorkPutCommand = new ListenerCommand<Work>(WorkPut);
                }
                return _WorkPutCommand;
            }
        }

        public async void WorkPut(Work Work)
        {
            System.Diagnostics.Debug.WriteLine("PutCommand" + Work.Id);
            CWork = Work;

            Work putwork = await Work.PutWorkAsync(this.CWork);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Put"));
        }
        #endregion

        public async void Initialize()
        {
            Work work = new Work();
            this.Work = await work.GetWorkAsync();


            this.CWork = new Work();

        }
    }
}
