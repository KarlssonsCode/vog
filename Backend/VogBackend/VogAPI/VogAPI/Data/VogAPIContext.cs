using Microsoft.EntityFrameworkCore;
using VogAPI.Models;

namespace VogAPI.Data
{
    public class VogAPIContext : DbContext
    {
        public VogAPIContext(DbContextOptions<VogAPIContext> options) : base(options) { }

        public DbSet<Backlog> Backlogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CustomUserList> CustomUserLists { get; set; }
        public DbSet<CustomUserListGame> CustomUserGameLists { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
