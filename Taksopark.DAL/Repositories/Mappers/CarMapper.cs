using System;
using System.Data;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Mappers
{
    static class CarMapper
    {
        public static Car Map(IDataRecord record)
        {
            var car = new Car
            {
                Id = (int)record["Id"],
                CarBrand = (string)record["Brand"],
                CarYear = (string)record["Year"],
                StartWorkTime = (DateTime)record["StartWorkTime"],
                FinishWorkTime = (DateTime)record["FinishWorkTime"],
                Location = (string)record["Location"]
            };
            return car;
        }
    }
}
