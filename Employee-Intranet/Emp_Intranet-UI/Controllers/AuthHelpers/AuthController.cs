using Emp_Intranet_UI.API;
using Emp_Intranet_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Emp_Intranet_UI.Controllers.AuthHelpers
{
    public class AuthController : Controller
    {
        UserEndPoint _user;

        public AuthController(UserEndPoint user)
        {
            _user = user;
        }

        // GET: Auth
        public async Task<ActionResult> Login(loginModel loginModel)
        {
            if (loginModel != null && !string.IsNullOrEmpty(loginModel.user_email) && !string.IsNullOrEmpty(loginModel.user_password))
            {
                var canLogin = true;
                if (!canLogin)
                {
                    // Need to handle this 
                }
                var authenticatedUser = await _user.Login(loginModel);
                if (authenticatedUser != null && authenticatedUser.Id > 0)
                {
                    // We pass the profile Model as a Temp data to the Index Action
                    TempData["LoggedInUser"] = authenticatedUser;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
    }
}