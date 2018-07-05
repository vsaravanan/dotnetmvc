using velocity.Models;
using velocity.Generic;
using velocity.DataManager;

namespace velocity.Controllers
{

    public class RoleController : GenericController<RoleManager, Role, int>
    {

        public RoleManager mgr { get; set; }

        public RoleController(RoleManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }


    }
}
