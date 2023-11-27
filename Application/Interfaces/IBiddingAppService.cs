using Application.ViewModels;
using Domain.DTOs;

namespace Application.Interfaces
{
    public interface IBiddingAppService : IAppServiceBase<BiddingCreateVM>
    {
        BiddingEditVM GetById(int id);
        List<string> Update(BiddingEditVM obj);
        (int total, IEnumerable<BiddingDTO>) GetPaginated(BiddingPaginatedDTO biddingPaginated);
    }
}
