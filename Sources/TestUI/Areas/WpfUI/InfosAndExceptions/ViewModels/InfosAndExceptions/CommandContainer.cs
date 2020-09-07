using System;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Grids.InformationGrids.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.InfosAndExceptions.ViewModels.InfosAndExceptions
{
    public class CommandContainer : IViewModelCommandContainer<InfosAndExceptionsViewModel>
    {
        private readonly IInformationPublisher _infoPublisher;
        private InfosAndExceptionsViewModel _context;

        public CommandContainer(IInformationPublisher infoPublisher)
        {
            _infoPublisher = infoPublisher;
        }

        public CommandsViewData Commands { get; private set; }

        private static ViewModelCommand ThrowException =>
            new ViewModelCommand(
                "Throw Exception",
                new RelayCommand(
                    () => throw new ArgumentException("Hello Test")));

        private ViewModelCommand AddInformationGridEntry =>
            new ViewModelCommand(
                "Add Info Grid",
                new RelayCommand(
                    () =>
                    {
                        _context.InformationEntries.Add(new InformationGridEntryViewData("Tra " + Guid.NewGuid()));
                    }));

        private ViewModelCommand ShowInfo =>
            new ViewModelCommand(
                "Show Info",
                new RelayCommand(() => _infoPublisher.Publish(InformationEntry.CreateInfo("Hello Info", true, 5))));

        private ViewModelCommand ShowSuccess =>
            new ViewModelCommand(
                "Show Success",
                new RelayCommand(() => _infoPublisher.Publish(InformationEntry.CreateSuccess("Hello Success", false))));

        public Task InitializeAsync(InfosAndExceptionsViewModel context)
        {
            _context = context;

            Commands = new CommandsViewData(
                ShowInfo,
                ShowSuccess,
                ThrowException,
                AddInformationGridEntry);

            return Task.CompletedTask;
        }
    }
}