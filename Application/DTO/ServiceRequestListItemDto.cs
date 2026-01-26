using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ServiceRequestListItemDto
    {
        public required int Id { get; set; }
        public required string Status { get; set; }
        public required string ClientName { get; set; }
        public string? TechnicianName { get; set; }
        public required DateTime ScheduledAt { get; set; }
    }
}
