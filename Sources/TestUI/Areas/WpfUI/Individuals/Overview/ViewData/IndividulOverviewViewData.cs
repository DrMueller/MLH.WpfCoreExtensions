using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.ViewData
{
    public class IndividulOverviewViewData
    {
        public string FormattedBirthdate { get; }
        public string FormattedName { get; }
        public string Id { get; }

        public IndividulOverviewViewData(string formattedName, string formattedBirthdate, string id)
        {
            Guard.StringNotNullOrEmpty(() => formattedName);
            Guard.StringNotNullOrEmpty(() => formattedBirthdate);
            Guard.StringNotNullOrEmpty(() => id);

            FormattedName = formattedName;
            Id = id;
            FormattedBirthdate = formattedBirthdate;
        }
    }
}