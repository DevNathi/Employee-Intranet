﻿using Emp_Intranet_Api.DataAccess;
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

        LeaveData _leaveData = new LeaveData();
        [HttpGet]
        [Route("api/Leave/{leaveID}")]
        public IHttpActionResult GetLeaveByID(int leaveID)
        {
            var output = _leaveData.GetLeaveById(leaveID);

            if (output == null)
            {
                return NotFound(); // 404 status code if leave is not found
            }

            return Ok(output); // 200 status code with the leave model
        }
        /// <summary>
        /// Get leave by ID.
        /// </summary>
        /// <param name="id">The ID of the leave.</param>
        /// <returns>Returns a single leave model.</returns>
        /// <response code="200">Returns the leave model if found.</response>
        /// <response code="404">If the leave with the specified ID is not found.</response>
        [HttpGet]
        [Route("api/MyLeaves/{empId}")]
        public IHttpActionResult GetLeavesByUser(int empId)
        {
             var output = _leaveData.GetLeavesByEmployeeId(empId);

            if (output == null)
            {
                return NotFound(); // 404 status code if leave is not found
            }

            return Ok(output); // 200 status code with the leave model
        }
        [HttpGet]
        [Route("api/MyLeaveStats/{empId}")]
        public IHttpActionResult GetStatsForEmployeePerLeave(int empId)
        {
            var output = _leaveData.GetLeaveStatsForEmployeePerLeave(empId);

            if (output == null)
            {
                return NotFound(); // 404 status code if leave is not found
            }

            return Ok(output); // 200 status code with the leave model
        }
        [HttpGet]
        [Route("api/leaves")]
        public IHttpActionResult GetAll()
        {
    
            var output = _leaveData.GetAllLeave();
            if (output == null)
            {
                return NotFound();
            }
            return Ok(output);
        }
        [HttpPost]
        [Route("api/NewLeave")]
        public void CreateNewLeave([FromBody] LeaveModel NewLeave)
        {
            try
            {
               _leaveData.AddLeaveForUser(NewLeave);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/UpdateLeave")]
        public void UpdateLeave([FromBody] LeaveModel NewLeave)
        {
            try
            {
                _leaveData.UpdateLeaveForUser(NewLeave);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        [Route("api/Leave/{leaveID}")]
        public void DeleteLeaveByID(int leaveID)
        {
            _leaveData.DeleteLeaveById(leaveID);

        }
    }
}
