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

                if (profile != null && employee != null)
                {
                    //populate the  View Data For View
                    ViewData.Add(new KeyValuePair<string, object>("p_name", profile.profile_name));
                    ViewData.Add(new KeyValuePair<string, object>("p_surname", profile.profile_surname));
                    ViewData.Add(new KeyValuePair<string, object>("p_title", profile.profile_title));
                    ViewData.Add(new KeyValuePair<string, object>("e_jobtitle", employee.employee_jobtitle));
                    ViewData.Add(new KeyValuePair<string, object>("e_contract", employee.employee_contract));
                    ViewData.Add(new KeyValuePair<string, object>("e_startdate", employee.employee_startdate));
                    ViewData.Add(new KeyValuePair<string, object>("e_department", employee.employee_department));

                   
                    //_UserDisplayModel.Profile = profile;
                    //_UserDisplayModel.employee = employee;
                    return View();
                }
            }
            ModelState.AddModelError(string.Empty, "You are not logged in!");
            return View(loggedInUser); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
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
        [HttpGet]
        public async Task<ActionResult> _NewLeave()
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
                return RedirectToAction("Index", "Home", _updateUserInfoModel);
            }

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _NewLeave(HomeDisplayModel newLeave)
        {
            if (ModelState.IsValid)
            {
                await _leave.CreateNewLeave(newLeave.MyLeaves);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "The information you have provided is not correct!");
            return PartialView("_NewLeave", newLeave);
        }

    }
}