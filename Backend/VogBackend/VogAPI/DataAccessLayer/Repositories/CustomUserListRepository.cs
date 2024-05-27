using DataAccessLayer.Interface;
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
        public async Task<CustomUserList> CreateCustomListAsync(CustomUserList customUserList)
        {
            _context.CustomUserLists.Add(customUserList);
            await _context.SaveChangesAsync();
            return customUserList;
        }
    }
}
