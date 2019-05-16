using System;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ExceptionHandling.Services
{
    public interface IExceptionHandler
    {
        void Handle(Exception exception);
    }
}