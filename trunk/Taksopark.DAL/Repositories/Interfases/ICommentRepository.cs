using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Interfases
{
    interface ICommentRepository
    {
        void Update(Comment comment);
        void Create(Comment comment);
        IEnumerable<Comment> GetAllCommentsByCreatorId(int id);
        IEnumerable<Comment> GetAllCommentsByRequestId(int id);
    }
}
