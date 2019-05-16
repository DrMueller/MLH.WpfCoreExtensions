using System;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Logging.Services
{
    public interface ILoggingService
    {
        void LogInformation(string message);

        void LogException(Exception exception);
    }
}