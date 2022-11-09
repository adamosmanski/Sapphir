using SapphirApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SapphirApp.ViewModels
{
    public class NotifyPopUpVM : ObserveObject
    {
        private bool _isVisible = true;
        private string _err;
        public NotifyPopUpVM()
        {
            ;
        }
        public NotifyPopUpVM(string _error)
        {
            _err = _error;
            Informations = _err;
            CmdClose = new RelayCommand(Close);
            IsVisible = _isVisible;
        }
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }
        public string Informations
        {
            get => _err;
            set
            {
                _err = value;
                OnPropertyChanged(nameof(Informations));
            }
        }
        public ICommand CmdClose { get; }
        private void Close(object obj)
        {
            IsVisible = false;
        }
    }
}
