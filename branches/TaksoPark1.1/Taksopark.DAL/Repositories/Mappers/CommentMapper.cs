using System;
using System.Data;
using System.Data.SqlClient;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Mappers
{
    static class CommentMapper
    {
        public static Comment Map(SqlDataReader record)
        {
            if (record == null) throw new ArgumentNullException("record");
            var commment = new Comment
            {
                Id = (int)record["Id"],
                CreatorId = (int)record["CreatorId"],
                RequestId = (int)record["RequestId"],
                CommentText = (string)record["CommentText"]
            };
            return commment;
        }
    }
}
