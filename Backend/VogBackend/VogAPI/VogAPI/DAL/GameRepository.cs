using Microsoft.EntityFrameworkCore;
using VogAPI.Data;
using VogAPI.Models;

namespace VogAPI.DAL
{
    public class GameRepository
    {
        private readonly VogAPIContext _context;

        public GameRepository(VogAPIContext context)
        {
            _context = context;
        }

        public void AddGame(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            List<Game> games = await _context.Games.ToListAsync();

            return games;
        }

        public async Task<Game> AddGameFromRawgToVogLibraryAsync(int rawgId, string rawgTitle, string backgroundImage, string releaseDate, string description, int? metacritic)
        {
            var existingGame = await _context.Games.FirstOrDefaultAsync(g => g.RawgId == rawgId);
            if (existingGame != null)
            {
                return existingGame;
            }

            var newGame = new Game
            {
                RawgId = rawgId,
                Title = rawgTitle,
                BackgroundImage = backgroundImage,
                ReleaseDate = releaseDate,
                Description = description,
                Metacritic = metacritic
            };

            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();
            return newGame;



        }
    }
}
