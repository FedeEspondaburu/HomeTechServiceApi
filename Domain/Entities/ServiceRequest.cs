using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class ServiceRequest
    {
        [Key]
        public int Id { get; set; }
      
        public required RequestType RequestType { get; set; }
      
        public required User CreatedByUser { get; set; }
      
        public required RequestStatus Status { get; set; }
      
        public required DateTime CreationTime { get; set; }
        public string? Observation { get; set; }
        public User? Technician { get; set; }
      
        public required DateTime ScheduledAt { get; set; }
    }
}
