using System;
using System.Data;
using System.Data.SqlClient;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Mappers
{
    static class CarMapper
    {
        public static Car Map(SqlDataReader record)
        {
            if (record == null) throw new ArgumentNullException("record");
            var car = new Car
            {
                Id = (int)record["Id"],
                CarBrand = (string)record["Brand"],
                CarYear = (string)record["Year"],
                StartWorkTime = (DateTime)record["StartWorkTime"],
                FinishWorkTime = (DateTime)record["FinishWorkTime"],
                Latitude = (string)record["Latitude"],
                Longitude = (string)record["Longitude"]
            };
            return car;
        }
    }
}
