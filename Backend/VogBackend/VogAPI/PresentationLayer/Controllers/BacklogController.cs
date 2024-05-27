using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Contracts.Responses;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer.Controllers
{

    [Route("/Backlog")]
    [ApiController]
    public class BacklogController : ControllerBase
    {
        private readonly IBacklogService _backlogService;

        public BacklogController(IBacklogService backlogService)
        {
            _backlogService = backlogService;
        }

        [HttpPost("AddToBackLog")]
        public async Task<IActionResult> AddGameToBacklog(CreateBacklogRequest backlogRequest)
        {
            await _backlogService.AddGameToBacklogAsync(backlogRequest);
            return Ok();
        }

        [HttpDelete]
        [Route("RemoveFromBacklog")]
        public async Task<IActionResult> DeleteGameFromBacklog(int backlogId)
        {
            var result = await _backlogService.DeleteGameFromBacklog(backlogId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


        //[HttpGet]
        //[Route("GetUserBacklog")]
        //public async Task<IActionResult> GetUserBacklog(int userId)
        //{
        //    var backlogResponse = await _backlogService.GetUserBacklogAsync(userId);
        //    var backlogList = await backlogResponse.ToListAsync();
        //    return Ok(backlogList);
        //}

        [HttpGet]
        [Route("GetUserBacklogByUserId")]
        public async Task<ActionResult<ICollection<GetBacklogResponse>>> GetUserBacklog(int userId)
        {
            var response = await _backlogService.GetUserBacklogAsync(userId);
            return Ok(response);
        }



    }
}
