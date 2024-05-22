using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBacklogService
    {
        //Task<Backlog> AddGameToBacklog(int userId, int rawgId, string rawgTitle, string backgroundImage, string releaseDate, string description, int? metacritic);
        Task AddGameToBacklogAsync(CreateBacklogRequest backlogRequest);
        Task <bool>DeleteGameFromBacklog(int backlogId);
        //Task<GetBacklogResponse> GetUserBacklog(int userId);
    }
}
