using System.ComponentModel.DataAnnotations;

namespace VogAPI.Models
{
    public class CustomUserListGame
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CustomUserListId { get; set; }
        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }
        public CustomUserList CustomUserList { get; set; }
    }
}
