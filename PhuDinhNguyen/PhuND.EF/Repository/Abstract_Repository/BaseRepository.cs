using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Repository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public DbContext dbContext { get; set; }

        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> Get(Func<T, bool> predicate)
        {
            var result = dbContext.Set<T>().Where(predicate);
            return result.AsQueryable();
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
            ((System.Data.Entity.Infrastructure.IObjectContextAdapter)dbContext).ObjectContext.Detach(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().AsEnumerable();
        }

        public virtual T Find(int Id)
        {
            throw new NotImplementedException();
        }
    }
}