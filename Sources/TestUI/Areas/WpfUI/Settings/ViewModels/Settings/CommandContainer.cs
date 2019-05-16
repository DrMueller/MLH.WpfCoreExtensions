using System;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Settings.ViewModels.Settings
{
    public class CommandContainer : IViewModelCommandContainer<SettingsViewModel>
    {
        private readonly ISettingsProvider _settingsProvider;
        private SettingsViewModel _context;
        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand ReadSettings
        {
            get
            {
                return new ViewModelCommand(
                    "Read Settings",
                    new RelayCommand(() =>
                    {
                        var settings = _settingsProvider.ProvideSettings();
                        _context.SettingsInfo = settings.Value1 + Environment.NewLine + settings.Value2;
                    }));
            }
        }

        public CommandContainer(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public Task InitializeAsync(SettingsViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(ReadSettings);
            return Task.CompletedTask;
        }
    }
}