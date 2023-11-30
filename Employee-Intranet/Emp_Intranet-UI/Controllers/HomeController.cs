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
        StuffEndPoint _stuff;
        IHomeDisplayModel _UserDisplayModel;

        public HomeController(UserEndPoint user, StuffEndPoint stuff, IHomeDisplayModel UserDisplayModel)
        {

            _user = user ?? throw new ArgumentNullException(nameof(user));
            _stuff = stuff ?? throw new ArgumentException(nameof(stuff));
            _UserDisplayModel = UserDisplayModel;
            
        }
      
        public async Task<ActionResult> Index()
        {
            //TODO - need another way to keep data on the UI 
            var loggedInUser = TempData["LoggedInUser"] as UserModel;
            if (loggedInUser != null && loggedInUser.Id > 0)
            {
                var profile = await _user.GetProfileByUser(loggedInUser.Id);
                var employee = await _stuff.GetEmployeeByUserId(loggedInUser.Id);
                if (profile != null && employee != null)
                {
                    _UserDisplayModel.Profile = profile;
                    _UserDisplayModel.employee = employee;
                    return View(_UserDisplayModel);
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