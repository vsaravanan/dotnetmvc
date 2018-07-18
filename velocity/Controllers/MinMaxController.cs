using velocity.Models;
using velocity.Generic;
using velocity.DataManager;

namespace velocity.Controllers
{

    public class MinMaxController : GenericController<MinMaxManager, MinMax, int>
    {

        public MinMaxManager mgr { get; set; }

        public MinMaxController(MinMaxManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }


    }
}
