﻿using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Logging
{
    public class LoggingViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;

        public LoggingViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public CommandsViewData Commands => _commandContainer.Commands;

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }

        public string HeadingDescription => "Logging stuff";
        public string NavigationDescription => "Logging";
        public int NavigationSequence => 4;
    }
}