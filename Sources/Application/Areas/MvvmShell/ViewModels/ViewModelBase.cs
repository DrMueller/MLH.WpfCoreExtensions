using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels
{
    [PublicAPI]
    public abstract class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        private readonly IDictionary<string, Action> _propChangeCallbacks = new Dictionary<string, Action>();

        public void PublishPropertyChanged(string propertyName)
        {
            if (_propChangeCallbacks.TryGetValue(propertyName, out var callback))
            {
                callback();
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RegisterPropertyChange(string propertyName, Action callback)
        {
            _propChangeCallbacks.Add(propertyName, callback);
        }

        protected virtual void OnPropertyChanged<T>(
            T newValue,
            ref T oldValue,
            [CallerMemberName] string propertyName = null)
        {
            if (Equals(newValue, oldValue))
            {
                return;
            }

            oldValue = newValue;
            PublishPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}