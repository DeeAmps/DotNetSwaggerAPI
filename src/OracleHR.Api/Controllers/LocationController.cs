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
    [RoutePrefix("api/locations")]
    public class LocationController : ApiController
    {
        [Route("getAllLocations")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllLocations()
        {
            var results = await LocationRepository.Instance.GetLocations();
            return Ok(results);
        }

        [Route("getSingleLocation/{locationId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetSingleLocation([FromUri]int locationId)
        {
            var results = await LocationRepository.Instance.GetLocation(locationId);
            if (results == null)
            {
                return BadRequest(String.Format("No Location with id {0}", locationId));
            }
            return Ok(results);
        }
    }
}
