using System.ComponentModel.DataAnnotations;

namespace VogAPI.Models
{
    public class UserReview
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public string? ReviewText { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
