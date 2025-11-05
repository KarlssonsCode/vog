using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using VogAPI.Models;

namespace DataAccessLayer.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
      return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
      return await _context.Users.FindAsync(id);
    }

    public async Task<User> CreateUserAsync(User user)
    {
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
      return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
      _context.Entry(user).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return user;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
      var user = await _context.Users.FindAsync(id);
      if (user == null)
      {
        return false;
      }

      _context.Users.Remove(user);
      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
    {
      return await _context.Users.SingleOrDefaultAsync(u =>
        u.Email == email && u.Password == password
      );
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
      return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
      return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
    }
  }
}
