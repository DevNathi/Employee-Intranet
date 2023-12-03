using Emp_Intranet_UI.API;
using Emp_Intranet_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Emp_Intranet_UI.Controllers.AuthHelpers
{
    public class AuthController : Controller
    {
        UserEndPoint _user;

        public AuthController(UserEndPoint user)
        {
            _user = user;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(loginModel loginModel)
        {
            if (IsValidUser(loginModel))
            {
                var authenticatedUser = await _user.Login(loginModel);
                if (authenticatedUser != null && authenticatedUser.Id > 0)
                {
                    // We store the Login Model to a Session data 
                    Session["LoggedInUser"] = authenticatedUser;
                    FormsAuthentication.SetAuthCookie(Convert.ToString(authenticatedUser.Id), createPersistentCookie: false);
                    return RedirectToAction("Index", "Home");
                }
                
            }

            
            return View(loginModel);
        }

        public ActionResult Logout()
        {
            Session["LoggedInUser"] = null;
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool IsValidUser(loginModel loginModel)
        {
            // Your custom logic to validate the user
            // Example: Check credentials against a database
            // Return true if the user is valid, false otherwise
            if (ModelState.IsValid)
            {
                return true;
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return false;
        }
    }
}