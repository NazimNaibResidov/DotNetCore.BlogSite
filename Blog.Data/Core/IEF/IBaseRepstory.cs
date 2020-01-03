using System.Linq;

namespace Blog.Data.Core.IEF
{
    public interface IBaseRepstory<T> where T : class
    {
     
        IQueryable<T> Select();
        bool Add(T entity);
        bool Delete(T entity);
        bool UpDate(T entity);
        T    GetById(int id);
    }
}
