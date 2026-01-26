using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class LoginResponseDto
    {
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
        public required bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
