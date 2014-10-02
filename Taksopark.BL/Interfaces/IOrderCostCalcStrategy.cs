using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taksopark.BL.Interfaces
{
    public interface IOrderCostCalcStrategy
    {
        decimal CalcCost(decimal distance, bool isTracking, decimal? animalWeight, bool isHaulage);
    }
}
