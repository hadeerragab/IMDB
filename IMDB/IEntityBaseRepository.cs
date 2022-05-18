using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IMDB.Data.Base
{
    public interface IEntityBaseRepository<T>where T : class ,IEntityBase , new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        T GetByID(int EntityID);
        void AddNew(T EntityNewData);
        T Update(int EntityID, T EntityNewData);
        void Delete(int EntityID, T EntityData);
    }
}
