using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using WaitScreenDemo.Annotations;

namespace WaitScreenDemo.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private RelayCommand _updateCommand;
        private bool _loadComplete;
        private BackgroundWorker bg;

        public MainWindowViewModel()
        {
            bg = new BackgroundWorker();
            bg.DoWork += (s, e) => Thread.Sleep(5000);
            bg.RunWorkerCompleted += (s, e) => LoadComplete = true;
            bg.RunWorkerAsync();
        }

        public bool LoadComplete
        {
            get { return !_loadComplete; }
            set
            {
                _loadComplete = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateCommand
        {
            get { return _updateCommand ?? (_updateCommand = new RelayCommand(x => LoadComplete = true)); }
        }
       
    }
}
