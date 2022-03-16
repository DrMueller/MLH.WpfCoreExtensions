using System;
using JetBrains.Annotations;
using NLog;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.Logging.Services.Implementation
{
    [UsedImplicitly]
    internal class LoggingService : ILoggingService
    {
        private static readonly ILogger _logger = LogManager.GetLogger(nameof(LoggingService));

        public void LogException(Exception exception)
        {
            _logger.Error(exception);
        }

        public void LogInformation(string message)
        {
            _logger.Info(message);
        }
    }
}