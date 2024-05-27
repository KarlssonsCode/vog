using System.ComponentModel.DataAnnotations;

namespace VogAPI.Models
{
    public class Backlog
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required] 
        public User User { get; set; }

        [Required]
        public int GameId { get; set; }

        public Game Game { get; set; }

    }
}
