using Microsoft.EntityFrameworkCore;
using VogAPI.Data;
using VogAPI.Models;

namespace VogAPI.DAL
{
    public class BacklogRepository
    {
        private readonly VogAPIContext _context;
        private readonly GameRepository _gameRepository;

        public BacklogRepository(VogAPIContext context, GameRepository gameRepository)
        {
            _context = context;
            _gameRepository = gameRepository;
        }

        public async Task AddGameToBacklogAsync(int userId, int rawgId, string rawgTitle, string backgroundImage, string releaseDate, string description, int? metacritic)
        {
            var game = await _gameRepository.AddGameFromRawgToVogLibraryAsync(rawgId, rawgTitle, backgroundImage, releaseDate, description, metacritic);

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            var gameAdd = _context.Games.FirstOrDefault(g => g.Id == game.Id);
            if (user == null || game == null)
            {
                return;
            }

            if (!_context.Backlogs.Any(b => b.UserId == userId && b.GameId == game.Id))
            {
                var backlogItem = new Backlog
                {
                    UserId = userId,
                    GameId = game.Id,
                };

                _context.Backlogs.Add(backlogItem);
                await _context.SaveChangesAsync();
            }
        }

        public void RemoveGameFromBacklog(int backlogId)
        {
            var backlogGame = _context.Backlogs.FirstOrDefault(g => g.Id == backlogId);

            _context.Backlogs.Remove(backlogGame);
            _context.SaveChanges();
        }

        public async Task<List<Game>> GetUserBacklogGames(int userId)
        {
           List<Game> backlogGames = await _context.Backlogs.Where(b => b.UserId == userId).Select(b => b.Game).ToListAsync();

            return backlogGames;

        }

        //public bool GameExistsInBacklog(int userId, int gameId)
        //{
        //    return _context.Backlogs.Any(b => b.UserId == userId && b.GameId == gameId);
        //}

       
    }
}
