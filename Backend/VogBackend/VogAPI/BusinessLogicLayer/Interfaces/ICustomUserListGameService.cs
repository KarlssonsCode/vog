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
    public interface ICustomUserListGameService
    {
        Task AddGameToCustomListAsync(CreateCustomUserListGameRequest customUserListGame);
        Task<IQueryable<GetCustomUserListGameResponse>> GetCustomUserListGamesByListIdAsync(int customUserListId);
    }
}
