using IBS.DataAccess.Data;
using IBS.DataAccess.Repository.MasterFile.IRepository;
using IBS.Models.MasterFile;
using Microsoft.EntityFrameworkCore;

namespace IBS.DataAccess.Repository.MasterFile
{
    public class ServiceMasterRepository : Repository<ServiceMaster>, IServiceMasterRepository
    {
        private readonly ApplicationDbContext _db;

        public ServiceMasterRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<string> GetLastNumber(CancellationToken cancellationToken = default)
        {
            var lastNumber = await _db
                .Services
                .OrderByDescending(s => s.ServiceId)
                .FirstOrDefaultAsync(cancellationToken);

            if (lastNumber == null || !int.TryParse(lastNumber.ServiceNo, out var serviceNo))
            {
                return "2001";
            }

            return (serviceNo + 1).ToString();

        }

        public async Task<bool> IsServicesExist(string serviceName, string company, CancellationToken cancellationToken = default)
        {
            return await _db.Services
                .AnyAsync(c => c.Company == company && c.Name == serviceName, cancellationToken);
        }

        public async Task UpdateAsync(ServiceMaster model, CancellationToken cancellationToken = default)
        {
            var existingService = await _db.Services
                .FirstOrDefaultAsync(x => x.ServiceId == model.ServiceId, cancellationToken)
                ?? throw new InvalidOperationException($"Service with id '{model.ServiceId}' not found.");

            existingService.Name = model.Name;
            existingService.Percent = model.Percent;
            existingService.Company = model.Company;
            existingService.CurrentAndPreviousNo = model.CurrentAndPreviousNo;
            existingService.CurrentAndPreviousTitle = model.CurrentAndPreviousTitle;
            existingService.UnearnedNo = model.UnearnedNo;
            existingService.UnearnedTitle = model.UnearnedTitle;

            if (_db.ChangeTracker.HasChanges())
            {
                await _db.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("No data changes!");
            }
        }
    }
}
