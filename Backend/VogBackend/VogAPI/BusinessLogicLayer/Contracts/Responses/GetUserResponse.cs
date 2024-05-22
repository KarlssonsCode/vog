using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Contracts.Responses
{
    public class GetUserResponse
    {
        [Required] public int Id { get; set; }
        [Required] public string Username { get; set; }      
    }
}
