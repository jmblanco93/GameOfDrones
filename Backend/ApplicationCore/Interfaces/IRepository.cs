using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        Task<List<T>> GetEntitiesAsync();
        void Remove(T entity);
        void Update(T entity);
        Task<List<T>> GetEntitiesByFilterAsync(Expression<Func<T, bool>> filter, bool includeRelated = false);
        Task<T> GetEntityByFilterAsync(Expression<Func<T, bool>> filter, bool includeRelated = false);
    }
}
