using  System.Drawing;

namespace Taksopark.DAL.Models
{
    public class Images
    {
        public int Id { get; set; }
        public byte[] PhotoImage { get; set; }
        public int OwnerId { get; set; }
        public int CarId { get; set; }
    }
}