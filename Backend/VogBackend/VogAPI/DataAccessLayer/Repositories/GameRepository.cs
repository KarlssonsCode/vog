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
    public class GameRepository(ApplicationDbContext context) : IGameRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Game>> GetAllGamesAsync()
        {
            List<Game> games = await _context.Games.ToListAsync();

            return games;
        }

        public async Task<Game> AddGame(Game game)
        {
            var existingGame = await _context.Games.FirstOrDefaultAsync(g => g.RawgId == game.RawgId);
            if (existingGame != null)
            {
                return existingGame;
            }

            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }
    }
}
