using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Contracts.Requests
{
    public class CreateCustomUserListGameRequest
    {
        [Required]
        public int ListId { get; set; }
        [Required]
        public int GameId { get; set; }
    }
}
