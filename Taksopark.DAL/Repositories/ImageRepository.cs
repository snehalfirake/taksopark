using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Taksopark.DAL.Models;
using Taksopark.DAL.Repositories.Interfases;
using Taksopark.DAL.Repositories.Mappers;

namespace Taksopark.DAL.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly SqlConnection _connection;
        public ImageRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Update image record
        /// </summary>
        /// <param name="image">Image model</param>
        public void Update(Images image)
        {
            using (var command = new SqlCommand("UpdateImage", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Photo", image.PhotoImage);
                command.Parameters.AddWithValue("@OwnerId", image.OwnerId);
                command.Parameters.AddWithValue("@CarId", image.CarId);
                command.Parameters.AddWithValue("@ImageId", image.Id);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert image record
        /// </summary>
        /// <param name="image">Image model</param>
        public void Create(Images image)
        {
            using (var command = new SqlCommand("CreateImage", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Photo", image.PhotoImage);
                command.Parameters.AddWithValue("@OwnerId", image.OwnerId);
                command.Parameters.AddWithValue("@CarId", image.CarId);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get all image record
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Images> GetAllImages()
        {
            using (var command = new SqlCommand("GetAllImages", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                var imageList = new List<Images>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var image = ImageMapper.Map(reader);
                        imageList.Add(image);
                    }
                }
                return imageList;
            }
        }

        /// <summary>
        /// Delete image record drom DB
        /// </summary>
        /// <param name="imageId">Image id in DB</param>
        public void DeleteImage(int imageId)
        {
            using (var command = new SqlCommand("DeleteImage", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ImageId", imageId);
                command.ExecuteNonQuery();
            }
        }
    }
}
