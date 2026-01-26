using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ServiceRequestResponseDto
    {
        public required int Id { get; set; }
        public required string RequestType { get; set; }
        public required string Status { get; set; }

        public required DateTime CreationTime { get; set; }
        public required DateTime ScheduledAt { get; set; }

        public  required string ClientName { get; set; }
        public string? TechnicianName { get; set; }

        public string? Observation { get; set; }
    }
}
