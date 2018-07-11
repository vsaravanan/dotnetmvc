using velocity.Models;
using velocity.Generic;
using velocity.DataManager;

namespace velocity.Controllers
{

    public class MifidController : GenericController<MifidManager, Mifid, int>
    {

        public MifidManager mgr { get; set; }

        public MifidController(MifidManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }


    }
}
