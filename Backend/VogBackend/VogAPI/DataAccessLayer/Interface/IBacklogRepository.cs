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
        //Task<Backlog> AddGameToBacklog(Backlog backlog);
        Task AddGameToBacklogAsync(Backlog backlog);
        Task <bool>DeleteGameFromBacklogAsync(int backlogId);
        Task<Backlog> GetUserBacklog(int userId);
    }
}
