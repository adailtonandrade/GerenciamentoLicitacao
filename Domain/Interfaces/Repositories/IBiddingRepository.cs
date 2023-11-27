using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBiddingRepository : IRepositoryBase<Bidding>
    {
        IEnumerable<Bidding> GetPaginated(BiddingPaginatedDTO biddingPaginatedDTO, out int number);
    }
}
