using System;
using System.ComponentModel.DataAnnotations.Schema;
using Covid19.Morocco.Data.Enums;

namespace Covid19.Morocco.Data.Models
{
    public class Cases
    {
        public Guid Id { get; set; }
        public DateTime CaseDate { get; set; }
        public CaseType CaseType { get; set; }
        public int CasesCount { get; set; }
        [ForeignKey("City")]
        public Guid? City_Id { get; set; }
        [ForeignKey("Region")]
        public Guid? Region_Id { get; set; }
        public virtual City City { get; set; }
        public virtual Region Region { get; set; }
    }
}