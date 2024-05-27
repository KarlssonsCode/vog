using BusinessLogicLayer.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICustomUserListService
    {
        Task<CustomUserList> CreateCustomListAsync(CustomUserList customListRequest);
    }
}
