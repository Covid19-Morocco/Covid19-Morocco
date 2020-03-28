using System;

namespace Covid19.Morocco.Data.Models
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Region Region { get; set; }
    }
}