using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ExceptionHandling.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ExceptionHandling.Services.Implementation
{
    [UsedImplicitly]
    internal class ExceptionInitializationService : IExceptionInitializationService
    {
        private readonly IExceptionHandler _exceptionHandler;

        public ExceptionInitializationService(IExceptionHandler exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        public void HookGlobalExceptions()
        {
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }

            Console.WriteLine($"Global exception: {e.Exception}");
            Debug.WriteLine($"Global exception: {e.Exception}");

            _exceptionHandler.Handle(e.Exception);
            e.Handled = true;
        }
    }
}