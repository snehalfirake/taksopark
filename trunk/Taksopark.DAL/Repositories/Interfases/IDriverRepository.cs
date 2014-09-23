using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Interfases
{
    interface IDriverRepository
    {
        IEnumerable<Driver> GetAllDrivers();
        IEnumerable<Driver> GetAllDriversByStatus(string status);
    }
}
