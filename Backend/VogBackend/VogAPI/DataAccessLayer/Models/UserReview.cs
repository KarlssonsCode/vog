using System.ComponentModel.DataAnnotations;

namespace VogAPI.Models
{
    public class UserReview
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string? ReviewText { get; set; }
        [Required]
        public string Score { get; set; }
        [Required]
        public int GameId { get; set; }
    }
}
