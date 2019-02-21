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
    [RoutePrefix("api/departments")]
    public class DepartmentController : ApiController
    {
        [Route("getAllDepartments")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllDepartments()
        {
            var results = await DepartmentRepository.Instance.GetDepartments();
            return Ok(results);
        }

        [Route("getSingleDepartment/{departmentId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetSingleDepartment([FromUri]string departmentId)
        {
            var results = await DepartmentRepository.Instance.GetDepartment(departmentId);
            if (results == null)
            {
                return BadRequest(String.Format("No Departments with id {0}", departmentId));
            }
            return Ok(results);
        }
    }
}
