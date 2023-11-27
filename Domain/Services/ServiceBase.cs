using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Service;
using FluentValidation;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : EntityBase<T>
    {
        private readonly IRepositoryBase<T> _baseRepository;
        private readonly IMapper _mapper;

        public ServiceBase(IRepositoryBase<T> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public void Add(T inputModel)
        {
            T entity = _mapper.Map<T>(inputModel);
            entity.ValidateAndThrow(entity);
            _baseRepository.Insert(entity);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null, Expression<Func<IQueryable<T>, IOrderedQueryable<T>>>? orderBy = null, string includeProperties = "")
        {
            return _baseRepository.Get(filter, orderBy != null ? orderBy.Compile() : null, includeProperties);
        }

        public T? GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        public T? GetByIdNoTracking(int id)
        {
            return _baseRepository.GetByIdNoTracking(id);
        }

        public void Update(T inputModel)
        {
            T entity = _mapper.Map<T>(inputModel);

            entity.ValidateAndThrow(entity);
            _baseRepository.Update(entity);
        }
        public virtual List<string> Validate(T variable)
        {
            return new List<string>();
        }

        public bool IsUniqueField(string propertyName, string name, int? id)
        {
            var domains = Expression.Parameter(typeof(T));
            Expression filter = Expression.Empty();

            name = name.Trim();

            if (id == null || id == 0)
            {
                if (!name.Equals(string.Empty))
                {
                    filter = Expression.Equal(Expression.Property(domains, propertyName.ToString().ToLower()), Expression.Constant(name.ToLower()));
                }
            }
            else
            {
                if (!name.Equals(string.Empty))
                {
                    var arg1 = Expression.Equal(Expression.Property(domains, propertyName.ToString().ToLower()), Expression.Constant(name.ToLower()));
                    var arg2 = Expression.NotEqual(Expression.Property(domains, "Id"), Expression.Constant(id));
                    filter = Expression.And(arg1, arg2);
                }
            }
            var filterExpression = Expression.Lambda<Func<T, bool>>(filter, domains);
            var result = Get(filterExpression).FirstOrDefault();
            return result == null;
        }
    }
}
