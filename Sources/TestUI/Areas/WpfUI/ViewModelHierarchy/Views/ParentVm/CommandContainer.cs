using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.ViewModelHierarchy.Views.ParentVm
{
    [PublicAPI]
    public class CommandContainer : IViewModelCommandContainer<IParentVmViewModel>
    {
        private IParentVmViewModel _context;
        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand SetChildText => new ViewModelCommand(
            "Set child text",
            new RelayCommand(
                () =>
                {
                    _context.ChildVm.ChildText = $"Hello from Parent {DateTime.Now.ToLongTimeString()}";
                }));

        public Task InitializeAsync(IParentVmViewModel context)
        {
            _context = context;

            Commands = new CommandsViewData(SetChildText);

            return Task.CompletedTask;
        }
    }
}