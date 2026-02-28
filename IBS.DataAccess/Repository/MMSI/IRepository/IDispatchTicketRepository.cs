using IBS.DataAccess.Repository.IRepository;
using IBS.Models.MMSI;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IBS.DataAccess.Repository.MMSI.IRepository
{
    public interface IDispatchTicketRepository : IRepository<MMSIDispatchTicket>
    {
        Task SaveAsync(CancellationToken cancellationToken);

        Task<MMSIDispatchTicket> GetDispatchTicketLists(MMSIDispatchTicket model, CancellationToken cancellationToken = default);
    }
}
