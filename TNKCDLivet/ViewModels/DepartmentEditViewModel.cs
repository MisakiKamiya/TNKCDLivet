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
    public class DepartmentEditViewModel : ViewModel
    {
        /* コマンド、プロパティの定義にはそれぞれ 
         * 
         *  lvcom   : ViewModelCommand
         *  lvcomn  : ViewModelCommand(CanExecute無)
         *  llcom   : ListenerCommand(パラメータ有のコマンド)
         *  llcomn  : ListenerCommand(パラメータ有のコマンド・CanExecute無)
         *  lprop   : 変更通知プロパティ(.NET4.5ではlpropn)
         *  
         * を使用してください。
         * 
         * Modelが十分にリッチであるならコマンドにこだわる必要はありません。
         * View側のコードビハインドを使用しないMVVMパターンの実装を行う場合でも、ViewModelにメソッドを定義し、
         * LivetCallMethodActionなどから直接メソッドを呼び出してください。
         * 
         * ViewModelのコマンドを呼び出せるLivetのすべてのビヘイビア・トリガー・アクションは
         * 同様に直接ViewModelのメソッドを呼び出し可能です。
         */

        /* ViewModelからViewを操作したい場合は、View側のコードビハインド無で処理を行いたい場合は
         * Messengerプロパティからメッセージ(各種InteractionMessage)を発信する事を検討してください。
         */

        /* Modelからの変更通知などの各種イベントを受け取る場合は、PropertyChangedEventListenerや
         * CollectionChangedEventListenerを使うと便利です。各種ListenerはViewModelに定義されている
         * CompositeDisposableプロパティ(LivetCompositeDisposable型)に格納しておく事でイベント解放を容易に行えます。
         * 
         * ReactiveExtensionsなどを併用する場合は、ReactiveExtensionsのCompositeDisposableを
         * ViewModelのCompositeDisposableプロパティに格納しておくのを推奨します。
         * 
         * LivetのWindowテンプレートではViewのウィンドウが閉じる際にDataContextDisposeActionが動作するようになっており、
         * ViewModelのDisposeが呼ばれCompositeDisposableプロパティに格納されたすべてのIDisposable型のインスタンスが解放されます。
         * 
         * ViewModelを使いまわしたい時などは、ViewからDataContextDisposeActionを取り除くか、発動のタイミングをずらす事で対応可能です。
         */

        /* UIDispatcherを操作する場合は、DispatcherHelperのメソッドを操作してください。
         * UIDispatcher自体はApp.xaml.csでインスタンスを確保してあります。
         * 
         * LivetのViewModelではプロパティ変更通知(RaisePropertyChanged)やDispatcherCollectionを使ったコレクション変更通知は
         * 自動的にUIDispatcher上での通知に変換されます。変更通知に際してUIDispatcherを操作する必要はありません。
         */
        #region Busyo
        private List<Busyo> _Busyo;

        public List<Busyo> Busyo
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

        #region BusyoP
        private Busyo _BusyoP;

        public Busyo BusyoP
        {
            get
            { return _BusyoP; }
            set
            {
                if (_BusyoP == value)
                    return;
                _BusyoP = value;
                RaisePropertyChanged(nameof(BusyoP));
            }
        }
        #endregion

        #region Ka
        private List<Ka> _Ka;

        public List<Ka> Ka
        {
            get
            { return _Ka; }
            set
            {
                if (_Ka == value)
                    return;
                _Ka = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region KaP
        private Ka _KaP;

        public Ka KaP
        {
            get
            { return _KaP; }
            set
            {
                if (_KaP == value)
                    return;
                _KaP = value;
                RaisePropertyChanged(nameof(KaP));
            }
        }
        #endregion

        #region BusyoDeleteCommand
        private ListenerCommand<Busyo> _BusyoDeleteCommand;

        public ListenerCommand<Busyo> BusyoDeleteCommand
        {
            get
            {
                if (_BusyoDeleteCommand == null)
                {
                    _BusyoDeleteCommand = new ListenerCommand<Busyo>(BusyoDelete);
                }
                return _BusyoDeleteCommand;
            }
        }

        public async void BusyoDelete(Busyo Busyo)
        {
            Busyo deletedBusyo = await Busyo.DeleteBusyoAsync(Busyo.Id);
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "ShowBusyoDeleteCommand"));
        }
        #endregion

        #region KaDeleteCommand
        private ListenerCommand<Ka> _KaDeleteCommand;

        public ListenerCommand<Ka> KaDeleteCommand
        {
            get
            {
                if (_KaDeleteCommand == null)
                {
                    _KaDeleteCommand = new ListenerCommand<Ka>(KaDelete);
                }
                return _KaDeleteCommand;
            }
        }

        public async void KaDelete(Ka Ka)
        {
            Ka deletedKa = await Ka.DeleteKaAsync(Ka.Id);
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "ShowKaDeleteCommand"));
        }
        #endregion

        #region BusyoPutCommand
        private ListenerCommand<Busyo> _BusyoPutCommand;

        public ListenerCommand<Busyo> BusyoPutCommand
        {
            get
            {
                if (_BusyoPutCommand == null)
                {
                    _BusyoPutCommand = new ListenerCommand<Busyo>(BusyoPut);
                }
                return _BusyoPutCommand;
            }
        }

        public async void BusyoPut(Busyo Busyo)
        {
            System.Diagnostics.Debug.WriteLine("PutCommand" + Busyo.Id);
            BusyoP = Busyo;

            Busyo putBusyo = await Busyo.PutBusyoAsync(this.BusyoP);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Put"));
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

        #region SubmitCommandB
        private ViewModelCommand _SubmitCommandB;

        public ViewModelCommand SubmitCommandB
        {
            get
            {
                if (_SubmitCommandB == null)
                {
                    _SubmitCommandB = new ViewModelCommand(SubmitB);
                }
                return _SubmitCommandB;
            }
        }

        public async void SubmitB()
        {
            Busyo createdBusyo = await BusyoP.PostBusyoAsync(this.BusyoP);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "ShowSubmitCommandB"));
        }
        #endregion

        #region SubmitCommandK
        private ViewModelCommand _SubmitCommandK;

        public ViewModelCommand SubmitCommandK
        {
            get
            {
                if (_SubmitCommandK == null)
                {
                    _SubmitCommandK = new ViewModelCommand(SubmitK);
                }
                return _SubmitCommandK;
            }
        }

        public async void SubmitK()
        {
            Ka createdKa = await KaP.PostKaAsync(this.KaP);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "ShowSubmitCommandK"));
        }
        #endregion

        public async void Initialize()
        {
            Busyo busyo = new Busyo();
            this.Busyo = await busyo.GetBusyoAsync();

            Ka ka = new Ka();
            this.Ka = await ka.GetKaAsync();

            this.BusyoP = new Busyo();
            this.KaP = new Ka();
        }
    }
}
