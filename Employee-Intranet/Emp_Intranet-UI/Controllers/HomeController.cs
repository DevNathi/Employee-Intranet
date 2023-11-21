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

        public HomeController(ILeaveLoader leaveLoader)
        {
            _leaveLoader = leaveLoader ?? throw new ArgumentNullException(nameof(leaveLoader));
        }

        public async Task<ActionResult> Index()
        {
            
            IEnumerable<LeaveModel> leaveDisplay = await _leaveLoader.GetLeaves();

            return View(leaveDisplay);

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