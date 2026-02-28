using IBS.DataAccess.Repository.IRepository;
using IBS.Models.MasterFile;

namespace IBS.DataAccess.Repository.MasterFile.IRepository
{
    public interface IServiceMasterRepository : IRepository<ServiceMaster>
    {
        Task<string> GetLastNumber(CancellationToken cancellationToken = default);

        Task<bool> IsServicesExist(string serviceName, string company, CancellationToken cancellationToken = default);
    }
}
