using System;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.Logging.Services
{
    public interface ILoggingService
    {
        void LogException(Exception exception);

        void LogInformation(string message);
    }
}