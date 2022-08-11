using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.ViewModelHierarchy.Views.ChildVm
{
    [PublicAPI]
    public class CommandContainer : IViewModelCommandContainer<IChildVmViewModel>
    {
        private IChildVmViewModel _context;

        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand SetChildText => new ViewModelCommand(
            "Set child text",
            new RelayCommand(
                () =>
                {
                    _context.ChildText = $"Hello from child {DateTime.Now.ToLongTimeString()}";
                }));

        public Task InitializeAsync(IChildVmViewModel context)
        {
            _context = context;

            Commands = new CommandsViewData(SetChildText);

            return Task.CompletedTask;
        }
    }
}