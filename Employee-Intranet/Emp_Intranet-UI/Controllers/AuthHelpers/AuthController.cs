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
            if (Session["LoggedInUser"] == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");

        }
        /// <summary>
        /// we post the Log in model to the API to log in the user. 
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Login(loginModel loginModel)
        {
            if (IsValidCredentials(loginModel))
            {
                var authenticatedUser = await _user.Login(loginModel);
                if (authenticatedUser.Id > 0)
                {
                    // We store the Login Model to a Session data 
                    Session["LoggedInUser"] = authenticatedUser;
                    FormsAuthentication.SetAuthCookie(Convert.ToString(authenticatedUser.Id), createPersistentCookie: false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "User not found or password incorrect");

            }
            else
            {
                // Display error message on the login page
                ViewBag.ErrorMessage = "Invalid username or password";
                return View("Login");
            }

            ModelState.AddModelError(string.Empty, "ERROR - Invalid login attempt");
            return View(loginModel);
        }
        /// <summary>
        /// Log out function - we clear the Session and the Forms authentication
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session["LoggedInUser"] = null;
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        //User/Account validation before sign in 
        private bool IsValidCredentials(loginModel loginModel)
        {
            if (ModelState.IsValid)
            { 
                return true;
            } 
            if (string.IsNullOrEmpty(loginModel.user_email) || string.IsNullOrEmpty(loginModel.user_password))
            {
                ModelState.AddModelError(string.Empty, "Email or Password is missing");
                return false;
            }
            ModelState.AddModelError(string.Empty, "Unknown Error, Please try again");
            return false;
        }
    }
}