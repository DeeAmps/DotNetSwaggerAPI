using OracleHR.Models.dbModels;
using OracleHR.Repository.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OracleHR.Api.Controllers
{
    [RoutePrefix("api/regions")]
    public class RegionController : ApiController
    {
        [Route("getAllRegions")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllRegions()
        {
            var results = await RegionRepository.Instance.GetRegions();
            return Ok(results); 
        }
    }
}
