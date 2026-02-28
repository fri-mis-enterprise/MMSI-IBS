using IBS.DataAccess.Repository.IRepository;
using IBS.Models.AccountsPayable;

namespace IBS.DataAccess.Repository.AccountsPayable.IRepository
{
    public interface IJournalVoucherRepository : IRepository<JournalVoucherHeader>
    {
        Task<string> GenerateCodeAsync(string company, string? type, int additionalIncrement = 0, CancellationToken cancellationToken = default);

        Task PostAsync(JournalVoucherHeader header,
            IEnumerable<JournalVoucherDetail> details,
            CancellationToken cancellationToken = default);
    }
}
