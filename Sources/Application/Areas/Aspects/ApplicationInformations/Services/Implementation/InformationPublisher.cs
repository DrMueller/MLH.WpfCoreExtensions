using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services.Implementation
{
    [UsedImplicitly]
    internal class InformationPublisher : IInformationPublisher
    {
        private readonly IInformationSubscriptionService _subscriptionService;
        private readonly IInformationEntryViewDataAdapter _viewDataAdapter;
        private InformationEntryViewData _currentViewData;

        public InformationPublisher(
            IInformationEntryViewDataAdapter viewDataAdapter,
            IInformationSubscriptionService subscriptionService)
        {
            _viewDataAdapter = viewDataAdapter;
            _subscriptionService = subscriptionService;
        }

        public void Publish(InformationEntry infoEntry)
        {
            var viewData = _viewDataAdapter.Adapt(infoEntry);
            _subscriptionService.OnInformationReceived(viewData);
            _currentViewData = viewData;

            if (viewData.DisplayLengthInSeconds.HasValue)
            {
                ResetInfo(viewData);
            }
        }

        private void ResetInfo(
            InformationEntryViewData viewData
        )
        {
            Task.Run(
                async () =>
                {
                    await Task.Delay(viewData.DisplayLengthInSeconds!.Value * 1000);

                    if (viewData.Message == _currentViewData.Message)
                    {
                        var emptyInfo = _viewDataAdapter.Adapt(InformationEntry.CreateEmpty());
                        _subscriptionService.OnInformationReceived(emptyInfo);
                    }
                });
        }
    }
}