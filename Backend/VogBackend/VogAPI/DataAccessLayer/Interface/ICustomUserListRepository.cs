using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace DataAccessLayer.Interface
{
    public interface ICustomUserListRepository
    {
        Task CreateCustomListAsync(CustomUserList customUserList);
        Task<ICollection<CustomUserList>> GetCustomUserListsByUserIdAsync(int userId);
    }
}
