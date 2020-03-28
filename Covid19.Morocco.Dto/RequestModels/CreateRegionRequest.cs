using System;

namespace Covid19.Morocco.Dto.RequestModels
{
    public class CreateRegionRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}