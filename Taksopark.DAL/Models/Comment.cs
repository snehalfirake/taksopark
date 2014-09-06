namespace Taksopark.DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int CreatorId { get; set; }
        public int RequestId { get; set; }
    }
}