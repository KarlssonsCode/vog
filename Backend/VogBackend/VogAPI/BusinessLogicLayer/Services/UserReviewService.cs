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

        public UserReviewService(IUserReviewRepository userReviewRepository)
        {
            _userReviewRepository = userReviewRepository;
        }

        public async Task CreateUserReviewAsync(CreateUserReviewRequest userReviewRequest)
        {
            var userReview = new
            {
                userReviewRequest.UserId,
                userReviewRequest.GameId,
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
