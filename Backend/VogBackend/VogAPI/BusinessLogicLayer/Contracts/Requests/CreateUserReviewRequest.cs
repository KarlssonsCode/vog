using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace BusinessLogicLayer.Contracts.Requests
{
    public class CreateUserReviewRequest
    {
        [Required]
        public int UserId { get; set; }
        public string? ReviewText { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public int GameId { get; set; }
    }
}
