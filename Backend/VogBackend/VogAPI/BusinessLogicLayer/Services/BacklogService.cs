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

        //public async Task<CreateBacklogRequest> AddGameToBacklog(int userId, int rawgId, string rawgTitle, string backgroundImage, string releaseDate, string description, int? metacritic)
        //{
        //    var backlog = new
        //    {
        //        UserId = userId,
        //        RawgId = rawgId,
        //        RawgTitle = rawgTitle,
        //        BackgroundImage = backgroundImage,
        //        ReleaseDate = releaseDate,
        //        Description = description,
        //        Metacritic = metacritic
        //    }.Adapt<Backlog>();

        //    await _backlogRepository.AddGameToBacklog(backlog);
        //    return backlog;
        //}

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

        //public Task<GetBacklogResponse> GetUserBacklog(int userId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
