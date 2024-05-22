using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Contracts.Responses
{
    public class GetBacklogResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string? BackgroundImage { get; set; }

        [Required]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public int? Metacritic { get; set; }

    }
}
