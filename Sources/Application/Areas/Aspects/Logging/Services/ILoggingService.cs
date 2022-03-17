using System;
using JetBrains.Annotations;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.Logging.Services
{
    [PublicAPI]
    public interface ILoggingService
    {
        void LogException(Exception exception);

        void LogInformation(string message);
    }
}