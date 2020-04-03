using System;
using Covid19.Morocco.Dto.Enums;

namespace Covid19.Morocco.Dto.RequestModels
{
    public class CreateRegionCasesRequest
    {
        public string CaseDate { get; set; }
        public int CaseType { get; set; }
        public int CasesCount { get; set; }
        public string RegionCode { get; set; }
    }
}