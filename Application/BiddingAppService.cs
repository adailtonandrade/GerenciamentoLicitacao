using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Data;
using Domain.Interfaces.Service;

namespace Application
{
    public class BiddingAppService : UnitOfWorkAppService, IBiddingAppService
    {
        private readonly IBiddingService _biddingService;
        private readonly IMapper _mapper;
        List<string> _errors = [];

        public BiddingAppService(IBiddingService biddingService, IMapper mapper,
            IUnitOfWork uow) : base(uow)
        {
            _biddingService = biddingService;
            _mapper = mapper;
        }
        public List<string> Delete(int id)
        {
            Bidding? bidding = _biddingService.GetById(id);
            try
            {
                if (bidding != null)
                {
                    if (bidding.IsActive.Equals(Convert.ToBoolean((int)GenericStatusEnum.Inactive)))
                        _errors = Reactivate(bidding);
                    else
                        _errors = Deactivate(bidding);
                }
                throw new NullReferenceException();
            }
            catch (Exception e)
            {
                if (bidding != null)
                    _errors.Add("Erro: " + e.Message.ToString() + "\nInner Exception: " + e.InnerException?.Message.ToString());
                else
                    _errors.Add("A Licitação não foi encontrada");
            }
            return _errors;
        }

        private List<string> Deactivate(Bidding bidding)
        {
            try
            {
                var users = _biddingService.Get(t => t.Id == bidding.Id);
                if (users == null || users.Count() == 0)
                {
                    BeginTransaction();
                    bidding.IsActive = Convert.ToBoolean(((int)GenericStatusEnum.Inactive));
                    _biddingService.Update(bidding);
                    SaveChanges();
                    Commit();
                }
                else
                    _errors.Add(String.Format("A Licitação de Número {0} não pode ser desativada pois não foi encontrada na base de dados", bidding.Number));
            }
            catch (Exception e)
            {
                _errors.Add(String.Format("Ocorreu um erro ao desativar a Licitação"));
                Rollback();
            }
            return _errors;
        }

        private List<string> Reactivate(Bidding bidding)
        {
            try
            {
                BeginTransaction();
                bidding.IsActive = Convert.ToBoolean(((int)GenericStatusEnum.Active));
                _biddingService.Update(bidding);
                SaveChanges();
                Commit();
            }
            catch (Exception e)
            {
                _errors.Add(String.Format("Ocorreu uma falha ao reativar a Licitação"));
                Rollback();
            }
            return _errors;
        }

        public IEnumerable<BiddingCreateVM> GetAll()
        {
            throw new NotImplementedException();
        }

        public BiddingEditVM GetById(int id)
        {
            return _mapper.Map<BiddingEditVM>(_biddingService.GetById(id));
        }

        public (int total, IEnumerable<BiddingDTO>) GetPaginated(BiddingPaginatedDTO biddingPaginated)
        {
            return _biddingService.GetPaginated(biddingPaginated);
        }

        public List<string> Insert(BiddingCreateVM obj)
        {
            try
            {
                var biddingEntity = _mapper.Map<BiddingCreateVM, Bidding>(obj);
                biddingEntity.IsActive = Convert.ToBoolean(((int)GenericStatusEnum.Active));
                _errors = _biddingService.Validate(biddingEntity);
                if (_errors?.Count == 0)
                {
                    biddingEntity.OpeningDate = DateOnly.FromDateTime(DateTime.Now);
                    biddingEntity.Status = BiddingStatusEnum.Opened;
                    BeginTransaction();
                    _biddingService.Add(biddingEntity);
                    SaveChanges();
                    Commit();
                }
            }
            catch (Exception e)
            {
                _errors.Add("Erro: " + e.Message.ToString() + "\nInner Exception: " + e.InnerException?.Message.ToString());
                Rollback();
            }
            return _errors ?? [];
        }

        public List<string> Update(BiddingEditVM obj)
        {
            try
            {
                Bidding bidding = _mapper.Map<BiddingEditVM, Bidding>(obj);
                bidding.IsActive = Convert.ToBoolean((int)GenericStatusEnum.Active);
                _errors = _biddingService.Validate(bidding);
                if (_errors?.Count == 0)
                {
                    BeginTransaction();
                    _biddingService.Update(bidding);
                    SaveChanges();
                    Commit();
                }
            }
            catch (Exception e)
            {
                _errors.Add("Erro: " + e.Message.ToString() + "\nInner Exception: " + e.InnerException.Message.ToString());
                Rollback();
            }
            return _errors ?? [];
        }
    }
}
