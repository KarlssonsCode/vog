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
    public class CustomUserListGameRepository : ICustomUserListGameRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomUserListGameRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddGameToCustomListAsync(CustomUserListGame game)
        {
            var existingGameInList = await CheckIfInListAlready(game.GameId, game.CustomUserListId);

            if (existingGameInList != null)
            {
                return;
            }
            _context.CustomUserListGames.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task<CustomUserListGame> CheckIfInListAlready(int gameId, int listId)
        {
            return await _context.CustomUserListGames
                .FirstOrDefaultAsync(c => c.GameId == gameId && c.CustomUserListId == listId);
        }

        public async Task<ICollection<CustomUserListGame>> GetCustomUserListGamesByListIdAsync(int listId)
        {
            return await _context.CustomUserListGames.Where(game => game.CustomUserListId == listId).Include(g => g.Game)
            .ToListAsync();
        }
    }
}
