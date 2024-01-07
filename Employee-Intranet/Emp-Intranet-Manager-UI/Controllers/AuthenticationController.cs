using Emp_Intranet_Manager_UI.API;
using Emp_Intranet_Manager_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Emp_Intranet_Manager_UI.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserEndPoint _user;

        public AuthenticationController(IUserEndPoint user)
        {
            _user = user;
        }

        // GET: Authentication/Create
        [HttpGet]
        public ActionResult LoginManager()
        {
            if (Session["LoggedInUser"] == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

            // POST: Authentication/Create
            [HttpPost]
        public async Task<ActionResult> LoginManager(LoginModel login)
        {
            try
            {
                if (IsValidUser(login))
                {
                    var loggedinManager = await _user.Login(login);
                    if (loggedinManager.Id > 0)
                    {
                        Session["LoggedInManager"] = loggedinManager;
                        FormsAuthentication.SetAuthCookie(loggedinManager.Email, createPersistentCookie: false);
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
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["LoggedInUser"] = null;
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        private bool IsValidUser(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                return true;
            }
            if (string.IsNullOrEmpty(login.user_email) || string.IsNullOrEmpty(login.user_password))
            {
                ModelState.AddModelError(string.Empty, "Email or Password is missing");
                return false;
            }
            ModelState.AddModelError(string.Empty, "Unknown Error, Please try again");
            return false;
        }

    }
}
