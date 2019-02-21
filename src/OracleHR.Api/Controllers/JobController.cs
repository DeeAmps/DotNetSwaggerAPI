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
    [RoutePrefix("api/jobs")]
    public class JobController : ApiController
    {
        [Route("getAllJobs")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllJobs()
        {
            var results = await JobRepository.Instance.GetJobs();
            return Ok(results);
        }

        [Route("getSingleJob/{jobId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetSingleJob([FromUri]string jobId)
        {
            var results = await JobRepository.Instance.GetJob(jobId);
            if (results == null)
            {
                return BadRequest(String.Format("No Job with id {0}", jobId));
            }
            return Ok(results);
        }
    }
}
