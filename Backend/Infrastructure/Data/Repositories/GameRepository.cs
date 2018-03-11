using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private readonly DronesContext _context;

        public GameRepository(DronesContext context)
        {
            _context = context;
        }
        public void Add(Game entity)
        {
            _context.Games.Add(entity);
        }

        public async Task<List<Game>> GetEntitiesAsync()
        {
            return await _context.Games
                .Include(g => g.Rounds)
                .Include(g => g.Player1)
                .Include(g => g.Player2)
                .Include(g => g.Winner)
                .ToListAsync();
        }

        public async Task<List<Game>> GetEntitiesByFilterAsync(Expression<Func<Game, bool>> filter, bool includeRelated = false)
        {
            return await _context.Games.Where(filter)
                .Include(g => g.Rounds)
                .Include(g => g.Player1)
                .Include(g => g.Player2)
                .Include(g => g.Winner)
                .ToListAsync();
        }

        public async Task<Game> GetEntityByFilterAsync(Expression<Func<Game, bool>> filter, bool includeRelated = false)
        {
            return await _context.Games.Where(filter)
                .Include(g => g.Rounds)
                .Include(g => g.Player1)
                .Include(g => g.Player2)
                .Include(g => g.Winner)
                .FirstOrDefaultAsync();
        }

        public void Remove(Game entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Game entity)
        {
            throw new NotImplementedException();
        }
    }
}
