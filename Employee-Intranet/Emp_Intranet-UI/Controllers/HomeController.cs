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
      
        UserEndPoint _user;

        public HomeController(ILeaveLoader leaveLoader, UserEndPoint user)
        {

            _user = user ?? throw new ArgumentNullException(nameof(user));
        }
      
        public async Task<ActionResult> Index()
        {
            var loggedInUser = TempData["LoggedInUser"] as UserModel;

            if (loggedInUser != null && loggedInUser.Id > 0)
            {
                var profile = await _user.GetProfileByUser(loggedInUser.Id);
                if (profile != null && profile.Id > 0)
                {
                    return View(profile);
                }

            }

            return View(string.Empty); 
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