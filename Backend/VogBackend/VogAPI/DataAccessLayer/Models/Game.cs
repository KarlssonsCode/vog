using System.ComponentModel.DataAnnotations;

namespace VogAPI.Models
{
    public class Game
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RawgId { get; set; }
        [Required]
        public string Title { get; set; }
        public string? BackgroundImage { get; set; }
        public string? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public int? Metacritic {  get; set; }
        public ICollection<Backlog>? BacklogGames { get; set; }

    }
}
