using System;
using JetBrains.Annotations;
using Mmu.Mlh.LanguageExtensions.Areas.Exceptions;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.Logging.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ExceptionHandling.Services.Implementation
{
    [UsedImplicitly]
    internal class ExceptionHandler : IExceptionHandler
    {
        private readonly IInformationPublisher _informationPublisher;
        private readonly ILoggingService _loggingService;

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
            _informationPublisher.Publish(InformationEntry.CreateError(mostInnerException));
        }
    }
}