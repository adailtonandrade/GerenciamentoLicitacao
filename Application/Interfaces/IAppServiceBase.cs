using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IAppServiceBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        List<string> Insert(T obj);
        List<string> Update(T obj);
        List<string> Delete(int id);
    }
}
