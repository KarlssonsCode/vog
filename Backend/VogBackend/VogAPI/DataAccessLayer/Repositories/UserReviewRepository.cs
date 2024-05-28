using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace DataAccessLayer.Repositories
{
    public class UserReviewRepository : IUserReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public UserReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserReview> CreateUserReviewAsync(UserReview userReview)
        {
            var existingGameReview = await _context.UserReviews.FirstOrDefaultAsync(g => g.GameId == userReview.GameId && g.UserId == userReview.UserId);
            if (existingGameReview != null)
            {
                return existingGameReview;
            }

            _context.UserReviews.Add(userReview);
            await _context.SaveChangesAsync();
            return userReview;
        }

        public async Task<ICollection<UserReview>> GetUserReviewsByUserIdAsync(int userId)
        {
            return await _context.UserReviews
             .Where(b => b.UserId == userId)
             .Include(b => b.Game)
             .Include(u => u.User)
             .AsNoTracking()
             .ToListAsync();
        }
    }
}
