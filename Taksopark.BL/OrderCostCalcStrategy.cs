using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taksopark.BL.Interfaces;

namespace Taksopark.BL
{
    public class OrderCostCalcStrategy : IOrderCostCalcStrategy
    {
        private const decimal ORDER_COST = 15m;
        private const decimal MIN_DISTANCE = 2m;
        private const decimal MIN_DISTANCE_COST = 3m;

        public decimal CalcCost(decimal distance, bool isTracking, decimal? animalWeight, bool isHaulage)
        {
            #region Validation

            if (distance <= 0)
            {
                throw new ArgumentException("'Distance' has to be > 0");
            }
            if (animalWeight.HasValue && (animalWeight.Value <= 0 || animalWeight.Value > 70))
            {
                throw new ArgumentException("Animal weight has to be > 0 and <= 70");
            }
            if ((isTracking && animalWeight.HasValue) || (isTracking && isHaulage) || 
                (animalWeight.HasValue && isHaulage))
            {
                throw new ArgumentException("Only one additional parameter may be defined");
            }

            #endregion

            decimal cost;
            if (distance < MIN_DISTANCE)
            {
                cost = MIN_DISTANCE_COST + ORDER_COST;
            }
            else
            {
                cost = (3 * distance) + ORDER_COST;
            }
            if (isTracking == true)
            {
                cost *= 2;
            }
            if (animalWeight.HasValue)
            {
                if (animalWeight.Value < 20)
                {
                    cost += 30;
                }
                else
                {
                    cost += 50;
                }
            }
            if (isHaulage == true)
            {
                cost = (30 * distance) + ORDER_COST;
            }

            return cost;
        }
    }
}
