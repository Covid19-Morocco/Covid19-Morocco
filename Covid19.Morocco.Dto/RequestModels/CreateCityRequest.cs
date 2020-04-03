using System;

namespace Covid19.Morocco.Dto.RequestModels
{
    public class CreateCityRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string RegionCode { get; set; }
    }
}