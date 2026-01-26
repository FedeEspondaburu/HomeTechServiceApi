using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required int Document { get; set; }
        [Required]
        public required string EMail { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
        public required UserRole Role { get; set; }
        public Address? Address { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
