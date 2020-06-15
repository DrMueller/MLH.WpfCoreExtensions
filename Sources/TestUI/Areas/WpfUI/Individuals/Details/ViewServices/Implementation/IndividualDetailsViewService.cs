using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Factories;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Repositories;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewServices.Implementation
{
    public class IndividualDetailsViewService : IIndividualDetailsViewService
    {
        private readonly IIndividualFactory _individualFactory;
        private readonly IIndividualRepository _individualRepository;
        private readonly IViewModelFactory _viewModelFactory;

        public IndividualDetailsViewService(
            IViewModelFactory viewModelFactory,
            IIndividualFactory individualFactory,
            IIndividualRepository individualRepository)
        {
            _viewModelFactory = viewModelFactory;
            _individualFactory = individualFactory;
            _individualRepository = individualRepository;
        }

        public async Task<IndividualDetailsViewData> LoadAsync(string id)
        {
            var individual = await _individualRepository.LoadByIdAsync(id);
            var viewData = await _viewModelFactory.CreateAsync<IndividualDetailsViewData>();
            viewData.Birthdate = individual.Birthdate;
            viewData.FirstName = individual.FirstName;
            viewData.Id = individual.Id;
            viewData.LastName = individual.LastName;

            return viewData;
        }

        public async Task SaveAsync(IndividualDetailsViewData data)
        {
            var individual = _individualFactory.Create(data.FirstName, data.LastName, data.Birthdate, data.Id);
            await _individualRepository.SaveAsync(individual);
        }
    }
}