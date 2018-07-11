using velocity.Generic;
using velocity.Models;

namespace velocity.DataManager
{
    public class TradeManager : DataRepository<Trade, int>
    {

        VelocityContext ctx;

        public TradeManager(VelocityContext c) : base(c)
        {
            ctx = c;
        }
    }
}
