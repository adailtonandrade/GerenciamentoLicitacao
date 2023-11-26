using Domain.Entities;
using FluentValidation;
using System.Linq.Expressions;

namespace Domain.Interfaces.Service
{
    public interface IServiceBase<T> where T : EntityBase
    {
        TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TValidator : AbstractValidator<T>
        where TInputModel : class
        where TOutputModel : class;
        IEnumerable<T> GetAll();
        T? GetById(int id);
        T? GetByIdNoTracking(int id);

        IEnumerable<T> GetAllNoTracking();
        IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null,
        Expression<Func<IQueryable<T>, IOrderedQueryable<T>>>? orderBy = null,
        string includeProperties = "");
        TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<T>
            where TInputModel : class
            where TOutputModel : class;
    }
}
