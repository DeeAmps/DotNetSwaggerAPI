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
    [RoutePrefix("api/employees")]
    public class EmployeeController : ApiController
    {
        [Route("getAllEmployees")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllEmployees()
        {
            var results = await EmployeeRepository.Instance.GetEmployees();
            return Ok(results);
        }

        [Route("getSingleEmployee/{employeeId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetSingleEmployee([FromUri]int employeeId)
        {
            var results = await EmployeeRepository.Instance.GetEmployee(employeeId);
            if (results == null)
            {
                return BadRequest(String.Format("No Employee with id {0}", employeeId));
            }
            return Ok(results);
        }
    }
}
