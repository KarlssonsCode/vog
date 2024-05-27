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

        Task AddGameToBacklogAsync(CreateBacklogRequest backlogRequest);
        Task <bool>DeleteGameFromBacklog(int backlogId);
        Task<IQueryable<GetBacklogResponse>> GetUserBacklogAsync(int userId);
    }
}
