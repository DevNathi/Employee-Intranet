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
        public UserController()
        {
        }


        // GET: api/User
        [HttpPost]
        [Route("api/Login")]
        public IHttpActionResult Login([FromBody]loginModel login)
        {
            UserData userData = new UserData();
            
            try
            {
                var output = userData.Login(login);
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

        // GET: api/Profile/Id
        [HttpGet]
        [Route("api/Profile/{id}")]
        public IHttpActionResult GetProfile(int Id)
        {
            UserData _user = new UserData();
   
            var output = _user.GetProfile(Id);
            if (output == null)
            {
                return NotFound();
            }
            return Ok(output);
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
