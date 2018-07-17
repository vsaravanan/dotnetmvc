using velocity.Models;
using velocity.Generic;
using velocity.DataManager;

namespace velocity.Controllers
{

    public class FeeController : GenericController<FeeManager, Fee, int>
    {

        public FeeManager mgr { get; set; }

        public FeeController(FeeManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }


    }
}
