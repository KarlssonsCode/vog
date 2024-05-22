namespace VogAPI.Models
{
    public class Backlog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }

    }
}
