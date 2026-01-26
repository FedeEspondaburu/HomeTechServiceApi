using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum UserRole
    {
        Administrator = 1,
        Client = 2,
        Operator = 3,
        Technician = 4
    }
}
