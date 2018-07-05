using Microsoft.AspNetCore.Mvc;
using velocity.Models;
using velocity.Generic;
using velocity.DataManager;

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
        //[HttpPost("Login")]
        public string Login([FromBody]User value)
        {


            var loginValidated = mgr.LoginValidate(value.bankId, value.password)
                ? Constants.Constants.Success
                : Constants.Constants.Failure
                ;
            return loginValidated;

        }



    }
}
