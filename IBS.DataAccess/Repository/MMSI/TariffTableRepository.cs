using System.Linq.Expressions;
using IBS.DataAccess.Data;
using IBS.DataAccess.Repository.MMSI.IRepository;
using IBS.Models.MMSI;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IBS.DataAccess.Repository.MMSI
{
    public class TariffTableRepository : Repository<MMSITariffRate>, ITariffTableRepository
    {
        private readonly ApplicationDbContext _db;

        public TariffTableRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<MMSITariffRate?> GetAsync(Expression<Func<MMSITariffRate, bool>> filter, CancellationToken cancellationToken = default)
        {
            var model =  await dbSet
                .Include(t => t.Terminal).ThenInclude(t => t!.Port)
                .Where(filter)
                .OrderByDescending(t => t.AsOfDate)
                .FirstOrDefaultAsync(cancellationToken);

            return model;
        }

        public override async Task<IEnumerable<MMSITariffRate>> GetAllAsync(Expression<Func<MMSITariffRate, bool>>? filter, CancellationToken cancellationToken = default)
        {
            IQueryable<MMSITariffRate> query = dbSet
                .Include(t => t.Customer)
                .Include(t => t.Terminal).ThenInclude(t => t!.Port)
                .Include(t => t.Service);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
    }
}
