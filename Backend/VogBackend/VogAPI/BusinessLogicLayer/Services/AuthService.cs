using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using DataAccessLayer.Repositories;
using VogAPI.Models;

namespace BusinessLogicLayer.Services
{
  public class AuthService
  {
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<User> ValidateUserAsync(string userName, string password)
    {
      var user = await _userRepository.GetUserByUsernameAsync(userName);
      if (user == null)
      {
        return null;
      }
      return user.Password == password ? user : null;
    }
  }
}
