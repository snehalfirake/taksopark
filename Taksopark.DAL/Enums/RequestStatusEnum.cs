using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taksopark.DAL.Enums
{
    public enum RequestStatusEnum
    {
        Active = 2,
        InProgress = 4,
        Closed = 8,
        Rejected = 32
    };
}
