using Mmu.Mlh.DataAccess.Areas.Repositories;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.DataAccess.DataModeling;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.DataAccess.Repositories.DataModelRepositories;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.DataAccess.Repositories.DataModelRepositories.Adapters;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Models;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Repositories;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.DataAccess.Repositories.Implementation
{
    public class IndividualRepository : RepositoryBase<Individual, IndividualDataModel, string>, IIndividualRepository
    {
        public IndividualRepository(
            IIndividualDataModelRepository dataModelRepository,
            IIndividualDataModelAdapter dataModelAdapter)
            : base(dataModelRepository, dataModelAdapter)
        {
        }
    }
}