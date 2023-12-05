using Emp_Intranet_UI.API;
using Emp_Intranet_UI.Controllers.AuthHelpers;
using Emp_Intranet_UI.Controllers.LeaveHelpers;
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
    public class HomeController : Controller
    {
      
        UserEndPoint _user;
        StuffEndPoint _stuff;
        LeaveEndPoint _leave;
        IHomeDisplayModel _UserDisplayModel;
        IUpdateUserInfoModel _updateUserInfoModel;
        int Id = 1;

        public HomeController(UserEndPoint user, StuffEndPoint stuff, IHomeDisplayModel UserDisplayModel, LeaveEndPoint leave, IUpdateUserInfoModel updateUserInfoModel)
        {

            _user = user ?? throw new ArgumentNullException(nameof(user));
            _stuff = stuff ?? throw new ArgumentException(nameof(stuff));
            _leave = leave ?? throw new ArgumentException(nameof(leave));
            _UserDisplayModel = UserDisplayModel;
            _updateUserInfoModel = updateUserInfoModel;

            
        }
      
        public async Task<ActionResult> Index()
        {
            
            //We use a session to keep the track oof the logged in user
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
            ModelState.AddModelError(string.Empty, "You are not logged in!");
            return View(loggedInUser); 
        }
        public ActionResult TakeLeave(int id)
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> UpdateUser()
        {
            var loggedInUser = Session["LoggedInUser"] as UserModel;
            if (loggedInUser != null && loggedInUser.Id > 0)
            {
                // Fetch user and profile data based on the logged in userId
                var myprofile = await _user.GetProfileByUser(loggedInUser.Id);
                var myemployee = await _stuff.GetEmployeeByUserId(loggedInUser.Id);
                //// populate the Display Model for the Partial View
                _UserDisplayModel.Profile = myprofile;
                _UserDisplayModel.employee = myemployee;
                return RedirectToAction("Index", "Home",_updateUserInfoModel);
            }

            return View();
           
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser(HomeDisplayModel updateUserModel)
        {
            if (ModelState.IsValid)
            {
                // Update user, profile, and roles based on updateUserViewModel
                var updatedProfile = await _user.UpdateProfileByUser(updateUserModel.Profile);
                var updatedEmployee = await _stuff.UpdateEmployeeByUser(updateUserModel.employee);
                return RedirectToAction("Index", "Home", _updateUserInfoModel); ;
                // Handle the updated data as needed
            }

            // If ModelState is not valid, return to the update form with errors
            return PartialView("UpdateUser", updateUserModel);
        }

    }
}