using System;
using System.Web.Http;
using Covid19.Morocco.Data.Models;
using Covid19.Morocco.Service;

namespace Covid19.Morocco.WebApi.Controllers
{
    [Route("api/cities")]
    public class CitiesController : ApiController
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET api/cities
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_cityService.GetAll());
        }
    }
}