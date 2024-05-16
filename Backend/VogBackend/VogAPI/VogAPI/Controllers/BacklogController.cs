using Microsoft.AspNetCore.Mvc;
using VogAPI.DAL;
using VogAPI.Models;

namespace VogAPI.Controllers
{
    [Route("/Backlog")]
    [ApiController]
    public class BacklogController : ControllerBase
    {
        private readonly BacklogRepository _backlogRepository;

        public BacklogController (BacklogRepository backlogRepository)
        {
            _backlogRepository = backlogRepository;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddGameToBacklog(int userId, int rawgId, string rawgTitle, string backgroundImage, string releaseDate, string description, int? metacritic)
        {
            await _backlogRepository.AddGameToBacklogAsync(userId, rawgId, rawgTitle, backgroundImage, releaseDate, description, metacritic);
            return Ok();
        }

        [HttpDelete]
        [Route("Remove")]
        public IActionResult DeleteGameFromBacklog(int backlogId) 
        {
            _backlogRepository.RemoveGameFromBacklog(backlogId);
            return Ok();
        }

        [HttpGet]
        [Route("GetUserBacklog")]
        public async Task<IActionResult> GetUserBacklog(int userId)
        {
            var backlogGames = await _backlogRepository.GetUserBacklogGames(userId);
            return Ok(backlogGames);
        }
    }
}
