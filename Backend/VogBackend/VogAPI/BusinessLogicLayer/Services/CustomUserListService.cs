using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interface;
using Mapster;
using VogAPI.Models;

namespace BusinessLogicLayer.Services
{
    public class CustomUserListService : ICustomUserListService
    {
        private readonly ICustomUserListRepository _customUserListRepository;

        public CustomUserListService(ICustomUserListRepository customUserListRepository)
        {
            _customUserListRepository = customUserListRepository;
        }

        public async Task<CustomUserList> CreateCustomListAsync(CustomUserList customUserListRequest)
        {
            return await _customUserListRepository.CreateCustomListAsync(customUserListRequest);
        }

    }
}
