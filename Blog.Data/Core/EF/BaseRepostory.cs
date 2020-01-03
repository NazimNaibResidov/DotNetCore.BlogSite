using Blog.Data.Core.IEF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog.Data.Core.EF
{
    public class BaseRepostory<T> : IBaseRepstory<T> where T : class
    {
        private readonly DbContext context;
        public BaseRepostory(DbContext _context)
        {
            context = _context;
        }

        public bool Add(T entity)
        {
            context.Set<T>().Add(entity);
            try
            {
                return context.SaveChanges() > 0;
            }

            catch (DbUpdateConcurrencyException e)
            {
                return false;
            }
            catch (DbUpdateException ex)
            {

                return false;
            }

        }

        public bool Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            try
            {
                return context.SaveChanges() > 0;
            }

            catch (DbUpdateConcurrencyException e)
            {
                return false;
            }
            catch (DbUpdateException ex)
            {

                return false;
            }
        }

        public T GetById(int id)
        {
          return  context.Set<T>().Find(id);
        }

        public IQueryable<T> Select()
        {
            return context.Set<T>().AsQueryable();
        }

        public bool UpDate(T entity)
        {
            context.Set<T>().Update(entity);
            try
            {
                return context.SaveChanges() > 0;
            }

            catch (DbUpdateConcurrencyException e)
            {
                return false;
            }
            catch (DbUpdateException ex)
            {

                return false;
            }
        }
    }
}
