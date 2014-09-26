using System.Collections.Generic;
using System.Data;
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
            using (var command = new SqlCommand("sp_UpdateCar", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Brand", car.CarBrand);
                command.Parameters.AddWithValue("@Year", car.CarYear);
                command.Parameters.AddWithValue("@StartWorkTime", car.StartWorkTime);
                command.Parameters.AddWithValue("@FinishWorkTime", car.FinishWorkTime);
                command.Parameters.AddWithValue("@Latitude", car.Latitude);
                command.Parameters.AddWithValue("@Longitude", car.Longitude);
                command.Parameters.AddWithValue("@CarId", car.Id);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create new car record
        /// </summary>
        /// <param name="car">Car model</param>
        public void Create(Car car)
        {
            using (var command = new SqlCommand("sp_CreateCar", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Brand", car.CarBrand);
                command.Parameters.AddWithValue("@Year", car.CarYear);
                command.Parameters.AddWithValue("@StartWorkTime", car.StartWorkTime);
                command.Parameters.AddWithValue("@FinishWorkTime", car.FinishWorkTime);
                command.Parameters.AddWithValue("@Latitude", car.Latitude);
                command.Parameters.AddWithValue("@Longitude", car.Longitude);
                command.Parameters.AddWithValue("@CarId", car.Id);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get all car records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Car> GetAllCars()
        {
            using (var command = new SqlCommand("sp_GetAllCars", _connection))
            {
                var carsList = new List<Car>();
                command.CommandType = CommandType.StoredProcedure;
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
        /// Get car by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetCarById(int id)
        {
            using (var command = new SqlCommand("GetCarById", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                var findCar = new Car();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var car = CarMapper.Map(reader);
                        findCar = car;
                    }
                }
                return findCar;
            }
        }


        public bool IsCarIdBooked(int id)
        {
            using (var command = new SqlCommand("GetCarById", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                var car = new Car();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        car = CarMapper.Map(reader);
                    }
                }
                if (car.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
