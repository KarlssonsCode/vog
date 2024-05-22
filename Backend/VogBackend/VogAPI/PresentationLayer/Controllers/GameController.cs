using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using VogAPI.Models;

namespace PresentationLayer.Controllers
{
    [Route("/Game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> AddGameToVogLibrary([FromBody] Game game)
        {
            var addedGame = await _gameService.AddGame(game);
            return Ok(addedGame);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            if (games == null || games.Count == 0)
            {
                return NotFound();
            }
            return Ok(games);
        }
    }
}
