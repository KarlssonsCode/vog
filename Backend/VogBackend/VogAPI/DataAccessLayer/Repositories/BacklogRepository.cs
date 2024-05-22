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
        //public async Task AddGameToBacklogAsync(int userId, int rawgId, string rawgTitle, string backgroundImage, string releaseDate, string description, int? metacritic)
        //{
        //    var game = new Game
        //    {
        //        RawgId = rawgId,
        //        Title = rawgTitle,
        //        BackgroundImage = backgroundImage,
        //        ReleaseDate = releaseDate,
        //        Description = description,
        //        Metacritic = metacritic
        //    };

        //    game = await _gameRepository.AddGame(game);

        //    var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        //    var gameAdd = _context.Games.FirstOrDefault(g => g.Id == game.Id);
        //    if (user == null || game == null)
        //    {
        //        return;
        //    }

        //    if (!_context.Backlogs.Any(b => b.UserId == userId && b.GameId == game.Id))
        //    {
        //        var backlogItem = new Backlog
        //        {
        //            UserId = userId,
        //            GameId = game.Id,
        //        };

        //        _context.Backlogs.Add(backlogItem);
        //        await _context.SaveChangesAsync();
        //    }
        //}
        public async Task AddGameToBacklogAsync(Backlog backlog)
        {
            _context.Backlogs.Add(backlog);
            await _context.SaveChangesAsync();
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

    }
}
