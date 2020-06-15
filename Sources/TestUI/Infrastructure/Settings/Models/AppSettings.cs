using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Models
{
    public class AppSettings
    {
        public AppSettings(string value1, long value2)
        {
            Guard.StringNotNullOrEmpty(() => value1);
            Value1 = value1;
            Value2 = value2;
        }

        public string Value1 { get; }

        public long Value2 { get; }
    }
}