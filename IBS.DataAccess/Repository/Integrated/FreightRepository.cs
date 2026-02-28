using IBS.DataAccess.Data;
using IBS.DataAccess.Repository.Integrated.IRepository;
using IBS.Models;

namespace IBS.DataAccess.Repository.Integrated
{
    public class FreightRepository : Repository<Freight>, IFreightRepository
    {
        private readonly ApplicationDbContext _db;

        public FreightRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
