using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Direction { get; set; }
        [Required]
        public required int PostalCode { get; set; }
        [Required]
        public required string City { get; set; }
        [Required]
        public required string Province { get; set; }
    }
}
