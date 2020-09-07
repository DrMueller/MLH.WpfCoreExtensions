using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services
{
    internal interface IInformationSubscriptionService
    {
        void OnInformationReceived(InformationEntryViewData data);

        void Register(Action<InformationEntryViewData> callback);
    }
}