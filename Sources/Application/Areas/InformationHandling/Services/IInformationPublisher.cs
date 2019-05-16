using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services
{
    public interface IInformationPublisher
    {
        void Publish(InformationEntry informationEntry);
    }
}