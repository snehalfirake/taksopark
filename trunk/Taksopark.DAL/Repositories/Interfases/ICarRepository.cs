using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Interfases
{
    interface ICarRepository
    {
        void Update(Car car);
        void Create(Car car);
        IEnumerable<Car> GetAllCars();
    }
}
