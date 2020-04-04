using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid19.Morocco.Data.Models
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }
        [ForeignKey("Region")]
        public Guid? Region_Id { get; set; }
        public virtual Region Region { get; set; }
    }
}