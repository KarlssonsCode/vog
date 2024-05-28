using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace DataAccessLayer.Repositories
{
    public class CustomUserListRepository : ICustomUserListRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomUserListRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateCustomListAsync(CustomUserList customUserList)
        {
            _context.CustomUserLists.Add(customUserList);
            await _context.SaveChangesAsync();           
        }
        public async Task<ICollection<CustomUserList>> GetCustomUserListsByUserIdAsync(int userId)
        {
            return await _context.CustomUserLists
                .Include(list => list.User)
                .Where(list => list.UserId == userId)
                .ToListAsync();
        }


    }
}
