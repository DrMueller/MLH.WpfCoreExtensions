using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData
{
    public class CommandsViewData
    {
        public IReadOnlyCollection<IViewModelCommand> Entries { get; }

        public CommandsViewData(params IViewModelCommand[] entries)
        {
            Guard.ObjectNotNull(() => entries);
            Entries = entries;
        }
    }
}