using System.Web.Http;
using Covid19.Morocco.Service;

namespace Covid19.Morocco.WebApi.Controllers
{
    [System.Web.Mvc.Route("api/regions")]
    public class RegionsController : ApiController
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        // GET api/cities
        [System.Web.Mvc.HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_regionService.GetAll());
        }
    }
}