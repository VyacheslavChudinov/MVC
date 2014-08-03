using System;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class CodeManagerRepository<T>: ICodeManagerRepository<T> where T : class
    {
        internal IDbSet<T> DbSet;
        public  CodeManagerRepository(IDbSet<T> dbSet)
        {
            DbSet = dbSet;
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
        }

        public T Get(Guid id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }
    }
}