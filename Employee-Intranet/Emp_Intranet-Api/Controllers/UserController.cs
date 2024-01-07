using Emp_Intranet_Api.DataAccess;
using Emp_Intranet_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Emp_Intranet_Api.Controllers
{
    public class UserController : ApiController
    {
        UserData _userData = new UserData();

        /// <summary>
        /// This Endpoint handles the log in for the system.
        /// </summary>
        /// <param name="login"></param>
        /// <returns>User Model with a JWT Token</returns>

        [HttpPost]
        [Route("api/Login")]
        public IHttpActionResult Login(loginModel login)
        {
           
            
            try
            {
                var output = _userData.Login(login);
                if (output == null)
                {
                    return NotFound();
                }
                
                return Ok(output);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// This Endpoint handles the fetching of the Profile based on the ID passed
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>"Profile"</returns>
        [HttpGet]
        [Route("api/Profile/{id}")]
        public IHttpActionResult GetProfile(int Id)
        {

   
            var output = _userData.GetProfile(Id);
            if (output == null)
            {
                return NotFound();
            }
            return Ok(output);
        }

        // POST: api/User
        [HttpPost]
        [Route("api/Profile/")]
        public void Post([FromBody]ProfileModel profilee)
        {
            try
            {
                //
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="profile"></param>
        // PUT: api/User/5
        [HttpPut]
        [Route("api/Profile/")]
        public void Put([FromBody]ProfileModel profile)
        {
            try
            {
                _userData.UpdateProfile(profile);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
