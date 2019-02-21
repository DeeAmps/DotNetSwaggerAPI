using OracleHR.Models.dbModels;
using OracleHR.Repository.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace OracleHR.Api.Controllers
{
    /// <summary>
    /// Region Controller
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Success</response>
    [RoutePrefix("api/regions")]
    public class RegionController : ApiController
    {
        /// <summary>
        /// Get all Regions from Oracle HR Database
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        [Route("getAllRegions")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Region>))]
        public async Task<IHttpActionResult> GetAllRegions()
        {
            var results = await RegionRepository.Instance.GetRegions();
            return Ok(results); 
        }

        /// <summary>
        /// Get a Single Region from Oracle HR Database
        /// </summary>
        /// <returns ></returns>
        /// <response code="200">Success</response>
        /// <response code="400">No Region with Id</response>
        /// <param name="regionId">Region Id</param>
        [Route("getSingleRegion/{regionId}")]
        [HttpGet]
        [ResponseType(typeof(Region))]
        public async Task<IHttpActionResult> GetSingleRegion([FromUri]int regionId)
        {
            var results = await RegionRepository.Instance.GetRegion(regionId);
            if (results == null)
            {
                return BadRequest(String.Format("No Region with id {0}", regionId));
            }
            return Ok(results);
        }

        /// <summary>
        /// Add a New Region
        /// </summary>
        /// <returns ></returns>
        /// <response code="201">Region Added</response>
        /// <response code="500">Internal Server Error</response>
        [Route("addNewRegion")]
        [HttpPost]
        public async Task<IHttpActionResult> AddRegion([FromBody]Region region)
        {
            if (!ModelState.IsValidField("RegionName"))
            {
                return BadRequest("RegionName is required!");
            }
            Region results = await RegionRepository.Instance.AddNewRegion(region);
            if (results.RegionId != 0)
            {
                return Created(new Uri(String.Format("/getSingleRegion/{0}", results.RegionId)), region);
            }
            return InternalServerError();
            
        }

        /// <summary>
        /// Update Region
        /// </summary>
        /// <returns ></returns>
        /// <response code="200">Region Updated</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="400">Bad Request</response>
        /// <param name="regionId">Region Id</param>
        [Route("updateRegion/{regionId}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRegion([FromBody]Region region, [FromUri] int regionId)
        {
            if (!ModelState.IsValidField("RegionName"))
            {
                return BadRequest("RegionName is required!");
            }
            Region results = await RegionRepository.Instance.UpdateRegion(region, regionId);
            if (results.RegionId != 0)
            {
                return Ok(results);
            }
            return InternalServerError();

        }

        /// <summary>
        /// Delete Region
        /// </summary>
        /// <returns ></returns>
        /// <response code="404">Successful Deletion</response>
        /// <response code="400">Bad Request</response>
        /// <param name="regionId">Region Id</param>
        [Route("removeRegion/{regionId}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRegion([FromUri]int regionId)
        {
            int results = await RegionRepository.Instance.DeleteRegion(regionId);
            if (results == 0)
            {
                return BadRequest(String.Format("No Region with id {0}", regionId));
            }
            return NotFound();
        }
    }
}
