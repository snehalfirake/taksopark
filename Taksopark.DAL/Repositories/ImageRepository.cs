using System.Collections.Generic;
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
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE Image SET "
                                      + "Photo = @photo, "
                                      + "OwnerId = @ownerId, "
                                      + "CarId = @carId, "
                                      + "Where Id = @imageId";
                command.Parameters.AddWithValue("photo", image.PhotoImage);
                command.Parameters.AddWithValue("ownerId", image.OwnerId);
                command.Parameters.AddWithValue("carId", image.CarId);
                command.Parameters.AddWithValue("imageId", image.Id);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert image record
        /// </summary>
        /// <param name="image">Image model</param>
        public void Create(Images image)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO IMAGE(Photo, OwnerId, CarId) "
                                      + "VALUES(@photo, @ownerId, @carId)";
                command.Parameters.AddWithValue("photo", image.PhotoImage);
                command.Parameters.AddWithValue("ownerId", image.OwnerId);
                command.Parameters.AddWithValue("carId", image.CarId);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get all image record
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Images> GetAllImages()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Image";
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
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Coments WHERE ID = @imageId";
                command.Parameters.AddWithValue("imageId", imageId);
                command.ExecuteNonQuery();
            }
        }
    }
}
