
using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Interfases
{
    interface IImageRepository
    {
        void Update(Images image);
        void Create(Images image);
        IEnumerable<Images> GetAllImages();
    }
}
