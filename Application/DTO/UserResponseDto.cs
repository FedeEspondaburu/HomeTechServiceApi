using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UserResponseDto
    {
        public required int Id { get; set; }
        public required string FullName { get; set; }
        public required string EMail { get; set; }
        public required string RoleName { get; set; }
        public required int Document { get; set; }
    }
}
