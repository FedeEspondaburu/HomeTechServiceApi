using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ChangeStatusDto
    {
        [Required]
        public required RequestStatus Status { get; set; }
        public string? Reason { get; set; }
    }
}
