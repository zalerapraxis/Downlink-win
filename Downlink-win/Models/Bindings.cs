using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Downlink_win.Annotations;

namespace Downlink_win
{
    public class Bindings : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _programStatus;
        private string _lastUpdated;

        public string ProgramStatus
        {
            get => _programStatus;
            set
            {
                if (value != _programStatus)
                {
                    _programStatus = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastUpdated
        {
            get => _lastUpdated;
            set
            {
                if (value != _lastUpdated)
                {
                    _lastUpdated = value;
                    OnPropertyChanged();
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
