using Emp_Intranet_UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emp_Intranet_UI.Controllers.LeaveHelpers
{
    public interface ILeaveLoader
    {
        Task<List<LeaveModel>> GetLeaves();
    }
}