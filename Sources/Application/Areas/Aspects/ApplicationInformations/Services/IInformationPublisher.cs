using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services
{
    public interface IInformationPublisher
    {
        void Publish(InformationEntry informationEntry);
    }
}