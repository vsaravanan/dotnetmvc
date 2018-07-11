using velocity.Models;
using velocity.Generic;
using velocity.DataManager;

namespace velocity.Controllers
{

    public class TradeController : GenericController<TradeManager, Trade, int>
    {

        public TradeManager mgr { get; set; }

        public TradeController(TradeManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }


    }
}
