using Microsoft.EntityFrameworkCore;
using VogAPI.Data;
using VogAPI.Models;

namespace VogAPI.DAL
{
    public class UserRepository
    {
        private readonly VogAPIContext _context;

        public UserRepository(VogAPIContext context) 
        {
            _context = context; 
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> users = await _context.Users.ToListAsync();

            return users;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }


        public void UpdateUsername(int userId, string newUsername) 
        {
           var user = _context.Users.FirstOrDefault(u =>u.Id == userId);
            if (user != null)
            {
                user.Username = newUsername;
                _context.SaveChanges();
            }
        }
        //public static implicit operator UserRepository(VogAPIContext context)
        //{
        //    return new UserRepository(context);
        //}

    }
}
