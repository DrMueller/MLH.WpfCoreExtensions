using System;
using Mmu.Mlh.LanguageExtensions.Areas.Exceptions;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.Logging.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ExceptionHandling.Services.Implementation
{
    internal class ExceptionHandler : IExceptionHandler
    {
        private readonly ILoggingService _loggingService;
        private readonly IInformationPublisher _informationPublisher;

        public ExceptionHandler(
            ILoggingService loggingService,
            IInformationPublisher informationPublisher)
        {
            _loggingService = loggingService;
            _informationPublisher = informationPublisher;
        }

        public void Handle(Exception exception)
        {
            _loggingService.LogException(exception);
            var mostInnerException = exception.GetMostInnerException();
            _informationPublisher.Publish(InformationEntry.CreateException(mostInnerException));
        }
    }
}