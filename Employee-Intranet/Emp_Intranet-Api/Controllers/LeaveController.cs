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
        // GET: api/Leave/5
       [HttpGet]
        public LeaveModel GetById(int Id)
        {
            LeaveData leave = new LeaveData();

            var output = leave.GetLeaveById(Id);

            return output;
        }

    }
}
