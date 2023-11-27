using Data.Context;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class BiddingRepository : RepositoryBase<Bidding>, IBiddingRepository
    {
        private readonly ModelContext _context;
        public BiddingRepository(ModelContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Bidding> GetPaginated(BiddingPaginatedDTO biddingPaginatedDTO, out int number)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(biddingPaginatedDTO.Search))
                query = query.Where(b => b.Description.ToLower().Contains(biddingPaginatedDTO.Search.ToLower())
                || b.Number.ToLower().Contains(biddingPaginatedDTO.Search.ToLower())
                || b.OpeningDate.ToString().ToLower().Contains(biddingPaginatedDTO.Search.ToLower()));

            number = query.Count();
            var columName = biddingPaginatedDTO.SortColumn;
            if (!string.IsNullOrEmpty(biddingPaginatedDTO.SortColumn) && biddingPaginatedDTO.SortDirection.Equals("asc", StringComparison.CurrentCultureIgnoreCase))
                query = query.OrderBy(e => EF.Property<object>(e, columName));
            else
                query = query.OrderByDescending(e => EF.Property<object>(e, columName));
            if (biddingPaginatedDTO.Paginated)
            {
                return query.Skip(biddingPaginatedDTO.Skip).Take(biddingPaginatedDTO.Take).ToList();
            }
            return query.ToList();
        }
    }
}
