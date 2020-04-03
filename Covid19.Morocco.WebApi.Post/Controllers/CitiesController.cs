using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Covid19.Morocco.Data.Models;
using Covid19.Morocco.Dto.RequestModels;
using Covid19.Morocco.Service;

namespace Covid19.Morocco.WebApi.Post.Controllers
{
    public class CitiesController : ApiController
    {
        private readonly ICityService _cityService;
        private readonly IRegionService _regionService;

        public CitiesController(ICityService cityService, IRegionService regionService)
        {
            _cityService = cityService;
            _regionService = regionService;
        }

        // GET api/cities
        [Route("api/CreateCity")]
        [HttpPost]
        [ResponseType(typeof(CreateCityRequest))]
        public IHttpActionResult CreateCity(CreateCityRequest createCityRequest)
        {
            try
            {
                var region = _regionService.GetMany(c => c.Code.Equals(createCityRequest.RegionCode)).FirstOrDefault();
                _cityService.Add(new City
                {
                    Id = Guid.NewGuid(),
                    Name = createCityRequest.Name,
                    Code = createCityRequest.Code,
                    Region_Id = region?.Id ?? throw new Exception("Region not found, please check the region code and try again.")
                });
                _cityService.Save();
                return Created("City created successfully !", createCityRequest.Name + " - " + region.Name);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}