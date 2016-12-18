using System;
using System.ComponentModel;

namespace FacesToSmileys.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        bool _isBusy;

        public bool IsBusy 
        {
            get { return _isBusy; }
            set { Set(nameof(IsBusy), ref _isBusy, value); }
        }

        protected void Set<TType>(string propertyName, ref TType currentValue, TType newValue)
        {
            if (currentValue != null && currentValue.Equals(newValue)) return;

            currentValue = newValue;

            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
