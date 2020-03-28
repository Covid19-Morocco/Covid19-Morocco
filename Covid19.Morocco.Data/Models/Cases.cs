﻿using System;
using Covid19.Morocco.Data.Enums;

namespace Covid19.Morocco.Data.Models
{
    public class Cases
    {
        public Guid Id { get; set; }
        public DateTime CaseDate { get; set; }
        public CaseType CaseType { get; set; }
        public int CasesCount { get; set; }
        public virtual City City { get; set; }
        public virtual Region Region { get; set; }
    }
}