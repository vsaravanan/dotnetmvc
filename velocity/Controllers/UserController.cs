using Microsoft.AspNetCore.Mvc;
using velocity.Models;
using velocity.Generic;
using velocity.DataManager;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using velocity.Extn;
using System;

namespace velocity.Controllers
{

    public class UserController : GenericController<UserManager, User, int>
    {

        public UserManager mgr { get; set; }

        public UserController(UserManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }

        // POST: api/Login
        [Route("[controller]/Login")]
        public System.Object Login([FromBody]User value)
        {

            System.Diagnostics.Debug.WriteLine("Checking bank Id " + value.bankId + "   " );

            var token = HttpContext.Session.GetString(Constants.Constants.SessionId);

            var row = mgr.LoginValidate(value.bankId, value.password);


            if (row.GetType() ==  typeof(velocity.Models.User) )
            {
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
            else
            {
                HttpContext.Session.SetString(Constants.Constants.SessionId, "");
                return row;
            }
            //var jsonvalue = JObject.FromObject(retValue);
            //if (jsonvalue["error"] == null)

        }



    }
}
