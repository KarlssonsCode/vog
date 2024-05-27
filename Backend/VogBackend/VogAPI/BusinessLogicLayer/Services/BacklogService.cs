using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Contracts.Responses;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
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
    public class BacklogService : IBacklogService
    {
        private readonly IBacklogRepository _backlogRepository;
        private readonly IGameService _gameService;
        private readonly ApplicationDbContext _context;

        public BacklogService(IBacklogRepository backlogRepository, IGameService gameService, ApplicationDbContext context)
        {
            _backlogRepository = backlogRepository;
            _gameService = gameService;
            _context = context;
        }

        public async Task AddGameToBacklogAsync(CreateBacklogRequest backlogRequest)
        {

            var game = new Game
            {
                RawgId = backlogRequest.RawgId,
                Title = backlogRequest.RawgTitle,
                BackgroundImage = backlogRequest.BackgroundImage,
                ReleaseDate = backlogRequest.ReleaseDate,
                Description = backlogRequest.Description,
                Metacritic = backlogRequest.Metacritic
            };

            game = await _gameService.AddGame(game);

            var backlog = new
            {
                backlogRequest.UserId,
                GameId = game.Id
            }.Adapt<Backlog>();

            await _backlogRepository.AddGameToBacklogAsync(backlog);


        }

        public async Task<bool> DeleteGameFromBacklog(int backlogId)
        {
            return await _backlogRepository.DeleteGameFromBacklogAsync(backlogId);
        }

        public async Task<IQueryable<GetBacklogResponse>> GetUserBacklogAsync(int userId)
        {
            var response = await _backlogRepository.GetBacklogItemsByUserIdAsync(userId);
            var mappedBacklog = response
                .AsQueryable()
                .ProjectToType<GetBacklogResponse>();

            return mappedBacklog;
        }

    }
}
