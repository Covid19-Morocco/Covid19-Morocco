using System;
using System.Web.Http;
using Covid19.Morocco.Data.Enums;
using Covid19.Morocco.Data.Models;
using Covid19.Morocco.Service;

namespace Covid19.Morocco.WebApi.Controllers
{
    [System.Web.Mvc.Route("api/cases")]
    public class CasesController : ApiController
    {
        private readonly ICasesService _casesService;

        public CasesController(ICasesService casesService)
        {
            _casesService = casesService;
        }

        // GET api/cities
        [System.Web.Mvc.HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_casesService.GetAll());
        }
    }
}