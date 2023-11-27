using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces.Service
{
    public interface IBiddingService : IServiceBase<Bidding>
    {
        (int total, IEnumerable<BiddingDTO>) GetPaginated(BiddingPaginatedDTO biddingPaginated);
    }
}
