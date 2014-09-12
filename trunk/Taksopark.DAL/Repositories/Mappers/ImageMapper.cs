using System;
using System.Data;
using System.Data.SqlClient;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Mappers
{
    static class ImageMapper
    {
        public static Images Map(SqlDataReader record)
        {
            if (record == null) throw new ArgumentNullException("record");
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
