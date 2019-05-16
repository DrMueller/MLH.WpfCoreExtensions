using System;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.InfosAndExceptions.ViewModels.InfosAndExceptions
{
    public class CommandContainer : IViewModelCommandContainer<InfosAndExceptionsViewModel>
    {
        private readonly IInformationPublisher _infoPublisher;
        public CommandsViewData Commands { get; private set; }

        private static ViewModelCommand ThrowException
        {
            get
            {
                return new ViewModelCommand(
                    "Throw Exception",
                    new RelayCommand(
                        () => throw new ArgumentException("Hello Test")));
            }
        }

        private ViewModelCommand ShowInfo
        {
            get
            {
                return new ViewModelCommand(
                    "Show Info",
                    new RelayCommand(() => _infoPublisher.Publish(InformationEntry.CreateInfo("Hello Info", true, 5))));
            }
        }

        private ViewModelCommand ShowSuccess
        {
            get
            {
                return new ViewModelCommand(
                    "Show Success",
                    new RelayCommand(() => _infoPublisher.Publish(InformationEntry.CreateSuccess("Hello Success", false))));
            }
        }

        public CommandContainer(IInformationPublisher infoPublisher)
        {
            _infoPublisher = infoPublisher;
        }

        public Task InitializeAsync(InfosAndExceptionsViewModel context)
        {
            Commands = new CommandsViewData(
                ShowInfo,
                ShowSuccess,
                ThrowException);

            return Task.CompletedTask;
        }
    }
}