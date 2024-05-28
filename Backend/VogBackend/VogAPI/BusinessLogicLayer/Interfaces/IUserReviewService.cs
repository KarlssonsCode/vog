using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserReviewService
    {
        Task CreateUserReviewAsync(CreateUserReviewRequest userReview);
        Task<IQueryable<GetUserReviewResponse>> GetUserReviewsByUserIdAsync(int userId);
    }
}
