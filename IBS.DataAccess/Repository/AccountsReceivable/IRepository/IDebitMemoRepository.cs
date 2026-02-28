using IBS.Models.Books;
using IBS.DataAccess.Repository.IRepository;
using IBS.Models;
using IBS.Models.AccountsReceivable;

namespace IBS.DataAccess.Repository.AccountsReceivable.IRepository
{
    public interface IDebitMemoRepository : IRepository<DebitMemo>
    {
        Task<string> GenerateCodeAsync(string company, string type, CancellationToken cancellationToken = default);
    }
}
