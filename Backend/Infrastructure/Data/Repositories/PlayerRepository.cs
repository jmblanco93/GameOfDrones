using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly DronesContext _context;

        public PlayerRepository(DronesContext context)
        {
            _context = context;
        }
        public void Add(Player entity)
        {
            _context.Players.Add(entity);
        }

        public async Task<List<Player>> GetEntitiesAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public Task<List<Player>> GetEntitiesByFilterAsync(Expression<Func<Player, bool>> filter, bool includeRelated = false)
        {
            throw new NotImplementedException();
        }

        public async Task<Player> GetEntityByFilterAsync(Expression<Func<Player, bool>> filter, bool includeRelated = false)
        {
            return await _context.Players.Where(filter).FirstOrDefaultAsync();
        }

        public void Remove(Player entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Player entity)
        {
            throw new NotImplementedException();
        }
    }
}
