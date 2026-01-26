using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class LoginRequestDto
    {
        [Required, EmailAddress]
        public required string EMail { get; set; }

        [Required, DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
