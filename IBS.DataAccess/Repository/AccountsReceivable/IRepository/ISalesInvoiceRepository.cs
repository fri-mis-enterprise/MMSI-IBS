using IBS.DataAccess.Repository.IRepository;
using IBS.Models.AccountsReceivable;

namespace IBS.DataAccess.Repository.AccountsReceivable.IRepository
{
    public interface ISalesInvoiceRepository : IRepository<SalesInvoice>
    {
        Task<string> GenerateCodeAsync(string company, string type, CancellationToken cancellationToken = default);

        Task PostAsync(SalesInvoice salesInvoice, CancellationToken cancellationToken = default);
    }
}
