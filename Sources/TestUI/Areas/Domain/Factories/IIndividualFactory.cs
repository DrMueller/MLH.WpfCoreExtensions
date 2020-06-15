using System;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Models;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Domain.Factories
{
    public interface IIndividualFactory
    {
        Individual Create(string firstName, string lastName, DateTime birthdate, string id = null);
    }
}