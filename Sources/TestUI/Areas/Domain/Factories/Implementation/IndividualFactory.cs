using System;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Models;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Factories.Implementation
{
    public class IndividualFactory : IIndividualFactory
    {
        public Individual Create(string firstName, string lastName, DateTime birthdate, string id = null)
        {
            return new Individual(
                firstName,
                lastName,
                birthdate,
                id);
        }
    }
}