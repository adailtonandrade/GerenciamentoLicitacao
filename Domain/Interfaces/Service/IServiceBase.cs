using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces.Service
{
    public interface IServiceBase<T> where T : EntityBase<T>
    {
        void Add(T inputModel);
        T? GetById(int id);
        T? GetByIdNoTracking(int id);
        IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null,
        Expression<Func<IQueryable<T>, IOrderedQueryable<T>>>? orderBy = null,
        string includeProperties = "");
        List<string> Validate(T variable);
        bool IsUniqueField(string propertyName, string name, int? id);
        void Update(T inputModel);
    }
}
