using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class TechnicianListItemDto
    {
        public required int Id { get; set; }
        public required string FullName { get; set; }
        public required int Document { get; set; }
    }
}
