using System;
using System.Diagnostics;
using System.Windows;
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

        public void HookGlobalExceptions(bool handleException)
        {
            Application.Current.DispatcherUnhandledException += (_, args) =>
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                Console.WriteLine($"Global exception: {args.Exception}");
                Debug.WriteLine($"Global exception: {args.Exception}");

                _exceptionHandler.Handle(args.Exception);
                args.Handled = handleException;
            };
        }
    }
}