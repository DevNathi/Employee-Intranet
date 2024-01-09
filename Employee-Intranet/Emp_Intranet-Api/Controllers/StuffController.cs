using Emp_Intranet_Api.DataAccess.Query;
using Emp_Intranet_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Emp_Intranet_Api.Controllers
{

    public class StuffController : ApiController
    {
        
        /// <summary>
        /// This is an endpoint to get a Employee from the Employees table
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        // GET: api/Stuff
        [HttpGet]
        [Route("api/Employee/{id}")]
        public IHttpActionResult GetEmployeeByUser(int id)
        {
            StuffData _stuffData = new StuffData();

            var output = _stuffData.GetEmployeeByUserId(id);
            if (output != null)
            {
                return Ok(output);
            }
            return NotFound();
        }
        /// <summary>
        /// the endpoint gets a manager for an employee
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/MyManager/{department}")]
        public IHttpActionResult GetMyManagerByDepartment(string department)
        {
            StuffData _stuffData = new StuffData();
            var output = _stuffData.GetMyManangerByDepartment(department);
            if (output != null)
            {
                return Ok(output);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/MyColeagues/{department}")]
        public IHttpActionResult GetMyColleaguesByDepartment(string department)
        {
            StuffData _stuff = new StuffData();
            var myColleagues = _stuff.GetMycolleague(department);
            if (myColleagues != null)
            {
                return Ok(myColleagues);
            }
            return NotFound();
        }
    
        // PUT: api/User/5
        [HttpPut]
        [Route("api/Employee/")]
        public void Put([FromBody] EmployeeModel employee)
        {
            StuffData _stuffData = new StuffData();
            try
            {
                _stuffData.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
