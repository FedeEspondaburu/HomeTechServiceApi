using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum RequestStatus
    {
        New = 1,
        InProgress = 2,
        Finished = 3,
        Cancelled = 4
    }
}
