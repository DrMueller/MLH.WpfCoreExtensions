using System;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ExceptionHandling.Services
{
    public interface IExceptionHandler
    {
        void Handle(Exception exception);
    }
}