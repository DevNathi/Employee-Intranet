using Emp_Intranet_UI.API;
using Emp_Intranet_UI.Models;
using Emp_Intranet_UI.Models.DisplayModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Emp_Intranet_UI.Controllers
{
    [Authorize]
    public class LeaveController : Controller
    {
        UserEndPoint _user;
        StuffEndPoint _stuff;
        LeaveEndPoint _leave;
        LeaveDisplayModel _LeaveDisplay;

        public LeaveController( UserEndPoint user, StuffEndPoint stuff, LeaveEndPoint leave, LeaveDisplayModel leaveDisplay)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _stuff = stuff ?? throw new ArgumentException(nameof(stuff));
            _leave = leave ?? throw new ArgumentException(nameof(leave));
            _LeaveDisplay = leaveDisplay;
        }

        public async Task<ActionResult> Leave()
        {
            return View();
        }
    }
}