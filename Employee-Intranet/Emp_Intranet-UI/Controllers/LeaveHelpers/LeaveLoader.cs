using Emp_Intranet_UI.API;
using Emp_Intranet_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Emp_Intranet_UI.Controllers.LeaveHelpers
{
    public class LeaveLoader : ILeaveLoader
    {
        private LeaveEndPoint _leaveEndPoint;

        public LeaveLoader(LeaveEndPoint leaveEndPoint)
        {
            _leaveEndPoint = leaveEndPoint;
        }

        public async Task<List<LeaveModel>> GetLeaves()
        {

            var leaves = await _leaveEndPoint.GetAllLeaves();

            return leaves;
        }
    }
}