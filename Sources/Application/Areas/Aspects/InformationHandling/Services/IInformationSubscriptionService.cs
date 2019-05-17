using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services
{
    internal interface IInformationSubscriptionService
    {
        void OnInformationReceived(InformationEntryViewData data);

        void Register(Action<InformationEntryViewData> callback);
    }
}