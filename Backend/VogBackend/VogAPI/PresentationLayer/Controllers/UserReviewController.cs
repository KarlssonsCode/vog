using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Contracts.Responses;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/UserReview")]
    [ApiController]
    public class UserReviewController : ControllerBase
    {
        private readonly IUserReviewService _userReviewService;

        public UserReviewController(IUserReviewService userReviewService)
        {
            _userReviewService = userReviewService;
        }

        [HttpPost("CreateUserReview")]
        public async Task <IActionResult> CreateUserReview(CreateUserReviewRequest userReviewRequest)
        {
            await _userReviewService.CreateUserReviewAsync(userReviewRequest);
            return Ok(userReviewRequest); 
        }

        [HttpGet("GetUserReviewsByUserId")]
        public async Task<ActionResult<ICollection<GetUserReviewResponse>>> GetUserReviewsByUserId(int userId)
        {
            var userReviews = await _userReviewService.GetUserReviewsByUserIdAsync(userId);
            return Ok(userReviews);
        }
    }
}
