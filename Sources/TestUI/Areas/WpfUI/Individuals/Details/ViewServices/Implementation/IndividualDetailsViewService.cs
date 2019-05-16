using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Factories;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Repositories;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewServices.Implementation
{
    public class IndividualDetailsViewService : IIndividualDetailsViewService
    {
        private readonly IIndividualFactory _individualFactory;
        private readonly IIndividualRepository _individualRepository;

        public IndividualDetailsViewService(
            IIndividualFactory individualFactory,
            IIndividualRepository individualRepository)
        {
            _individualFactory = individualFactory;
            _individualRepository = individualRepository;
        }

        public async Task<IndividualDetailsViewData> LoadAsync(string id)
        {
            var individual = await _individualRepository.LoadByIdAsync(id);
            var viewData = new IndividualDetailsViewData
            {
                Birthdate = individual.Birthdate,
                FirstName = individual.FirstName,
                Id = individual.Id,
                LastName = individual.LastName
            };

            return viewData;
        }

        public async Task SaveAsync(IndividualDetailsViewData data)
        {
            var individual = _individualFactory.Create(data.FirstName, data.LastName, data.Birthdate, data.Id);
            await _individualRepository.SaveAsync(individual);
        }
    }
}