using System.Collections.Generic;
using System.Data.SqlClient;
using Taksopark.DAL.Models;
using Taksopark.DAL.Repositories.Interfases;
using Taksopark.DAL.Repositories.Mappers;

namespace Taksopark.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly SqlConnection _connection;

        public CommentRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Update comment record
        /// </summary>
        /// <param name="comment">Comment model</param>
        public void Update(Comment comment)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE Coments SET "
                                      + "CreatorId = @creatorId, "
                                      + "RequestId = @requestId, "
                                      + "CommentText = @commentText";
                command.Parameters.AddWithValue("creatorId", comment.CreatorId);
                command.Parameters.AddWithValue("requestId", comment.RequestId);
                command.Parameters.AddWithValue("commentText", comment.CommentText);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert comment record
        /// </summary>
        /// <param name="comment">Comment model</param>
        public void Create(Comment comment)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Coments(CreatorId, RequestId, CommentText) "
                                      + "VALUES(@creatorId, @requestId, @commentText)";
                command.Parameters.AddWithValue("creatorId", comment.CreatorId);
                command.Parameters.AddWithValue("requestId", comment.RequestId);
                command.Parameters.AddWithValue("commentText", comment.CommentText);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get all comment record
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Comment> GetAllComments()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Coments";
                var commentList = new List<Comment>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var comment = CommentMapper.Map(reader);
                        commentList.Add(comment);
                    }
                }
                return commentList;
            }
        }

        /// <summary>
        /// Delete comment record from DB
        /// </summary>
        /// <param name="commentId">Comment id in DB</param>
        public void DeleteComment(int commentId)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Coments WHERE ID = @commentId";
                command.Parameters.AddWithValue("commentId", commentId);
                command.ExecuteNonQuery();
            }
        }
    }
}
