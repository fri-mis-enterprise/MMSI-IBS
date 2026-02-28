using System.Linq.Expressions;
using IBS.DataAccess.Repository.IRepository;
using IBS.Models.MMSI;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IBS.DataAccess.Repository.MMSI.IRepository
{
    public interface ICollectionRepository : IRepository<MMSICollection>
    {
        Task SaveAsync(CancellationToken cancellationToken);

        Task<List<SelectListItem>> GetMMSICustomersById(CancellationToken cancellationToken = default);

        Task<List<SelectListItem>> GetMMSICustomersWithCollectiblesSelectList(int collectionId, string type, CancellationToken cancellationToken = default);

        Task<List<SelectListItem>> GetMMSIUncollectedBillingsById(CancellationToken cancellationToken = default);

        Task<List<SelectListItem>> GetMMSICollectedBillsById(int collectionId, CancellationToken cancellationToken = default);

        Task<List<SelectListItem>?> GetMMSIUncollectedBillingsByCustomer(int? customerId, CancellationToken cancellationToken);

        Task<string> GenerateCollectionNumber(CancellationToken cancellationToken = default);

        // Accounting Methods
        Task PostAsync(MMSICollection collection, List<Offsettings> offsettings, CancellationToken cancellationToken = default);

        Task DepositAsync(MMSICollection collection, CancellationToken cancellationToken = default);

        Task ReturnedCheck(string collectionNo, string company, string userName, CancellationToken cancellationToken = default);

        Task RedepositAsync(MMSICollection collection, CancellationToken cancellationToken = default);

        Task UpdateBillingPayment(int billingId, decimal paidAmount, CancellationToken cancellationToken = default);

        Task RemoveBillingPayment(int billingId, decimal paidAmount, decimal offsetAmount, CancellationToken cancellationToken = default);
    }
}
