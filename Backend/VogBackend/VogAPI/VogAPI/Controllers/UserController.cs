using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using VogAPI.DAL;
using VogAPI.Models;


namespace VogAPI.Controllers
{
    [Route("/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository context)
        {
            _userRepository = context;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _userRepository.AddUser(user);
            return Ok();
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            if (users == null || users.Count == 0)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPut("{userId}/ChangeUsername")]
        public IActionResult ChangeUsername(int userId, [FromBody] string newUsername)
        {
            _userRepository.UpdateUsername(userId, newUsername);
            return Ok();
        }

    }
}
