using Emp_Intranet_UI.API;
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
        LeaveHelper _leaveHelper;
        IHomeDisplayModel _UserDisplayModel;
        IUpdateUserInfoModel _updateUserInfoModel;

        public HomeController(UserEndPoint user, StuffEndPoint stuff, IHomeDisplayModel UserDisplayModel, LeaveEndPoint leave,LeaveHelper leaveHelper, IUpdateUserInfoModel updateUserInfoModel)
        {

            _user = user ?? throw new ArgumentNullException(nameof(user));
            _stuff = stuff ?? throw new ArgumentException(nameof(stuff));
            _leaveHelper = leaveHelper ?? throw new ArgumentException(nameof(leave));
            _leave = leave ?? throw new ArgumentException(nameof(leave));
            _UserDisplayModel = UserDisplayModel;
            _updateUserInfoModel = updateUserInfoModel;

        }
      
        public async Task<ActionResult> Index()
        {
            
            //We use a session to keep track of the logged in user
            var loggedInUser = Session["LoggedInUser"] as UserModel;
            if (loggedInUser != null && loggedInUser.Id > 0)
            {
                //we pull the data from the API using our endpoints that have the API client connec
                var _profile = await _user.GetProfileByUser(loggedInUser.Id);
                var _employee = await _stuff.GetEmployeeByUserId(loggedInUser.Id);
                var _MyManager = await _stuff.GetMyManagerByDepartment(_employee.employee_department);
                var _myColleagues = await _stuff.GetMyColleageasByDepartment(_employee.employee_department);
                var _myLeaves = await _leave.GetLeavesByEmployeeId(_employee.Id);
                var _myStatsPerLeaveType = await _leave.GetStatsByEmployeePerLeave(_employee.Id);
                

                // Create a list of Employee instances with values
                List<LeaveTypes> _leaveTypes = new List<LeaveTypes>
                {
                    new LeaveTypes {LeaveName = "Annual", LeaveDays = 15, LeaveDaysRemaining = 0, LeaveDaysTaken = 0 },
                    new LeaveTypes {LeaveName = "Sick", LeaveDays = 30, LeaveDaysRemaining = 0, LeaveDaysTaken = 0  },
                    new LeaveTypes {LeaveName = "Study", LeaveDays = 10, LeaveDaysRemaining = 0, LeaveDaysTaken = 0  },
                    new LeaveTypes {LeaveName = "Maternity", LeaveDays = 90, LeaveDaysRemaining = 0, LeaveDaysTaken = 0  },
                    
                };
                if (_profile != null && _employee != null)
                {
                    _leaveHelper.UpdateLeaveTypes(_leaveTypes, _myStatsPerLeaveType);

                    //populate the  View Data For View
                    _UserDisplayModel.Profile = _profile;
                    _UserDisplayModel.employee = _employee;
                    _UserDisplayModel.MyColleagues = _myColleagues;
                    _UserDisplayModel.MyManager = _MyManager;
                    _UserDisplayModel.LeaveTypes = _leaveTypes;
                    _UserDisplayModel.MyLeaveRecord = _myLeaves;
                    _UserDisplayModel.MyLeaveStatsPerLeave = _myStatsPerLeaveType;


                    //populate session values for later use
                    Session["EmployeeId"] = _employee.Id;
                    Session["MyManagerId"] = _MyManager.Id;
                    return View(_UserDisplayModel);
                }
            }
            ModelState.AddModelError(string.Empty, "You are not logged in!");
            return View(loggedInUser); 
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
                // Update user, profile, based on updateUserViewModel
                var updatedProfile = await _user.UpdateProfileByUser(updateUserModel.Profile);
                var updatedEmployee = await _stuff.UpdateEmployeeByUser(updateUserModel.employee);
                return RedirectToAction("Index", "Home", _updateUserInfoModel); ;
                // Handle the updated data as needed
            }

            // If ModelState is not valid, return to the update form with errors
            return PartialView("UpdateUser", updateUserModel);
        }
        //[HttpGet]
        //public async Task<ActionResult> _NewLeave()
        //{
        //    var loggedInUser = Session["LoggedInUser"] as UserModel;
        //    if (loggedInUser != null && loggedInUser.Id > 0)
        //    {
        //        // Fetch user and profile data based on the logged in userId
        //        var myprofile = await _user.GetProfileByUser(loggedInUser.Id);
        //        var myemployee = await _stuff.GetEmployeeByUserId(loggedInUser.Id);
        //        //// populate the Display Model for the Partial View
        //        _UserDisplayModel.Profile = myprofile;
        //        _UserDisplayModel.employee = myemployee;
        //        return RedirectToAction("Index", "Home", _updateUserInfoModel);
        //    }

        //    return View();

        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _NewLeave(HomeDisplayModel newLeave)
        {
            if (newLeave.MyLeaves != null)
            {
                var empId = Convert.ToInt32(Session["EmployeeId"]);
                var manId = Convert.ToInt32(Session["MyManagerId"]);
                newLeave.MyLeaves.EmployeeId = empId;
                newLeave.MyLeaves.ManagerId = manId;
                newLeave.MyLeaves.EmployeeId = empId;
                newLeave.MyLeaves.ManagerId = manId;

                await _leave.CreateNewLeave(newLeave.MyLeaves);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "The information you have provided is not correct!");
            return PartialView("_NewLeave", newLeave);
        }

    }
}