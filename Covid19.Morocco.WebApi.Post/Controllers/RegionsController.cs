using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Covid19.Morocco.Data.Models;
using Covid19.Morocco.Dto.RequestModels;
using Covid19.Morocco.Service;

namespace Covid19.Morocco.WebApi.Post.Controllers
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
        [Route("api/CreateRegion")]
        [HttpPost]
        [ResponseType(typeof(CreateRegionRequest))]
        public IHttpActionResult CreateCity(CreateRegionRequest createRegionRequest)
        {
            try
            {
                _regionService.Add(new Region
                {
                    Id = Guid.NewGuid(),
                    Name = createRegionRequest.Name,
                    Code = createRegionRequest.Code
                });
                _regionService.Save();
                return Created("City created successfully !", createRegionRequest.Name);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}