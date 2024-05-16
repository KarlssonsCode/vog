using Microsoft.AspNetCore.Mvc;
using VogAPI.DAL;
using VogAPI.Models;

namespace VogAPI.Controllers
{
    [Route("/Game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameRepository _gameRepository;

        public GameController (GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpPost]
        public IActionResult AddGameToVogLibrary([FromBody] Game game)
        {
            _gameRepository.AddGame(game);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameRepository.GetAllGamesAsync();
            if (games == null || games.Count == 0)
            {
                return NotFound();
            }
            return Ok(games);
        }


    }
}
