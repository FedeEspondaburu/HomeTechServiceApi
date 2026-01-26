using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CreateServiceRequestDto
    {
        [Required]
        public required int RequestTypeId { get; set; }
        public string? Observation { get; set; }
        [Required]
        public required DateTime ScheduledAt { get; set; }
        [Required]
        public required string CreatedBy { get; set; }
        [Required]
        public required string ClientEmail { get; set; }
    }
}
