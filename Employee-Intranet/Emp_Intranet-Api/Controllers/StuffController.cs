﻿using Emp_Intranet_Api.DataAccess.Query;
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
        [Route("api/employee")]
        public IHttpActionResult GetEmployeeByUser(int userId)
        {
            StuffData _stuffData = new StuffData();

            var output = _stuffData.GetEmployeeByUserId(userId);
            if (output != null)
            {
                return Ok(output);
            }
            return NotFound();
        }
        /// <summary>
        /// This endpoint gets the Department 
        /// </summary>
        /// <param name="depId"></param>
        /// <returns></returns>
       [HttpGet]
       [Route("api/department")]
        public IHttpActionResult GetDepartmentById(int depId)
        {

            StuffData _stuffData = new StuffData();

            var department = _stuffData.GetDepartmentById(depId);
            if (department != null)
            {
                return Ok(department);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/permissions")]
        public IHttpActionResult GetPermissionsById(int pemId)
        {
            StuffData _stuffData = new StuffData();

            var permissions = _stuffData.GetPermissionsById(pemId);
            if (permissions != null && permissions.Count >= 0)
            {
                return Ok(permissions);
            }
            return NotFound();
        }
    }
}
