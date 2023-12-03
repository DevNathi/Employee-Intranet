using Emp_Intranet_UI.API;
using Emp_Intranet_UI.Controllers.AuthHelpers;
using Emp_Intranet_UI.Controllers.LeaveHelpers;
using Emp_Intranet_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Emp_Intranet_UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
      
        UserEndPoint _user;
        StuffEndPoint _stuff;
        LeaveEndPoint _leave;
        IHomeDisplayModel _UserDisplayModel;
        int Id = 1;

        public HomeController(UserEndPoint user, StuffEndPoint stuff, IHomeDisplayModel UserDisplayModel, LeaveEndPoint leave)
        {

            _user = user ?? throw new ArgumentNullException(nameof(user));
            _stuff = stuff ?? throw new ArgumentException(nameof(stuff));
            _leave = leave ?? throw new ArgumentException(nameof(leave));
            _UserDisplayModel = UserDisplayModel;
            
        }
      
        public async Task<ActionResult> Index()
        {
            //TODO - need another way to keep data on the UI 

            var loggedInUser = Session["LoggedInUser"] as UserModel;
            if (loggedInUser != null && loggedInUser.Id > 0)
            {
                var profile = await _user.GetProfileByUser(loggedInUser.Id);
                var employee = await _stuff.GetEmployeeByUserId(loggedInUser.Id);
                var leaveType = await _leave.GetAllLeaveType();
                var leaves = await _leave.GetLeavesByUserId(loggedInUser.Id);

                if (profile != null && employee != null)
                {
                    //populate the Display Model for the View
                    _UserDisplayModel.Profile = profile;
                    _UserDisplayModel.employee = employee;
                    _UserDisplayModel.LeaveTypes = leaveType;
                    _UserDisplayModel.leave = leaves;


                    return View(_UserDisplayModel);
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View(loggedInUser); 
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}