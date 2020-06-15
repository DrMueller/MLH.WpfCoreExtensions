using Mmu.Mlh.DataAccess.FileSystem.Areas.DataModelRepositories.Services.Implementation;
using Mmu.Mlh.DataAccess.FileSystem.Areas.DataModelRepositories.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.DataAccess.DataModeling;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.DataAccess.Repositories.DataModelRepositories.Implementation
{
    public class IndividualDataModelRepository : FileSystemDataModelRepository<IndividualDataModel>, IIndividualDataModelRepository
    {
        public IndividualDataModelRepository(
            IFileSystemProxy<IndividualDataModel> fileSystemProxy,
            IDataModelFileAdapter<IndividualDataModel> fileAdapter)
            : base(fileSystemProxy, fileAdapter)
        {
        }
    }
}