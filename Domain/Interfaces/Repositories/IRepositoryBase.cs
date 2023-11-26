using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase<T>
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        T? GetByIdNoTracking(int id);

        IEnumerable<T> GetAllNoTracking();
        IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");
        void Insert(T obj);
        void Update(T obj);
        void Save();
    }
}
