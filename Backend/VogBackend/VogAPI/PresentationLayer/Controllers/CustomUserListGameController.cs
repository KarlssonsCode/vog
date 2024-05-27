using BusinessLogicLayer.Contracts.Requests;
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
        public async Task<IActionResult> AddGameToCustomList(CreateCustomUserListGameRequest customUserListGame)
        {
            await _customUserListGameService.AddGameToCustomListAsync(customUserListGame);
            return Ok();
        }
    }
}
