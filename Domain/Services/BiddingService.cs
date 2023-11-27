using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Service;

namespace Domain.Services
{
    public class BiddingService : ServiceBase<Bidding>, IBiddingService
    {
        private readonly IBiddingRepository _biddingRepository;
        private readonly IMapper _mapper;

        private List<string> _errors = new();

        public BiddingService(IBiddingRepository biddingRepository, IMapper mapper) : base(biddingRepository, mapper)
        {
            _biddingRepository = biddingRepository;
            _mapper = mapper;
        }
        public (int total, IEnumerable<BiddingDTO>) GetPaginated(BiddingPaginatedDTO biddingPaginated)
        {
            var biddings = _biddingRepository.GetPaginated(biddingPaginated, out int number);
            var biddingsMap = _mapper.Map<List<BiddingDTO>>(biddings);

            return (number, biddingsMap);
        }

        public override List<string> Validate(Bidding bidding)
        {
            if (!IsUniqueField(nameof(bidding.Number), bidding.Number, bidding.Id))
                _errors.Add("O Número informado já esta em uso para outra licitação");
            return _errors;
        }
    }
}