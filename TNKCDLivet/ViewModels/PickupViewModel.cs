﻿using System;
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
using System.Windows;

namespace TNKCDLivet.ViewModels
{
    public class PickupViewModel : ViewModel
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

        #region Work

        private List<Work> _Work;

        public List<Work> Work
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

        #region Employee
        private List<Employee> _Employee;

        public List<Employee> Employee
        {
            get
            { return _Employee; }
            set
            {
                if (_Employee == value)
                {
                    return;
                }

                _Employee = value;
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

        #region PTCombo(絞り込み)
        private IEnumerable<TNKCD> _PTcombo;

        public IEnumerable<TNKCD> PTcombo
        {
            get
            { return _PTcombo; }
            set
            {
                if (_PTcombo == value)
                    return;
                _PTcombo = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region SelectPTCommand(絞り込み)
        private ListenerCommand<int> _SelectPTCommand;

        public ListenerCommand<int> SelectPTCommand
        {
            get

            {
                if (_SelectPTCommand == null)
                {
                    _SelectPTCommand = new ListenerCommand<int>(SelectPT);
                }
                return _SelectPTCommand;
            }
        }

        public void SelectPT(int parameter)
        {
            this.PTcombo = TNKCD.Where(t => parameter == t.WorkId);
        }
        #endregion

       


        public async void Initialize()
        {
            TNKCD tnkcd = new TNKCD();
            this.TNKCD = await tnkcd.GetTNKCDAsync();

            Work work = new Work();
            this.Work = await work.GetWorkAsync();

            Employee employee = new Employee();
            this.Employee = await employee.GetEmployeeAsync();

          

        }
    }
}
