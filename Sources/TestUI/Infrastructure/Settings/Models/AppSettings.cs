namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Models
{
    public class AppSettings
    {
        public const string SectionKey = "AppSettings";

        public string DirectoryPath { get; set; }

        public string Value1 { get; set; }

        public long Value2 { get; set; }
    }
}