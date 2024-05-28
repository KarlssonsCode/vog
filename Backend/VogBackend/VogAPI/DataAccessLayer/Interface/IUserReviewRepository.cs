using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace DataAccessLayer.Interface
{
    public interface IUserReviewRepository
    {
        Task<UserReview> CreateUserReviewAsync(UserReview userReview);
        Task<ICollection<UserReview>> GetUserReviewsByUserIdAsync(int userId);
    }
}
