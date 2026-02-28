using IBS.DataAccess.Data;
using IBS.DataAccess.Repository.MasterFile.IRepository;
using IBS.Models.MasterFile;

namespace IBS.DataAccess.Repository.MasterFile
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
