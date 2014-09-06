using System.Data;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Mappers
{
    static class CommentMapper
    {
        public static Comment Map(IDataRecord record)
        {
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
