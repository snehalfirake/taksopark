using System.Collections.Generic;
using System.Data;
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
            using (var command = new SqlCommand("UpdateComment", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CreatorId", comment.CreatorId);
                command.Parameters.AddWithValue("@RequestId", comment.RequestId);
                command.Parameters.AddWithValue("@CommentText", comment.CommentText);
                command.Parameters.AddWithValue("@CommentId", comment.Id);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert comment record
        /// </summary>
        /// <param name="comment">Comment model</param>
        public void Create(Comment comment)
        {
            using (var command = new SqlCommand("CreateComment", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CreatorId", comment.CreatorId);
                command.Parameters.AddWithValue("@RequestId", comment.RequestId);
                command.Parameters.AddWithValue("@CommentText", comment.CommentText);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get all comment record
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Comment> GetAllComments()
        {
            using (var command = new SqlCommand("GetAllComments", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
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

    }
}
