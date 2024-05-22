namespace VogAPI.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int RawgId { get; set; }
        public string Title { get; set; }
        public string? BackgroundImage { get; set; }
        public string? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public int? Metacritic {  get; set; }

    }
}
