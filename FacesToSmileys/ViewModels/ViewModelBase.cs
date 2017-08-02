using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FacesToSmileys.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Set<T>(string propertyName, ref T oldValue, T newValue)
        {
            if(string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(propertyName);

            if(!EqualityComparer<T>.Default.Equals(oldValue, newValue))
            {
                oldValue = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
