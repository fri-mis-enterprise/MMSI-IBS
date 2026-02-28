using IBS.Models.Books;
using IBS.DataAccess.Repository.IRepository;
using IBS.Models;

namespace IBS.DataAccess.Repository.IRepository
{
    public interface IAuditTrailRepository : IRepository<AuditTrail>
    {
    }
}
