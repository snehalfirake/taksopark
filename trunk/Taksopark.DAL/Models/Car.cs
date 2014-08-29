using System;

namespace Taksopark.DAL.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string CarBrand { get; set; }
        public string CarYear { get; set; }
        public DateTime StartWorkTime { get; set; }
        public DateTime FinishWorkTime { get; set; }
    }
}