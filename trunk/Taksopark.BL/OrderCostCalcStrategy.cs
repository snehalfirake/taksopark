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
        public const decimal ORDER_COST = 15m;
        public const decimal MIN_DISTANCE = 2m;
        public const decimal MIN_DISTANCE_COST = 3m;
        public const decimal ONE_KILOMETER_COST = 3m;
        public const decimal TRACKING_COEFFICIENT = 2m;
        public const decimal AVERAGE_ANIMAL_WEIGHT = 20m;
        public const decimal MIN_ANIMAL_WEIGHT_COST = 30m;
        public const decimal MAX_ANIMAL_WEIGHT_COST = 50m;
        public const decimal ONE_KILOMETER_HAULAGE_COST = 30m;

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
                cost = (ONE_KILOMETER_COST * distance) + ORDER_COST;
            }
            if (isTracking == true)
            {
                cost *= TRACKING_COEFFICIENT;
            }
            if (animalWeight.HasValue)
            {
                if (animalWeight.Value < AVERAGE_ANIMAL_WEIGHT)
                {
                    cost += MIN_ANIMAL_WEIGHT_COST;
                }
                else
                {
                    cost += MAX_ANIMAL_WEIGHT_COST;
                }
            }
            if (isHaulage == true)
            {
                cost = (ONE_KILOMETER_HAULAGE_COST * distance) + ORDER_COST;
            }
            return cost;
        }
    }
}
