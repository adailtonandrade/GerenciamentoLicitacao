using Application.ViewModels;
using Domain.DTOs;

namespace Application.Interfaces
{
    public interface IBiddingAppService : IAppServiceBase<BiddingCreateVM>
    {
        (int total, IEnumerable<BiddingDTO>) GetPaginated(BiddingPaginatedDTO biddingPaginated);
    }
}
