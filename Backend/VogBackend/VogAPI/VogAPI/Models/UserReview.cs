namespace VogAPI.Models
{
    public class UserReview
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ReviewText { get; set; }
        public string Score { get; set; }
        public int GameId { get; set; }
    }
}
