using velocity.Generic;
using velocity.Models;

namespace velocity.DataManager
{
    public class MinMaxManager : DataRepository<MinMax, int>
    {

        VelocityContext ctx;

        public MinMaxManager(VelocityContext c) : base(c)
        {
            ctx = c;
        }
    }
}
