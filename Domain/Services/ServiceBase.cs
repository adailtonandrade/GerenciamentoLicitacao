using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Service;
using FluentValidation;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        private readonly IRepositoryBase<T> _baseRepository;
        private readonly IMapper _mapper;

        public ServiceBase(IRepositoryBase<T> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<T>
        {
            T entity = _mapper.Map<T>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(entity);

            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null, Expression<Func<IQueryable<T>, IOrderedQueryable<T>>>? orderBy = null, string includeProperties = "")
        {
            return _baseRepository.Get(filter, orderBy != null ? orderBy.Compile() : null, includeProperties);
        }

        public IEnumerable<T> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public IEnumerable<T> GetAllNoTracking()
        {
            return _baseRepository.GetAllNoTracking();
        }

        public T? GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        public T? GetByIdNoTracking(int id)
        {
            return _baseRepository.GetByIdNoTracking(id);
        }

        public TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<T>
        {
            T entity = _mapper.Map<T>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(entity);

            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }
        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
