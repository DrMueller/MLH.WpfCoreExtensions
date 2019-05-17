using System;
using NLog;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.Logging.Services.Implementation
{
    internal class LoggingService : ILoggingService
    {
        private static readonly ILogger Logger = LogManager.GetLogger(nameof(LoggingService));

        public void LogInformation(string message)
        {
            Logger.Info(message);
        }

        public void LogException(Exception exception)
        {
            Logger.Error(exception);
        }
    }
}