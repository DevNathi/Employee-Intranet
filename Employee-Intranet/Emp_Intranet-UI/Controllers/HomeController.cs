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
    public class HomeController : Controller
    {
        private ILeaveLoader _leaveLoader;
        private IProfileLoader _profileLoader;
        private UserModel _loggedInUser;
        UserEndPoint _user;

        public HomeController(ILeaveLoader leaveLoader, IProfileLoader profileLoader, UserModel loggedInUser, UserEndPoint user)
        {
            _leaveLoader = leaveLoader ?? throw new ArgumentNullException(nameof(leaveLoader));
            _profileLoader = profileLoader ?? throw new ArgumentNullException(nameof(profileLoader));
            _loggedInUser = loggedInUser ?? throw new ArgumentNullException(nameof(loggedInUser));
            _user = user ?? throw new ArgumentNullException(nameof(user));
        }
        public async Task<ActionResult> Login(loginModel loginModel)
        {

            if (loginModel != null)
            {

                if (loginModel.user_email?.Length > 0 && loginModel.user_password?.Length > 0)
                {
                    var canLogin = true;
                    if (canLogin == false)
                    {
                        // Need to handle this 
                    }
                    var profile = await _user.Login(loginModel);
                    if (profile != null && profile.Id > 0)
                    {
                        ViewBag.User = profile.Id;
                        return Redirect("Index");
                    }
                }

            }
            return View();
        }
        //public new ActionResult Profile()
        //{
        //    int userId = ViewBag.User;
        //    var loggedInUser =  _user.GetProfileByUser(userId);
        //    if (loggedInUser is null)
        //    {
        //        return RedirectToAction("Login");
        //    }
        //    return ViewBag;
        //}
        public ActionResult Index()
        {

            ViewBag.Message = "Welcome to your Dashboard";
            return View();

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