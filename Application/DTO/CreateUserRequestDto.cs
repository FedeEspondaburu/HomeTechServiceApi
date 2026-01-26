using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CreateUserRequestDto
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required int Document { get; set; }
        [Required, EmailAddress]
        public required string EMail { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required int Phone { get; set; }
        [Required]
        public required UserRole Role { get; set; }

        // Address
        public string? Direction { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public int? PostalCode { get; set; }
    }
}
