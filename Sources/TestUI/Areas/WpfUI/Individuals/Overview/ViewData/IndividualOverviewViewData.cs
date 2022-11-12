using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewData
{
    public class IndividualOverviewViewData
    {
        public string FormattedBirthdate { get; }
        public string FormattedName { get; }
        public string Id { get; }

        public IndividualOverviewViewData(string formattedName, string formattedBirthdate, string id)
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