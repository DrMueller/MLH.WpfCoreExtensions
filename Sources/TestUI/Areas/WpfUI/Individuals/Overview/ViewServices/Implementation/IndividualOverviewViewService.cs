using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Models;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Repositories;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewServices.Implementation
{
    public class IndividualOverviewViewService : IIndividualOverviewViewService
    {
        private readonly IIndividualRepository _individualRepository;

        public IndividualOverviewViewService(
            IIndividualRepository individualRepository)
        {
            _individualRepository = individualRepository;
        }

        public async Task DeleteIndividualAsync(string id)
        {
            await _individualRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<IndividualOverviewViewData>> LoadAllAsync()
        {
            var allIndividuals = await _individualRepository.LoadAllAsync();
            var result = allIndividuals.Select(Adapt).ToList();
            return result;
        }

        private IndividualOverviewViewData Adapt(Individual individual)
        {
            var formattedName = $"{individual.FirstName} {individual.LastName}";
            var formattedBirthdate = individual.Birthdate.ToString("dd.MM.yyyy");
            return new IndividualOverviewViewData(formattedName, formattedBirthdate, individual.Id);
        }
    }
}