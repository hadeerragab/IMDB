using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMDB.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        private AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddNew(T EntityNewData)
        {
            _context.Set<T>().Add(EntityNewData);
            _context.SaveChanges();
        }

        public void Delete(int EntityID, T EntityData)
        {
            _context.Set<T>().Remove(EntityData);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            var All = _context.Set<T>().ToList();
            return All;
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.ToList();
        }

        public T GetByID(int EntityID)
        {
            var EntityData = _context.Set<T>().FirstOrDefault(EntityRequird => EntityRequird.ID == EntityID);

            return EntityData;
        }

        public T Update(int EntityID, T EntityNewData)
        {
            _context.Set<T>().Update(EntityNewData);
            _context.SaveChanges();
            return EntityNewData;
        }
    }
}
