using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace DataAccessLayer.Repositories
{
    public class BacklogRepository : IBacklogRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IGameRepository _gameRepository;

        public BacklogRepository(ApplicationDbContext context, IGameRepository gameRepository)
        {
            _context = context;
            _gameRepository = gameRepository;
        }
        public async Task AddGameToBacklogAsync(Backlog backlog)
        {
            var existingBacklog = await GetBacklogItemAsync(backlog.UserId, backlog.GameId);

            if (existingBacklog != null)
            {
                return;
            }
            _context.Backlogs.Add(backlog);
            await _context.SaveChangesAsync();
        }

        public async Task<Backlog> GetBacklogItemAsync(int userId, int gameId)
        {
            return await _context.Backlogs
                .FirstOrDefaultAsync(b => b.UserId == userId && b.GameId == gameId);
        }
        public async Task<bool> DeleteGameFromBacklogAsync(int backlogId)
        {
            var backlog = await _context.Backlogs.FindAsync(backlogId);
            if (backlog == null)
            {
                return false;
            }

            _context.Backlogs.Remove(backlog);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<ICollection<Backlog>> GetBacklogItemsByUserIdAsync(int userId)
        {
            return await _context.Backlogs
             .Where(b => b.UserId == userId)
             .Include(b => b.Game)            
             .AsNoTracking()
             .ToListAsync();
        }



    }
}
