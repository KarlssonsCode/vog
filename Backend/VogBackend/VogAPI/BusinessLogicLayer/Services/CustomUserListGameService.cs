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
        private readonly IGameService _gameService;

        public CustomUserListGameService(ICustomUserListGameRepository customUserListGameRepository, IGameService gameService)
        {
            _customUserListGameRepository = customUserListGameRepository;
            _gameService = gameService;
        }

        public async Task AddGameToCustomListAsync(CreateCustomUserListGameRequest customUserListGame)
        {
            var game = new Game
            {
                RawgId = customUserListGame.RawgId,
                Title = customUserListGame.RawgTitle,
                BackgroundImage = customUserListGame.BackgroundImage,
                ReleaseDate = customUserListGame.ReleaseDate,
                Description = customUserListGame.Description,
                Metacritic = customUserListGame.Metacritic
            };

            game = await _gameService.AddGame(game);

            var customListGame = new
            {
                customUserListGame.CustomUserListId,
                GameId = game.Id
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
