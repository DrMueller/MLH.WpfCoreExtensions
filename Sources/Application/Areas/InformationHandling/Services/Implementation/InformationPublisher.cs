using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services.Implementation
{
    internal class InformationPublisher : IInformationPublisher
    {
        private readonly IInformationSubscriptionService _subscriptionService;

        public InformationPublisher(IInformationSubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        public void Publish(InformationEntry informationEntry)
        {
            var viewData = new InformationEntryViewData(informationEntry.Message, informationEntry.ShowBusy);
            _subscriptionService.OnInformationReceived(viewData);
        }
    }
}