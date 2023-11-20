using Emp_Intranet_Api.DataAccess;
using Emp_Intranet_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Emp_Intranet_Api.Controllers
{
    public class LeaveController : ApiController
    {
        /// <summary>
        /// Get leave by ID.
        /// </summary>
        /// <param name="id">The ID of the leave.</param>
        /// <returns>Returns a single leave model.</returns>
        /// <response code="200">Returns the leave model if found.</response>
        /// <response code="404">If the leave with the specified ID is not found.</response>
        [HttpGet]
        [Route("api/Leave/{id}")]
        
        public IHttpActionResult GetById(int id)
        {
            LeaveData leave = new LeaveData();
       
             var output = leave.GetLeaveById(id);

            if (output == null)
            {
                return NotFound(); // 404 status code if leave is not found
            }

            return Ok(output); // 200 status code with the leave model
        }

    }
}
