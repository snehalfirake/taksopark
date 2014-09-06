using System.Data;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Mappers
{
    static class ImageMapper
    {
        public static Images Map(IDataRecord record)
        {
            var image = new Images
            {
                Id = (int)record["Id"],
                PhotoImage = (byte[])record["Photo"],
                OwnerId = (int)record["OwnerId"],
                CarId = (int)record["CarId"]   
            };
            return image;
        }
    }
}
