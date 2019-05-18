﻿using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services;

namespace Mmu.Mlh.WpfCoreExtensions.NugetTestUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var wpfAppConfig = WpfAppConfig.CreateWithDefaultIcon(typeof(App).Assembly, "Hello App");
            await AppStartService.StartAppAsync(wpfAppConfig);
        }
    }
}