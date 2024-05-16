using System.ComponentModel;

namespace VogAPI.Models
{
    public class CustomUserList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
