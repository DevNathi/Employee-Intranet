﻿using Emp_Intranet_UI.API;
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
                //we pull the data from the API using our endpoints that have the API client connection
                var _profile = await _user.GetProfileByUser(loggedInUser.Id);
                var _employee = await _stuff.GetEmployeeByUserId(loggedInUser.Id);
                var _MyManager = await _stuff.GetMyManagerByDepartment(_employee.employee_department);
                var _myColleagues = await _stuff.GetMyColleageasByDepartment(_employee.employee_department);
                var _myLeaves = await _leave.GetLeavesByEmployeeId(_employee.Id);
                var _myStatsPerLeaveType = await _leave.GetStatsByEmployeePerLeave(_employee.Id);
                

                // Create a list of Leave Types instances with values
                List<LeaveTypes> _leaveTypes = new List<LeaveTypes>
                {
                    new LeaveTypes {LeaveName = "Annual", LeaveDays = 15, LeaveDaysRemaining = 0, LeaveDaysTaken = 0 },
                    new LeaveTypes {LeaveName = "Sick", LeaveDays = 30, LeaveDaysRemaining = 0, LeaveDaysTaken = 0  },
                    new LeaveTypes {LeaveName = "Study", LeaveDays = 10, LeaveDaysRemaining = 0, LeaveDaysTaken = 0  },
                    new LeaveTypes {LeaveName = "Maternity", LeaveDays = 90, LeaveDaysRemaining = 0, LeaveDaysTaken = 0  },
                    
                };
                if (_profile != null && _employee != null)
                {
                    _leaveHelper.UpdateLeaveTypes(_leaveTypes, _myStatsPerLeaveType,_employee);

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
                    Session["LeaveTypes"] = _leaveTypes;
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
        /// <summary>
        /// We Post the data from the Update user form 
        /// </summary>
        /// <param name="updateUserModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateUser(HomeDisplayModel updateUserModel)
        {
            if (ModelState.IsValid)
            {
                // Update user, profile, based on updateUserViewModel
                var updatedProfile = await _user.UpdateProfileByUser(updateUserModel.Profile);
                var updatedEmployee = await _stuff.UpdateEmployeeByUser(updateUserModel.employee);
                return RedirectToAction("Index", "Home", _updateUserInfoModel);
               
            }

            // If ModelState is not valid, return to the update form with errors
            return PartialView("UpdateUser", updateUserModel);
        }
        [HttpGet]
        public async Task<ActionResult> _NewLeave(int Id)
        {
            var loggedInUser = Session["LoggedInUser"] as UserModel;
            if (loggedInUser != null && loggedInUser.Id > 0)
            {
                //var leaveTypes = Session["LeaveType"] as LeaveTypes;

                // Fetch user and profile data based on the logged in userId
                var myprofile = await _user.GetProfileByUser(loggedInUser.Id);
                var myemployee = await _stuff.GetEmployeeByUserId(loggedInUser.Id);

                // populate the Display Model for the Partial View
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
            try
            {
                if (newLeave.MyLeaves != null)
                {
                    // Retrieve employee and manager IDs from session
                    var empId = Convert.ToInt32(Session["EmployeeId"]);
                    var manId = Convert.ToInt32(Session["MyManagerId"]);

                    // Set employee and manager IDs for the new leave
                    newLeave.MyLeaves.EmployeeId = empId;
                    newLeave.MyLeaves.ManagerId = manId;

                    // Check if the employee has enough leave days before applying
                    var daysRequested = CalculateDaysRequested(newLeave.MyLeaves.Leave_StartDate, newLeave.MyLeaves.Leave_EndDate);
                    //if (IsLeaveDaysAvailable(daysRequested) = true)
                    //{
                    //    // Create the new leave record
                        await _leave.CreateNewLeave(newLeave.MyLeaves);

                        // Redirect to the Index page
                        return RedirectToAction("Index");
                    //}
                       
                    
                    //else
                    //{
                    //    ModelState.AddModelError(string.Empty, "Insufficient leave days.");
                    //}
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "The information you have provided is not correct!");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                ModelState.AddModelError(string.Empty, "An error occurred while processing the request.");
            }

            // If there are validation errors or other issues, return to the partial view with the updated model
            return PartialView("_NewLeave", newLeave);
        }
        [HttpGet]
        public async Task<ActionResult> DeleteLeave(int id)
        {
            try
            {

                var employeeId = Convert.ToInt32(Session["EmployeeId"]);
                var managerId = Convert.ToInt32(Session["MyManagerId"]);
                var loggedInUser = Session["LoggedInUser"] as UserModel;
                if (loggedInUser != null && loggedInUser.Id > 0)
                {
                    var _leaveToDelete = await _leave.FindLeaveById(id);

                    var _profile = await _user.GetProfileByUser(loggedInUser.Id);
                    var _employee = await _stuff.GetEmployeeByUserId(loggedInUser.Id);
                    var _manager = await _stuff.GetMyManagerByDepartment(_employee.employee_department);

                    _UserDisplayModel.Profile = _profile;
                    _UserDisplayModel.employee = _employee;
                    _UserDisplayModel.MyManager = _manager;
                    _UserDisplayModel.MyLeaves = _leaveToDelete;
                }
                return PartialView("DeleteLeave", _UserDisplayModel);
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Delete the 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeleteLeave(int id)
        {
           _leave.DeleteLeave(id);

            return RedirectToAction("Index");
        }
 /// <summary>
 /// We get the details to show for the leave to be editted 
 /// </summary>
 /// <param name="Id"></param>
 /// <returns></returns>
        public async Task<ActionResult> EditLeave(int Id)
        {
            var employeeId = Convert.ToInt32(Session["EmployeeId"]);
            var managerId = Convert.ToInt32(Session["MyManagerId"]);
            var loggedInUser = Session["LoggedInUser"] as UserModel;
            if (loggedInUser != null && loggedInUser.Id > 0)
            { 

                //GET THE DATA FROM THE API
                var leaveToEdit = await _leave.FindLeaveById(Id);
                var _profile = await _user.GetProfileByUser(loggedInUser.Id);
                var _employee = await _stuff.GetEmployeeByUserId(loggedInUser.Id);
                var _manager = await _stuff.GetMyManagerByDepartment(_employee.employee_department);

                _UserDisplayModel.Profile = _profile;
                _UserDisplayModel.employee = _employee;
                _UserDisplayModel.MyManager = _manager;
                //PASS THE DATA TO THE VIEW MODEL TO POPULATE THE VIEW WITH THE INFORMATION
                _UserDisplayModel.MyLeaves = leaveToEdit;

                
            }
            return PartialView("EditLeave", _UserDisplayModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmEditLeave(LeaveModel updateLeave)
        {
            if (ModelState.IsValid)
            {
                // Update Leave for a user
                _leave.UpdateLeave(updateLeave);

                return RedirectToAction("Index","Home", _UserDisplayModel); 
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Calculate the number of days between the start and end dates
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>Days requested for the leave</returns>
        /// 
        private int CalculateDaysRequested(DateTime startDate, DateTime endDate)
        {

            return (int)(endDate - startDate).TotalDays + 1;
        }
        /// <summary>
        /// Validate if the days requested are available for the employee/user
        /// </summary>
        /// <param name="requestedDays"></param>
        /// <param name="requestedLeavetype"></param>
        /// <returns></returns>
        private bool IsLeaveDaysAvailable(int requestedDays, string requestedLeavetype)
        {
            //if (entitledDays >= requestedDays)
            //{
            //    return true;
            //}
            return false;
        }
    }
}