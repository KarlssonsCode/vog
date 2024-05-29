using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Contracts.Responses;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interface;
using DataAccessLayer.Repositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace BusinessLogicLayer.Services
{
    public class CustomUserListGameService : ICustomUserListGameService
    {
        private readonly ICustomUserListGameRepository _customUserListGameRepository;

        public CustomUserListGameService(ICustomUserListGameRepository customUserListGameRepository)
        {
            _customUserListGameRepository = customUserListGameRepository;
        }

        public async Task AddGameToCustomListAsync(CreateCustomUserListGameRequest customUserListGame)
        {
            var customListGame = new
            {
                customUserListGame.CustomUserListId,
                customUserListGame.GameId
            }.Adapt<CustomUserListGame>();

            await _customUserListGameRepository.AddGameToCustomListAsync(customListGame);
        }

        public async Task<IQueryable<GetCustomUserListGameResponse>> GetCustomUserListGamesByListIdAsync(int listId)
        {
            var response = await _customUserListGameRepository.GetCustomUserListGamesByListIdAsync(listId);
            var mappedCustomListGames = response.AsQueryable().ProjectToType<GetCustomUserListGameResponse>();
            
            return mappedCustomListGames;
        }
    }
}
