using velocity.Generic;
using velocity.Models;

namespace velocity.DataManager
{
    public class FeeManager : DataRepository<Fee, int>
    {

        VelocityContext ctx;

        public FeeManager(VelocityContext c) : base(c)
        {
            ctx = c;
        }
    }
}
