using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IAppServiceBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        List<string> Insert(T obj);
        List<string> Delete(int id);
    }
}
