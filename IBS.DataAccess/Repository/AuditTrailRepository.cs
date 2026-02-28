using IBS.DataAccess.Data;
using IBS.DataAccess.Repository.IRepository;
using IBS.Models;

namespace IBS.DataAccess.Repository
{
    public class AuditTrailRepository : Repository<AuditTrail>, IAuditTrailRepository
    {
        private readonly ApplicationDbContext _db;

        public AuditTrailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
