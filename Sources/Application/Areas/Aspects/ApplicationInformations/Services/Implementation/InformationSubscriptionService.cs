using System;
using System.Collections.Generic;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services.Implementation
{
    internal class InformationSubscriptionService : IInformationSubscriptionService
    {
        private readonly List<Action<InformationEntryViewData>> _callbacks = new List<Action<InformationEntryViewData>>();

        public void OnInformationReceived(InformationEntryViewData data)
        {
            _callbacks.ForEach(cb => cb(data));
        }

        public void Register(Action<InformationEntryViewData> callback)
        {
            _callbacks.Add(callback);
        }
    }
}