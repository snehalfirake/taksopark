using System.Collections.Generic;
using System.Data.SqlClient;
using Taksopark.DAL.Models;
using Taksopark.DAL.Repositories.Interfases;
using Taksopark.DAL.Repositories.Mappers;

namespace Taksopark.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly SqlConnection _connection;

        public CarRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Update Car record
        /// </summary>
        /// <param name="car">Car model</param>
        public void Update(Car car)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE Cars SET Brand = @brand, "
                                      + "Year = @year, "
                                      + "StartWorkTime = @startWorkTime, "
                                      + "FinishWorkTime = @finishWorkTime, "
                                      + "Location = @location "
                                      + "WHERE Id = @userId";
                command.Parameters.AddWithValue("brand", car.CarBrand);
                command.Parameters.AddWithValue("year", car.CarYear);
                command.Parameters.AddWithValue("startWorkTime", car.StartWorkTime);
                command.Parameters.AddWithValue("finishWorkTime", car.FinishWorkTime);
                command.Parameters.AddWithValue("location", car.Location);
                command.Parameters.AddWithValue("userId", car.Id);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create new car record
        /// </summary>
        /// <param name="car">Car model</param>
        public void Create(Car car)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Cars (Brand, Year, StartWorkTime, FinishWorkTime, Location) "
                                      + "VALUES(@brand, @year, @startWorkTime, @finishWorkTime, @location)";
                command.Parameters.AddWithValue("brand", car.CarBrand);
                command.Parameters.AddWithValue("year", car.CarYear);
                command.Parameters.AddWithValue("startWorkTime", car.StartWorkTime);
                command.Parameters.AddWithValue("finishWorkTime", car.FinishWorkTime);
                command.Parameters.AddWithValue("location", car.Location);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get all car records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Car> GetAllCars()
        {
            using (var command = _connection.CreateCommand())
            {
                var carsList = new List<Car>();
                command.CommandText = "SELECT * FROM Cars";
               
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var car = CarMapper.Map(reader);
                        carsList.Add(car);
                    }
                }
                return carsList;
            }
        }

        /// <summary>
        /// Delete car record from DB
        /// </summary>
        /// <param name="carId">Car id in DB</param>
        public void DeleteCar(int carId)
        {

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Cars WHERE ID = @carId";
                command.Parameters.AddWithValue("carId", carId);
                command.ExecuteNonQuery();
            }
        }
    }
}
