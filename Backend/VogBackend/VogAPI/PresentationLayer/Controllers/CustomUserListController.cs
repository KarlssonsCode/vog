using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using VogAPI.Models;

namespace PresentationLayer.Controllers
{
    [Route("/CustomUserList")]
    [ApiController]
    public class CustomUserListController : ControllerBase
    {
        private readonly ICustomUserListService _customUserListService;

        public CustomUserListController(ICustomUserListService customUserListService)
        {
            _customUserListService = customUserListService;
        }

        [HttpPost("CreateCustomList")]
        public async Task<IActionResult> CreateCustomList(CustomUserList customUserList)
        {
            var createdList = await _customUserListService.CreateCustomListAsync(customUserList);
            return Ok(createdList);
        }
    }
}
