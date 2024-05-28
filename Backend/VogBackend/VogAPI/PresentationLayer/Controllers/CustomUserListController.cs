using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Contracts.Responses;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> CreateCustomList(CreateCustomUserListRequest customUserListRequest)
        {
            await _customUserListService.CreateCustomListAsync(customUserListRequest);
            return Ok(customUserListRequest);
        }


        [HttpGet("GetCustomUserListsById")]
        public async Task<ActionResult<ICollection<GetCustomUserListResponse>>> GetCustomUserLists(int userId)
        {
            var customLists = await _customUserListService.GetCustomUserListsByUserIdAsync(userId);
            return Ok(customLists);
        }
    }
}
