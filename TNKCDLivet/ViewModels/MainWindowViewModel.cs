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
using TNKCDLivet.Views;
using TNKCDLivet.Models;
using System.Windows;

namespace TNKCDLivet.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
       
        #region ThanksCardsProperty
        private List<TNKCD> _ThanksCards;

        public List<TNKCD> ThanksCards
        {
            get
            { return _ThanksCards; }
            set
            { 
                if (_ThanksCards == value)
                {
                    return;
                }

                _ThanksCards = value;
                RaisePropertyChanged();
            }
        }
        #endregion        

        #region ShowThanksCardCreateCommand
        private ViewModelCommand _ShowThanksCardCreateCommand;

        public ViewModelCommand ShowThanksCardCreateCommand
        {
            get
            {
                if (_ShowThanksCardCreateCommand == null)
                {
                    _ShowThanksCardCreateCommand = new ViewModelCommand(ShowThanksCardCreate);
                }
                return _ShowThanksCardCreateCommand;
            }
        }

        public void ShowThanksCardCreate()
        {
            System.Diagnostics.Debug.WriteLine("ShowThanksCardCreate");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                TNKCDCreateViewModel ViewModel = new TNKCDCreateViewModel();
                var message = new TransitionMessage(typeof(Views.TNKCDCreate),new TNKCDCreateViewModel(), TransitionMode.Modal, "ShowThanksCardCreate");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion

        #region ShowUserMstCommand
        private ViewModelCommand _ShowUserMstCommand;

        public ViewModelCommand ShowUserMstCommand
        {
            get
            {
                if (_ShowUserMstCommand == null)
                {
                    _ShowUserMstCommand = new ViewModelCommand(ShowUserMst);
                }
                return _ShowUserMstCommand;
            }
        }

        public void ShowUserMst()
        {
            System.Diagnostics.Debug.WriteLine("ShowUserMst");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive); 

            try
            {
                // MainWindow を非表示
                window.Hide();
                UserPropertiesViewModel ViewModel = new UserPropertiesViewModel();
                var message = new TransitionMessage(typeof(Views.UserProperties),new UserPropertiesViewModel(), TransitionMode.Modal, "ShowUserMst");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion

        #region ShowDepartmentMstCommand
        private ViewModelCommand _ShowDepartmentMstCommand;

        public ViewModelCommand ShowDepartmentMstCommand
        {
            get
            {
                if (_ShowDepartmentMstCommand == null)
                {
                    _ShowDepartmentMstCommand = new ViewModelCommand(ShowDepartmentMst);
                }
                return _ShowDepartmentMstCommand;
            }
        }

        public void ShowDepartmentMst()
        {
            System.Diagnostics.Debug.WriteLine("ShowDepartmentMst");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                DepartmentEditViewModel ViewModel = new DepartmentEditViewModel();
                var message = new TransitionMessage(typeof(Views.DepartmentEdit),new DepartmentEditViewModel(), TransitionMode.Modal, "ShowDepartmentMst");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion

        #region ShowCardCountCommand
        private ViewModelCommand _ShowCardCountCommand;

        public ViewModelCommand ShowCardCountCommand
        {
            get
            {
                if (_ShowCardCountCommand == null)
                {
                    _ShowCardCountCommand = new ViewModelCommand(ShowCardCount);
                }
                return _ShowCardCountCommand;
            }
        }

        public void ShowCardCount()
        {
            System.Diagnostics.Debug.WriteLine("ShowCardCount");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                CardCountViewModel ViewModel = new CardCountViewModel();
                var message = new TransitionMessage(typeof(Views.CardCount),new CardCountViewModel(), TransitionMode.Modal, "ShowCardCount");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion

        #region ShowWorkRelationCommand
        private ViewModelCommand _ShowWorkRelationCommand;

        public ViewModelCommand ShowWorkRelationCommand
        {
            get
            {
                if (_ShowWorkRelationCommand == null)
                {
                    _ShowWorkRelationCommand = new ViewModelCommand(ShowWorkRelation);
                }
                return _ShowWorkRelationCommand;
            }
        }

        public void ShowWorkRelation()
        {
            System.Diagnostics.Debug.WriteLine("ShowWorkRelation");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                WorkRelationViewModel ViewModel = new WorkRelationViewModel();
                var message = new TransitionMessage(typeof(Views.WorkRelation),new WorkRelationViewModel(), TransitionMode.Modal, "ShowWorkRelation");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion

        #region ShowPickupCommand
        private ViewModelCommand _ShowPickupCommand;

        public ViewModelCommand ShowPickupCommand
        {
            get
            {
                if (_ShowPickupCommand == null)
                {
                    _ShowPickupCommand = new ViewModelCommand(ShowPickup);
                }
                return _ShowPickupCommand;
            }
        }

        public void ShowPickup()
        {
            System.Diagnostics.Debug.WriteLine("ShowPickup");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                PickupViewModel ViewModel = new PickupViewModel();
                var message = new TransitionMessage(typeof(Views.Pickup),new PickupViewModel(), TransitionMode.Modal, "ShowPickup");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion

        #region ShowBusyoRelationCommand
        private ViewModelCommand _ShowBusyoRelationCommand;

        public ViewModelCommand ShowBusyoRelationCommand
        {
            get
            {
                if (_ShowBusyoRelationCommand == null)
                {
                    _ShowBusyoRelationCommand = new ViewModelCommand(ShowBusyoRelation);
                }
                return _ShowBusyoRelationCommand;
            }
        }

        public void ShowBusyoRelation()
        {
            System.Diagnostics.Debug.WriteLine("ShowBusyoRelation");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                BusyoRelationViewModel ViewModel = new BusyoRelationViewModel();
                var message = new TransitionMessage(typeof(Views.BusyoRelation),new BusyoRelationViewModel(), TransitionMode.Modal, "ShowBusyoRelation");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion

        #region TNKCD
        private List<TNKCD> _TNKCD;

        public List<TNKCD> TNKCD
        {
            get
            { return _TNKCD; }
            set
            {
                if (_TNKCD == value)
                    return;
                _TNKCD = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        

        public async  void Initialize()
        {
            var message = new TransitionMessage(typeof(Views.Logon), new LogonViewModel(), TransitionMode.Modal, "ShowLogon");
            Messenger.Raise(message);


            TNKCD tnkcd = new TNKCD();
            this.TNKCD = await tnkcd.GetTNKCDAsync();

        }
        

    }
       }