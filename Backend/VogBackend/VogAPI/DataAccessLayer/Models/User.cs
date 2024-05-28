using System.ComponentModel.DataAnnotations;

namespace VogAPI.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        public ICollection<CustomUserList> CustomUserLists { get; set; }
    }
}
