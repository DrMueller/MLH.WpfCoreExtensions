using System;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Logging.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Logging.ViweModels.Logging
{
    public class CommandContainer : IViewModelCommandContainer<LoggingViewModel>
    {
        private readonly ILoggingService _loggingService;

        public CommandsViewData Commands { get; private set; }

        private static ViewModelCommand ThrowException
        {
            get
            {
                return new ViewModelCommand(
                    "Throw Exception",
                    new RelayCommand(
                        () => throw new ArgumentException("Hello Logging Test")));
            }
        }

        private ViewModelCommand LogInfo
        {
            get
            {
                return new ViewModelCommand(
                    "Log Info",
                    new RelayCommand(() => _loggingService.LogInformation("Hello Info")));
            }
        }

        public CommandContainer(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public Task InitializeAsync(LoggingViewModel context)
        {
            Commands = new CommandsViewData(
                LogInfo,
                ThrowException);

            return Task.CompletedTask;
        }
    }
}