using System.ComponentModel;
using System.Runtime.CompilerServices;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels
{
    public abstract class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}