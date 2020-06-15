using System.Windows.Input;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Models
{
    internal class NavigationEntry
    {
        public NavigationEntry(ICommand navigationCommand, string navigationDescription)
        {
            Guard.ObjectNotNull(() => navigationCommand);
            Guard.StringNotNullOrEmpty(() => navigationDescription);

            NavigationCommand = navigationCommand;
            NavigationDescription = navigationDescription;
        }

        public ICommand NavigationCommand { get; }
        public string NavigationDescription { get; }
    }
}