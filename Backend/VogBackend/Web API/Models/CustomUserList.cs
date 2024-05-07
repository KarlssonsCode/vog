namespace Web_API.Models
{
    public class CustomUserList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set; }
        public bool Private { get; set; }
    }
}
