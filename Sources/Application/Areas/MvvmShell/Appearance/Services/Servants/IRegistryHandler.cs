namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services.Servants
{
    public interface IRegistryHandler
    {
        string LoadFromCurrentUserApplicationRegistry(string keyName);

        void SaveIntoCurrentUserApplicationRegistry(string keyName, string value);
    }
}