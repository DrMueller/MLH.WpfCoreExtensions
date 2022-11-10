using AutoMapper;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.DataAccess.DataModeling;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Factories;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Models;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.DataAccess.Repositories.DataModelRepositories.Adapters.Implementation
{
    public class IndividualDataModelAdapter : DataModelAdapterBase<IndividualDataModel, Individual, string>,
        IIndividualDataModelAdapter
    {
        private readonly IIndividualFactory _individualFactory;

        public IndividualDataModelAdapter(IMapper mapper, IIndividualFactory individualFactory)
            : base(mapper)
        {
            _individualFactory = individualFactory;
        }

        public override Individual Adapt(IndividualDataModel dataModel)
        {
            return _individualFactory.Create(
                dataModel.FirstName,
                dataModel.LastName,
                dataModel.Birthdate,
                dataModel.Id);
        }
    }
}