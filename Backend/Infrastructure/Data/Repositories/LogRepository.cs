using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class LogRepository : IRepository<Log>
    {
        private readonly DronesContext _context;

        public LogRepository(DronesContext context)
        {
            _context = context;
        }
        public void Add(Log entity)
        {
            _context.Logs.Add(entity);
        }

        public async Task<List<Log>> GetEntitiesAsync()
        {
            return await _context.Logs.ToListAsync();
        }

        public Task<List<Log>> GetEntitiesByFilterAsync(Expression<Func<Log, bool>> filter, bool includeRelated = false)
        {
            throw new NotImplementedException();
        }

        public Task<Log> GetEntityByFilterAsync(Expression<Func<Log, bool>> filter, bool includeRelated = false)
        {
            throw new NotImplementedException();
        }

        public void Remove(Log entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
