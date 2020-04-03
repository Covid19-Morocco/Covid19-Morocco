using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Covid19.Morocco.Data.Enums;
using Covid19.Morocco.Data.Models;
using Covid19.Morocco.Dto.RequestModels;
using Covid19.Morocco.Service;

namespace Covid19.Morocco.WebApi.Post.Controllers
{
    public class CasesController : ApiController
    {
        private readonly ICasesService _casesService;
        private readonly ICityService _cityService;
        private readonly IRegionService _regionService;

        public CasesController(ICasesService casesService, ICityService cityService, IRegionService regionService)
        {
            _casesService = casesService;
            _cityService = cityService;
            _regionService = regionService;
        }

        // Post api/cities
        [Route("api/CreateCityCases")]
        [HttpPost]
        [ResponseType(typeof(CreateCityCasesRequest))]
        public IHttpActionResult CreateCityCases([FromBody]CreateCityCasesRequest cityCasesRequest)
        {
            try
            {
                var city = _cityService.GetMany(c => c.Code.Equals(cityCasesRequest.CityCode)).FirstOrDefault();
                _casesService.Add(new Cases
                {
                    Id = Guid.NewGuid(),
                    CaseType = (CaseType)cityCasesRequest.CaseType,
                    CaseDate = DateTime.Parse(cityCasesRequest.CaseDate),
                    CasesCount = cityCasesRequest.CasesCount,
                    City_Id = city?.Id ?? throw new Exception("City not found, please check the city code and try again.")
                });
                _cityService.Save();
                return Created("Case created successfully !", city.Name);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //// Post api/cities
        [Route("api/CreateRegionCases")]
        [HttpPost]
        [ResponseType(typeof(CreateRegionCasesRequest))]
        public IHttpActionResult CreateRegionCases([FromBody]CreateRegionCasesRequest createRegionCasesRequest)
        {
            try
            {
                var region = _regionService.GetMany(c => c.Code.Equals(createRegionCasesRequest.RegionCode)).FirstOrDefault();
                _casesService.Add(new Cases
                {
                    Id = Guid.NewGuid(),
                    CaseType = (CaseType)createRegionCasesRequest.CaseType,
                    CaseDate = DateTime.Parse(createRegionCasesRequest.CaseDate),
                    CasesCount = createRegionCasesRequest.CasesCount,
                    Region_Id = region?.Id ?? throw new Exception("Region not found, please check the region code and try again.")
                }); 
                _cityService.Save();
                return Created("Case created successfully !", region.Name);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}