using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VogAPI.Models
{
    public class CustomUserList
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        public User User { get; set; }

    }
}
