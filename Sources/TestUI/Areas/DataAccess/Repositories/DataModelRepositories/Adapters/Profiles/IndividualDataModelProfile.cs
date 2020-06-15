using AutoMapper;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.DataAccess.DataModeling;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Models;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.DataAccess.Repositories.DataModelRepositories.Adapters.Profiles
{
    public class IndividualDataModelProfile : Profile
    {
        public IndividualDataModelProfile()
        {
            CreateMap<Individual, IndividualDataModel>()
                .ForMember(d => d.Birthdate, c => c.MapFrom(f => f.Birthdate))
                .ForMember(d => d.FirstName, c => c.MapFrom(f => f.FirstName))
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.LastName, c => c.MapFrom(f => f.LastName));
        }
    }
}