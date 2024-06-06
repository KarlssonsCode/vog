using BusinessLogicLayer.Contracts.Responses;
using BusinessLogicLayer.Interfaces;
using VogAPI.Models;
using DataAccessLayer.Interface;
using BusinessLogicLayer.Contracts.Requests;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<GetUserResponse> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return new GetUserResponse
            {
                Id = user.Id,
                Username = user.Username,
            };
        }

        public async Task<(bool, string)> IsUsernameOrEmailInUseAsync(string username, string email)
        {
            if (await _userRepository.GetUserByUsernameAsync(username) != null)
            {
                return (true, "Username is already in use.");
            }

            if (await _userRepository.GetUserByEmailAsync(email) != null)
            {
                return (true, "Email is already in use.");
            }

            return (false, null);
        }

        public async Task<User> CreateUserAsync(CreateUserRequest user)
        {
            var (inUse, message) = await IsUsernameOrEmailInUseAsync(user.Username, user.Email);

            if (inUse)
            {
                throw new InvalidOperationException(message);
            }

            User newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
            };

            return await _userRepository.CreateUserAsync(newUser);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<GetUserResponse> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(email, password);
            if (user == null)
            {
                return null;
            }

            return new GetUserResponse
            {
                Id = user.Id,
                Username = user.Username,
            };
        }
    }
}
