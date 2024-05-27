using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace DataAccessLayer.Interface
{
    public interface ICustomUserListGameRepository
    {
        Task AddGameToCustomListAsync(CustomUserListGame game);
    }
}
