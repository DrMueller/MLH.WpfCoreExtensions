using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels
{
    public abstract class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged<T>(T newValue, ref T oldValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(newValue, oldValue))
            {
                return;
            }

            oldValue = newValue;
            PublishPropertyChanged(propertyName);
        }

        public void PublishPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}