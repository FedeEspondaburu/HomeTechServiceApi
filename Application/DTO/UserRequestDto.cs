using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UserRequestDto
    {
        [EmailAddress]
        public string? EMail { get; set; }
        public UserRole? UserRole{ get; set; }
    }
}
