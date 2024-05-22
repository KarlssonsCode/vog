using Microsoft.EntityFrameworkCore;
using VogAPI.Models;


namespace DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Backlog> Backlogs { get; set; }
        public DbSet<CustomUserList> CustomUserLists { get; set; }
        public DbSet<CustomUserListGame> CustomUserListGames { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
    }
}
