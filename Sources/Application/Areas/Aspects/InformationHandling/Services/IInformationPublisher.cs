using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services
{
    public interface IInformationPublisher
    {
        void Publish(InformationEntry informationEntry);
    }
}