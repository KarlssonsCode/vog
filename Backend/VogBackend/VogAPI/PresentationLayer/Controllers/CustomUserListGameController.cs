using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Contracts.Responses;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using VogAPI.Models;

namespace PresentationLayer.Controllers
{
    [Route("/CustomUserListGame")]
    [ApiController]
    public class CustomUserListGameController : ControllerBase
    {
        private readonly ICustomUserListGameService _customUserListGameService;
        public CustomUserListGameController(ICustomUserListGameService customUserListGameService)
        {
            _customUserListGameService = customUserListGameService;
        }

        [HttpPost("AddGameToCustomList")]
        public async Task<IActionResult> AddGameToCustomList(CreateCustomUserListGameRequest customUserListGameRequest)
        {
            await _customUserListGameService.AddGameToCustomListAsync(customUserListGameRequest);
            return Ok();
        }

        [HttpGet("GetCustomUserListGamesByListId")]
        public async Task<ActionResult<ICollection<GetCustomUserListGameResponse>>> GetCustomUserListGamesByListId(int customUserListId)
        {
            var customListGames = await _customUserListGameService.GetCustomUserListGamesByListIdAsync(customUserListId);
            return Ok(customListGames);
        }

    }
}
