using Microsoft.AspNetCore.Mvc;
using velocity.Models;
using velocity.Generic;
using velocity.DataManager;
using Microsoft.AspNetCore.Http;
using velocity.Extn;
using System;
using System.Net;
using Newtonsoft.Json;

namespace velocity.Controllers
{

    public class UserController : GenericController<UserManager, User, int>
    {

        public UserManager mgr { get; set; }

        public UserController(UserManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }

        [Route("Logout")]
        public string Logout()
        {
            HttpContext.Session.SetString(Constants.Constants.SessionId, "");
            return "Logout success";
        }

        // POST: api/Login
        [Route("Login")]
        public Object Login([FromBody]User value)
        {

            System.Diagnostics.Debug.WriteLine("Checking bank Id " + value.bankId + "   " );

            var token = HttpContext.Session.GetString(Constants.Constants.SessionId);

            var row = mgr.LoginValidate(value.bankId, value.password);


            if (row.GetType() !=  typeof(velocity.Models.User) )
            {
                HttpContext.Session.SetString(Constants.Constants.SessionId, "");
                //return StatusCode((int) HttpStatusCode.Unauthorized, (string) row);
                ErrorData errors = new ErrorData((int)HttpStatusCode.Unauthorized, (string)row);
                TempData["Error"] = JsonConvert.SerializeObject(errors);
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.Unauthorized);

            }

            User user = (User) row;

            if (String.IsNullOrEmpty(token))
            {
                token = Util.sessionId();
            }
            HttpContext.Session.SetString(Constants.Constants.SessionId, token);

            return new
            {
                user.bankId,
                user.username,
                user.role,
                user.avatar,
                token
            };

        }



    }
}
