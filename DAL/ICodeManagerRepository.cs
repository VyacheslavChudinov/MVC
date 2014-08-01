using System;
using System.Linq;

namespace DAL
{
    public interface ICodeManagerRepository<T>
    {
        void Insert(T entity);
        void Delete(Guid id);
        void Update(T entity);
        T Get(Guid id);
        IQueryable<T> GetAll();
    }
}
