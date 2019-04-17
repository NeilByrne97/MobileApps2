using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileApp
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T Value,
        [CallerMemberName] string properyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, Value)) return;
            backingField = Value;
            OnPropertyChanged(properyName);
        }
    }
}