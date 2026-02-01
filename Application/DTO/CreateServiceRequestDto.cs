using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CreateServiceRequestDto
    {
        [Required]
        public required RequestType RequestType { get; set; }
        [Required]
        public required string Observations { get; set; }
        [Required]
        public required DateTime ScheduledAt { get; set; }
        [Required]
        public required string ClientEmail { get; set; }
    }
}
