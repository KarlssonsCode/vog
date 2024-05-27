using System.ComponentModel.DataAnnotations;

namespace VogAPI.Models
{
    public class CustomUserListGame
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ListId { get; set; }
        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
