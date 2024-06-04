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
    public class UserReviewService : IUserReviewService
    {
        private readonly IUserReviewRepository _userReviewRepository;
        private readonly IGameService _gameService;

        public UserReviewService(IUserReviewRepository userReviewRepository, IGameService gameService)
        {
            _userReviewRepository = userReviewRepository;
            _gameService = gameService;
        }

        public async Task CreateUserReviewAsync(CreateUserReviewRequest userReviewRequest)
        {
            var game = new Game
            {
                RawgId = userReviewRequest.RawgId,
                Title = userReviewRequest.RawgTitle,
                BackgroundImage = userReviewRequest.BackgroundImage,
                ReleaseDate = userReviewRequest.ReleaseDate,
                Description = userReviewRequest.Description,
                Metacritic = userReviewRequest.Metacritic
            };

            game = await _gameService.AddGame(game);

            var userReview = new
            {
                userReviewRequest.UserId,
                GameId = game.Id,
                userReviewRequest.ReviewText,
                userReviewRequest.Score
            }.Adapt<UserReview>();
            await _userReviewRepository.CreateUserReviewAsync(userReview);
        }

        public async Task<IQueryable<GetUserReviewResponse>> GetUserReviewsByUserIdAsync(int userId)
        {
            var response = await _userReviewRepository.GetUserReviewsByUserIdAsync(userId);
            var mappedUserReviews = response
                .AsQueryable()
                .ProjectToType<GetUserReviewResponse>();

            return mappedUserReviews;
        }
    }
}
