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
        private const decimal MIN_DISTANSE = 2m;
        private const decimal MIN_DISTANSE_COST = 3m;

        public decimal CalcCost(decimal distance, bool isTracking, decimal? animalWeight, bool isHaulage)
        {

            #region Validatioin

            if (distance <= 0)
            {
                throw new ArgumentException("'Distance' has to be > 0");
            }
            if (animalWeight.HasValue && (animalWeight.Value <= 0 || animalWeight.Value > 70))
            {
                throw new ArgumentException("Animal weight has to be > 0 and <= 70");
            } 

            #endregion

            decimal cost;
            if (distance < MIN_DISTANSE)
            {
                cost = MIN_DISTANSE_COST + ORDER_COST;
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

            return cost;
        }
    }
}
