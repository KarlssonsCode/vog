using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Contracts.Responses;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interface;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Collections;
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

        public async Task CreateCustomListAsync(CreateCustomUserListRequest customUserListRequest)
        {
            var customList = new
            {
                customUserListRequest.UserId,
                customUserListRequest.Name,
                customUserListRequest.Description
            }.Adapt<CustomUserList>();

            await _customUserListRepository.CreateCustomListAsync(customList);
        }

        public async Task<IQueryable<GetCustomUserListResponse>> GetCustomUserListsByUserIdAsync(int userId)
        {

            var customListsQuery = await _customUserListRepository.GetCustomUserListsByUserIdAsync(userId);


            var response = customListsQuery.Select(list => new GetCustomUserListResponse
            {
                Id = list.Id,
                Name = list.Name,
                Description = list.Description,
                Username = list.User.Username
            }).ToList();

            return response.AsQueryable();
        }
    }
}
