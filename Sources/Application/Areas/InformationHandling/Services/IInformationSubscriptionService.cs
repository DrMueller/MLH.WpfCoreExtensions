using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services
{
    internal interface IInformationSubscriptionService
    {
        void Register(Action<InformationEntryViewData> callback);

        void OnInformationReceived(InformationEntryViewData data);
    }
}