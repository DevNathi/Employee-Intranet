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
            //We use a session to keep the track oof the logged in user
            var loggedInUser = Session["LoggedInUser"] as UserModel;
            if (loggedInUser != null && loggedInUser.Id > 0)
            {
                //We pull the data of the logged in user, profile and employee status 
                var profile = await _user.GetProfileByUser(loggedInUser.Id);
                var employee = await _stuff.GetEmployeeByUserId(loggedInUser.Id);
                var leave = await _stuff.GetEmployeeByUserId(loggedInUser.Id);


                if (profile != null && employee != null)
                {
                    //populate the Display Model for the View
                    _LeaveDisplay.Profile = profile;
                    _LeaveDisplay.employee = employee;
                    


                    return View(_LeaveDisplay);
                }
            }
            ModelState.AddModelError(string.Empty, "You are not logged in!");
            return View(loggedInUser);
        }
       
    }
}