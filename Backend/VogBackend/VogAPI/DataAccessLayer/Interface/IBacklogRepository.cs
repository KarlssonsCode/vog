using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace DataAccessLayer.Interface
{
    public interface IBacklogRepository
    {
        Task AddGameToBacklogAsync(Backlog backlog);
        Task <bool>DeleteGameFromBacklogAsync(int backlogId);
        Task<ICollection<Backlog>> GetBacklogItemsByUserIdAsync(int userId);
    }
}

