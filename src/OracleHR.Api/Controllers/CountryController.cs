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
    /// <summary>
    /// Country Controller
    /// </summary>
    [RoutePrefix("api/countries")]
    public class CountryController : ApiController
    {
        /// <summary>
        /// Get all Countries from Oracle HR Database
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        [Route("getAllCountries")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllCountries()
        {
            var results = await CountryRepository.Instance.GetCountries();
            return Ok(results);
        }

        /// <summary>
        /// Get a Single Country from Oracle HR Database
        /// </summary>
        /// <returns ></returns>
        /// <response code="200">Success</response>
        /// <response code="400">No Country with Id</response>
        /// <param name="countryId">Country Id</param>
        [Route("getSingleCountry/{countryId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetSingleCountry([FromUri]string countryId)
        {
            var results = await CountryRepository.Instance.GetCountry(countryId);
            if (results == null)
            {
                return BadRequest(String.Format("No Country with id {0}", countryId));
            }
            return Ok(results);
        }
    }
}
