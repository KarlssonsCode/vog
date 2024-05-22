using BusinessLogicLayer.Contracts.Responses;
using BusinessLogicLayer.Interfaces;
using VogAPI.Models;
using DataAccessLayer.Interface;

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

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepository.CreateUserAsync(user);
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
